using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComImport]
[Guid("2C941FD6-975B-59BE-A960-9A2A262853A5")]
[CoClass(typeof(EnumProgressItemsClass))]
public interface EnumProgressItems : IEnumProgressItems
{
}