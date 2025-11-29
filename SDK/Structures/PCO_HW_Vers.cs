using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_HW_Vers
{
    public ushort BoardNum;       // number of devices
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public PCO_SC2_Hardware_DESC[] Board;// 622
};