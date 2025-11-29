using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

/// <summary>
/// Struct containing information about camera type, hardware/firmware version, serial number, current temperatures and camera status.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PCO_General
{
    public ushort wSize;        // Sizeof this struct
    public ushort ZZwAlignDummy1;
    public PCO_CameraType strCamType;
    public uint dwCamHealthWarnings;
    public uint dwCamHealthErrors;
    public uint dwCamHealthStatus;
    public short sCCDTemperature;
    public short sCamTemperaure;
    public short sPowerSupplyTemperature;
    public ushort[] ZZwDummy;
}