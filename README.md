.NET library wrapper for the PCO SDK from Excelitas-PCO.

Classes contained:
LibWrapper			- static class which wraps the main C++ SDK (v1.34).
GetLastError		- debug class for converting numerical error codes from the SDK to readable strings.
LUTConversion		- class which contains ConvertSDK with different LUT conversion routines for PCO cameras.
BCDConverter		- utility class for converting between binary decimal and decimal coded values.
TimestampConverter	- utility class for extracting image counters and timestamps from images using BCD encoding.
