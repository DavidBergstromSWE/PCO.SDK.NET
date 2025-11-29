using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

/// <summary>
/// Struct containing description of general margins for all sensor related settings and bitfields for available options of the camera. This set of information can be used to validate the input parameter for commands, which change camera settings, before they are sent to the camera.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PCO_Description
{
    public ushort wSize;                   // Sizeof this struct
    public ushort wSensorTypeDESC;         // Sensor type
    public ushort wSensorSubTypeDESC;      // Sensor subtype
    public ushort wMaxHorzResStdDESC;      // Maxmimum horz. resolution in std.mode
    public ushort wMaxVertResStdDESC;      // Maxmimum vert. resolution in std.mode
    public ushort wMaxHorzResExtDESC;      // Maxmimum horz. resolution in ext.mode
    public ushort wMaxVertResExtDESC;      // Maxmimum vert. resolution in ext.mode
    public ushort wDynResDESC;             // Dynamic resolution of ADC in bit
    public ushort wMaxBinHorzDESC;         // Maxmimum horz. binning
    public ushort wBinHorzSteppingDESC;    // Horz. bin. stepping (0:bin, 1:lin)
    public ushort wMaxBinVertDESC;         // Maxmimum vert. binning
    public ushort wBinVertSteppingDESC;    // Vert. bin. stepping (0:bin, 1:lin)
    public ushort wRoiHorStepsDESC;        // Minimum granularity of ROI in pixels
    public ushort wRoiVertStepsDESC;       // Minimum granularity of ROI in pixels
    public ushort wNumADCsDESC;            // Number of ADCs in system

    public ushort wMinSizeHorzDESC;        // Minimum size in pixels in horizontal direction

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] dwPixelRateDESC;       // Possible pixelrate in Hz
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public uint[] ZZdwDummypr;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public ushort[] wConvFactDESC;       // Possible conversion factor in e/cnt

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public short[] sCoolingSetpoints;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public ushort[] ZZwDummycv;

    public ushort wSoftRoiHorStepsDESC;    // Minimum granularity of SoftROI in pixels
    public ushort wSoftRoiVertStepsDESC;   // Minimum granularity of SoftROI in pixels

    public ushort wIRDESC;                 // IR enhancment possibility

    public ushort wMinSizeVertDESC;        // Minimum size in pixels in vertical direction

    public uint dwMinDelayDESC;          // Minimum delay time in ns
    public uint dwMaxDelayDESC;          // Maximum delay time in ms
    public uint dwMinDelayStepDESC;      // Minimum stepping of delay time in ns
    public uint dwMinExposureDESC;       // Minimum exposure time in ns
    public uint dwMaxExposureDESC;       // Maximum exposure time in ms
    public uint dwMinExposStepDESC;   // Minimum stepping of exposure time in ns
    public uint dwMinDelayIRDESC;        // Minimum delay time in ns
    public uint dwMaxDelayIRDESC;        // Maximum delay time in ms
    public uint dwMinExposureIRDESC;     // Minimum exposure time in ns
    public uint dwMaxExposureIRDESC;     // Maximum exposure time in ms
    public ushort wTimeTableDESC;          // Timetable for exp/del possibility
    public ushort wDoubleImageDESC;        // Double image mode possibility
    public short sMinCoolSetDESC;         // Minimum value for cooling
    public short sMaxCoolSetDESC;         // Maximum value for cooling

    public short sDefaultCoolSetDESC;     // Default value for cooling
    public ushort wPowerDownModeDESC;      // Power down mode possibility 
    public ushort wOffsetRegulationDESC;   // Offset regulation possibility
    public ushort wColorPatternDESC;       // Color pattern of color chip
                                           // four nibbles (0,1,2,3) in ushort 
                                           //  ----------------- 
                                           //  | 3 | 2 | 1 | 0 |
                                           //  ----------------- 
                                           //   
                                           // describe row,column  2,2 2,1 1,2 1,1
                                           // 
                                           //   column1 column2
                                           //  ----------------- 
                                           //  |       |       |
                                           //  |   0   |   1   |   row1
                                           //  |       |       |
                                           //  -----------------
                                           //  |       |       |
                                           //  |   2   |   3   |   row2
                                           //  |       |       |
                                           //  -----------------

    public ushort wPatternTypeDESC;        // Pattern type of color chip
                                           // 0: Bayer pattern RGB
                                           // 1: Bayer pattern CMY

    public ushort wDummy1;
    public ushort wDummy2;
    public ushort wNumCoolingSetpoints;
    public uint dwGeneralCapsDESC1;
    public uint dwGeneralCapsDESC2;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] dwExtSyncFrequency;

    public uint dwGeneralCapsDESC3;
    public uint dwGeneralCapsDESC4;

    //public ushort wDSNUCorrectionModeDESC; // DSNU correction mode possibility
    //public ushort ZZwAlignDummy3;          //
    //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    //public uint[] dwReservedDESC;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public uint[] ZZdwDummy;
};