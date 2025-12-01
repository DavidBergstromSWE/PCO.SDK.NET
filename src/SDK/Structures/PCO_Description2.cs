using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Description2
{
    public ushort wSize;                   // Sizeof this struct
    public ushort ZZwAlignDummy1;
    public uint dwMinPeriodicalTimeDESC2;// Minimum periodical time tp in (nsec)
    public uint dwMaxPeriodicalTimeDESC2;// Maximum periodical time tp in (msec)        (12)
    public uint dwMinPeriodicalConditionDESC2;// System imanent condition in (nsec)
                                              // tp - (td + te) must be equal or longer than
                                              // dwMinPeriodicalCondition
    public uint dwMaxNumberOfExposuresDESC2;// Maximum number of exporures possible        (20)
    public int lMinMonitorSignalOffsetDESC2;// Minimum monitor signal offset tm in (nsec) // long?
                                            // if(td + tstd) > dwMinMon.)
                                            //   tm must not be longer than dwMinMon
                                            // else
                                            //   tm must not be longer than td + tstd
    public uint dwMaxMonitorSignalOffsetDESC2;// Maximum -''- in (nsec)                      
    public uint dwMinPeriodicalStepDESC2;// Minimum step for periodical time in (nsec)  (32)
    public uint dwStartTimeDelayDESC2; // Minimum monitor signal offset tstd in (nsec)
                                       // see condition at dwMinMonitorSignalOffset
    public uint dwMinMonitorStepDESC2; // Minimum step for monitor time in (nsec)     (40)
    public uint dwMinDelayModDESC2;    // Minimum delay time for modulate mode in (nsec)
    public uint dwMaxDelayModDESC2;    // Maximum delay time for modulate mode in (msec)
    public uint dwMinDelayStepModDESC2;// Minimum delay time step for modulate mode in (nsec)(52)
    public uint dwMinExposureModDESC2; // Minimum exposure time for modulate mode in (nsec)
    public uint dwMaxExposureModDESC2; // Maximum exposure time for modulate mode in (msec)(60)
    public uint dwMinExposureStepModDESC2;// Minimum exposure time step for modulate mode in (nsec)
    public uint dwModulateCapsDESC2;   // Modulate capabilities descriptor
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public uint[] dwReserved;                                                    //(132)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 41)]
    public uint[] ZZdwDummy;                                                         // 296};
};