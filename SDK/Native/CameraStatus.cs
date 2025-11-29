using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    // Contains methods to get access to information about which camera is connected and if the camera is operating in good condition. Additionally there exist functions to set the camera to a default operating state.

    /// <summary>
    /// General information is queried from the camera and the variables of the PCO_General structure are filled with this information. 
    /// This function is a combined version of the following functions, which request information about camera type, hardware/firmware version, serial number, current temperatures and camera status.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strGeneral">Pointer to a PCO_General structure: On input the wSize parameter of this structure and also of all nested structures must be filled with the correct structure size in bytes. On output the structure is filled with the requested information from the camera</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetGeneral", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetGeneral(nint pHandle, ref PCO_General strGeneral);

    /// <summary>
    /// This function retrieves the following parameters of the camera: camera type code, hardware/firmware version, serial number and interface type.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strCameraType">Pointer to a PCO_CameraType structure: On input the wSize parameter of this structure must be filled with the correct structure size in bytes. On output the structure is filled with the requested information from the camera</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetCameraType", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetCameraType(nint pHandle, ref PCO_CameraType strCameraType);

    /// <summary>
    /// The PCO_GetCameraHealthStatus function retrieves information about the current camera status. The returned parameters are presented as a bit field, where each bit is describing a distinct camera condition.
    /// Cleared bits in the bitfield indicate that the particular condition is not valid, set bits show valid (error, warning, status) conditions.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="dwWarn">Pointer to a uint variable to get warning bit field (see Warning Bits).</param>
    /// <param name="dwError">Pointer to a uint variable to get error bit field (see Error Bits).</param>
    /// <param name="dwStatus">Pointer to a uint variable to get the status bit field (see Status Bits).</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetCameraHealthStatus")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetCameraHealthStatus(nint pHandle, ref uint dwWarn, ref uint dwError, ref uint dwStatus);

    /// <summary>
    /// This function retrieves the current temperatures in °C of the imaging sensor, camera and additional devices e.g. power supply.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="sCCDTemp">Pointer to a short variable to get the image sensor temperature in tenth of a degree. e.g. 100 = 10.0 °C.</param>
    /// <param name="sCamTemp">Pointer to a short variable to get the internal temperature of the camera in °C.</param>
    /// <param name="sPowTemp">Pointer to a short variable to get the temperature of additional devices (e.g. power supply) in °C.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetTemperature")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetTemperature(nint pHandle, ref short sCCDTemp, ref short sCamTemp, ref short sPowTemp);

    /// <summary>
    /// This function retrieves the name of the camera. A zero terminated ASCII string will be returned in the provided array. This array must be large enough to hold the complete string and the termination value.
    /// If not, an error will be returned. At most 40 bytes will be returned from the camera.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="szCameraName">Pointer to a character array (40 byte) as ASCII string.</param>
    /// <param name="wSZCameraNameLen">Size of the array szCameraName, which has passed in.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [LibraryImport("sc2_cam.dll", EntryPoint = "PCO_GetCameraName")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_GetCameraName(nint pHandle, [Out] byte[] szCameraName, ushort wSZCameraNameLen);
}