using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_SC2_Hardware_DESC
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string szName;               // string with board name
    public ushort wBatchNo;             // production batch no
    public ushort wRevision;            // use range 0 to 99
    public ushort wVariant;             // variant    // 22
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public ushort[] ZZwDummy;             //            // 62
};