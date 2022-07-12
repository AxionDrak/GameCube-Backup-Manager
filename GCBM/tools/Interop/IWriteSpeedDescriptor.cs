using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     A single optical drive Write Speed Configuration
    /// </summary>
    [ComImport]
    [Guid("27354144-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FDual)]
    public interface IWriteSpeedDescriptor
    {
        // The type of media that this descriptor is valid for
        [DispId(0x101)] IMAPI_MEDIA_PHYSICAL_TYPE MediaType { get; }

        // Whether or not this descriptor represents a writing configuration that uses 
        // Pure CAV rotation control
        [DispId(0x102)] bool RotationTypeIsPureCAV { get; }

        // The maximum speed at which the media will be written in the write configuration 
        // represented by this descriptor
        [DispId(0x103)] int WriteSpeed { get; }
    }
}