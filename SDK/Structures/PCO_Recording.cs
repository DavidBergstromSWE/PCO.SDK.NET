using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_Recording
{
    public ushort wSize;                // Sizeof this struct
    public ushort wStorageMode;         // Storage mode: 0 = recorder, 1 = FIFO buffer
    public ushort wRecSubMode;          // Recorder sub mode: 0 = sequence, 1 = ring buffer
    public ushort wRecState;            // Recording state: 0 = off, 1 = on
    public ushort wAcquMode;            // Aquire mode: 0 = internal auto, 1 = external, 2 = external frame, 3 = reserved, 4 = external sequence    // 10
    public ushort wAcquEnableStatus;    // Acquire status: 0 = disabled, 1 = enabled
    public byte ucDay;                  // Timestamp data week date (1-31)
    public byte ucMonth;                // Timestamp data month (1-12)  // 14
    public ushort wYear;                // Timestamp data year
    public ushort wHour;                // Timestamp data hour (0-23)
    public byte ucMin;                  // Timestamp data minutes (0-59)
    public byte ucSec;                  // Timestamp data seconds (0-59)    // 20
    public ushort wTimeStampMode;       // Timestamp mode: 0 = no stamp, 1 = BCD coded, 2 = BCD coded + ASCII, 3 = ASCII
    public ushort wRecordStopEventMode; // Record stop event mode: 0 = off, 1 = on
    public uint dwRecordStopDelayImages;// Number of images which should pass by until stop event is executed   // 28
    public ushort wMetaDataMode;        // Metadata mode: 0 = off, 1 = enabled
    public ushort wMetaDataSize;        // Size of metadata in number of pixels
    public ushort wMetaDataVersion;     // Version info for metadata
    public ushort ZZwDummy1;            // reserved
    public uint dwAcquModeExNumberImages; // Number of images in one acquire sequence; valid when in acquire mode [external sequence]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] dwAcquModeExReserved;   // reserved
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public ushort[] ZZwDummy;           // reserved     // 100
}