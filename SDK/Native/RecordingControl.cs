using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains methods to control the recording state.

    /// <summary>
    /// Recording control information is queried from the camera and the variables of the PCO_Recording structure are filled with this information.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strRecording">Pointer to a PCO_Recording structure. On input the wSize parameter of this structure and also of all nested structures must be filled with the correct structure size in bytes. On output the structure is filled with the requested information from the camera.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetRecordingStruct", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetRecordingStruct(nint pHandle, ref PCO_Recording strRecording);

    /// <summary>
    /// This function sets the complete set of recording settings at once.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strRecording">Pointer to a PCO_Recording structure filled with appropriate parameters.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_SetRecordingStruct", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_SetRecordingStruct(nint pHandle, ref PCO_Recording strRecording);

    /// <summary>
    /// This function returns the current Recording State of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wRecState">ushort variable to set the current recording state: 0 = camera is stopped, recording state[stop], 1 = camera is running, recording state[run].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetRecordingState")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetRecordingState(nint pHandle, ref ushort wRecState);

    /// <summary>
    /// This function sets the Recording State and waits until the state is valid. If the requested state is already set the function will return a warning. 
    /// If the state cannot be set within one second (+ current frametime for [stop]), the function will return an error.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wRecState">Pointer to a ushort variable to set the active recording state: 0 = stop camera and wait until recording state = [stop], 1 = start camera and wait until recording state = [run].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetRecordingState")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetRecordingState(nint pHandle, ushort wRecState);

    /// <summary>
    /// This function sets date and time information for the internal camera clock, which is used for the timestamp function. 
    /// When powering up the camera the camera clock is reset and all date and time information is set to zero. 
    /// If timestamp data should be synchronized with the PC time, this function must be called at least once.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="ucDay">byte variable to set the day of month (1 - 31).</param>
    /// <param name="ucMonth">byte variable to set the month (1 - 12).</param>
    /// <param name="wYear">ushort variable to set the year (4 digits e.g. 2017).</param>
    /// <param name="wHour">ushort variable to set the hour (0 - 24).</param>
    /// <param name="ucMin">byte variable to set the minute (0 - 60).</param>
    /// <param name="ucSec">byte variable to set the second (0 - 60).</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetDateTime")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetDateTime(nint pHandle, byte ucDay, byte ucMonth, ushort wYear, ushort wHour, byte ucMin, byte ucSec);

    /// <summary>
    /// This function returns the current timestamp mode.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wTimeStampMode">ushort variable to set the timestamp mode: 0 = [off], 1 = [binary] BCD coded timestamp in the first 14 pixel, 2 = [binary+ASCII] BCD coded timestamp in the first 14 pixel + ASCII text, 3 = [ASCII] ASCII text only(see camera descriptor for availability).</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetTimestampMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetTimestampMode(nint pHandle, ref ushort wTimeStampMode);

    /// <summary>
    /// This function sets the timestamp mode of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wTimeStampMode">ushort variable to set the timestamp mode: 0 = [off], 1 = [binary] BCD coded timestamp in the first 14 pixel, 2 = [binary+ASCII] BCD coded timestamp in the first 14 pixel + ASCII text, 3 = [ASCII] ASCII text only(see camera descriptor for availability).</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetTimestampMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetTimestampMode(nint pHandle, ushort wTimeStampMode);

    /// <summary>
    /// Queries current acquisition mode of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wAcquMode">Variable indicating current acquire mode: 0 = [auto], 1 = [external], 2 = [external modulate].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetAcquireMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetAcquireMode(nint pHandle, ref ushort wAcquMode);

    /// <summary>
    /// Sets current acquisition mode of the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wAcquMode">Variable indicating current acquire mode: 0 = [auto], 1 = [external], 2 = [external modulate].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetAcquireMode")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetAcquireMode(nint pHandle, ushort wAcquMode);
}