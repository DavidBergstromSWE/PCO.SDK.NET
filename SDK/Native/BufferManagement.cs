using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

/// <summary>
/// Contains all native code from the PCO.SDK (C++) library, imported using P/Invokes.
/// </summary>
internal static partial class SDK
{
    // Contains methods to allocate buffers for image transfers from camera and to request the status of the transfer.

    /// <summary>
    /// This function sets up a buffer context to receive the transferred images. A buffer index is returned, which must be used for the image transfer functions. 
    /// There is a maximum of 16 buffers per camera. The buffers are attached to the camera handle.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="sBufNr">Pointer to a short variable: On input: -1 (create a new buffer) or 0 … 15 (buffer index from previous call). On output: the buffer index.</param>
    /// <param name="size">Buffer size in bytes.</param>
    /// <param name="wBuf">Pointer to a pointer (nuint) of a memory region: On input: Zero (allocate memory internal) or pointer (to a valid memory block). On output: Pointer (to the allocated memory block).</param>
    /// <param name="hEvent">Pointer to a handle variable: On input: Zero: create event internal or handle of event. On output: handle of the (created) event.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_AllocateBuffer")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_AllocateBuffer(nint pHandle, ref short sBufNr, int size, ref nuint wBuf, ref nint hEvent);

    /// <summary>
    /// This function frees a previously allocated buffer context with the given index. If internal memory was allocated for this buffer context it will be freed. 
    /// If an internal event handle was created, it will be closed.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="sBufNr">Buffer index.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_FreeBuffer")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_FreeBuffer(nint pHandle, short sBufNr);

    /// <summary>
    /// This function queries the status of the buffer context with the given index.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="sBufNr">Buffer index.</param>
    /// <param name="dwStatusDll">Pointer to a uint variable to get the status inside the SDK DLL: 0x80000000 = Buffer is allocated, 0x40000000 = Buffer event created inside the SDK DLL, 0x20000000 = Buffer is allocated externally, 0x00008000 = Buffer event is set.</param>
    /// <param name="dwStatusDrv">Pointer to a uint variable to get the status for the image transfer: PCO_NOERROR = Image transfer succeeded, others = See error codes.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetBufferStatus")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetBufferStatus(nint pHandle, short sBufNr, ref uint dwStatusDll, ref uint dwStatusDrv);

    /// <summary>
    /// This function is used to query the objects of the buffer context with the given index. The pointer to the allocated or attached memory region and the assigned event handle are returned.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="sBufNr">Buffer index.</param>
    /// <param name="wBuf">Pointer to a pointer (nuint) of a memory region.</param>
    /// <param name="hEvent">Pointer to a handle variable.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetBuffer")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetBuffer(nint pHandle, short sBufNr, ref nuint wBuf, ref nint hEvent);
}