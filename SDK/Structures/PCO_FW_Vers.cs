using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_FW_Vers
{
    public ushort DeviceNum;       // number of devices
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public PCO_SC2_Firmware_DESC[] Device;// 642
};