using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains methods to handle image transfers from camera.

    /// <summary>
    /// This function can be used to get a single image from the camera. The function does not return until the image is transferred to the buffer or an error occured.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wSegment">short variable to select a segment</param>
    /// <param name="dw1stImage">uint variable to select the image number: 1 to ValidImageCnt if PCO_SetRecordingState is [stop], 0 if PCO_SetRecordingState is [run].</param>
    /// <param name="dwLastImage">Must be set to same value as dw1stImage.</param>
    /// <param name="sBufNr">Buffer index.</param>
    /// <param name="wXRes">Current horizontal resolution of the image which should be transferred.</param>
    /// <param name="wYRes">Current vertical resolution of the image which should be transferred.</param>
    /// <param name="wBitPerPixel">Bit resolution of the image which should be transferred.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetImageEx")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetImageEx(nint pHandle, short wSegment, uint dw1stImage, uint dwLastImage, short sBufNr, ushort wXRes, ushort wYRes, ushort wBitPerPixel);

    /// <summary>
    /// This function can be used to setup a request for a single image transfer from the camera. The transfer request is added to the internal request queue and this function returns immediately.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="dwFirstImage">uint variable to select the image number: 1 to ValidImageCnt if recording state is [stop], 0 if recording state is [run].</param>
    /// <param name="dwLastImage">Must be set to same value as dw1stImage.</param>
    /// <param name="sBufNr">Buffer index</param>
    /// <param name="wXRes">Current horizontal resolution of the image which should be transferred.</param>
    /// <param name="wYRes">Current vertical resolution of the image which should be transferred.</param>
    /// <param name="wBitPerPixel">Bit resolution of the image which should be transferred.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_AddBufferEx")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_AddBufferEx(nint pHandle, uint dwFirstImage, uint dwLastImage, short sBufNr, ushort wXRes, ushort wYRes, ushort wBitPerPixel);

    /// <summary>
    /// This function removes all remaining buffers from the internal queue, reset the internal queue and also reset the transfer state machine in the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_CancelImages")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_CancelImages(nint pHandle);

    /// <summary>
    /// This function can be used to query the number of pending buffers in the internal queue.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="number">Pointer to an int variable to get the number of pending buffers in the internal queue.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetPendingBuffer")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetPendingBuffer(nint pHandle, ref int number);

    /// <summary>
    /// This function can be used to wait for one or more buffers, which have been set into the internal request queue of the driver. 
    /// To handle the buffers, a list of PCO_Buflist structures must be set up, each filled with the buffer number of the allocated buffer.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="nr_of_buffer">Number of entries of type structure PCO_Buflist structure, which are setup.</param>
    /// <param name="bl">Pointer to a list of structures PCO_Buflist structure, which hold buffer parameter, which should be processed.</param>
    /// <param name="timeout">Timeout in milliseconds.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_WaitforBuffer")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_WaitforBuffer(nint pHandle, int nr_of_buffer, ref PCO_Buflist bufferList, int timeout);
}