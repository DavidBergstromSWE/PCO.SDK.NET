using System.Runtime.InteropServices;

namespace PCO.SDK.NET;

internal static partial class SDK
{
    /// <summary>
    /// Sensor and camera specific description is queried. In the returned PCO_Description structure margins for all sensor related settings and bitfields for available options of the camera are given.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strDescription">Pointer to a PCO_Description structure: On input the wSize parameter of this structure must be filled with the correct structure size in bytes. On output the structure is filled with the requested information from the camera</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetCameraDescription", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetCameraDescription(nint pHandle, ref PCO_Description strDescription);

    /// <summary>
    /// Any of the available sensor and camera specific description can be queried. With input parameter wType the returned description structure can be selected. 
    /// PCO_DescriptionEx is a generic structure which has to be casted to/from the queried structure. The wSize parameter has to be filled with the correct value for the requested structure. 
    /// This function was introduced due to the size limitation of the standard camera descriptor and the need for describing additional features.
    /// </summary>
    /// <param name="pHandle">Handle to a previously opened camera device.</param>
    /// <param name="strDescription">Pointer to any PCO_Description structure typecasted to PCO_DescriptionEx*: On input the wSize parameter of this structure must be filled with the correct structure size in Bytes. On output the structure is filled with the requested information from the camera.</param>
    /// <param name="wType">ushort variable to select the returned descriptor: 0 = PCO_Description. 1 = PCO_Description2.</param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetCameraDescriptionEx", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetCameraDescriptionEx(nint pHandle, ref PCO_Description strDescription, ushort wType);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pHandle"></param>
    /// <param name="strDescription"></param>
    /// <param name="wType"></param>
    /// <returns>int ErrorMessage: 0 in case of success else less than 0, see ERROR / WARNING CODES.</returns>
    [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetCameraDescriptionEx", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_GetCameraDescriptionEx2(nint pHandle, ref PCO_Description2 strDescription, ushort wType);
}