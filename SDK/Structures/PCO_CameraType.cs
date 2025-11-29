using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

/// <summary>
/// Struct containing camera type code, hardware/firmware version, serial number and interface type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PCO_CameraType
{
    public ushort wSize;                   // Sizeof this struct
    public ushort wCamType;                // Camera type
    public ushort wCamSubType;             // Camera sub type
    public ushort ZZwAlignDummy1;
    public uint dwSerialNumber;          // Serial number of camera // 12
    public uint dwHWVersion;             // Hardware version number
    public uint dwFWVersion;             // Firmware version number
    public ushort wInterfaceType;          // Interface type          // 22
    public PCO_HW_Vers strHardwareVersion;      // Hardware versions of all boards // 644
    public PCO_FW_Vers strFirmwareVersion;      // Firmware versions of all devices // 1286
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 39)]
    public ushort[] ZZwDummy;                                          // 1364
};