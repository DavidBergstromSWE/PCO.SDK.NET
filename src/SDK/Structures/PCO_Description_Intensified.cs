using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Description_Intensified
{
    public ushort wSize;                   // Sizeof this struct
    public ushort wChannelNumberIntensifiedDESC; // 0: Master channel; 1…x: Slave channels
    public ushort wNumberOfChannelsIntensifiedDESC; // Number of active channels in this camera

    public ushort wMinVoltageIntensifiedDESC; // Min voltage for MCP, usually ~700V (GaAs, ~600V)
    public ushort wMaxVoltageIntensifiedDESC; // Max voltage for MCP, usually ~1100V (GaAs, ~900V)
    public ushort wVoltageStepIntensifiedDESC; // Voltage step for MCP, usually 10V
    public ushort wExtendedMinVoltageIntensifiedDESC; // Extended min voltage for MCP, 600V (GaAs, ~500V)

    public ushort wMaxLoopCountIntensifiedDESC;  // Maximum loop count for multi exposure (16)
    public uint dwMinPhosphorDecayIntensified_ns_DESC; // Minimum decay time in (nsec)
    public uint dwMaxPhosphorDecayIntensified_ms_DESC; // Maximum decay time in (msec)        (24)

    public uint dwFlagsIntensifiedDESC;        // Flags which gating modes are supported        (28)
                                               // 0x0001: Gating mode 1 (switch off MCP after and till next exposure)
                                               // 0x0002: Gating mode 2 (switch off MCP and on when a trigger signal is detected)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
    public char[] szIntensifierTypeDESC;     // Type of image intensifier;

    // dwMCP_Rectangle??_DESC describes the position of the rectangle including the MCP circle area 
    //   referenced to the sensor format which is greater. Note that the data in 1/100 pixel reso-
    //   lution, thus you have to divide the values by 100 to get the pixel coordinate
    // If data is not valid, all values are 0x80000000!

    public uint dwMCP_RectangleXL_DESC;        // rectangle of the MCP circle area, x left
    public uint dwMCP_RectangleXR_DESC;        // rectangle of the MCP circle area, x right 
    public uint dwMCP_RectangleYT_DESC;        // rectangle of the MCP circle area, y top
    public uint dwMCP_RectangleYB_DESC;        // rectangle of the MCP circle area, y bottom (68)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
    public uint[] ZZdwDummy;                                                          //(160)
}