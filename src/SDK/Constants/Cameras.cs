namespace PCO.SDK.NET;

public static class Cameras
{
    // ------------------------------------------------------------------------ //
    // -- Defines for Get Camera Type Command: -------------------------------- //
    // ------------------------------------------------------------------------ //

    // Source: SC2_defs.h (defines and constants for use with SDK commands for pco.camera (SC2) - Rev 0.29 (21.02.2014)

    // pco.camera types
    public const int CAMERATYPE_PCO1200HS = 0x0100;
    public const int CAMERATYPE_PCO1300 = 0x0200;
    public const int CAMERATYPE_PCO1600 = 0x0220;
    public const int CAMERATYPE_PCO2000 = 0x0240;
    public const int CAMERATYPE_PCO4000 = 0x0260;

    // pco.1300 types
    public const int CAMERATYPE_ROCHEHTC = 0x0800; // Roche OEM
    public const int CAMERATYPE_284XS = 0x0800;
    public const int CAMERATYPE_KODAK1300OEM = 0x0820; // Kodak OEM

    // pco.1400 types
    public const int CAMERATYPE_PCO1400 = 0x0830;
    public const int CAMERATYPE_NEWGEN = 0x0840; // Roche OEM
    public const int CAMERATYPE_PROVEHR = 0x0850; // Zeiss OEM

    // pco.usb.pixelfly
    public const int CAMERATYPE_PCO_USBPIXELFLY = 0x0900;

    // pco.dimax types
    public const int CAMERATYPE_PCO_DIMAX_STD = 0x1000;
    public const int CAMERATYPE_PCO_DIMAX_TV = 0x1010;

    public const int CAMERATYPE_PCO_DIMAX_AUTOMOTIVE = 0x1020;   // obsolete and not used for the pco.dimax, please remove from your sources!
    public const int CAMERATYPE_PCO_DIMAX_CS = 0x1020;   // code is now used for pco.dimax CS

    public const int CAMERASUBTYPE_PCO_DIMAX_Weisscam = 0x0064;   // 100 = Weisscam, all features
    public const int CAMERASUBTYPE_PCO_DIMAX_HD = 0x80FF;   // pco.dimax HD
    public const int CAMERASUBTYPE_PCO_DIMAX_HD_plus = 0xC0FF;   // pco.dimax HD+
    public const int CAMERASUBTYPE_PCO_DIMAX_X35 = 0x00C8;   // 200 = Weisscam/P+S HD35

    public const int CAMERASUBTYPE_PCO_DIMAX_HS1 = 0x207F;
    public const int CAMERASUBTYPE_PCO_DIMAX_HS2 = 0x217F;
    public const int CAMERASUBTYPE_PCO_DIMAX_HS4 = 0x237F;

    public const int CAMERASUBTYPE_PCO_DIMAX_CS_AM_DEPRECATED = 0x407F;
    public const int CAMERASUBTYPE_PCO_DIMAX_CS_1 = 0x417F;
    public const int CAMERASUBTYPE_PCO_DIMAX_CS_2 = 0x427F;
    public const int CAMERASUBTYPE_PCO_DIMAX_CS_3 = 0x437F;
    public const int CAMERASUBTYPE_PCO_DIMAX_CS_4 = 0x447F;

    // pco.sensicam types                   // tbd., all names are internal ids
    public const int CAMERATYPE_SC3_SONYQE = 0x1200; // SC3 based - Sony 285
    public const int CAMERATYPE_SC3_EMTI = 0x1210; // SC3 based - TI 285SPD
    public const int CAMERATYPE_SC3_KODAK4800 = 0x1220; // SC3 based - Kodak KAI-16000

    // pco.edge types
    public const int CAMERATYPE_PCO_EDGE = 0x1300; // pco.edge 5.5 (Sensor CIS2521) Interface: CameraLink , rolling shutter
    public const int CAMERATYPE_PCO_EDGE_42 = 0x1302; // pco.edge 4.2 (Sensor CIS2020) Interface: CameraLink , rolling shutter
    public const int CAMERATYPE_PCO_EDGE_GL = 0x1310; // pco.edge 5.5 (Sensor CIS2521) Interface: CameraLink , global  shutter
    public const int CAMERATYPE_PCO_EDGE_USB3 = 0x1320; // pco.edge     (all sensors   ) Interface: USB 3.0    ,(all shutter modes)
    public const int CAMERATYPE_PCO_EDGE_HS = 0x1340; // pco.edge     (all sensors   ) Interface: high speed ,(all shutter modes) 
    public const int CAMERATYPE_PCO_EDGE_MT = 0x1304; // pco.edge MT2 (all sensors   ) Interface: CameraLink Base, rolling shutter

    public const int CAMERASUBTYPE_PCO_EDGE_SPRINGFIELD = 0x0006;
    public const int CAMERASUBTYPE_PCO_EDGE_31 = 0x0031;
    public const int CAMERASUBTYPE_PCO_EDGE_42 = 0x0042;
    public const int CAMERASUBTYPE_PCO_EDGE_55 = 0x0055;
    public const int CAMERASUBTYPE_PCO_EDGE_DEVELOPMENT = 0x0100;
    public const int CAMERASUBTYPE_PCO_EDGE_X2 = 0x0200;
    public const int CAMERASUBTYPE_PCO_EDGE_RESOLFT = 0x0300;
    public const int CAMERASUBTYPE_PCO_EDGE_GOLD = 0x0FF0;
    public const int CAMERASUBTYPE_PCO_EDGE_DUAL_CLOCK = 0x000D;
    public const int CAMERASUBTYPE_PCO_EDGE_DICAM = 0xDC00;
    public const int CAMERASUBTYPE_PCO_EDGE_42_LT = 0x8042;

    // pco.flim types
    public const int CAMERATYPE_PCO_FLIM = 0x1400; // pco.flim

    // pco.flow types
    public const int CAMERATYPE_PCO_FLOW = 0x1500; // pco.flow

    // pco.panda types
    public const int CAMERATYPE_PCO_PANDA = 0x1600; // pco.panda (deprecated, use CAMERATYPE_PCO_FAMILY_PANDA for the future)

    // camera types for pco camera families
    public const int CAMERATYPE_PCO_FAMILY_PANDA = 0x1600; // pco.panda
    public const int CAMERATYPE_PCO_FAMILY_EDGE = 0x1800; // pco.edge
    public const int CAMERATYPE_PCO_FAMILY_DICAM = 0x1700; // pco.dicam
    public const int CAMERATYPE_PCO_FAMILY_DIMAX = 0x1900; // pco.dimax


    // PANDA Family
    public const int CAMERASUBTYPE_PCO_PANDA_42 = 0x0000; // pco.panda 4.2
    public const int CAMERASUBTYPE_PCO_PANDA_42_BI = 0x0001; // pco.panda 4.2 bi
    public const int CAMERASUBTYPE_PCO_PANDA_150 = 0x0002; // pco.panda 15

    // EDGE Family
    public const int CAMERASUBTYPE_PCO_EDGE_42_BI = 0x0001; // pco.edge 4.2 bi
    public const int CAMERASUBTYPE_PCO_EDGE_260 = 0x0002; // pco.edge 26

    // DICAM Family
    public const int CAMERASUBTYPE_PCO_DICAM_C1 = 0x0001; // pco.dicam C1
    public const int CAMERASUBTYPE_PCO_DICAM_C2 = 0x0002; // reserved
    public const int CAMERASUBTYPE_PCO_DICAM_C3 = 0x0003; // reserved
    public const int CAMERASUBTYPE_PCO_DICAM_C4 = 0x0004; // pco.dicam C4
}