using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_OpenStruct
{
    public ushort wSize;        // Sizeof this struct
    public ushort wInterfaceType;
    public ushort wCameraNumber;
    public ushort wCameraNumAtInterface; // Current number of camera at the interface
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public ushort[] wOpenFlags;   // [0]: moved to dwnext to position 0xFF00
                                  // [1]: moved to dwnext to position 0xFFFF0000
                                  // [2]: Bit0: PCO_OPENFLAG_GENERIC_IS_CAMLINK
                                  //            Set this bit in case of a generic Cameralink interface
                                  //            This enables the import of the additional three camera-
                                  //            link interface functions.
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
    public uint[] dwOpenFlags;// [0]-[4]: moved to strCLOpen.dummy[0]-[4]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
    public nint[] wOpenPtr;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public ushort[] zzwDummy;     // 88 - 64bit: 112
};