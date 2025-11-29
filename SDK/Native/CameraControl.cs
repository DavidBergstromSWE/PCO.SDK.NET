using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains methods for controlling general camera settings.

    /// <summary>
    /// This function arms the camera, which means prepare the camera for a following recording. All configurations and settings made up to this moment are accepted, 
    /// validated and the internal settings of the camera are prepared. If the arm was successful the camera state is changed to [armed] and the camera is able to start image recording immediately, when Recording State is set to [run].
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_ArmCamera")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_ArmCamera(nint pHandle);

    /// <summary>
    /// This function sets the image parameters for internal allocated resources.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wxRes">Current horizontal resolution of the image to be transferred.</param>
    /// <param name="wyRes">Current vertical resolution of the image to be transferred.</param>
    /// <param name="dwFlags">Soft ROI action bit field , see table Image Parameter Bits Only valid, if PCO_EnableSoftROI is enabled.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetImageParameters")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetImageParameters(nint pHandle, ushort wxRes, ushort wyRes, uint dwFlags); // reserved removed: ref Action param, int ilen

    /// <summary>
    /// This function can be used to reset all camera settings to its default values. This function is also executed during a power-up sequence. 
    /// The camera must be stopped before calling this command. Default settings are slightly different for all cameras.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_ResetSettingsToDefault")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_ResetSettingsToDefault(nint pHandle);

    /// <summary>
    /// This function sets the internal timeout values for different tasks.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="buf_in">Pointer to an array of unsigned int values: buf_in[0] = command timeout in ms, buf_in[1] = image timeout in ms, buf_in[2] = transfer timeout in ms.</param>
    /// <param name="size_in">Number of valid values in the array in bytes.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetTimeouts")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetTimeouts(nint pHandle, [In] uint[] buf_in, ushort size_in);

    /// <summary>
    /// This function will reboot the camera. The function will return immediately and the reboot process in the camera is started.
    /// After calling this command the handle to this camera should be closed with PCO_CloseCamera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_RebootCamera")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_RebootCamera(nint pHandle);

    /// <summary>
    /// This function issues a low level command to the camera. This call is part of most of the other calls. Normally calling this function is not needed.
    /// It can be used to cover those camera commands, which are not implemented in regular SDK functions.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="buf_in">Pointer to a buffer which does hold the camera command telegram.</param>
    /// <param name="size_in">Size of the input buffer in bytes.</param>
    /// <param name="buf_out">Pointer to a buffer which does hold the camera response telegram.</param>
    /// <param name="size_out">Size of the output buffer in bytes.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_ControlCommandCall")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_ControlCommandCall(nint pHandle, nuint buf_in, uint size_in, ref nuint buf_out, uint size_out);
}