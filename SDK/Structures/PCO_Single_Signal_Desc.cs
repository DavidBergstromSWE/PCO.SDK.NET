using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Single_Signal_Desc
{
    public ushort wSize;                            // Sizeof 'this' (for future enhancements)
    public ushort ZZwAlignDummy1;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 25)] // 4*25?
    public char[] strSignalName;                   // Name of signal 104
                                                   // Specifies NUM_SIGNAL_NAMES functionalities (1-4)
    public ushort wSignalDefinitions;               // Flags showing signal options
                                                    // 0x01: Signal can be enabled/disabled
                                                    // 0x02: Signal is a status (output)
                                                    // 0x10: Func. 1 has got timing settings
                                                    // 0x20: Func. 2 has got timing settings
                                                    // 0x40: Func. 3 has got timing settings
                                                    // 0x80: Func. 4 has got timing settings
                                                    // Rest: future use, set to zero!
    public ushort wSignalTypes;                     // Flags showing the selectability of signal types
                                                    // 0x01: TTL
                                                    // 0x02: High Level TTL
                                                    // 0x04: Contact Mode
                                                    // 0x08: RS485 diff.
                                                    // Rest: future use, set to zero!
    public ushort wSignalPolarity;                  // Flags showing the selectability
                                                    // of signal levels/transitions
                                                    // 0x01: High Level active
                                                    // 0x02: Low Level active
                                                    // 0x04: Rising edge active
                                                    // 0x08: Falling edge active
                                                    // Rest: future use, set to zero!
    public ushort wSignalFilter;                    // Flags showing the selectability of filter
                                                    // settings
                                                    // 0x01: Filter can be switched off (t > ~65ns)
                                                    // 0x02: Filter can be switched to medium (t > ~1us)
                                                    // 0x04: Filter can be switched to high (t > ~100ms) 112
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public uint[] dwDummy;                          // reserved for future use. (only in SDK) 200
}