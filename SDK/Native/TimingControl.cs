using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains methods regarding the image timing of the camera like trigger mode, exposure time and frame rate.

    /// <summary>
    /// Timing related information is queried from the camera and the variables of the PCO_Timing structure are filled with this information. 
    /// This function is a combined version of the functions which request information about the current settings of timing related parameter.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strTiming">Pointer to a PCO_Timing structure structure: On input the wSize parameter of this structure and also of all nested structures must be filled with the correct structure size in bytes.
    /// On output the structure is filled with the requested information from the camera to get the timing settings</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetTimingStruct", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetTimingStruct(nint pHandle, ref PCO_Timing strTiming);

    /// <summary>
    /// This function sets the complete set of the timing settings.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strTiming">Pointer to a PCO_Timing structure filled with appropriate parameters. 
    /// The wSize parameter of this structure and also of all nested structures must be filled with the correct structure size in bytes</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_SetTimingStruct", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_SetTimingStruct(nint pHandle, ref PCO_Timing strTiming);

    /// <summary>
    /// This function can be used to calculate the current frame rate of the camera. The returned values describe exactly how much time is required to take a single image.
    /// The resulting time is calculated inside the camera and depends on the settings of the timing and sensor parameters.
    /// To cover the full range of possible times it is splitted in two parts. 
    /// Parameter dwTime_s gives the number of seconds and dwTime_ns gives the number of nano seconds in the range from 0 to 999999999 ns.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="dwTime_s">Pointer to a uint variable to get the COC runtime part in seconds.</param>
    /// <param name="dwTime_ns">Pointer to a uint variable to get the COC runtime part in nanoseconds.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetCOCRuntime")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetCOCRuntime(nint pHandle, ref uint dwTime_s, ref uint dwTime_ns);

    /// <summary>
    /// This function returns the current setting of the delay and exposure time values and the associated time base values.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="dwDelay">Pointer to a uint variable to get the delay time.</param>
    /// <param name="dwExposure">Pointer to a uint variable to get the exposure time.</param>
    /// <param name="wTimeBaseDelay">Pointer to a ushort variable to get the time base of the delay time: 0 = [ns], 1 = [μs], 2 = [ms].</param>
    /// <param name="wTimeBaseExposure">Pointer to a ushort variable to get the time base of the exposure time: 0 = [ns], 1 = [μs], 2 = [ms].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetDelayExposureTime")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetDelayExposureTime(nint pHandle, ref uint dwDelay, ref uint dwExposure, ref ushort wTimeBaseDelay, ref ushort wTimeBaseExposure);

    /// <summary>
    /// This function sets the delay and exposure time and the associated time base values.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="dwDelay">uint variable to set the delay time.</param>
    /// <param name="dwExposure">uint variable to set the exposure time.</param>
    /// <param name="wTimeBaseDelay">ushort variable to set the time base of the delay time: 0 = [ns], 1 = [μs], 2 = [ms].</param>
    /// <param name="wTimeBaseExposure">ushort variable to set the time base of the exposure time: 0 = [ns], 1 = [μs], 2 = [ms].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetDelayExposureTime")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetDelayExposureTime(nint pHandle, uint dwDelay, uint dwExposure, ushort wTimeBaseDelay, ushort wTimeBaseExposure);

    /// <summary>
    /// This function returns the current trigger mode setting of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wTriggerMode">ushort variable to set the trigger mode.</param>
    /// <returns></returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetTriggerMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetTriggerMode(nint pHandle, ref ushort wTriggerMode);

    /// <summary>
    /// This function sets the trigger mode of the camera. For a short description of the available trigger modes, see table Explanation of available trigger modes.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wTriggerMode">ushort variable to set the trigger mode.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetTriggerMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetTriggerMode(nint pHandle, ushort wTriggerMode);
}