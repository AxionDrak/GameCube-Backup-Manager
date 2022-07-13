using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     ISO Image Manager: Helper object for ISO image file manipulation
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [Guid("6CA38BE5-FBBB-4800-95A1-A438865EB0D4")]
    public interface IIsoImageManager
    {
        // Path to the ISO image file
        [DispId(0x100)]
        string path
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
        }

        // Stream from the ISO image
        [DispId(0x101)]
        FsiStream Stream
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
        }

        // Set path to the ISO image file, overwrites stream
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetPath(string Val);

        // Set stream from the ISO image, overwrites path
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetStream([In] [MarshalAs(UnmanagedType.Interface)] FsiStream Data);

        // Validate if the ISO image file is a valid file
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Validate();
    }
}