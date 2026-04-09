.NET library wrapper for the PCO SDK from Excelitas-PCO, with unmanaged (C++) code invoked using P/Invoke. The current version supports version 1.35 of the SDK. 

 Entrypoint is the static class LibWrapper, found in the [src](src) folder, which contains methods for camera access, status, control, buffer handling, image acquisition and recording etc. All native (P/invoked) code is contained in the internal static SDK class, found under the [SDK](src/SDK/Native) folder.
