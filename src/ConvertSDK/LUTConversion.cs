using System;
using System.Runtime.InteropServices;

namespace PCO.SDK.NET.Convert;

internal static partial class LUTConversion
{
    #region Class Members

    public const int BAYER_UPPER_LEFT_IS_RED = 0x000000000;
    public const int BAYER_UPPER_LEFT_IS_GREEN_RED = 0x000000001;
    public const int BAYER_UPPER_LEFT_IS_GREEN_BLUE = 0x000000002;
    public const int BAYER_UPPER_LEFT_IS_BLUE = 0x000000003;

    public const int PCO_BW_CONVERT = 0;
    public const int PCO_COLOR_CONVERT = 2;
    public const int PCO_PSEUDO_CONVERT = 3;
    public const int PCO_COLOR16_CONVERT = 4;

    #endregion

    /**************************************************************************************************************************
      * PCO Convert Object API Calls
      * ***********************************************************************************************************************/
    #region PCO Convert Object API Calls

    /// <summary>
    /// Creates a new convert object based on the PCO_SensorInfor structure. Convert structure handle will be used during conversion.
    /// Call PCO_ConvertDelete to unload convert dll.
    /// </summary>
    /// <param name="pHandle">nint handle to store the address of the created convert object.</param>
    /// <param name="pSensorInfo">Pass by Ref SensorInfo structure.</param>
    /// <param name="iConvertType">Int variable to determine the conversion type.</param>
    /// <returns>Int error code value.</returns>
    [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertCreate", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_ConvertCreate(ref nint pHandle, ref PCO_SensorInfo pSensorInfo, int iConvertType);

    /// <summary>
    /// Deletes a previously created convert object. Mandatory to call this before closing application.
    /// </summary>
    /// <param name="pHandle">nint handle to store the address of the created convert object.</param>
    /// <returns>Int error code value.</returns>
    [LibraryImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertDelete")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_ConvertDelete(nint pHandle);

    /// <summary>
    /// Gets all the values of a previously created convert object.
    /// </summary>
    /// <param name="pHandle">nint handle to store the address of the created convert object.</param>
    /// <param name="pConvert">Pass by Ref Convert structure.</param>
    /// <returns>Int error code value.</returns>
    [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertGet", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_ConvertGet(nint pHandle, ref PCO_Convert pConvert);

    #endregion

    /// <summary>
    /// Gets the display structure values of a previously created convert object. Use this functions to change the conversion parameters.
    /// </summary>
    /// <param name="pHandle">nint handle to store the address of the created convert object.</param>
    /// <param name="pDisplay"></param>
    /// <returns>Int error code value.</returns>
    [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertGetDisplay", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_ConvertGetDisplay(nint pHandle, ref PCO_Display pDisplay);

    /// <summary>
    /// Sets the display structure values of a previously created convert object. Use this functions to change the conversion parameters.
    /// </summary>
    /// <param name="pHandle">nint handle to store the address of the created convert object.</param>
    /// <param name="pDisplay">Pointer to a pco display structure.</param>
    /// <returns>Int error code value.</returns>
    [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertSetDisplay", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_ConvertSetDisplay(nint pHandle, ref PCO_Display pDisplay);

    /// <summary>
    /// Converts the camera raw 16 bit data to 8 bit b/w format.
    /// </summary>
    /// <param name="pHandle">Handle to a previously created convert object.</param>
    /// <param name="imode">Mode parameter.</param>
    /// <param name="icolormode">Color mode parameter.</param>
    /// <param name="width">Width of the image to convert.</param>
    /// <param name="height">Height of the image to convert.</param>
    /// <param name="rawImagePointer">Pointer to the raw image.</param>
    /// <param name="resultingImagePointer">Pointer to allocated memory to store the resulting image.</param>
    /// <returns>Int error code value.</returns>
    [LibraryImport("PCO_Conv.dll", EntryPoint = "PCO_Convert16TO8")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_Convert16TO8(nint pHandle, int imode, int icolormode, int width, int height, nuint rawImagePointer, [Out] byte[] resultingImagePointer);

    /// <summary>
    /// Converts the camera raw 16 bit data to color LookUp Table (LUT).
    /// </summary>
    /// <param name="pHandle">Handle to a previously created convert object.</param>
    /// <param name="imode">Mode parameter.</param>
    /// <param name="icolormode">Color mode parameter.</param>
    /// <param name="width">Width of the image to convert.</param>
    /// <param name="height">Height of the image to convert.</param>
    /// <param name="rawImagePointer">Pointer to the raw image.</param>
    /// <param name="resultingImagePointer">Pointer to the resulting image.</param>
    /// <returns></returns>
    [LibraryImport("PCO_Conv.dll", EntryPoint = "PCO_Convert16TOCOL")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    internal static partial int PCO_Convert16TOCOL(nint pHandle, int imode, int icolormode, int width, int height, nuint rawImagePointer, [Out] byte[] resultingImagePointer);

    /// <summary>
    /// Sets the PCO_SensorInfo structure for a previously created convert object.
    /// </summary>
    /// <param name="pHandle">Handle to a previously created convert object.</param>
    /// <param name="pSensorInfo">Pass by Ref Sensor information structure. Do not forget to set pSensorInfo.wSize.</param>
    /// <returns>Int error code value.</returns>
    [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertSetSensorInfo", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
    internal static extern int PCO_ConvertSetSensorInfo(nint pHandle, ref PCO_SensorInfo pSensorInfo);
}
