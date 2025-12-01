.NET library wrapper for the PCO SDK (v1.34) from Excelitas-PCO, with unmanaged (C++) code invoked using P/Invoke.

 Entrypoint is the static LibWrapper class, which contains methods for camera access, status, control, acquisition and recording as well as buffer handling. All native (P/invoked) code is contained in the internal static SDK class, found under the [SDK](SDK/Native) folder.
