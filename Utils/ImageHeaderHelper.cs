using System;

namespace PCO.SDK.NET.Utils;

/// <summary>
/// Helper class for extracting data from image headers (first 14 pixels of image data).
/// </summary>
public static class ImageHeaderHelper
{
    /// <summary>
    /// Extracts timestamp from image header.
    /// </summary>
    /// <param name="pixels">Pixels containing image header.</param>
    /// <returns>Timestamp in PC ticks (1 tick is 100 ns).</returns>
    public static ulong GetTimestamp(ReadOnlySpan<short> pixels)
    {
        // template:
        //LSB: (byteNumber & 0x0F)
        //MSB: ((byteNumber & 0xF0) >> 4)

        int year = ((pixels[4] & 0xF0) >> 4) * 1000 + (pixels[4] & 0x0F) * 100 + ((pixels[5] & 0xF0) >> 4) * 10 + (pixels[5] & 0x0F) * 1; // Year
        int month = ((pixels[6] & 0xF0) >> 4) * 10 + (pixels[6] & 0x0F) * 1; // Month
        int day = ((pixels[7] & 0xF0) >> 4) * 10 + (pixels[7] & 0x0F) * 1; // Day
        int hour = ((pixels[8] & 0xF0) >> 4) * 10 + (pixels[8] & 0x0F) * 1; // Hour
        int minute = ((pixels[9] & 0xF0) >> 4) * 10 + (pixels[9] & 0x0F) * 1; // Minute
        int second = ((pixels[10] & 0xF0) >> 4) * 10 + (pixels[10] & 0x0F) * 1; // Second
        int microSecond = ((pixels[11] & 0xF0) >> 4) * 100000 + (pixels[11] & 0x0F) * 10000 + ((pixels[12] & 0xF0) >> 4) * 1000 + (pixels[12] & 0x0F) * 100 + ((pixels[13] & 0xF0) >> 4) * 10 + (pixels[13] & 0x0F) * 1; // Microsecond

        DateTime dateTime = new(year: year, month: month, day: day, hour: hour, minute: minute, second: second, millisecond: microSecond / 1000, microsecond: microSecond % 1000);

        return (ulong)dateTime.Ticks;

    }

    /// <summary>
    /// Extracts image number from image header.
    /// </summary>
    /// <param name="pixels">Pixels containing image header.</param>
    /// <returns>Image number.</returns>
    public static int GetImageNumber(ReadOnlySpan<short> pixels)
    {
        // Image counter (use BCD class?)
        return ((pixels[0] & 0xF0) >> 4) * 10000000 + (pixels[0] & 0x0F) * 1000000 + ((pixels[1] & 0xF0) >> 4) * 100000 + (pixels[1] & 0x0F) * 10000 + +((pixels[2] & 0xF0) >> 4) * 1000 + (pixels[2] & 0x0F) * 100 + ((pixels[3] & 0xF0) >> 4) * 10 + (pixels[3] & 0x0F) * 1;
    }
}