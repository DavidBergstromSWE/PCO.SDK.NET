using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

/// <summary>
/// Contains timing related information about camera.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PCO_Timing
{
    public ushort wSize;        // Sizeof this struct
    public ushort wTimeBaseDelay; // Timebase delay 0:ns, 1:µs, 2:ms
    public ushort wTimeBaseExposure; // Timebase expos 0:ns, 1:µs, 2:ms
    public ushort wCMOSParameter; // Line Time mode: 0: off 1: on    // 8
    public uint dwCMOSDelayLines; // See next line
    public uint dwCMOSExposureLines;     // Delay and Exposure lines for lightsheet // 16
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public uint[] dwDelayTable; // Delay table             // 80
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 110)]
    public uint[] ZZdwDummy1; // 520
    public uint dwCMOSLineTimeMin;       // Minimum line time in ns
    public uint dwCMOSLineTimeMax;       // Maximum line time in ms         // 528
    public uint dwCMOSLineTime;          // Current line time value         // 532
    public ushort wCMOSTimeBase;           // Current time base for line time
    public ushort wIntensifiedLoopCount;   // Number of loops to use for mutli exposure
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public uint[] dwExposureTable; // Exposure table       // 600
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 110)]
    public uint[] ZZdwDummy2;
    public uint dwCMOSFlags; // Flags indicating the option, whether it is possible to LS-Mode with slow/fast scan, etc.
    public uint ZZdwDummy3;
    public ushort wTriggerMode; // Trigger mode 0: auto, 1: software trg, 2:extern 3: extern exp. ctrl // 1050
    public ushort wForceTrigger; // Force trigger (Auto reset flag!)
    public ushort wCameraBusyStatus; // Camera busy status 0: idle, 1: busy
    public ushort wPowerDownMode; // Power down mode 0: auto, 1: user // 1056
    public uint dwPowerDownTime; // Power down time 0ms...49,7d     // 1060
    public ushort wExpTrgSignal; // Exposure trigger signal status
    public ushort wFPSExposureMode; // Cmos-Sensor FPS exposure mode
    public uint dwFPSExposureTime; // Resulting exposure time in FPS mode // 1068
    public ushort wModulationMode; // Mode for modulation (0 = modulation off, 1 = modulation on) // 1070
    public ushort wCameraSynchMode; // Camera synchronization mode (0 = off, 1 = master, 2 = slave)
    public uint dwPeriodicalTime; // Periodical time (unit depending on timebase) for modulation // 1076
    public ushort wTimeBasePeriodical; // timebase for periodical time for modulation  0 -> ns, 1 -> µs, 2 -> ms
    public ushort ZZwAlignDummy3;
    public uint dwNumberofExposures; // Number of exposures during modulation // 1084
    public int lMonitorOffset; // Monitor offset value in ns      // 1088
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public PCO_Signal[] strSignal; // Signal settings               // 2288
    public ushort wStatusFrameRate; // Framerate status
    public ushort wFrameRateMode; // Dimax: Mode for frame rate
    public uint dwFrameRate; // Dimax: Framerate in mHz
    public uint dwFrameRateExposure; // Dimax: Exposure time in ns      // 2300
    public ushort wTimingControlMode; // Dimax: Timing Control Mode: 0->Exp./Del. 1->FPS
    public ushort wFastTimingMode; // Dimax: Fast Timing Mode: 0->off 1->on
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
    public ushort[] ZZwDummy;
}