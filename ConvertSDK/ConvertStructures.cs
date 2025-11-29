using System.Runtime.InteropServices;

namespace PCO.SDK.NET.Convert;


[StructLayout(LayoutKind.Sequential)]
public struct SRGBCOLCORRCOEFF
{
    public double da11, da12, da13;
    public double da21, da22, da23;
    public double da31, da32, da33;
}//sRGB_color_correction_coefficients


[StructLayout(LayoutKind.Sequential)]
public struct PCO_SensorInfo
{
    public ushort wSize;
    public ushort wDummy;
    public int iConversionFactor;              // Conversion factor of sensor in 1/100 e/count
    public int iDataBits;                      // Bit resolution of sensor
    public int iSensorInfoBits;                // Flags:
    // 0x00000001: Input is a color image (see Bayer struct!)
    // 0x00000002: Input is upper aligned
    public int iDarkOffset;                    // Hardware dark offset
    public uint dwzzDummy0;
    public SRGBCOLCORRCOEFF strColorCoeff;      // 9 double -> 18int // 24 int
    public int iCamNum;                        // Camera number (enumeration of cameras controlled by app)
    public nint hCamera;                      // Handle of the camera loaded, future use; set to zero.
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
    public uint[] dwzzDummy1;
};

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Display
{
    public PCO_Display()
    {
        wSize = 0;
        wDummy = 0;
        iScale_maxmax = 0;
        iScale_max = 0;
        iScale_min = 0;
        iColor_temp = 0;
        iColor_tint = 0;
        iColor_saturation = 0;
        iColor_vibrance = 0;
        iColor_vibrance = 0;
        iContrast = 0;
        iGamma = 0;
        iSRGB = 0;
        pucLut = nint.Zero;
        dwzzDummy1 = new uint[52];
        for (int i = 0; i < 52; i++)
            dwzzDummy1[i] = 0;
    }
    public ushort wSize;
    public ushort wDummy;
    public int iScale_maxmax;// Maximum value for max 
    public int iScale_min;   // Lowest value for processing
    public int iScale_max;   // Highest value for processing
    public int iColor_temp;  // Color temperature  3500...20000
    public int iColor_tint;  // Color correction  -100...100 // 5 int
    public int iColor_saturation; // Color saturation  -100...100
    public int iColor_vibrance; // Color dynamic saturation  -100...100
    public int iContrast;    // Contrast  -100...100
    public int iGamma;       // Gamma  -100...100
    public int iSRGB;				 // sRGB mode
    public nint pucLut;       // Pointer to Lookup-Table // 10 int
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
    public uint[] dwzzDummy1;
};

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Bayer
{
    public ushort wSize;
    public ushort wDummy;
    public int iKernel;
    public int iColorMode;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 61)]
    public uint[] dwzzDummy1;
};

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Filter
{
    public ushort wSize;
    public ushort wDummy;
    public int iMode;
    public int iType;
    public int iSharpen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
    public uint[] dwzzDummy1;
};

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Convert
{
    public ushort wSize;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public ushort[] wDummy;
    public PCO_Display str_Display;     // Process settings for output image // 66 int
    public PCO_Bayer str_Bayer;       // Bayer processing settings // 130 int
    public PCO_Filter str_Filter;      // Filter processing settings // 198 int
    public PCO_SensorInfo str_SensorInfo;  // Sensor parameter // 258 int
    public int iData_Bits_Out;

    public uint dwModeBitsDataOut;
    public int iGPU_Processing_mode;// Mode for processing: 0->CPU, 1->GPU // 261 int
    public int iConvertType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 58)]
    public uint[] dwzzDummy1;
};
