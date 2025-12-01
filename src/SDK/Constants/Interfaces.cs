namespace PCO.SDK.NET;

public static class Interfaces
{
    // ------------------------------------------------------------------------ //
    // -- Defines for Interfaces ---------------------------------------------- //
    // ------------------------------------------------------------------------ //
    // These defines are camera internal defines and are not SDK related!

    // Source: SC2_defs.h (defines and constants for use with SDK commands for pco.camera (SC2) - Rev 0.29 (21.02.2014)

    public const int INTERFACE_FIREWIRE = 0x0001;
    public const int INTERFACE_CAMERALINK = 0x0002;
    public const int INTERFACE_USB = 0x0003;
    public const int INTERFACE_ETHERNET = 0x0004;
    public const int INTERFACE_SERIAL = 0x0005;
    public const int INTERFACE_USB3 = 0x0006;
    public const int INTERFACE_CAMERALINKHS = 0x0007;
    public const int INTERFACE_COAXPRESS = 0x0008;
    public const int INTERFACE_USB31_GEN1 = 0x0009;
}