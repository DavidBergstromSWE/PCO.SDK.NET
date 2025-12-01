using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains methods to get information about the layout of the images stored in the segments of the camera, bit alignment during image transfer and used image correction mode.

    /// <summary>
    /// Information about previously recorded images is queried from the camera and the variables of the PCO_Image structure are filled with this information.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strImage">Pointer to a PCO_Image structure to get the image settings.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetImageStruct", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetImageStruct(nint pHandle, ref PCO_Image strImage);

    /// <summary>
    /// Gets the bit alignment of the transferred image data.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera.</param>
    /// <param name="wBitAlignment">Pointer to a ushort variable to receive the bit alignment: 0 = [MSB], 1 = [LSB].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetBitAlignment")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetBitAlignment(nint pHandle, ref ushort wBitAlignment);

    /// <summary>
    /// Sets the bit alignment of the transferred image data.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera.</param>
    /// <param name="wBitAlignment">Pointer to a ushort variable to set the bit alignment: 0 = [MSB], 1 = [LSB].</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_SetBitAlignment")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_SetBitAlignment(nint pHandle, ushort wBitAlignment);
}