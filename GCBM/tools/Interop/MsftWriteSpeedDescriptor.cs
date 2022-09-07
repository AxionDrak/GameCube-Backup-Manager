using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComImport]
[CoClass(typeof(MsftWriteSpeedDescriptorClass))]
[Guid("27354144-7F64-5B0F-8F00-5D77AFBE261E")]
public interface MsftWriteSpeedDescriptor : IWriteSpeedDescriptor
{
}