using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains methods regarding image readout from sensor.

    /// <summary>
    /// Sensor related information is queried from the camera and the variables of the PCO_Sensor structure are filled with this information. 
    /// This function is a combined version of the functions, which request information about the installed imaging sensor and 
    /// the current settings of sensor related parameter like binning, ROI, pixel clock and others.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strSensor">Pointer to a PCO_Sensor structure: On input the wSize parameter of this structure and also of all nested structures must be filled with the correct structure size in bytes. 
    /// On output the structure is filled with the requested information from the camera</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetSensorStruct", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetSensorStruct(nint pHandle, ref PCO_Sensor strSensor);

    /// <summary>
    /// This function sets the complete set of sensor settings at once.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strSensor">Pointer to a PCO_Sensor structure filled with appropriate parameters.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_SetSensorStruct", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_SetSensorStruct(nint pHandle, ref PCO_Sensor strSensor);

    /// <summary>
    /// This function returns the current armed image size of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wXResAct">Pointer to a ushort variable to get the current horizontal resolution.</param>
    /// <param name="wYResAct">Pointer to a ushort variable to get the current vertical resolution.</param>
    /// <param name="wXResMax">Pointer to a ushort variable to get the maximum horizontal resolution.</param>
    /// <param name="wYResMax">Pointer to a ushort variable to get the maximum vertical resolution.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetSizes")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })] 
    internal static partial int PCO_GetSizes(nint pHandle, ref ushort wXResAct, ref ushort wYResAct, ref ushort wXResMax, ref ushort wYResMax);

    /// <summary>
    /// This function retrieves the current sensor format.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wSensor">Pointer to a ushort variable to get the sensor format: 0 = [standard], 1 = [extended].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetSensorFormat")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetSensorFormat(nint pHandle, ref ushort wSensor);

    /// <summary>
    /// This function sets the sensor format.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wSensor">ushort variable to set the sensor format: 0 = [standard], 1 = [extended].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetSensorFormat")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetSensorFormat(nint pHandle, ushort wSensor);

    /// <summary>
    /// This function returns the current ROI (region of interest) setting in pixels.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wRoiX0">Pointer to a ushort variable to get the horizontal start coordinate of the ROI.</param>
    /// <param name="wRoiY0">Pointer to a ushort variable to get the vertical start coordinate of the ROI.</param>
    /// <param name="wRoiX1">Pointer to a ushort variable to get the horizontal end coordinate of the ROI.</param>
    /// <param name="wRoiY1">Pointer to a ushort variable to get the vertical end coordinate of the ROI.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetROI")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetROI(nint pHandle, ref ushort wRoiX0, ref ushort wRoiY0, ref ushort wRoiX1, ref ushort wRoiY1);

    /// <summary>
    /// This function sets a ROI (region of interest) area on the sensor of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wRoiX0">ushort variable to set the horizontal start coordinate of the ROI.</param>
    /// <param name="wRoiY0">ushort variable to set the vertical start coordinate of the ROI.</param>
    /// <param name="wRoiX1">ushort variable to set the horizontal end coordinate of the ROI.</param>
    /// <param name="wRoiY1">ushort variable to set the vertical end coordinate of the ROI.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetROI")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetROI(nint pHandle, ushort wRoiX0, ushort wRoiY0, ushort wRoiX1, ushort wRoiY1);

    /// <summary>
    /// This function returns the current binning setting of the camera values for horizontal and vertical direction.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wBinHorz">Pointer to a ushort variable to get the horizontal binning</param>
    /// <param name="wBinVert">Pointer to a ushort variable to get the vertical binning</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetBinning")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetBinning(nint pHandle, ref ushort wBinHorz, ref ushort wBinVert);

    /// <summary>
    /// This function sets the horizontal and vertical binning of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wBinHorz">ushort variable to set the horizontal binning</param>
    /// <param name="wBinVert">ushort variable to set the vertical binning</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetBinning")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetBinning(nint pHandle, ushort wBinHorz, ushort wBinVert);

    /// <summary>
    /// This function returns the current pixel rate of the camera in Hz. The pixel rate determines the sensor readout speed.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="dwPixelRate">Pointer to a uint variable to get the pixel rate in Hz.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetPixelRate")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetPixelRate(nint pHandle, ref uint dwPixelRate);

    /// <summary>
    /// This function sets the pixel rate for the sensor readout.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="dwPixelRate">uint variable to set the pixel rate in Hz.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetPixelRate")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetPixelRate(nint pHandle, uint dwPixelRate);

    /// <summary>
    /// This function returns the current conversion factor setting of the image sensor multiplied with the factor 100. 
    /// To get the current conversion factor in electrons / count the returned value must be divided by 100.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wConvFact">ushort variable to get the conversion factor</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetConversionFactor")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetConversionFactor(nint pHandle, ref ushort wConvFact);

    /// <summary>
    /// This function sets the conversion factor of the camera. The input value is calculated from the conversion factor in electrons / count multiplied with 100.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wConvFact">ushort variable to set the conversion factor</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetConversionFactor")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetConversionFactor(nint pHandle, ushort wConvFact);

    /// <summary>
    /// This function returns the current operating mode of the image correction in the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wNoiseFilterMode">Pointer to a ushort variable to get the noise filter mode: 0 = [off], 1 = [on], 257 = [on + hot pixel correction.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetNoiseFilterMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetNoiseFilterMode(nint pHandle, ref ushort wNoiseFilterMode);

    /// <summary>
    /// This function sets the image correction operating mode of the camera. 
    /// Image correction can either be switched to totally off, noise filter only mode or noise filter plus hot pixel correction mode.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wNoiseFilterMode">ushort variable to get the noise filter mode: 0 = [off], 1 = [on], 257 = [on + hot pixel correction.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetNoiseFilterMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetNoiseFilterMode(nint pHandle, ushort wNoiseFilterMode);
}