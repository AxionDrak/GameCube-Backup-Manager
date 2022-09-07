using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

/// <summary>
///     Represents a single CD/DVD type device, enabling additional commands requiring advanced marshalling code
/// </summary>
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("27354132-7F64-5B0F-8F00-5D77AFBE261E")]
public interface IDiscRecorder2Ex
{
    //
    // Send a command to the device that does not transfer any data
    //
    void SendCommandNoData(
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
        byte[] Cdb,
        uint CdbSize,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 18)]
        byte[] SenseBuffer,
        uint Timeout);

    // Send a command to the device that requires data sent to the device
    void SendCommandSendDataToDevice(
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
        byte[] Cdb,
        uint CdbSize,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 18)]
        byte[] SenseBuffer,
        uint Timeout,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)]
        byte[] Buffer,
        uint BufferSize);

    // Send a command to the device that requests data from the device
    void SendCommandGetDataFromDevice(
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
        byte[] Cdb,
        uint CdbSize,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 18)]
        byte[] SenseBuffer,
        uint Timeout,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)]
        byte[] Buffer,
        uint BufferSize,
        out uint BufferFetched);

    // Read a DVD Structure from the media
    void ReadDvdStructure(uint format, uint address, uint layer, uint agid, out IntPtr data, out uint Count);

    // Sends a DVD structure to the media
    void SendDvdStructure(uint format,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
        byte[] data,
        uint Count);

    // Get the full adapter descriptor (via IOCTL_STORAGE_QUERY_PROPERTY).
    void GetAdapterDescriptor(out IntPtr data, ref uint byteSize);

    // Get the full device descriptor (via IOCTL_STORAGE_QUERY_PROPERTY).
    void GetDeviceDescriptor(out IntPtr data, ref uint byteSize);

    // Gets data from a READ_DISC_INFORMATION command
    void GetDiscInformation(out IntPtr discInformation, ref uint byteSize);

    // Gets data from a READ_TRACK_INFORMATION command
    void GetTrackInformation(uint address, IMAPI_READ_TRACK_ADDRESS_TYPE addressType, out IntPtr trackInformation,
        ref uint byteSize);

    // Gets a feature's data from a GET_CONFIGURATION command
    void GetFeaturePage(IMAPI_FEATURE_PAGE_TYPE requestedFeature, sbyte currentFeatureOnly, out IntPtr featureData,
        ref uint byteSize);

    // Gets data from a MODE_SENSE10 command
    void GetModePage(IMAPI_MODE_PAGE_TYPE requestedModePage, IMAPI_MODE_PAGE_REQUEST_TYPE requestType,
        out IntPtr modePageData, ref uint byteSize);

    // Sets mode page data using MODE_SELECT10 command
    void SetModePage(IMAPI_MODE_PAGE_REQUEST_TYPE requestType,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
        byte[] data,
        uint byteSize);

    // Gets a list of all feature pages supported by the device
    void GetSupportedFeaturePages(sbyte currentFeatureOnly, out IntPtr featureData, ref uint byteSize);

    // Gets a list of all PROFILES supported by the device
    void GetSupportedProfiles(sbyte currentOnly, out IntPtr profileTypes, out uint validProfiles);

    // Gets a list of all MODE PAGES supported by the device
    void GetSupportedModePages(IMAPI_MODE_PAGE_REQUEST_TYPE requestType, out IntPtr modePageTypes,
        out uint validPages);

    // The byte alignment requirement mask for this device.
    uint GetByteAlignmentMask();

    // The maximum non-page-aligned transfer size for this device.
    uint GetMaximumNonPageAlignedTransferSize();

    // The maximum non-page-aligned transfer size for this device.
    uint GetMaximumPageAlignedTransferSize();
}