using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Segment
{
    public ushort wSize;                   // Sizeof this struct
    public ushort wXRes;                   // Res. h. = resulting horz.res.(sensor resolution, ROI, binning)
    public ushort wYRes;                   // Res. v. = resulting vert.res.(sensor resolution, ROI, binning)
    public ushort wBinHorz;                // Horizontal binning
    public ushort wBinVert;                // Vertical binning                // 10
    public ushort wRoiX0;                  // Roi upper left x
    public ushort wRoiY0;                  // Roi upper left y
    public ushort wRoiX1;                  // Roi lower right x
    public ushort wRoiY1;                  // Roi lower right y
    public ushort ZZwAlignDummy1;                                             // 20
    public uint dwValidImageCnt;         // no. of valid images in segment
    public uint dwMaxImageCnt;           // maximum no. of images in segment // 28
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public ushort[] ZZwDummy;                                         // 188
};