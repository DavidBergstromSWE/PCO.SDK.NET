using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Image
{
    public ushort wSize;      // Sizeof this struct
    public ushort ZZwAlignDummy1;                                    // 4
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public PCO_Segment[] strSegment;// Segment info                      // 436
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public PCO_Segment[] ZZstrDummySeg;// Segment info dummy            // 2164
    public ushort wBitAlignment;// Bitalignment during readout. 0: MSB, 1: LSB aligned
    public ushort wHotPixelCorrectionMode;   // Correction mode for hotpixel
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
    public ushort[] ZZwDummy;                                              // 2244
};