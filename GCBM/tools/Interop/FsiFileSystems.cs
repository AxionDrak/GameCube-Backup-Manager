using System;

namespace GCBM.tools.Interop;

[Flags]
public enum FsiFileSystems
{
    FsiFileSystemNone = 0,
    FsiFileSystemISO9660 = 1,
    FsiFileSystemJoliet = 2,
    FsiFileSystemUDF = 4,
    FsiFileSystemUnknown = 0x40000000
}