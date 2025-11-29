using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PCO.SDK.NET;

/// <summary>
/// Wrapper class for the PCO.SDK (C++) library.
/// </summary>
public static class LibWrapper
{
    /// <summary>
    /// Stores errors coded as integers. Text descriptions of errors can be retrieved using <see cref="GetLastError"/> class.
    /// </summary>
    private static int _error;

    private static PCO_Description _cameraDescription = new() { wSize = (ushort)Marshal.SizeOf(_cameraDescription) };

    #region CameraAccess

    /// <summary>
    /// Open connection to camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to opened camera.</param>
    /// <returns>True if camera was found.</returns>
    public static bool OpenCamera(ref nint cameraHandle) 
    {
        return SDK.PCO_OpenCamera(pHandle: ref cameraHandle, wCamNum: 0) == 0;
    }

    /// <summary>
    /// Close connection to a previously opened camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <exception cref="PcoException"></exception>
    public static void CloseCamera(nint cameraHandle) 
    {
        _error = SDK.PCO_CloseCamera(pHandle: cameraHandle);
        if (_error != 0)
            throw new PcoException(_error);
    }

    #endregion

    #region CameraDescription

    // ToDo: Retrieve fields instead (eg. dynamic range, limits and increments of binning, roi, size and exposure?
    internal static PCO_Description GetCameraDescription(nint cameraHandle)
    {
        _error = SDK.PCO_GetCameraDescription(pHandle: cameraHandle, strDescription: ref _cameraDescription);
        if (_error != 0)
            throw new PcoException(_error);
        else return _cameraDescription;
    }

    /// <summary>
    /// Get bit depth of camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Bit depth (in bits per pixel).</returns>
    /// <exception cref="PcoException"></exception>
    public static ushort GetCameraBitDepth(nint cameraHandle)
    {
        _error = SDK.PCO_GetCameraDescription(pHandle: cameraHandle, strDescription: ref _cameraDescription);
        if(_error != 0)
            throw new PcoException(_error);
        else return _cameraDescription.wDynResDESC;
    }

    #endregion

    #region CameraStatus

    /// <summary>
    /// Get name of camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Camera name.</returns>
    public static string GetCameraName(nint cameraHandle)
    {
        byte[] szCameraName = new byte[40];
        _error = SDK.PCO_GetCameraName(pHandle: cameraHandle, szCameraName: szCameraName, wSZCameraNameLen: (ushort)szCameraName.Length);
        if (_error != 0)
            throw new PcoException(_error);

        // Return string with trailing zeros trimmed away.
        return Encoding.Default.GetString(szCameraName).TrimEnd('\0');
    }

    /// <summary>
    /// Get serial number of camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Camera serial number.</returns>
    public static string GetCameraSerialNumber(nint cameraHandle) 
    {
        var cameraType = new PCO_CameraType();
        cameraType.wSize = (ushort)Marshal.SizeOf(cameraType);
        _error = SDK.PCO_GetCameraType(pHandle: cameraHandle, strCameraType: ref cameraType);
        if (_error != 0)
            throw new PcoException(_error);
        else return cameraType.dwSerialNumber.ToString("");
    }

    /// <summary>
    /// Get temperature in camera, based on specified probe location.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="selector">Probe location.</param>
    /// <returns>Temperature in degrees Celsius.</returns>
    /// <exception cref="PcoException"></exception>
    public static float GetCameraTemperature(nint cameraHandle, TemperatureSelector selector)
    {
        short sensorTemp = 0, internalTemp = 0, additionalTemp = 0;
        _error = SDK.PCO_GetTemperature(pHandle: cameraHandle, sCCDTemp: ref sensorTemp, sCamTemp: ref internalTemp, sPowTemp: ref additionalTemp);
        if (_error != 0)
            throw new PcoException(_error);

        var deviceTemperature = selector switch
        {
            TemperatureSelector.Sensor => sensorTemp / 10,
            TemperatureSelector.Mainboard => internalTemp,
            TemperatureSelector.DeviceSpecific => additionalTemp,
            _ => sensorTemp / 10
        };
        return deviceTemperature;
    }

    /// <summary>
    /// Get current health status of camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="warningMessage">Warning message received.</param>
    /// <param name="errorMessage">Error message received.</param>
    /// <returns>True if camera is healthy.</returns>
    public static bool GetCameraHealth(nint cameraHandle, out string warningMessage, out string errorMessage)
    {
        uint cameraWarning = 0, cameraError = 0, cameraStatus = 0;
        _error = SDK.PCO_GetCameraHealthStatus(pHandle: cameraHandle, dwWarn: ref cameraWarning, dwError: ref cameraError, ref cameraStatus); // what is returned in case of warning, error, status fail?
        warningMessage = GetLastError.ToString((int)cameraWarning);
        errorMessage = GetLastError.ToString((int)cameraError);
        return _error == 0; // does it only return false when error is received?
    }

    #endregion

    #region CameraControl

    /// <summary>
    /// Reset all camera settings to their default values.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <exception cref="PcoException"></exception>
    public static void ResetSettingsToDefault(nint cameraHandle)
    {
        // Make sure camera is stopped.
        if (GetRecordingState(cameraHandle))
            SetRecordingState(cameraHandle, false);

        // Reset settings.
        _error = SDK.PCO_ResetSettingsToDefault(pHandle: cameraHandle);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Arms the camera, preparing it for recording.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <exception cref="PcoException"></exception>
    public static void ArmCamera(nint cameraHandle)
    {
        _error = SDK.PCO_ArmCamera(pHandle: cameraHandle);
        if (_error != 0)
            throw new PcoException(_error);
    }

    #endregion

    #region ImageSensor

    /// <summary>
    /// Get collective information about settings of imaging sensor.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Sensor settings.</returns>
    /// <exception cref="PcoException"></exception>
    internal static PCO_Sensor GetSensorStruct(nint cameraHandle)
    {
        // not working? 

        var cameraSensor = new PCO_Sensor { wSize = 8000 }; // (ushort)Marshal.SizeOf(_cameraSensor); // 5880
        cameraSensor.strDescription.wSize = (ushort)Marshal.SizeOf(cameraSensor.strDescription); // 436
        cameraSensor.strDescription2.wSize = (ushort)Marshal.SizeOf(cameraSensor.strDescription2); // 296
        cameraSensor.strDescriptionIntensified.wSize = (ushort)Marshal.SizeOf(cameraSensor.strDescriptionIntensified); // 160
        cameraSensor.strDescription3.wSize = (ushort)Marshal.SizeOf(cameraSensor.strDescription3); // 192        
        cameraSensor.strSignalDesc.wSize = (ushort)Marshal.SizeOf(cameraSensor.strSignalDesc);
        //for (int i = 0; i < 20; i++)
        //{
        //    _cameraSensor.strSignalDesc.strSingeSignalDesc[i].wSize = (ushort)Marshal.SizeOf(_cameraSensor.strSignalDesc.strSingeSignalDesc[i]);
        //}

        _error = SDK.PCO_GetSensorStruct(pHandle: cameraHandle, strSensor: ref cameraSensor);
        if (_error != 0)
            throw new PcoException(_error);
        else return cameraSensor;
    }

    /// <summary>
    /// Get current (armed) image size in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="width">Current horizontal resolution.</param>
    /// <param name="height">Current vertical resolution.</param>
    /// <param name="widthMax">Maximum horizontal resolution.</param>
    /// <param name="heightMax">Maximum vertical resolution.</param>
    /// <exception cref="PcoException"></exception>
    public static void GetSizes(nint cameraHandle, ref ushort width, ref ushort height, ref ushort widthMax, ref ushort heightMax)
    {
        _error = SDK.PCO_GetSizes(pHandle: cameraHandle, wXResAct: ref width, wYResAct: ref height, wXResMax: ref widthMax, wYResMax: ref heightMax);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Get current sensor format (standard or extended) in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="sensorWidth">Maximum width.</param>
    /// <param name="sensorHeight">Maximum height.</param>
    /// <exception cref="PcoException"></exception>
    public static void GetSensorFormat(nint cameraHandle, out ushort sensorWidth, out ushort sensorHeight, out ushort minimumWidth, out ushort minimumHeight)
    {
        // Retrieve information about sensor format in use (standard or extended).
        ushort wSensor = 0;
        _error = SDK.PCO_GetSensorFormat(pHandle: cameraHandle, wSensor: ref wSensor);
        if (_error != 0)
            throw new PcoException(_error);

        // Retrieve description of camera device.
        _error = SDK.PCO_GetCameraDescription(pHandle: cameraHandle, strDescription: ref _cameraDescription);
        if (_error != 0)
            throw new PcoException(_error);

        // Return maximum width and height based on sensor format.
        if (wSensor == 0) // standard
        {
            sensorHeight = _cameraDescription.wMaxVertResStdDESC;
            sensorWidth = _cameraDescription.wMaxHorzResStdDESC;
        }
        else // extended
        {
            sensorHeight = _cameraDescription.wMaxVertResExtDESC;
            sensorWidth = _cameraDescription.wMaxHorzResExtDESC;
        }

        minimumWidth = _cameraDescription.wMinSizeHorzDESC;
        minimumHeight = _cameraDescription.wMinSizeVertDESC;
    }

    /// <summary>
    /// Get currently used region-of-interest (ROI) in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="width">Width.</param>
    /// <param name="height">Height.</param>
    /// <param name="offsetX">OffsetX.</param>
    /// <param name="offsetY">OffsetY.</param>
    /// <exception cref="PcoException"></exception>
    public static void GetROI(nint cameraHandle, out ushort width, out ushort height, out ushort offsetX, out ushort offsetY)
    {
        ushort wRoiX0 = 0, wRoiY0 = 0, wRoiX1 = 0, wRoiY1 = 0;
        _error = SDK.PCO_GetROI(pHandle: cameraHandle, wRoiX0: ref wRoiX0, wRoiY0: ref wRoiY0, wRoiX1: ref wRoiX1, wRoiY1: ref wRoiY1);
        if (_error != 0)
            throw new PcoException(_error);

        width = (ushort)(wRoiX1 - wRoiX0 + 1);
        height = (ushort)(wRoiY1 - wRoiY0 + 1);
        offsetX = (ushort)(wRoiX0 - 1);
        offsetY = (ushort)(wRoiY0 - 1);
    }

    /// <summary>
    /// Set region-of-interest (ROI) in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="width">Width.</param>
    /// <param name="height">Height.</param>
    /// <param name="offsetX">OffsetX.</param>
    /// <param name="offsetY">OffsetY.</param>
    /// <exception cref="PcoException"></exception>
    public static void SetROI(nint cameraHandle, ushort width, ushort height, ushort offsetX, ushort offsetY)
    {
        _error = SDK.PCO_SetROI(pHandle: cameraHandle, wRoiX0: (ushort)(offsetX + 1), wRoiY0: (ushort)(offsetY + 1), wRoiX1: (ushort)(offsetX + width), wRoiY1: (ushort)(offsetY + height));
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Get smallest incremental steps available for region-of-interests (ROI) in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="horizontalStep">Horizontal ROI increment.</param>
    /// <param name="verticalStep">Vertical ROI increment.</param>
    /// <exception cref="PcoException"></exception>
    public static void GetROISteps(nint cameraHandle, out ushort horizontalStep, out ushort verticalStep)
    {
        _cameraDescription = GetCameraDescription(cameraHandle);

        horizontalStep = _cameraDescription.wRoiHorStepsDESC;
        verticalStep = _cameraDescription.wRoiVertStepsDESC;
    }

    /// <summary>
    /// Get binning setting currently used in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="orientation">Horizontal or vertical.</param>
    /// <returns>Binning setting.</returns>
    /// <exception cref="PcoException"></exception>
    public static ushort GetBinning(nint cameraHandle, BinningOrientation orientation)
    {
        ushort wBinHorz = 0, wBinVert = 0;
        _error = SDK.PCO_GetBinning(pHandle: cameraHandle, wBinHorz: ref wBinHorz, wBinVert: ref wBinVert);
        if (_error != 0)
            throw new PcoException(_error);

        return orientation switch
        {
            BinningOrientation.Horizontal => wBinHorz,
            _ => wBinVert
        };
    }

    /// <summary>
    /// Set binning settings in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="binningSetting">New binning setting.</param>
    /// <param name="orientation">Horizontal or vertical.</param>
    /// <exception cref="PcoException"></exception>
    public static void SetBinning(nint cameraHandle, ushort binningSetting, BinningOrientation orientation)
    {
        var horizontalBinning = GetBinning(cameraHandle, BinningOrientation.Horizontal);
        var verticalBinning = GetBinning(cameraHandle, BinningOrientation.Vertical);

        _error = orientation == BinningOrientation.Horizontal
            ? SDK.PCO_SetBinning(pHandle: cameraHandle, wBinHorz: binningSetting, wBinVert: verticalBinning)
            : SDK.PCO_SetBinning(pHandle: cameraHandle, wBinHorz: horizontalBinning, wBinVert: binningSetting);

        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Get limits available for binning settings in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="maximumHorizontalBinning">Maximum horizontal binning (number of pixels).</param>
    /// <param name="maximumVerticalBinning">Maximum vertical binning (number of pixels).</param>
    /// <param name="horizontalBinningStep">Horizontal binning increment.</param>
    /// <param name="verticalBinningStep">Vertical binning increment.</param>
    /// <exception cref="PcoException"></exception>
    public static void GetBinningLimits(nint cameraHandle, out ushort maximumHorizontalBinning, out ushort maximumVerticalBinning, out ushort horizontalBinningStep, out ushort verticalBinningStep)
    {
        _error = SDK.PCO_GetCameraDescription(pHandle: cameraHandle, strDescription: ref _cameraDescription);
        if (_error != 0)
            throw new PcoException(_error);
        else
        {
            maximumHorizontalBinning = _cameraDescription.wMaxBinHorzDESC;
            maximumVerticalBinning = _cameraDescription.wMaxBinVertDESC;
            horizontalBinningStep = _cameraDescription.wBinHorzSteppingDESC;
            verticalBinningStep = _cameraDescription.wBinVertSteppingDESC;
        }
    }

    /// <summary>
    /// Get list of valid binning settings of camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="orientation">Horizontal or vertical.</param>
    /// <returns></returns>
    /// <exception cref="PcoException"></exception>
    public static List<long> GetValidBinningModes(nint cameraHandle, BinningOrientation orientation)
    {
        _error = SDK.PCO_GetCameraDescription(pHandle: cameraHandle, strDescription: ref _cameraDescription);
        if (_error != 0)
            throw new PcoException(_error);

        var binningModes = new List<long>();

        if (orientation == BinningOrientation.Horizontal)
        {
            if (_cameraDescription.wBinHorzSteppingDESC == 0) // binary stepping
            {
                int i = 1;
                while (i <= _cameraDescription.wMaxBinHorzDESC)
                {
                    binningModes.Add(i);
                    i *= 2;
                }
            }
            else // linear stepping
            {
                int i = 1;
                while (i <= _cameraDescription.wMaxBinHorzDESC)
                {
                    binningModes.Add(i);
                    i += 1;
                }
            }
        }
        else
        {
            if (_cameraDescription.wBinVertSteppingDESC == 0) // binary stepping
            {
                int i = 1;
                while (i <= _cameraDescription.wMaxBinVertDESC)
                {
                    binningModes.Add(i);
                    i *= 2;
                }
            }
            else // linear stepping
            {
                int i = 1;
                while (i <= _cameraDescription.wMaxBinVertDESC)
                {
                    binningModes.Add(i);
                    i += 1;
                }
            }
        }

        return binningModes;
    }

    /// <summary>
    /// Get noise filter correction mode currently used in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Noise filter mode in use.</returns>
    /// <exception cref="PcoException"></exception>
    public static NoiseFilterMode GetNoiseFilterMode(nint cameraHandle)
    {
        ushort wNoiseFilterMode = 0;
        _error = SDK.PCO_GetNoiseFilterMode(pHandle: cameraHandle, wNoiseFilterMode: ref wNoiseFilterMode);
        if (_error != 0)
            throw new PcoException(_error);
        else return (NoiseFilterMode)wNoiseFilterMode;
    }

    /// <summary>
    /// Set noise filter correction mode in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="mode">Noise filter correction mode.</param>
    /// <exception cref="PcoException"></exception>
    public static void SetNoiseFilterMode(nint cameraHandle, NoiseFilterMode mode)
    {
        _error = SDK.PCO_SetNoiseFilterMode(pHandle: cameraHandle, wNoiseFilterMode: (ushort)mode);
        if (_error != 0)
            throw new PcoException(_error);
    }

    #endregion

    #region TimingControl

    /// <summary>
    /// Get current frame rate from camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Frame rate in [Hz].</returns>
    /// <exception cref="PcoException"></exception>
    public static float GetFrameRate(nint cameraHandle)
    {
        uint dwTime_s = 0, dwTime_ns = 0;
        _error = SDK.PCO_GetCOCRuntime(pHandle: cameraHandle, dwTime_s: ref dwTime_s, dwTime_ns: ref dwTime_ns); // get currently set COC runtime
        if (_error != 0)
            throw new PcoException(_error);

        float frameTime = dwTime_s * 1000000000 + dwTime_ns; // time required to take a single image [ns]
        return 1 / frameTime * 1E9f; // current framerate [Hz]
    }

    /// <summary>
    /// Set frame rate [Hz] in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="framerate">variable representing the wanted framerate in [Hz].</param>
    /// <exception cref="PcoException"></exception>
    public static void SetFrameRate(nint cameraHandle, float framerate)
    {
        // get current delay and exposure times
        ushort wTimeBaseDelay = 0, wTimeBaseExposure = 0; // time bases (ns)
        uint currentExposure = 0, currentDelay = 0; // exposure and delay times
        _error = SDK.PCO_GetDelayExposureTime(pHandle: cameraHandle, dwDelay: ref currentDelay, dwExposure: ref currentExposure, wTimeBaseDelay: ref wTimeBaseDelay, wTimeBaseExposure: ref wTimeBaseExposure); // get currently set delay and exposure times
        if (_error != 0)
            throw new PcoException(_error);

        currentDelay *= (uint)Math.Pow(1000, wTimeBaseDelay); // ns
        currentExposure *= (uint)Math.Pow(1000, wTimeBaseExposure); // ns

        // get current frame time
        uint dwTime_s = 0, dwTime_ns = 0;
        _error = SDK.PCO_GetCOCRuntime(pHandle: cameraHandle, dwTime_s: ref dwTime_s, dwTime_ns: ref dwTime_ns); // get currently set COC runtime
        if (_error != 0)
            throw new PcoException(_error);

        // calculate new delay time
        uint currentFrameTime = dwTime_s * 1000000000 + dwTime_ns; // time required to take a single image [ns]        
        int newDelay = System.Convert.ToInt32(currentDelay + (int)Math.Round(1 / framerate * 1E9 - currentFrameTime));
        if (newDelay >= 0)
            _error = SDK.PCO_SetDelayExposureTime(pHandle: cameraHandle, dwDelay: (uint)newDelay / 1000, dwExposure: currentExposure / 1000, wTimeBaseDelay: 1, wTimeBaseExposure: 1); // set new delay time [ns]
        else
            _error = SDK.PCO_SetDelayExposureTime(pHandle: cameraHandle, dwDelay: 0, dwExposure: (uint)(currentExposure / 1000 + newDelay / 1000), wTimeBaseDelay: 1, wTimeBaseExposure: 1); // reduce exposure time

        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Get exposure time in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Exposure time (in microseconds).</returns>
    /// <exception cref="PcoException"></exception>
    public static double GetExposureTime(nint cameraHandle)
    {
        uint currentExposure = 0, currentDelay = 0; // exposure and delay times
        ushort wTimeBaseDelay = 0, wTimeBaseExposure = 0; // timebases
        _error = SDK.PCO_GetDelayExposureTime(pHandle: cameraHandle, dwDelay: ref currentDelay, dwExposure: ref currentExposure, wTimeBaseDelay: ref wTimeBaseDelay, wTimeBaseExposure: ref wTimeBaseExposure); // get currently set delay and exposure times
        if (_error != 0)
            throw new PcoException(_error);

        currentExposure *= (uint)Math.Pow(1000, wTimeBaseExposure); // ns

        return currentExposure / 1000;
    }

    /// <summary>
    /// Get limits available for exposure time in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="minExposure">Minimum exposure time (in microseconds).</param>
    /// <param name="maxExposure">Maximum exposure time (in microseconds).</param>
    /// <param name="stepExposure">Exposure time increment (in microseconds).</param>
    /// <exception cref="PcoException"></exception>
    public static void GetExposureTimeLimits(nint cameraHandle, out uint minExposure, out uint maxExposure, out double stepExposure)
    {
        _error = SDK.PCO_GetCameraDescription(pHandle: cameraHandle, strDescription: ref _cameraDescription);
        if (_error != 0)
            throw new PcoException(_error);
        else
        {
            minExposure = _cameraDescription.dwMinExposureDESC / 1000; // ns => µs
            maxExposure = _cameraDescription.dwMaxExposureDESC * 1000; // ms => µs
            stepExposure = System.Convert.ToDouble(System.Convert.ToDecimal(_cameraDescription.dwMinExposStepDESC) / 1000); // ns => µs
        }
    }

    /// <summary>
    /// Set exposure time in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="exposureTime">Exposure time (in microseconds).</param>
    /// <exception cref="PcoException"></exception>
    public static void SetExposureTime(nint cameraHandle, double exposureTime)
    {
        // Retrieve current framerate.
        float framerate = GetFrameRate(cameraHandle);

        // Set delay and exposure time.
        int _error = SDK.PCO_SetDelayExposureTime(pHandle: cameraHandle, dwDelay: 0, dwExposure: (uint)exposureTime, wTimeBaseDelay: 1, wTimeBaseExposure: 1); // try to set requested exposure time (minimize delay)
        if (_error != 0)
            throw new PcoException(_error);

        // Retain frame rate used (will adjust delay time).
        SetFrameRate(cameraHandle, framerate);
    }

    /// <summary>
    /// Get trigger mode currently used in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Trigger mode.</returns>
    /// <exception cref="PcoException"></exception>
    public static TriggerMode GetTriggerMode(nint cameraHandle)
    {
        ushort wTriggerMode = 0;
        _error = SDK.PCO_GetTriggerMode(pHandle: cameraHandle, wTriggerMode: ref wTriggerMode);
        if (_error != 0)
            throw new PcoException(_error);
        else return (TriggerMode)wTriggerMode;
    }

    /// <summary>
    /// Sets trigger mode in camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="triggerMode">Trigger mode.</param>
    /// <exception cref="PcoException"></exception>
    public static void SetTriggerMode(nint cameraHandle, TriggerMode triggerMode)
    {
        _error = SDK.PCO_SetTriggerMode(pHandle: cameraHandle, wTriggerMode: (ushort)triggerMode);
        if (_error != 0)
            throw new PcoException(_error);
    }

    #endregion

    #region RecordingControl

    /// <summary>
    /// Get current recording state of camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>True if recording is active.</returns>
    /// <exception cref="PcoException"></exception>
    public static bool GetRecordingState(nint cameraHandle)
    {
        ushort recordingState = 0;
        _error = SDK.PCO_GetRecordingState(pHandle: cameraHandle, wRecState: ref recordingState);
        if (_error != 0)
            throw new PcoException(_error);
        else return recordingState == 1;
    }

    /// <summary>
    /// Set recording state of camera.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="state">True to start recording, false to stop.</param>
    /// <exception cref="PcoException"></exception>
    public static void SetRecordingState(nint cameraHandle, bool state)
    {
        _error = state ? SDK.PCO_SetRecordingState(pHandle: cameraHandle, wRecState: 1) : SDK.PCO_SetRecordingState(pHandle: cameraHandle, wRecState: 0);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Set date and time of internal camera clock.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="dateTime">Date and time to be set.</param>
    /// <exception cref="PcoException"></exception>
    public static void SetDateTime(nint cameraHandle, DateTime dateTime)
    {
        _error = SDK.PCO_SetDateTime(pHandle: cameraHandle, ucDay: (byte)dateTime.Day, ucMonth: (byte)dateTime.Month, wYear: (ushort)dateTime.Year, wHour: (ushort)dateTime.Hour, ucMin: (byte)dateTime.Minute, ucSec: (byte)dateTime.Second);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Set timestamp mode of camera, determining how timestamps are written to raw image data.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="mode">Timestamp mode.</param>
    /// <exception cref="PcoException"></exception>
    public static void SetTimestampMode(nint cameraHandle, TimestampMode mode)
    {
        _error = SDK.PCO_SetTimestampMode(pHandle: cameraHandle, wTimeStampMode: (ushort)mode);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Get current timestamp mode of camera, determining how timestamps are written to raw image data.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <returns>Current timestamp mode implemented.</returns>
    /// <exception cref="PcoException"></exception>
    public static TimestampMode GetTimestampMode(nint cameraHandle) 
    {
        ushort wTimeStampMode = 0;
        _error = SDK.PCO_GetTimestampMode(pHandle: cameraHandle, wTimeStampMode: ref wTimeStampMode);
        if (_error != 0)
            throw new PcoException(_error);
        else return (TimestampMode)wTimeStampMode;
    }

    #endregion

    #region ImageInformation

    #endregion

    #region BufferManagement

    // ToDo: Simplify buffer management methods?

    /// <summary>
    /// Allocate memory for buffer.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="sBufNr">Buffer index.</param>
    /// <param name="size">Buffer size (in bytes).</param>
    /// <param name="wBuf">Buffer handle.</param>
    /// <param name="hEvent">Buffer event handle.</param>
    /// <exception cref="PcoException"></exception>
    public static void AllocateBuffer(nint cameraHandle, ref short sBufNr, int size, ref nuint wBuf, ref nint hEvent)
    {
        _error = SDK.PCO_AllocateBuffer(pHandle: cameraHandle, sBufNr: ref sBufNr, size: size, wBuf: ref wBuf, hEvent: ref hEvent);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Free memory allocation of buffer.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="sBufNr">Buffer index.</param>
    /// <exception cref="PcoException"></exception>
    public static void FreeBuffer(nint cameraHandle, short sBufNr)
    {
        _error = SDK.PCO_FreeBuffer(pHandle: cameraHandle, sBufNr: sBufNr);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Retrieve status of buffer.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <param name="sBufNr">Buffer index.</param>
    /// <param name="dwStatusDll">SDK status.</param>
    /// <param name="dwStatusDrv">Image transfer status.</param>
    /// <exception cref="PcoException"></exception>
    public static void GetBufferStatus(nint cameraHandle, short sBufNr, ref uint dwStatusDll, ref uint dwStatusDrv)
    {
        _error = SDK.PCO_GetBufferStatus(pHandle: cameraHandle, sBufNr: sBufNr, dwStatusDll: ref dwStatusDll, dwStatusDrv: ref dwStatusDrv);
        if (_error != 0)
            throw new PcoException(_error);
    }

    #endregion

    #region ImageAcquisition

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cameraHandle"></param>
    /// <param name="dwFirstImage"></param>
    /// <param name="dwLastImage"></param>
    /// <param name="sBufNr"></param>
    /// <param name="wXRes"></param>
    /// <param name="wYRes"></param>
    /// <param name="wBitPerPixel"></param>
    /// <exception cref="PcoException"></exception>
    public static void AddBufferEx(nint cameraHandle, uint dwFirstImage, uint dwLastImage, short sBufNr, ushort wXRes, ushort wYRes, ushort wBitPerPixel)
    {
        _error = SDK.PCO_AddBufferEx(pHandle: cameraHandle, dwFirstImage: dwFirstImage, dwLastImage: dwLastImage, sBufNr: sBufNr, wXRes: wXRes, wYRes: wYRes, wBitPerPixel: wBitPerPixel);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// Removes all remaining buffers from internal queue and resets the transfer state.
    /// </summary>
    /// <param name="cameraHandle">Handle to a previously opened camera device.</param>
    /// <exception cref="PcoException"></exception>
    public static void CancelImages(nint cameraHandle)
    {
        _error = SDK.PCO_CancelImages(pHandle: cameraHandle);
        if (_error != 0)
            throw new PcoException(_error);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cameraHandle"></param>
    /// <param name="nr_of_buffer"></param>
    /// <param name="bufferList"></param>
    /// <param name="timeout"></param>
    /// <exception cref="PcoException"></exception>
    public static void WaitForBuffer(nint cameraHandle, int nr_of_buffer, ref PCO_Buflist bufferList, int timeout)
    {
        _error = SDK.PCO_WaitforBuffer(pHandle: cameraHandle, nr_of_buffer: nr_of_buffer, bufferList: ref bufferList, timeout: timeout);
        if (_error != 0)
            throw new PcoException(_error);
    }

    #endregion
}