using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

[StructLayout(LayoutKind.Sequential)]
public struct PCO_DescriptionEx
{
    public ushort wSize;                   // Sizeof this struct
};