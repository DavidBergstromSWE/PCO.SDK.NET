using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

/// <summary>
/// Struct containing all sensor settings.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PCO_Sensor
{
    public ushort wSize;                        // Sizeof this struct
    public ushort ZZwAlignDummy1;
    public PCO_Description strDescription;
    public PCO_Description2 strDescription2;

    public PCO_Description_Intensified strDescriptionIntensified;// Intensified camera descriptor        // 896
    public PCO_Description3 strDescription3;    // third descriptor             // 1088

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 168)]
    public uint[] ZZdwDummy2;
    public ushort wSensorformat;
    public ushort wRoiX0;
    public ushort wRoiY0;
    public ushort wRoiX1;
    public ushort wRoiY1;
    public ushort wBinHorz;
    public ushort wBinVert;
    //public ushort ZZwAlignDummy2;

    public ushort wIntensifiedFlags;       // Additional Intensified flags for setup: 0x01 - Enable Extended Min Voltage for MCP

    public uint dwPixelRate;
    public ushort wConvFact;
    public ushort wDoubleImage;
    public ushort wADCOperation;
    public ushort wIR;
    public short sCoolSet;
    public ushort wOffsetRegulation;
    public ushort wNoiseFilterMode;
    public ushort wFastReadoutMode;
    public ushort wDSNUAdjustMode;
    public ushort wCDIMode;

    public ushort wIntensifiedVoltage;     // MCP Voltage: ~700...~1100V
    public ushort wIntensifiedGatingMode;  // MCP gating mode 0: MCP always on; 1: MCP will be off after exp.; 2: MCP will be off till trigger
    public uint dwIntensifiedPhosphorDecay_us; // MCP phosphor decay (additional exp. time till phosphor light vanishes)

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public ushort[] ZZwDummy;

    public PCO_Signal_Description strSignalDesc;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
    public uint[] ZZdwDummy; // 8000
}