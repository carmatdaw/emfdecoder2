﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emfdecoder2
{
    internal class EMFRecordDecoder
    {
        static public string getRecordTypeName(EmfPlusRecordType type)
        {
            switch (type)
            {
                case EmfPlusRecordType.WmfSetBkColor:
                    return "WmfRecordTypeSetBkColor";
                case EmfPlusRecordType.WmfSetBkMode:
                    return "WmfRecordTypeSetBkMode";
                case EmfPlusRecordType.WmfSetMapMode:
                    return "WmfRecordTypeSetMapMode";
                case EmfPlusRecordType.WmfSetROP2:
                    return "WmfRecordTypeSetROP2";
                case EmfPlusRecordType.WmfSetRelAbs:
                    return "WmfRecordTypeSetRelAbs";
                case EmfPlusRecordType.WmfSetPolyFillMode:
                    return "WmfRecordTypeSetPolyFillMode";
                case EmfPlusRecordType.WmfSetStretchBltMode:
                    return "WmfRecordTypeSetStretchBltMode";
                case EmfPlusRecordType.WmfSetTextCharExtra:
                    return "WmfRecordTypeSetTextCharExtra";
                case EmfPlusRecordType.WmfSetTextColor:
                    return "WmfRecordTypeSetTextColor";
                case EmfPlusRecordType.WmfSetTextJustification:
                    return "WmfRecordTypeSetTextJustification";
                case EmfPlusRecordType.WmfSetWindowOrg:
                    return "WmfRecordTypeSetWindowOrg";
                case EmfPlusRecordType.WmfSetWindowExt:
                    return "WmfRecordTypeSetWindowExt";
                case EmfPlusRecordType.WmfSetViewportOrg:
                    return "WmfRecordTypeSetViewportOrg";
                case EmfPlusRecordType.WmfSetViewportExt:
                    return "WmfRecordTypeSetViewportExt";
                case EmfPlusRecordType.WmfOffsetWindowOrg:
                    return "WmfRecordTypeOffsetWindowOrg";
                case EmfPlusRecordType.WmfScaleWindowExt:
                    return "WmfRecordTypeScaleWindowExt";
                case EmfPlusRecordType.WmfOffsetViewportOrg:
                    return "WmfRecordTypeOffsetViewportOrg";
                case EmfPlusRecordType.WmfScaleViewportExt:
                    return "WmfRecordTypeScaleViewportExt";
                case EmfPlusRecordType.WmfLineTo:
                    return "WmfRecordTypeLineTo";
                case EmfPlusRecordType.WmfMoveTo:
                    return "WmfRecordTypeMoveTo";
                case EmfPlusRecordType.WmfExcludeClipRect:
                    return "WmfRecordTypeExcludeClipRect";
                case EmfPlusRecordType.WmfIntersectClipRect:
                    return "WmfRecordTypeIntersectClipRect";
                case EmfPlusRecordType.WmfArc:
                    return "WmfRecordTypeArc";
                case EmfPlusRecordType.WmfEllipse:
                    return "WmfRecordTypeEllipse";
                case EmfPlusRecordType.WmfFloodFill:
                    return "WmfRecordTypeFloodFill";
                case EmfPlusRecordType.WmfPie:
                    return "WmfRecordTypePie";
                case EmfPlusRecordType.WmfRectangle:
                    return "WmfRecordTypeRectangle";
                case EmfPlusRecordType.WmfRoundRect:
                    return "WmfRecordTypeRoundRect";
                case EmfPlusRecordType.WmfPatBlt:
                    return "WmfRecordTypePatBlt";
                case EmfPlusRecordType.WmfSaveDC:
                    return "WmfRecordTypeSaveDC";
                case EmfPlusRecordType.WmfSetPixel:
                    return "WmfRecordTypeSetPixel";
                case EmfPlusRecordType.WmfOffsetCilpRgn:
                    return "WmfRecordTypeOffsetClipRgn";
                case EmfPlusRecordType.WmfTextOut:
                    return "WmfRecordTypeTextOut";
                case EmfPlusRecordType.WmfBitBlt:
                    return "WmfRecordTypeBitBlt";
                case EmfPlusRecordType.WmfStretchBlt:
                    return "WmfRecordTypeStretchBlt";
                case EmfPlusRecordType.WmfPolygon:
                    return "WmfRecordTypePolygon";
                case EmfPlusRecordType.WmfPolyline:
                    return "WmfRecordTypePolyline";
                case EmfPlusRecordType.WmfEscape:
                    return "WmfRecordTypeEscape";
                case EmfPlusRecordType.WmfRestoreDC:
                    return "WmfRecordTypeRestoreDC";
                case EmfPlusRecordType.WmfFillRegion:
                    return "WmfRecordTypeFillRegion";
                case EmfPlusRecordType.WmfFrameRegion:
                    return "WmfRecordTypeFrameRegion";
                case EmfPlusRecordType.WmfInvertRegion:
                    return "WmfRecordTypeInvertRegion";
                case EmfPlusRecordType.WmfPaintRegion:
                    return "WmfRecordTypePaintRegion";
                case EmfPlusRecordType.WmfSelectClipRegion:
                    return "WmfRecordTypeSelectClipRegion";
                case EmfPlusRecordType.WmfSelectObject:
                    return "WmfRecordTypeSelectObject";
                case EmfPlusRecordType.WmfSetTextAlign:
                    return "WmfRecordTypeSetTextAlign";
                //case EmfPlusRecordType.WmfDrawText:
                //    return "WmfRecordTypeDrawText";
                case EmfPlusRecordType.WmfChord:
                    return "WmfRecordTypeChord";
                case EmfPlusRecordType.WmfSetMapperFlags:
                    return "WmfRecordTypeSetMapperFlags";
                case EmfPlusRecordType.WmfExtTextOut:
                    return "WmfRecordTypeExtTextOut";
                case EmfPlusRecordType.WmfSetDibToDev:
                    return "WmfRecordTypeSetDIBToDev";
                case EmfPlusRecordType.WmfSelectPalette:
                    return "WmfRecordTypeSelectPalette";
                case EmfPlusRecordType.WmfRealizePalette:
                    return "WmfRecordTypeRealizePalette";
                case EmfPlusRecordType.WmfAnimatePalette:
                    return "WmfRecordTypeAnimatePalette";
                case EmfPlusRecordType.WmfSetPalEntries:
                    return "WmfRecordTypeSetPalEntries";
                case EmfPlusRecordType.WmfPolyPolygon:
                    return "WmfRecordTypePolyPolygon";
                case EmfPlusRecordType.WmfResizePalette:
                    return "WmfRecordTypeResizePalette";
                case EmfPlusRecordType.WmfDibBitBlt:
                    return "WmfRecordTypeDIBBitBlt";
                case EmfPlusRecordType.WmfDibStretchBlt:
                    return "WmfRecordTypeDIBStretchBlt";
                case EmfPlusRecordType.WmfDibCreatePatternBrush:
                    return "WmfRecordTypeDIBCreatePatternBrush";
                case EmfPlusRecordType.WmfStretchDib:
                    return "WmfRecordTypeStretchDIB";
                case EmfPlusRecordType.WmfExtFloodFill:
                    return "WmfRecordTypeExtFloodFill";
                case EmfPlusRecordType.WmfSetLayout:
                    return "WmfRecordTypeSetLayout";
                //case EmfPlusRecordType.WmfResetDC:
                //    return "WmfRecordTypeResetDC";
                //case EmfPlusRecordType.WmfStartDoc:
                //    return "WmfRecordTypeStartDoc";
                //case EmfPlusRecordType.WmfStartPage:
                //    return "WmfRecordTypeStartPage";
                //case EmfPlusRecordType.WmfEndPage:
                //    return "WmfRecordTypeEndPage";
                //case EmfPlusRecordType.WmfAbortDoc:
                //    return "WmfRecordTypeAbortDoc";
                //case EmfPlusRecordType.WmfEndDoc:
                //    return "WmfRecordTypeEndDoc";
                case EmfPlusRecordType.WmfDeleteObject:
                    return "WmfRecordTypeDeleteObject";
                case EmfPlusRecordType.WmfCreatePalette:
                    return "WmfRecordTypeCreatePalette";
                //case EmfPlusRecordType.WmfCreateBrush:
                //    return "WmfRecordTypeCreateBrush";
                case EmfPlusRecordType.WmfCreatePatternBrush:
                    return "WmfRecordTypeCreatePatternBrush";
                case EmfPlusRecordType.WmfCreatePenIndirect:
                    return "WmfRecordTypeCreatePenIndirect";
                case EmfPlusRecordType.WmfCreateFontIndirect:
                    return "WmfRecordTypeCreateFontIndirect";
                case EmfPlusRecordType.WmfCreateBrushIndirect:
                    return "WmfRecordTypeCreateBrushIndirect";
                //case EmfPlusRecordType.WmfCreateBitmapIndirect:
                //    return "WmfRecordTypeCreateBitmapIndirect";
                //case EmfPlusRecordType.WmfCreateBitmap:
                //    return "WmfRecordTypeCreateBitmap";
                case EmfPlusRecordType.WmfCreateRegion:
                    return "WmfRecordTypeCreateRegion";
                case EmfPlusRecordType.EmfHeader:
                    return "EmfRecordTypeHeader";
                case EmfPlusRecordType.EmfPolyBezier:
                    return "EmfRecordTypePolyBezier";
                case EmfPlusRecordType.EmfPolygon:
                    return "EmfRecordTypePolygon";
                case EmfPlusRecordType.EmfPolyline:
                    return "EmfRecordTypePolyline";
                case EmfPlusRecordType.EmfPolyBezierTo:
                    return "EmfRecordTypePolyBezierTo";
                case EmfPlusRecordType.EmfPolyLineTo:
                    return "EmfRecordTypePolyLineTo";
                case EmfPlusRecordType.EmfPolyPolyline:
                    return "EmfRecordTypePolyPolyline";
                case EmfPlusRecordType.EmfPolyPolygon:
                    return "EmfRecordTypePolyPolygon";
                case EmfPlusRecordType.EmfSetWindowExtEx:
                    return "EmfRecordTypeSetWindowExtEx";
                case EmfPlusRecordType.EmfSetWindowOrgEx:
                    return "EmfRecordTypeSetWindowOrgEx";
                case EmfPlusRecordType.EmfSetViewportExtEx:
                    return "EmfRecordTypeSetViewportExtEx";
                case EmfPlusRecordType.EmfSetViewportOrgEx:
                    return "EmfRecordTypeSetViewportOrgEx";
                case EmfPlusRecordType.EmfSetBrushOrgEx:
                    return "EmfRecordTypeSetBrushOrgEx";
                case EmfPlusRecordType.EmfEof:
                    return "EmfRecordTypeEOF";
                case EmfPlusRecordType.EmfSetPixelV:
                    return "EmfRecordTypeSetPixelV";
                case EmfPlusRecordType.EmfSetMapperFlags:
                    return "EmfRecordTypeSetMapperFlags";
                case EmfPlusRecordType.EmfSetMapMode:
                    return "EmfRecordTypeSetMapMode";
                case EmfPlusRecordType.EmfSetBkMode:
                    return "EmfRecordTypeSetBkMode";
                case EmfPlusRecordType.EmfSetPolyFillMode:
                    return "EmfRecordTypeSetPolyFillMode";
                case EmfPlusRecordType.EmfSetROP2:
                    return "EmfRecordTypeSetROP2";
                case EmfPlusRecordType.EmfSetStretchBltMode:
                    return "EmfRecordTypeSetStretchBltMode";
                case EmfPlusRecordType.EmfSetTextAlign:
                    return "EmfRecordTypeSetTextAlign";
                case EmfPlusRecordType.EmfSetColorAdjustment:
                    return "EmfRecordTypeSetColorAdjustment";
                case EmfPlusRecordType.EmfSetTextColor:
                    return "EmfRecordTypeSetTextColor";
                case EmfPlusRecordType.EmfSetBkColor:
                    return "EmfRecordTypeSetBkColor";
                case EmfPlusRecordType.EmfOffsetClipRgn:
                    return "EmfRecordTypeOffsetClipRgn";
                case EmfPlusRecordType.EmfMoveToEx:
                    return "EmfRecordTypeMoveToEx";
                case EmfPlusRecordType.EmfSetMetaRgn:
                    return "EmfRecordTypeSetMetaRgn";
                case EmfPlusRecordType.EmfExcludeClipRect:
                    return "EmfRecordTypeExcludeClipRect";
                case EmfPlusRecordType.EmfIntersectClipRect:
                    return "EmfRecordTypeIntersectClipRect";
                case EmfPlusRecordType.EmfScaleViewportExtEx:
                    return "EmfRecordTypeScaleViewportExtEx";
                case EmfPlusRecordType.EmfScaleWindowExtEx:
                    return "EmfRecordTypeScaleWindowExtEx";
                case EmfPlusRecordType.EmfSaveDC:
                    return "EmfRecordTypeSaveDC";
                case EmfPlusRecordType.EmfRestoreDC:
                    return "EmfRecordTypeRestoreDC";
                case EmfPlusRecordType.EmfSetWorldTransform:
                    return "EmfRecordTypeSetWorldTransform";
                case EmfPlusRecordType.EmfModifyWorldTransform:
                    return "EmfRecordTypeModifyWorldTransform";
                case EmfPlusRecordType.EmfSelectObject:
                    return "EmfRecordTypeSelectObject";
                case EmfPlusRecordType.EmfCreatePen:
                    return "EmfRecordTypeCreatePen";
                case EmfPlusRecordType.EmfCreateBrushIndirect:
                    return "EmfRecordTypeCreateBrushIndirect";
                case EmfPlusRecordType.EmfDeleteObject:
                    return "EmfRecordTypeDeleteObject";
                case EmfPlusRecordType.EmfAngleArc:
                    return "EmfRecordTypeAngleArc";
                case EmfPlusRecordType.EmfEllipse:
                    return "EmfRecordTypeEllipse";
                case EmfPlusRecordType.EmfRectangle:
                    return "EmfRecordTypeRectangle";
                case EmfPlusRecordType.EmfRoundRect:
                    return "EmfRecordTypeRoundRect";
                //case EmfPlusRecordType.EmfArc:
                //    return "EmfRecordTypeArc";
                //case EmfPlusRecordType.EmfChord = EMR_CHORD:
                //    return "EmfRecordTypeChord = EMR_CHORD";
                //case EmfPlusRecordType.EmfPie = EMR_PIE:
                //    return "EmfRecordTypePie = EMR_PIE";
                case EmfPlusRecordType.EmfSelectPalette:
                    return "EmfRecordTypeSelectPalette";
                case EmfPlusRecordType.EmfCreatePalette:
                    return "EmfRecordTypeCreatePalette";
                case EmfPlusRecordType.EmfSetPaletteEntries:
                    return "EmfRecordTypeSetPaletteEntries";
                case EmfPlusRecordType.EmfResizePalette:
                    return "EmfRecordTypeResizePalette";
                case EmfPlusRecordType.EmfRealizePalette:
                    return "EmfRecordTypeRealizePalette";
                case EmfPlusRecordType.EmfExtFloodFill:
                    return "EmfRecordTypeExtFloodFill";
                case EmfPlusRecordType.EmfLineTo:
                    return "EmfRecordTypeLineTo";
                case EmfPlusRecordType.EmfArcTo:
                    return "EmfRecordTypeArcTo";
                case EmfPlusRecordType.EmfPolyDraw:
                    return "EmfRecordTypePolyDraw";
                case EmfPlusRecordType.EmfSetArcDirection:
                    return "EmfRecordTypeSetArcDirection";
                case EmfPlusRecordType.EmfSetMiterLimit:
                    return "EmfRecordTypeSetMiterLimit";
                case EmfPlusRecordType.EmfBeginPath:
                    return "EmfRecordTypeBeginPath";
                case EmfPlusRecordType.EmfEndPath:
                    return "EmfRecordTypeEndPath";
                case EmfPlusRecordType.EmfCloseFigure:
                    return "EmfRecordTypeCloseFigure";
                case EmfPlusRecordType.EmfFillPath:
                    return "EmfRecordTypeFillPath";
                case EmfPlusRecordType.EmfStrokeAndFillPath:
                    return "EmfRecordTypeStrokeAndFillPath";
                case EmfPlusRecordType.EmfStrokePath:
                    return "EmfRecordTypeStrokePath";
                case EmfPlusRecordType.EmfFlattenPath:
                    return "EmfRecordTypeFlattenPath";
                case EmfPlusRecordType.EmfWidenPath:
                    return "EmfRecordTypeWidenPath";
                case EmfPlusRecordType.EmfSelectClipPath:
                    return "EmfRecordTypeSelectClipPath";
                case EmfPlusRecordType.EmfAbortPath:
                    return "EmfRecordTypeAbortPath";
                //case EmfPlusRecordType.EmfReserved_069:
                //    return "EmfRecordTypeReserved_069 = 69";
                case EmfPlusRecordType.EmfGdiComment:
                    return "EmfRecordTypeGdiComment";
                case EmfPlusRecordType.EmfFillRgn:
                    return "EmfRecordTypeFillRgn";
                case EmfPlusRecordType.EmfFrameRgn:
                    return "EmfRecordTypeFrameRgn";
                case EmfPlusRecordType.EmfInvertRgn:
                    return "EmfRecordTypeInvertRgn";
                case EmfPlusRecordType.EmfPaintRgn:
                    return "EmfRecordTypePaintRgn";
                case EmfPlusRecordType.EmfExtSelectClipRgn:
                    return "EmfRecordTypeExtSelectClipRgn";
                case EmfPlusRecordType.EmfBitBlt:
                    return "EmfRecordTypeBitBlt";
                case EmfPlusRecordType.EmfStretchBlt:
                    return "EmfRecordTypeStretchBlt";
                case EmfPlusRecordType.EmfMaskBlt:
                    return "EmfRecordTypeMaskBlt";
                case EmfPlusRecordType.EmfPlgBlt:
                    return "EmfRecordTypePlgBlt";
                case EmfPlusRecordType.EmfSetDIBitsToDevice:
                    return "EmfRecordTypeSetDIBitsToDevice";
                case EmfPlusRecordType.EmfStretchDIBits:
                    return "EmfRecordTypeStretchDIBits";
                case EmfPlusRecordType.EmfExtCreateFontIndirect:
                    return "EmfRecordTypeExtCreateFontIndirect";
                case EmfPlusRecordType.EmfExtTextOutA:
                    return "EmfRecordTypeExtTextOutA";
                case EmfPlusRecordType.EmfExtTextOutW:
                    return "EmfRecordTypeExtTextOutW";
                case EmfPlusRecordType.EmfPolyBezier16:
                    return "EmfRecordTypePolyBezier16";
                case EmfPlusRecordType.EmfPolygon16:
                    return "EmfRecordTypePolygon16";
                case EmfPlusRecordType.EmfPolyline16:
                    return "EmfRecordTypePolyline16";
                case EmfPlusRecordType.EmfPolyBezierTo16:
                    return "EmfRecordTypePolyBezierTo16";
                case EmfPlusRecordType.EmfPolylineTo16:
                    return "EmfRecordTypePolylineTo16";
                case EmfPlusRecordType.EmfPolyPolyline16:
                    return "EmfRecordTypePolyPolyline16";
                case EmfPlusRecordType.EmfPolyPolygon16:
                    return "EmfRecordTypePolyPolygon16";
                case EmfPlusRecordType.EmfPolyDraw16:
                    return "EmfRecordTypePolyDraw16";
                case EmfPlusRecordType.EmfCreateMonoBrush:
                    return "EmfRecordTypeCreateMonoBrush";
                case EmfPlusRecordType.EmfCreateDibPatternBrushPt:
                    return "EmfRecordTypeCreateDIBPatternBrushPt";
                case EmfPlusRecordType.EmfExtCreatePen:
                    return "EmfRecordTypeExtCreatePen";
                case EmfPlusRecordType.EmfPolyTextOutA:
                    return "EmfRecordTypePolyTextOutA";
                case EmfPlusRecordType.EmfPolyTextOutW:
                    return "EmfRecordTypePolyTextOutW";
                case EmfPlusRecordType.EmfSetIcmMode:
                    return "EmfRecordTypeSetICMMode";
                case EmfPlusRecordType.EmfCreateColorSpace:
                    return "EmfRecordTypeCreateColorSpace";
                case EmfPlusRecordType.EmfSetColorSpace:
                    return "EmfRecordTypeSetColorSpace";
                case EmfPlusRecordType.EmfDeleteColorSpace:
                    return "EmfRecordTypeDeleteColorSpace";
                case EmfPlusRecordType.EmfGlsRecord:
                    return "EmfRecordTypeGLSRecord";
                case EmfPlusRecordType.EmfGlsBoundedRecord:
                    return "EmfRecordTypeGLSBoundedRecord";
                case EmfPlusRecordType.EmfPixelFormat:
                    return "EmfRecordTypePixelFormat";
                case EmfPlusRecordType.EmfDrawEscape:
                    return "EmfRecordTypeDrawEscape";
                case EmfPlusRecordType.EmfExtEscape:
                    return "EmfRecordTypeExtEscape";
                case EmfPlusRecordType.EmfStartDoc:
                    return "EmfRecordTypeStartDoc";
                case EmfPlusRecordType.EmfSmallTextOut:
                    return "EmfRecordTypeSmallTextOut";
                case EmfPlusRecordType.EmfForceUfiMapping:
                    return "EmfRecordTypeForceUFIMapping";
                case EmfPlusRecordType.EmfNamedEscpae:
                    return "EmfRecordTypeNamedEscape";
                case EmfPlusRecordType.EmfColorCorrectPalette:
                    return "EmfRecordTypeColorCorrectPalette";
                case EmfPlusRecordType.EmfSetIcmProfileA:
                    return "EmfRecordTypeSetICMProfileA";
                case EmfPlusRecordType.EmfSetIcmProfileW:
                    return "EmfRecordTypeSetICMProfileW";
                case EmfPlusRecordType.EmfAlphaBlend:
                    return "EmfRecordTypeAlphaBlend";
                case EmfPlusRecordType.EmfSetLayout:
                    return "EmfRecordTypeSetLayout";
                case EmfPlusRecordType.EmfTransparentBlt:
                    return "EmfRecordTypeTransparentBlt";
                //case EmfPlusRecordType.EmfReserved_117:
                //    return "EmfRecordTypeReserved_117";
                case EmfPlusRecordType.EmfGradientFill:
                    return "EmfRecordTypeGradientFill";
                case EmfPlusRecordType.EmfSetLinkedUfis:
                    return "EmfRecordTypeSetLinkedUFIs";
                case EmfPlusRecordType.EmfSetTextJustification:
                    return "EmfRecordTypeSetTextJustification";
                case EmfPlusRecordType.EmfColorMatchToTargetW:
                    return "EmfRecordTypeColorMatchToTargetW";
                case EmfPlusRecordType.EmfCreateColorSpaceW:
                    return "EmfRecordTypeCreateColorSpaceW";
                //case EmfPlusRecordType.EmfMax:
                //    return "EmfRecordTypeMax";
                //case EmfPlusRecordType.EmfMin:
                //    return "EmfRecordTypeMin";
                case EmfPlusRecordType.Invalid:
                    return "EmfPlusRecordTypeInvalid";
                case EmfPlusRecordType.Header:
                    return "EmfPlusRecordTypeHeader";
                case EmfPlusRecordType.EndOfFile:
                    return "EmfPlusRecordTypeEndOfFile";
                case EmfPlusRecordType.Comment:
                    return "EmfPlusRecordTypeComment";
                case EmfPlusRecordType.GetDC:
                    return "EmfPlusRecordTypeGetDC";
                case EmfPlusRecordType.MultiFormatStart:
                    return "EmfPlusRecordTypeMultiFormatStart";
                case EmfPlusRecordType.MultiFormatSection:
                    return "EmfPlusRecordTypeMultiFormatSection";
                case EmfPlusRecordType.MultiFormatEnd:
                    return "EmfPlusRecordTypeMultiFormatEnd";
                case EmfPlusRecordType.Object:
                    return "EmfPlusRecordTypeObject";
                case EmfPlusRecordType.Clear:
                    return "EmfPlusRecordTypeClear";
                case EmfPlusRecordType.FillRects:
                    return "EmfPlusRecordTypeFillRects";
                case EmfPlusRecordType.DrawRects:
                    return "EmfPlusRecordTypeDrawRects";
                case EmfPlusRecordType.FillPolygon:
                    return "EmfPlusRecordTypeFillPolygon";
                case EmfPlusRecordType.DrawLines:
                    return "EmfPlusRecordTypeDrawLines";
                case EmfPlusRecordType.FillEllipse:
                    return "EmfPlusRecordTypeFillEllipse";
                case EmfPlusRecordType.DrawEllipse:
                    return "EmfPlusRecordTypeDrawEllipse";
                case EmfPlusRecordType.FillPie:
                    return "EmfPlusRecordTypeFillPie";
                case EmfPlusRecordType.DrawPie:
                    return "EmfPlusRecordTypeDrawPie";
                case EmfPlusRecordType.DrawArc:
                    return "EmfPlusRecordTypeDrawArc";
                case EmfPlusRecordType.FillRegion:
                    return "EmfPlusRecordTypeFillRegion";
                case EmfPlusRecordType.FillPath:
                    return "EmfPlusRecordTypeFillPath";
                case EmfPlusRecordType.DrawPath:
                    return "EmfPlusRecordTypeDrawPath";
                case EmfPlusRecordType.FillClosedCurve:
                    return "EmfPlusRecordTypeFillClosedCurve";
                case EmfPlusRecordType.DrawClosedCurve:
                    return "EmfPlusRecordTypeDrawClosedCurve";
                case EmfPlusRecordType.DrawCurve:
                    return "EmfPlusRecordTypeDrawCurve";
                case EmfPlusRecordType.DrawBeziers:
                    return "EmfPlusRecordTypeDrawBeziers";
                case EmfPlusRecordType.DrawImage:
                    return "EmfPlusRecordTypeDrawImage";
                case EmfPlusRecordType.DrawImagePoints:
                    return "EmfPlusRecordTypeDrawImagePoints";
                case EmfPlusRecordType.DrawString:
                    return "EmfPlusRecordTypeDrawString";
                case EmfPlusRecordType.SetRenderingOrigin:
                    return "EmfPlusRecordTypeSetRenderingOrigin";
                case EmfPlusRecordType.SetAntiAliasMode:
                    return "EmfPlusRecordTypeSetAntiAliasMode";
                case EmfPlusRecordType.SetTextRenderingHint:
                    return "EmfPlusRecordTypeSetTextRenderingHint";
                case EmfPlusRecordType.SetTextContrast:
                    return "EmfPlusRecordTypeSetTextContrast";
                case EmfPlusRecordType.SetInterpolationMode:
                    return "EmfPlusRecordTypeSetInterpolationMode";
                case EmfPlusRecordType.SetPixelOffsetMode:
                    return "EmfPlusRecordTypeSetPixelOffsetMode";
                case EmfPlusRecordType.SetCompositingMode:
                    return "EmfPlusRecordTypeSetCompositingMode";
                case EmfPlusRecordType.SetCompositingQuality:
                    return "EmfPlusRecordTypeSetCompositingQuality";
                case EmfPlusRecordType.Save:
                    return "EmfPlusRecordTypeSave";
                case EmfPlusRecordType.Restore:
                    return "EmfPlusRecordTypeRestore";
                case EmfPlusRecordType.BeginContainer:
                    return "EmfPlusRecordTypeBeginContainer";
                case EmfPlusRecordType.BeginContainerNoParams:
                    return "EmfPlusRecordTypeBeginContainerNoParams";
                case EmfPlusRecordType.EndContainer:
                    return "EmfPlusRecordTypeEndContainer";
                case EmfPlusRecordType.SetWorldTransform:
                    return "EmfPlusRecordTypeSetWorldTransform";
                case EmfPlusRecordType.ResetWorldTransform:
                    return "EmfPlusRecordTypeResetWorldTransform";
                case EmfPlusRecordType.MultiplyWorldTransform:
                    return "EmfPlusRecordTypeMultiplyWorldTransform";
                case EmfPlusRecordType.TranslateWorldTransform:
                    return "EmfPlusRecordTypeTranslateWorldTransform";
                case EmfPlusRecordType.ScaleWorldTransform:
                    return "EmfPlusRecordTypeScaleWorldTransform";
                case EmfPlusRecordType.RotateWorldTransform:
                    return "EmfPlusRecordTypeRotateWorldTransform";
                case EmfPlusRecordType.SetPageTransform:
                    return "EmfPlusRecordTypeSetPageTransform";
                case EmfPlusRecordType.ResetClip:
                    return "EmfPlusRecordTypeResetClip";
                case EmfPlusRecordType.SetClipRect:
                    return "EmfPlusRecordTypeSetClipRect";
                case EmfPlusRecordType.SetClipPath:
                    return "EmfPlusRecordTypeSetClipPath";
                case EmfPlusRecordType.SetClipRegion:
                    return "EmfPlusRecordTypeSetClipRegion";
                case EmfPlusRecordType.OffsetClip:
                    return "EmfPlusRecordTypeOffsetClip";
                case EmfPlusRecordType.DrawDriverString:
                    return "EmfPlusRecordTypeDrawDriverString";
                //case EmfPlusRecordType.StrokeFillPath:
                //    return "EmfPlusRecordTypeStrokeFillPath";
                //case EmfPlusRecordType.SerializableObject:
                //    return "EmfPlusRecordTypeSerializableObject";
                //case EmfPlusRecordType.SetTSGraphics:
                //    return "EmfPlusRecordTypeSetTSGraphics";
                //case EmfPlusRecordType.SetTSClip:
                //    return "EmfPlusRecordTypeSetTSClip";
                //case EmfPlusRecordType.EmfPlusRecordTotal:
                //    return "EmfPlusRecordTotal";
                //case EmfPlusRecordType.Max:
                //    return "EmfPlusRecordTypeMax";
                //case EmfPlusRecordType.Mi:
                //    return "EmfPlusRecordTypeMi";
                default:
                    return "unknown record type";
                        }
        }
    }
}
