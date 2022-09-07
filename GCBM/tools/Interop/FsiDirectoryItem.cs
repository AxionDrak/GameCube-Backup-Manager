using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComImport]
[Guid("F7FB4B9B-6D96-4D7B-9115-201B144811EF")]
[CoClass(typeof(FsiDirectoryItemClass))]
public interface FsiDirectoryItem : IFsiDirectoryItem2
{
}