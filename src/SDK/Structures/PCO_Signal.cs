using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

/// <summary>
/// Contains settings of a distinct hardware IO signal line.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PCO_Signal
{
    public ushort wSize;        // Sizeof this struct
    public ushort wSignalNum;   // Index for strSignal (0,1,2,3,)
    public ushort wEnabled;     // Flag shows enable state of the signal (0: off, 1: on)
    public ushort wType;        // Selected signal type (1: TTL, 2: HL TTL, 4: contact, 8: RS485, 80: TTL-A/GND-B)
    public ushort wPolarity;    // Selected signal polarity (1: H, 2: L, 4: rising, 8: falling)
    public ushort wFilterSetting; // Selected signal filter (1: off, 2: med, 4: high) // 12
    public ushort wSelected;    // Select signal (0: standard signal, >1 other signal)
    public ushort ZzwReserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] dwParameter;  // Timing parameter for signal[wSelected]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] dwSignalFunctionality; // Type of functionality behind the signal[wSelected] to select the correct parameter set (e.g. 7->Parameter for 'Rolling Shutter exp.signal'
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public uint[] ZzdwReserved; // 60
}