using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     Microsoft IMAPIv2 Track-at-Once Audio CD Writer
    /// </summary>
    [ComImport]
    [Guid("27354154-8F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftDiscFormat2TrackAtOnceClass))]
    public interface MsftDiscFormat2TrackAtOnce : IDiscFormat2TrackAtOnce, DiscFormat2TrackAtOnce_Event
    {
    }
}