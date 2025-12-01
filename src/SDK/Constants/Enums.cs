namespace PCO.SDK.NET;

/// <summary>
/// Exposure trigger mode.
/// </summary>
public enum TriggerMode
{
    /// <summary>
    /// Exposure is started automatically, optimized to the current readout and timing settings (default mode usually).
    /// </summary>
    AutoSequence = 0,
    /// <summary>
    /// Exposure is only started by a force trigger command.
    /// </summary>
    SoftwareTrigger,
    /// <summary>
    /// Delay/exposure sequence is started depending on the HW signal at the trigger input line or by a force trigger command.
    /// </summary>
    ExternalExposureStart,
    /// <summary>
    /// Exposure sequence is started depending on the HW signal at the trigger input line. The exposure time is defined by the pulse length of the HW signal.
    /// </summary>
    ExternalExposureControl
}

/// <summary>
/// Noise filter correction mode.
/// </summary>
public enum NoiseFilterMode
{
    /// <summary>
    /// Switched off.
    /// </summary>
    Off = 0,
    /// <summary>
    /// Switched on.
    /// </summary>
    On = 1,
    /// <summary>
    /// Switched on plus hot pixel correction.
    /// </summary>
    HotCorrection = 0x0101
}

/// <summary>
/// Timestamp mode for camera, determining how timestamp will be included in the raw image data.
/// </summary>
public enum TimestampMode
{
    /// <summary>
    /// No timestamp written.
    /// </summary>
    Off = 0,
    /// <summary>
    /// Timestamp BCD coded in the lower byte of each pixel value (packed).
    /// </summary>
    Binary,
    /// <summary>
    /// Combination of <see cref="Binary"/> and <see cref="ASCII"/> modes.
    /// </summary>
    BinaryASCII,
    /// <summary>
    /// Timestamp coded in ASCII with digits in a 8 x 8 pixel matrix, showing white on black characters.
    /// </summary>
    ASCII
}

/// <summary>
/// Binning orientation.
/// </summary>
public enum BinningOrientation
{
    /// <summary>
    /// Horizontal.
    /// </summary>
    Horizontal = 0,
    /// <summary>
    /// Vertical.
    /// </summary>
    Vertical = 1
}

/// <summary>
/// Temperature probe location.
/// </summary>
public enum TemperatureSelector
{
    /// <summary>
    /// Sensor.
    /// </summary>
    Sensor = 0,
    /// <summary>
    /// Mainboard.
    /// </summary>
    Mainboard,
    /// <summary>
    /// Device-specific.
    /// </summary>
    DeviceSpecific
}