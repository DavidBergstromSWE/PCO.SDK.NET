using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Signal_Description
{
    public ushort wSize;                                // Sizeof �this� (for future enhancements)
    public ushort wNumOfSignals;                        // Parameter to fetch the num. of descr. from the camera
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public PCO_Single_Signal_Desc[] strSingeSignalDesc; // Array of singel signal descriptors // 4004
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 524)]
    public uint[] dwDummy;                              // reserved for future use.    // 6100
}