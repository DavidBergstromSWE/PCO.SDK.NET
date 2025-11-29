namespace PCO.SDK.NET;

public static class CameraHealth
{
    // ------------------------------------------------------------------------ //
    // -- Defines for Get Camera Health Status Command: ----------------------- //
    // ------------------------------------------------------------------------ //

    // Source: SC2_defs.h (defines and constants for use with SDK commands for pco.camera (SC2) - Rev 0.29 (21.02.2014)

    // mask bits: evaluate as follows: if (stat & ErrorSensorTemperature) ... //

    public const int WARNING_POWERSUPPLYVOLTAGERANGE = 0x00000001;
    public const int WARNING_POWERSUPPLYTEMPERATURE = 0x00000002;
    public const int WARNING_CAMERATEMPERATURE = 0x00000004;
    public const int WARNING_SENSORTEMPERATURE = 0x00000008;
    public const int WARNING_EXTERNAL_BATTERY_LOW = 0x00000010;
    public const int WARNING_OFFSET_REGULATION_RANGE = 0x00000020;
    public const int WARNING_CAMERARAM = 0x00020000;

    public const int ERROR_POWERSUPPLYVOLTAGERANGE = 0x00000001;
    public const int ERROR_POWERSUPPLYTEMPERATURE = 0x00000002;
    public const int ERROR_CAMERATEMPERATURE = 0x00000004;
    public const int ERROR_SENSORTEMPERATURE = 0x00000008;
    public const int ERROR_EXTERNAL_BATTERY_LOW = 0x00000010;
    public const int ERROR_FIRMWARE_CORRUPTED = 0x00000020;
    public const int ERROR_CAMERAINTERFACE = 0x00010000;
    public const int ERROR_CAMERARAM = 0x00020000;
    public const int ERROR_CAMERAMAINBOARD = 0x00040000;
    public const int ERROR_CAMERAHEADBOARD = 0x00080000;

    public const int STATUS_DEFAULT_STATE = 0x00000001;
    public const int STATUS_SETTINGS_VALID = 0x00000002;
    public const int STATUS_RECORDING_ON = 0x00000004;
    public const int STATUS_READ_IMAGE_ON = 0x00000008;
    public const int STATUS_FRAMERATE_VALID = 0x00000010;
    public const int STATUS_SEQ_STOP_TRIGGERED = 0x00000020;
    public const int STATUS_LOCKED_TO_EXTSYNC = 0x00000040;
    public const int STATUS_EXT_BATTERY_AVAILABLE = 0x00000080;
    public const int STATUS_IS_IN_POWERSAVE = 0x00000100;
    public const int STATUS_POWERSAVE_LEFT = 0x00000200;
    public const int STATUS_LOCKED_TO_IRIG = 0x00000400;
    public const long STATUS_IS_IN_BOOTLOADER = 0x80000000;
}