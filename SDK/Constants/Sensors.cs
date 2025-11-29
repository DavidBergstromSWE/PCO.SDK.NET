namespace PCO.SDK.NET;

public static class Sensors
{
    // ------------------------------------------------------------------------ //
    // -- Sensor type definitions --------------------------------------------- //
    // ------------------------------------------------------------------------ //

    // Source: SC2_defs.h (defines and constants for use with SDK commands for pco.camera (SC2) - Rev 0.29 (21.02.2014)

    // Sensor Type 
    // ATTENTION: Lowest bit is reserved for COLOR CCDs
    // In case a new color CCD is added the lowest bit MUST be set!!!

    public const int SENSOR_ICX285AL = 0x0010;      // Sony
    public const int SENSOR_ICX285AK = 0x0011;      // Sony
    public const int SENSOR_ICX263AL = 0x0020;      // Sony
    public const int SENSOR_ICX263AK = 0x0021;      // Sony
    public const int SENSOR_ICX274AL = 0x0030;      // Sony
    public const int SENSOR_ICX274AK = 0x0031;      // Sony
    public const int SENSOR_ICX407AL = 0x0040;      // Sony
    public const int SENSOR_ICX407AK = 0x0041;      // Sony
    public const int SENSOR_ICX414AL = 0x0050;      // Sony
    public const int SENSOR_ICX414AK = 0x0051;      // Sony
    public const int SENSOR_ICX407BLA = 0x0060;      // Sony UV type

    public const int SENSOR_KAI2000M = 0x0110;      // Kodak
    public const int SENSOR_KAI2000CM = 0x0111;      // Kodak
    public const int SENSOR_KAI2001M = 0x0120;     // Kodak
    public const int SENSOR_KAI2001CM = 0x0121;      // Kodak
    public const int SENSOR_KAI2002M = 0x0122;     // Kodak slow roi
    public const int SENSOR_KAI2002CM = 0x0123;      // Kodak slow roi

    public const int SENSOR_KAI4010M = 0x0130;     // Kodak
    public const int SENSOR_KAI4010CM = 0x0131;      // Kodak
    public const int SENSOR_KAI4011M = 0x0132;     // Kodak slow roi
    public const int SENSOR_KAI4011CM = 0x0133;      // Kodak slow roi

    public const int SENSOR_KAI4020M = 0x0140;     // Kodak
    public const int SENSOR_KAI4020CM = 0x0141;      // Kodak
    public const int SENSOR_KAI4021M = 0x0142;     // Kodak slow roi
    public const int SENSOR_KAI4021CM = 0x0143;      // Kodak slow roi
    public const int SENSOR_KAI4022M = 0x0144;     // Kodak 4022 monochrom
    public const int SENSOR_KAI4022CM = 0x0145;      // Kodak 4022 color

    public const int SENSOR_KAI11000M = 0x0150;     // Kodak
    public const int SENSOR_KAI11000CM = 0x0151;     // Kodak
    public const int SENSOR_KAI11002M = 0x0152;    // Kodak slow roi
    public const int SENSOR_KAI11002CM = 0x0153;     // Kodak slow roi

    public const int SENSOR_KAI16000AXA = 0x0160;    // Kodak t:4960x3324, e:4904x3280, a:4872x3248
    public const int SENSOR_KAI16000CXA = 0x0161;   // Kodak

    public const int SENSOR_MV13BW = 0x1010;   // Micron
    public const int SENSOR_MV13COL = 0x1011;    // Micron

    public const int SENSOR_CIS2051_V1_FI_BW = 0x2000;      //Fairchild front illuminated
    public const int SENSOR_CIS2051_V1_FI_COL = 0x2001;
    public const int SENSOR_CIS1042_V1_FI_BW = 0x2002;
    public const int SENSOR_CIS2051_V1_BI_BW = 0x2010;   //Fairchild back illuminated

    public const int SENSOR_TC285SPD = 0x2120;     // TI 285SPD

    public const int SENSOR_CYPRESS_RR_V1_BW = 0x3000;      // CYPRESS RoadRunner V1 B/W
    public const int SENSOR_CYPRESS_RR_V1_COL = 0x3001;     // CYPRESS RoadRunner V1 Color

    public const int SENSOR_CMOSIS_CMV12000_BW = 0x3100;  // CMOSIS CMV12000 4096x3072 b/w
    public const int SENSOR_CMOSIS_CMV12000_COL = 0x3101;  // CMOSIS CMV12000 4096x3072 color

    public const int SENSOR_QMFLIM_V2B_BW = 0x4000;     // CSEM QMFLIM V2B B/W

    //public const int SENSOR_GPIXEL_X2_BW       =0x5000 ; // Gpixel 2k
    //public const int SENSOR_GPIXEL_X2_COL      =0x5001 ; // Gpixel 2k

    //public const int SENSOR_GPIXEL_X5_BW       =0x5100 ;  // Gpixel 5k

    public const int SENSOR_GPIXEL_GSENSE2020_BW = 0x5000; // Gpixel GSENSE2020 4.2M
    public const int SENSOR_GPIXEL_GSENSE2020_COL = 0x5001; // Gpixel GSENSE2020 4.2M

    public const int SENSOR_GPIXEL_GSENSE2020BI_BW = 0x5002; // Gpixel GSENSE2020BSI 4.2M-BI

    public const int SENSOR_GPIXEL_GSENSE5130_BW = 0x5004; // Gpixel GSENSE5130 15M
    public const int SENSOR_GPIXEL_GSENSE5130_COL = 0x5005; // Gpixel GSENSE5130 15M

    public const int SENSOR_GPIXEL_GMAX0505_BW = 0x5006; // Gpixel GMAX0505 26M
    public const int SENSOR_GPIXEL_GMAX0505_COL = 0x5007; // Gpixel GMAX0505 26M

}