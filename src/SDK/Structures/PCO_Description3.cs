using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Description3
{
    public ushort wSize;
    public ushort wDarkOffsetDESC3;        // in counts (4)
    public uint dwGeneralCapsDESC3_1;               // 
    public uint dwGeneralCapsDESC3_2;               // 
    public uint dwGeneralCapsDESC3_3;               // 
    public uint dwGeneralCapsDESC3_4;               // (20)
    public ushort wMinHorzResStdDESC3;          // Minimum horz. resolution in std.mode
    public ushort wMinVertResStdDESC3;          // Minimum vert. resolution in std.mode
    public ushort wMinHorzResExtDESC3;          // Minimum horz. resolution in ext.mode
    public ushort wMinVertResExtDESC3;          // Minimum vert. resolution in ext.mode
    public ushort wPixelsize_horzDESC3;         // in nanometer
    public ushort wPixelsize_vertDESC3;         // in nanometer (32)
    public short sMinSensorTempWarningDESC3;   // lower bound Value in 1/10 degree Celsius which does set WARNING_SENSORTEMPERATURE Bit in Health Status
    public short sMaxSensorTempWarningDESC3;   // upper bound Value in 1/10 degree Celsius which does set WARNING_SENSORTEMPERATURE Bit in Health Status
    public short sMinCameraTempWarningDESC3;   // lower bound Value in 1/10 degree Celsius which does set WARNING_CAMERATEMPERATURE Bit in Health Status
    public short sMaxCameraTempWarningDESC3;   // upper bound Value in 1/10 degree Celsius which does set WARNING_CAMERATEMPERATURE Bit in Health Status
    public short sMinPowerTempWarningDESC3;    // lower bound Value in 1/10 degree Celsius which does set WARNING_POWERSUPPLYTEMPERATURE Bit in Health Status
    public short sMaxPowerTempWarningDESC3;    // upper bound Value in 1/10 degree Celsius which does set WARNING_POWERSUPPLYTEMPERATURE Bit in Health Status (44)
    public ushort wMinPowerVoltageWarningDESC3; // lower bound Value in 1/10 Volt which does set WARNING_POWERSUPPLYVOLTAGERANGE Bit in Health Status
    public ushort wMaxPowerVoltageWarningDESC3; // upper bound Value in 1/10 Volt which does set WARNING_POWERSUPPLYVOLTAGERANGE Bit in Health Status (48)
    public short sMinSensorTempErrorDESC3;     // lower bound Value in 1/10 degree Celsius which does set ERROR_SENSORTEMPERATURE Bit in Health Status
    public short sMaxSensorTempErrorDESC3;     // upper bound Value in 1/10 degree Celsius which does set ERROR_SENSORTEMPERATURE Bit in Health Status
    public short sMinCameraTempErrorDESC3;     // lower bound Value in 1/10 degree Celsius which does set ERROR_CAMERATEMPERATURE Bit in Health Status
    public short sMaxCameraTempErrorDESC3;     // upper bound Value in 1/10 degree Celsius which does set ERROR_CAMERATEMPERATURE Bit in Health Status
    public short sMinPowerTempErrorDESC3;      // lower bound Value in 1/10 degree Celsius which does set ERROR_POWERSUPPLYTEMPERATURE Bit in Health Status
    public short sMaxPowerTempErrorDESC3;      // upper bound Value in 1/10 degree Celsius which does set ERROR_POWERSUPPLYTEMPERATURE Bit in Health Status (60)
    public ushort wMinPowerVoltageErrorDESC3;   // lower bound Value in 1/10 Volt which does set ERROR_POWERSUPPLYVOLTAGERANGE Bit in Health Status
    public ushort wMaxPowerVoltageErrorDESC3;   // upper bound Value in 1/10 Volt which does set ERROR_POWERSUPPLYVOLTAGERANGE Bit in Health Status (64)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public uint[] dwReserved;               // (192)
}