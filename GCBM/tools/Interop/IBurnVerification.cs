using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

/// <summary>
///     An interface to control burn verification for a burning object
/// </summary>
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("D2FFD834-958B-426D-8470-2A13879C6A91")]
public interface IBurnVerification
{
    // The requested level of burn verification
    [DispId(0x400)] IMAPI_BURN_VERIFICATION_LEVEL BurnVerificationLevel { set; get; }
}