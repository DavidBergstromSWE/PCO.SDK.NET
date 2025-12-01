namespace PCO.SDK.NET;

/// <summary>
/// Buffer status list structure (used by PCO_WaitforBuffer).
/// </summary>
public struct PCO_Buflist
{
    public short sBufNr;
    public short ZZwAlignDummy;
    public uint dwStatusDll;
    public uint dwStatusDrv;                    // 12
}