using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains static methods to access connected cameras.

    /// <summary>
    /// This function is used to get a connection to a camera. A unique handle is returned, which must be used for all other function calls. 
    /// This function scans through all available interfaces and tries to connect to the next available camera. 
    /// If more than one camera is connected to the computer this function must be called a second time to get the handle for the next camera.
    /// </summary>
    /// <param name="pHandle">Pointer to a handle (set to nint.Zero to open next available camera). On output a unique handle is returned, if a valid connection was established.</param>
    /// <param name="wCamNum">Not used.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_OpenCamera")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_OpenCamera(ref nint pHandle, ushort wCamNum);

    /// <summary>
    /// This function is used to get a connection to a distinct camera, e.g. a camera which is connected to a specific interface port. 
    /// A unique handle is returned, which must be used for all other function calls.
    /// </summary>
    /// <param name="pHandle">Pointer to a handle (set to nint.Zero to open next available camera). On output a unique handle is returned, if a valid connection was established.</param>
    /// <param name="strOpen">Pointer to a previously filled PCO_Openstruct structure.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_OpenCameraEx", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_OpenCameraEx(ref nint pHandle, PCO_OpenStruct strOpen);

    /// <summary>
    /// This function is used to close the connection to a previously opened camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_CloseCamera")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_CloseCamera(nint pHandle);

    /// <summary>
    /// This function is used to set the SC2_cam Library to an initial state. All camera handles have to be closed with PCO_CloseCamera before this function is called.
    /// </summary>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_ResetLib")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_ResetLib();

    /// <summary>
    /// This function is used to check, if the connection to a previously opened camera is still valid.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="wNumif">Number of camera which should be checked for availability at a distinct interface.</param>
    /// <returns>0 in case of success, else less than 0.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_CheckDeviceAvailability")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_CheckDeviceAvailability(nint pHandle, ushort wNumif);
}