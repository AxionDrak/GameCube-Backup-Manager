using System.Collections;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

/// <summary>
///     FileSystemImageResult progress item
/// </summary>
[Guid("2C941FD7-975B-59BE-A960-9A2A262853A5")]
[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
public interface IProgressItems
{
    // Find the block mapping from the specified index
    [DispId(0)] IProgressItem this[int Index] { get; }

    // Number of items in the collection
    [DispId(1)] int Count { get; }

    // Get a non-variant enumerator
    [DispId(4)] IEnumProgressItems EnumProgressItems { get; }

    // Get an enumerator for the collection
    [DispId(-4)]
    [TypeLibFunc(0x41)]
    IEnumerator GetEnumerator();

    // Find the block mapping from the specified block
    [DispId(2)]
    IProgressItem ProgressItemFromBlock(uint block);

    // Find the block mapping from the specified item description
    [DispId(3)]
    IProgressItem ProgressItemFromDescription(string Description);
}