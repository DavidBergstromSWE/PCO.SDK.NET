using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_SC2_Firmware_DESC
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string szName;                // string with device name
    public byte bMinorRev;              // use range 0 to 99
    public byte bMajorRev;              // use range 0 to 255
    public ushort wVariant;             // variant    // 20
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public ushort[] ZZwDummy;             //            // 64
};