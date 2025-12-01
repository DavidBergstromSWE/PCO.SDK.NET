.NET library wrapper for the PCO SDK (v1.34) from Excelitas-PCO, with unmanaged (C++) code invoked using P/Invoke.

 Entrypoint is the static class LibWrapper, found in the [src](src) folder, which contains methods for camera access, status, control, buffer handling, image acquisition and recording etc. All native (P/invoked) code is contained in the internal static SDK class, found under the [SDK](SDK/Native) folder.
