using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace emfdecoder2
{
    public partial class MainForm : Form
    {
        private Metafile mf;
        enum ProcessState
        {
            idle,
            pendingDraw,
            postDraw
        };
        private bool newEmf = true;
        private string filePath = "./default.emf";
        private string fileDir = "c:/";
        private Graphics.EnumerateMetafileProc metafileRenderDelegate;
        private Graphics.EnumerateMetafileProc metafileDecomposeDelegate;
        private int recordCount;
        private int emfSelectedElement = 0;
        private static List<string> filesToProcess = new List<string>();
        private static Dictionary<string, int> recordsEncountered = new Dictionary<string,int>();
        private static System.Windows.Forms.Timer processingTimer = new System.Windows.Forms.Timer();
        private static ProcessState processingState = ProcessState.idle;
        private static string processingFile;
        private static MainForm self;
        private float zoomFactor = 1.0f;
        private Bitmap checkerPattern;
        
        // Filename -> (emfrecord -> count)
        private Dictionary<string, Dictionary<string, int>> emfFilesData = new Dictionary<string, Dictionary<string, int>>() ;
        private Dictionary<string, int> processingData;

        private enum RenderMode  {Full,ToSelection,SelectionOnly };
        private RenderMode renderMode = RenderMode.Full;

        public MainForm()
        {
            self = this;

            mf = new Metafile(filePath);
            
            metafileRenderDelegate = new Graphics.EnumerateMetafileProc(MetafileRenderCallback);
            metafileDecomposeDelegate = new Graphics.EnumerateMetafileProc(MetafileDecomposeCallback);
            processingTimer.Tick += new EventHandler(TimerEventProcessor);
            processingTimer.Interval = 10;
            InitializeComponent();

            checkerPattern = new Bitmap(emfdecoder2.Properties.Resources.checker);
            this.filePathLabel.Text = filePath;
            DetermineDefaultZoom(); 

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.renderModeCombo.SelectedIndex = 0;
        }

        private bool MetafileRenderCallback(
                   EmfPlusRecordType recordType,
                   int flags,
                   int dataSize,
                   IntPtr data,
                   PlayRecordCallback callbackData)
        {
            byte[] dataArray = new byte[0];
            if (data != IntPtr.Zero)
            {
                // Copy the unmanaged record to a managed byte buffer 
                // that can be used by PlayRecord.
                dataArray = new byte[dataSize];
                Marshal.Copy(data, dataArray, 0, dataSize);
            }
            if (this.renderMode == RenderMode.ToSelection)
            {
                if (recordCount <= this.emfSelectedElement)
                {
                    mf.PlayRecord(recordType, flags, dataSize, dataArray);
                }
                recordCount++;
            }
            else
            { 
                mf.PlayRecord(recordType, flags, dataSize, dataArray);
            }

            return true;
        }

        private bool MetafileDecomposeCallback(
                   EmfPlusRecordType recordType,
                   int flags,
                   int dataSize,
                   IntPtr data,
                   PlayRecordCallback callbackData)
        {
            string recordTypeName = EMFRecordDecoder.getRecordTypeName(recordType);
            string itemName = string.Format("{0}: {1}", recordCount, recordTypeName);
            recordCount++;
            emfElementList.Items.Add(itemName);

            if (processingState == ProcessState.pendingDraw)
            {
                int curFileCount = 0;
                processingData.TryGetValue(recordTypeName, out curFileCount);
                curFileCount++;
                processingData[recordTypeName] = curFileCount;

                int curRecordCount = 0;
                recordsEncountered.TryGetValue(recordTypeName, out curRecordCount);
                curRecordCount++;
                recordsEncountered[recordTypeName] = curRecordCount;    
            }
            return true;
        }

        private void DetermineDefaultZoom()
        {
            float scaleW = 1.0f;
            GraphicsUnit u = new GraphicsUnit();
            RectangleF bounds = mf.GetBounds(ref u);
            float viewWidth = splitContainer.Panel2.Width;
            float viewHeight = splitContainer.Panel2.Height;
            if (bounds.Width > viewWidth)
            {
                scaleW = (float)viewWidth / mf.Width;
            }
            float scaleH = 1.0f;
            if (bounds.Height > viewHeight)
            {
                scaleH = (float)viewHeight / mf.Height;
            }
            float scale = Math.Min(scaleW, scaleH);

            if (scale == 1.0f && bounds.Width < this.Width / 2)
            {
                scaleW = (viewWidth ) / bounds.Width;
                scaleH = (viewHeight) / bounds.Height;
                scale = Math.Min(scaleW, scaleH);
            }
            zoomFactor = scale *.8f;

        }
        private void emfView_Paint(object sender, PaintEventArgs e)
        {
            if (mf == null) return;

            RectangleF bounds;
            GraphicsUnit u = new GraphicsUnit();
            bounds = mf.GetBounds(ref u);
            float viewWidth = splitContainer.Panel2.Width;
            float viewHeight = splitContainer.Panel2.Height;
            // fill background
            TextureBrush brush = new TextureBrush(checkerPattern, WrapMode.Tile);
            e.Graphics.FillRectangle(brush, 0, 0, viewWidth, viewHeight);

            RectangleF sourceRect = new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            float destWidth = zoomFactor * bounds.Width;
            float destHeight = zoomFactor * bounds.Height;
            RectangleF destRect = new RectangleF(viewWidth/2-destWidth/2,viewHeight/2-destHeight/2, destWidth, destHeight);//

            recordCount = 0;
            e.Graphics.EnumerateMetafile(mf, destRect, sourceRect, GraphicsUnit.Pixel, metafileRenderDelegate);
            if (processingState == ProcessState.pendingDraw)
            {
                this.processingData = new Dictionary<string, int>();

            }
            if (newEmf)
            {
                recordCount = 0;
                e.Graphics.EnumerateMetafile(mf, destRect, sourceRect, GraphicsUnit.Pixel, metafileDecomposeDelegate);
                newEmf = false;
            }
            if (processingState == ProcessState.pendingDraw)
            {
                this.emfFilesData[MainForm.processingFile] = this.processingData;
                Console.WriteLine("processed file");
                processingState = ProcessState.postDraw;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = fileDir;
                openFileDialog.Filter = "emf files (*.emf)|*.emf";
                openFileDialog.FilterIndex = 0;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    mf = new Metafile(filePath);
                    ResetForNewFile();
                    this.filePathLabel.Text = filePath;

                }
            }
        }

        private void ResetForNewFile()
        {
            newEmf = true;
            ResetElementList();
            ResetZoom();
            RedrawEMF();

        }

        private void ResetElementList()
        {
            this.emfElementList.Items.Clear();
        }
        private void RedrawEMF()
        {
            this.splitContainer.Panel2.Invalidate();

        }

        private void ResetZoom()
        {
            DetermineDefaultZoom();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void emfElementList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void renderMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.renderModeCombo.Text == "Full")
            {
                this.renderMode = RenderMode.Full;
            }
            if (this.renderModeCombo.Text == "To Selection")
            {
                this.renderMode = RenderMode.ToSelection;
            }
            if (this.renderModeCombo.Text == "SelectionOnly")
            {
                this.renderMode = RenderMode.SelectionOnly;
            }
            RedrawEMF();

        }

        private void emfElementList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.emfSelectedElement = this.emfElementList.SelectedIndex;
            RedrawEMF();
        }

        IEnumerable<string> GetFiles(string path, string pattern)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path,pattern);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }

        private static void TimerEventProcessor(Object myObject,
                                                    EventArgs myEventArgs)
        {
            if (MainForm.self.ProcessingState == ProcessState.pendingDraw)
            {
                return;
            }
            if (filesToProcess.Count() > 0)
            {
                string nextFile = filesToProcess.First();
                filesToProcess.RemoveAt(0);
                MainForm.self.processAFile(nextFile);

            }
            else
            {
                Console.WriteLine("done");
                processingTimer.Stop();

                MainForm.self.ProcessingComplete();
                MainForm.self.LogProcessedData();
            }
        }

        private void LogProcessedData()
        {
            // sort emf record names in recordsEncountered dictionary
            List<string> keyList = new List<string>(recordsEncountered.Keys);
            keyList.Sort();
            StringBuilder builder = new StringBuilder();
            Console.Write("File,");
            builder.Append("File,");

            foreach (string key in keyList)
            {
                Console.Write(key + ",");
                builder.Append(key + ",");
            }
            Console.WriteLine("");
            builder.AppendLine("");

            // write list of record names encountered
            List<string> files = new List<string>(emfFilesData.Keys);
            files.Sort();
            foreach (string file in files)
            {
                Dictionary<string, int> fileData = emfFilesData[file];
                Console.Write(file + ",");
                builder.Append(file + ",");
                foreach(string key in keyList)
                {
                    int count = 0;
                    fileData.TryGetValue(key, out count);
                    Console.Write(count + ",");
                    builder.Append(count + ",");

                }
                Console.WriteLine("");
                builder.AppendLine("");
            }
            File.WriteAllText("./output.csv", builder.ToString());
            MessageBox.Show(" Wrote data to ./output.csv","Processing Complete");
    }
    private void processFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select director to recurse for .vssx files to process.";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string dir = fbd.SelectedPath;
                    filesToProcess.Clear();
                    foreach (string file in GetFiles(dir, "*.emf"))
                    {
                        filesToProcess.Add(file);
                    }
                }
            }
            if (filesToProcess.Count > 0)
            {
                Console.WriteLine("Processing Complete");
                processingState = ProcessState.idle;
                processingTimer.Start();
            }
        }

        private void processAFile(string file)
        {
            Console.WriteLine($"Processing {file}");
            processingState = ProcessState.pendingDraw;
            processingFile = file;
            mf = new Metafile(file);
            this.ResetForNewFile();
        }

        private ProcessState ProcessingState { get { return processingState; } }
        private void ProcessingComplete() { processingState = ProcessState.idle; }

        private void splitContainer_Panel2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void handleZoom(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                zoomFactor *= 1.25f;
                RedrawEMF();
            }
            else if (e.Button == MouseButtons.Right)
            {
                zoomFactor *= .8f;
                RedrawEMF();
            }

        }
        private void splitContainer_Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            handleZoom(e);
        }

        private void splitContainer_Panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            handleZoom(e);
        }
    }
}
