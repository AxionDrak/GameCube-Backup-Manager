﻿using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace PluginBurnMedia.Interop
{
    #region IMAPI2 Enums

    public enum EmulationType
    {
        EmulationNone,
        Emulation12MFloppy,
        Emulation144MFloppy,
        Emulation288MFloppy,
        EmulationHardDisk
    }

    [Flags]
    public enum FsiFileSystems
    {
        FsiFileSystemNone = 0,
        FsiFileSystemISO9660 = 1,
        FsiFileSystemJoliet = 2,
        FsiFileSystemUDF = 4,
        FsiFileSystemUnknown = 0x40000000
    }

    public enum FsiItemType
    {
        FsiItemNotFound,
        FsiItemDirectory,
        FsiItemFile
    }

    public enum IMAPI_BURN_VERIFICATION_LEVEL
    {
        IMAPI_BURN_VERIFICATION_NONE,
        IMAPI_BURN_VERIFICATION_QUICK,
        IMAPI_BURN_VERIFICATION_FULL
    }

    public enum IMAPI_CD_SECTOR_TYPE
    {
        IMAPI_CD_SECTOR_AUDIO,
        IMAPI_CD_SECTOR_MODE_ZERO,
        IMAPI_CD_SECTOR_MODE1,
        IMAPI_CD_SECTOR_MODE2FORM0,
        IMAPI_CD_SECTOR_MODE2FORM1,
        IMAPI_CD_SECTOR_MODE2FORM2,
        IMAPI_CD_SECTOR_MODE1RAW,
        IMAPI_CD_SECTOR_MODE2FORM0RAW,
        IMAPI_CD_SECTOR_MODE2FORM1RAW,
        IMAPI_CD_SECTOR_MODE2FORM2RAW
    }

    public enum IMAPI_CD_TRACK_DIGITAL_COPY_SETTING
    {
        IMAPI_CD_TRACK_DIGITAL_COPY_PERMITTED,
        IMAPI_CD_TRACK_DIGITAL_COPY_PROHIBITED,
        IMAPI_CD_TRACK_DIGITAL_COPY_SCMS
    }

    public enum IMAPI_FEATURE_PAGE_TYPE
    {
        IMAPI_FEATURE_PAGE_TYPE_PROFILE_LIST = 0,
        IMAPI_FEATURE_PAGE_TYPE_CORE = 1,
        IMAPI_FEATURE_PAGE_TYPE_MORPHING = 2,
        IMAPI_FEATURE_PAGE_TYPE_REMOVABLE_MEDIUM = 3,
        IMAPI_FEATURE_PAGE_TYPE_WRITE_PROTECT = 4,
        IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_READABLE = 0x10,
        IMAPI_FEATURE_PAGE_TYPE_CD_MULTIREAD = 0x1d,
        IMAPI_FEATURE_PAGE_TYPE_CD_READ = 0x1e,
        IMAPI_FEATURE_PAGE_TYPE_DVD_READ = 0x1f,
        IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_WRITABLE = 0x20,
        IMAPI_FEATURE_PAGE_TYPE_INCREMENTAL_STREAMING_WRITABLE = 0x21,
        IMAPI_FEATURE_PAGE_TYPE_SECTOR_ERASABLE = 0x22,
        IMAPI_FEATURE_PAGE_TYPE_FORMATTABLE = 0x23,
        IMAPI_FEATURE_PAGE_TYPE_HARDWARE_DEFECT_MANAGEMENT = 0x24,
        IMAPI_FEATURE_PAGE_TYPE_WRITE_ONCE = 0x25,
        IMAPI_FEATURE_PAGE_TYPE_RESTRICTED_OVERWRITE = 0x26,
        IMAPI_FEATURE_PAGE_TYPE_CDRW_CAV_WRITE = 0x27,
        IMAPI_FEATURE_PAGE_TYPE_MRW = 0x28,
        IMAPI_FEATURE_PAGE_TYPE_ENHANCED_DEFECT_REPORTING = 0x29,
        IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_RW = 0x2a,
        IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R = 0x2b,
        IMAPI_FEATURE_PAGE_TYPE_RIGID_RESTRICTED_OVERWRITE = 0x2c,
        IMAPI_FEATURE_PAGE_TYPE_CD_TRACK_AT_ONCE = 0x2d,
        IMAPI_FEATURE_PAGE_TYPE_CD_MASTERING = 0x2e,
        IMAPI_FEATURE_PAGE_TYPE_DVD_DASH_WRITE = 0x2f,
        IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_READ = 0x30,
        IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_R_WRITE = 0x31,
        IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_RW_WRITE = 0x32,
        IMAPI_FEATURE_PAGE_TYPE_LAYER_JUMP_RECORDING = 0x33,
        IMAPI_FEATURE_PAGE_TYPE_CD_RW_MEDIA_WRITE_SUPPORT = 0x37,
        IMAPI_FEATURE_PAGE_TYPE_BD_PSEUDO_OVERWRITE = 0x38,
        IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R_DUAL_LAYER = 0x3b,
        IMAPI_FEATURE_PAGE_TYPE_BD_READ = 0x40,
        IMAPI_FEATURE_PAGE_TYPE_BD_WRITE = 0x41,
        IMAPI_FEATURE_PAGE_TYPE_HD_DVD_READ = 0x50,
        IMAPI_FEATURE_PAGE_TYPE_HD_DVD_WRITE = 0x51,
        IMAPI_FEATURE_PAGE_TYPE_POWER_MANAGEMENT = 0x100,
        IMAPI_FEATURE_PAGE_TYPE_SMART = 0x101,
        IMAPI_FEATURE_PAGE_TYPE_EMBEDDED_CHANGER = 0x102,
        IMAPI_FEATURE_PAGE_TYPE_CD_ANALOG_PLAY = 0x103,
        IMAPI_FEATURE_PAGE_TYPE_MICROCODE_UPDATE = 0x104,
        IMAPI_FEATURE_PAGE_TYPE_TIMEOUT = 0x105,
        IMAPI_FEATURE_PAGE_TYPE_DVD_CSS = 0x106,
        IMAPI_FEATURE_PAGE_TYPE_REAL_TIME_STREAMING = 0x107,
        IMAPI_FEATURE_PAGE_TYPE_LOGICAL_UNIT_SERIAL_NUMBER = 0x108,
        IMAPI_FEATURE_PAGE_TYPE_MEDIA_SERIAL_NUMBER = 0x109,
        IMAPI_FEATURE_PAGE_TYPE_DISC_CONTROL_BLOCKS = 0x10a,
        IMAPI_FEATURE_PAGE_TYPE_DVD_CPRM = 0x10b,
        IMAPI_FEATURE_PAGE_TYPE_FIRMWARE_INFORMATION = 0x10c,
        IMAPI_FEATURE_PAGE_TYPE_AACS = 0x10d,
        IMAPI_FEATURE_PAGE_TYPE_VCPS = 0x110
    }

    public enum IMAPI_FORMAT2_DATA_MEDIA_STATE
    {
        [TypeLibVar((short)0x40)]
        IMAPI_FORMAT2_DATA_MEDIA_STATE_UNKNOWN = 0,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_OVERWRITE_ONLY = 1,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_RANDOMLY_WRITABLE = 1,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_BLANK = 2,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_APPENDABLE = 4,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_FINAL_SESSION = 8,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_INFORMATIONAL_MASK = 15,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_DAMAGED = 0x400,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_ERASE_REQUIRED = 0x800,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_NON_EMPTY_SESSION = 0x1000,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_WRITE_PROTECTED = 0x2000,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_FINALIZED = 0x4000,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MEDIA = 0x8000,
        IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MASK = 0xfc00
    }

    public enum IMAPI_FORMAT2_DATA_WRITE_ACTION
    {
        IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA,
        IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA,
        IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE,
        IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER,
        IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA,
        IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION,
        IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED,
        IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING
    }

    public enum IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE
    {
        IMAPI_FORMAT2_RAW_CD_SUBCODE_PQ_ONLY = 1,
        IMAPI_FORMAT2_RAW_CD_SUBCODE_IS_COOKED = 2,
        IMAPI_FORMAT2_RAW_CD_SUBCODE_IS_RAW = 3
    }

    public enum IMAPI_FORMAT2_RAW_CD_WRITE_ACTION
    {
        [TypeLibVar((short)0x40)]
        IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_UNKNOWN = 0,
        IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_PREPARING = 1,
        IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_WRITING = 2,
        IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_FINISHING = 3
    }


    public enum IMAPI_FORMAT2_TAO_WRITE_ACTION
    {
        [TypeLibVar((short)0x40)]
        IMAPI_FORMAT2_TAO_WRITE_ACTION_UNKNOWN = 0,
        IMAPI_FORMAT2_TAO_WRITE_ACTION_PREPARING = 1,
        IMAPI_FORMAT2_TAO_WRITE_ACTION_WRITING = 2,
        IMAPI_FORMAT2_TAO_WRITE_ACTION_FINISHING = 3,
        IMAPI_FORMAT2_TAO_WRITE_ACTION_VERIFYING = 4
    }

    public enum IMAPI_MEDIA_PHYSICAL_TYPE
    {
        IMAPI_MEDIA_TYPE_UNKNOWN = 0,
        IMAPI_MEDIA_TYPE_CDROM = 1,
        IMAPI_MEDIA_TYPE_CDR = 2,
        IMAPI_MEDIA_TYPE_CDRW = 3,
        IMAPI_MEDIA_TYPE_DVDROM = 4,
        IMAPI_MEDIA_TYPE_DVDRAM = 5,
        IMAPI_MEDIA_TYPE_DVDPLUSR = 6,
        IMAPI_MEDIA_TYPE_DVDPLUSRW = 7,
        IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER = 8,
        IMAPI_MEDIA_TYPE_DVDDASHR = 9,
        IMAPI_MEDIA_TYPE_DVDDASHRW = 10,
        IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER = 11,
        IMAPI_MEDIA_TYPE_DISK = 12,
        IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER = 13,
        IMAPI_MEDIA_TYPE_HDDVDROM = 14,
        IMAPI_MEDIA_TYPE_HDDVDR = 15,
        IMAPI_MEDIA_TYPE_HDDVDRAM = 0x10,
        IMAPI_MEDIA_TYPE_BDROM = 0x11,
        IMAPI_MEDIA_TYPE_BDR = 0x12,
        IMAPI_MEDIA_TYPE_BDRE = 0x13,
        IMAPI_MEDIA_TYPE_MAX = 0x13
    }

    public enum IMAPI_MEDIA_WRITE_PROTECT_STATE
    {
        IMAPI_WRITEPROTECTED_UNTIL_POWERDOWN = 1,
        IMAPI_WRITEPROTECTED_BY_CARTRIDGE = 2,
        IMAPI_WRITEPROTECTED_BY_MEDIA_SPECIFIC_REASON = 4,
        IMAPI_WRITEPROTECTED_BY_SOFTWARE_WRITE_PROTECT = 8,
        IMAPI_WRITEPROTECTED_BY_DISC_CONTROL_BLOCK = 0x10,
        IMAPI_WRITEPROTECTED_READ_ONLY_MEDIA = 0x4000
    }

    public enum IMAPI_MODE_PAGE_REQUEST_TYPE
    {
        IMAPI_MODE_PAGE_REQUEST_TYPE_CURRENT_VALUES,
        IMAPI_MODE_PAGE_REQUEST_TYPE_CHANGEABLE_VALUES,
        IMAPI_MODE_PAGE_REQUEST_TYPE_DEFAULT_VALUES,
        IMAPI_MODE_PAGE_REQUEST_TYPE_SAVED_VALUES
    }

    public enum IMAPI_MODE_PAGE_TYPE
    {
        IMAPI_MODE_PAGE_TYPE_READ_WRITE_ERROR_RECOVERY = 1,
        IMAPI_MODE_PAGE_TYPE_MRW = 3,
        IMAPI_MODE_PAGE_TYPE_WRITE_PARAMETERS = 5,
        IMAPI_MODE_PAGE_TYPE_CACHING = 8,
        IMAPI_MODE_PAGE_TYPE_POWER_CONDITION = 0x1a,
        IMAPI_MODE_PAGE_TYPE_TIMEOUT_AND_PROTECT = 0x1d,
        IMAPI_MODE_PAGE_TYPE_INFORMATIONAL_EXCEPTIONS = 0x1c,
        IMAPI_MODE_PAGE_TYPE_LEGACY_CAPABILITIES = 0x2a
    }

    public enum IMAPI_PROFILE_TYPE
    {
        IMAPI_PROFILE_TYPE_INVALID = 0,
        IMAPI_PROFILE_TYPE_NON_REMOVABLE_DISK = 1,
        IMAPI_PROFILE_TYPE_REMOVABLE_DISK = 2,
        IMAPI_PROFILE_TYPE_MO_ERASABLE = 3,
        IMAPI_PROFILE_TYPE_MO_WRITE_ONCE = 4,
        IMAPI_PROFILE_TYPE_AS_MO = 5,
        IMAPI_PROFILE_TYPE_CDROM = 8,
        IMAPI_PROFILE_TYPE_CD_RECORDABLE = 9,
        IMAPI_PROFILE_TYPE_CD_REWRITABLE = 10,
        IMAPI_PROFILE_TYPE_DVDROM = 0x10,
        IMAPI_PROFILE_TYPE_DVD_DASH_RECORDABLE = 0x11,
        IMAPI_PROFILE_TYPE_DVD_RAM = 0x12,
        IMAPI_PROFILE_TYPE_DVD_DASH_REWRITABLE = 0x13,
        IMAPI_PROFILE_TYPE_DVD_DASH_RW_SEQUENTIAL = 0x14,
        IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_SEQUENTIAL = 0x15,
        IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_LAYER_JUMP = 0x16,
        IMAPI_PROFILE_TYPE_DVD_PLUS_RW = 0x1a,
        IMAPI_PROFILE_TYPE_DVD_PLUS_R = 0x1b,
        IMAPI_PROFILE_TYPE_DDCDROM = 0x20,
        IMAPI_PROFILE_TYPE_DDCD_RECORDABLE = 0x21,
        IMAPI_PROFILE_TYPE_DDCD_REWRITABLE = 0x22,
        IMAPI_PROFILE_TYPE_DVD_PLUS_RW_DUAL = 0x2a,
        IMAPI_PROFILE_TYPE_DVD_PLUS_R_DUAL = 0x2b,
        IMAPI_PROFILE_TYPE_BD_ROM = 0x40,
        IMAPI_PROFILE_TYPE_BD_R_SEQUENTIAL = 0x41,
        IMAPI_PROFILE_TYPE_BD_R_RANDOM_RECORDING = 0x42,
        IMAPI_PROFILE_TYPE_BD_REWRITABLE = 0x43,
        IMAPI_PROFILE_TYPE_HD_DVD_ROM = 0x50,
        IMAPI_PROFILE_TYPE_HD_DVD_RECORDABLE = 0x51,
        IMAPI_PROFILE_TYPE_HD_DVD_RAM = 0x52,
        IMAPI_PROFILE_TYPE_NON_STANDARD = 0xffff
    }

    public enum IMAPI_READ_TRACK_ADDRESS_TYPE
    {
        IMAPI_READ_TRACK_ADDRESS_TYPE_LBA,
        IMAPI_READ_TRACK_ADDRESS_TYPE_TRACK,
        IMAPI_READ_TRACK_ADDRESS_TYPE_SESSION
    }

    public enum PlatformId
    {
        PlatformX86 = 0,
        PlatformPowerPC = 1,
        PlatformMac = 2,
        PlatformEFI = 0xef
    }
    #endregion

    #region IMAPI2 Structures

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct _FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct _LARGE_INTEGER
    {
        public long QuadPart;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct _ULARGE_INTEGER
    {
        public ulong QuadPart;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct tagCONNECTDATA
    {
        [MarshalAs(UnmanagedType.IUnknown)]
        public object pUnk;
        public uint dwCookie;
    }



    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct tagSTATSTG
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwcsName;
        public uint type;
        public _ULARGE_INTEGER cbSize;
        public _FILETIME mtime;
        public _FILETIME ctime;
        public _FILETIME atime;
        public uint grfMode;
        public uint grfLocksSupported;
        public Guid clsid;
        public uint grfStateBits;
        public uint reserved;
    }
    #endregion

    #region DDiscFormat2DataEvents
    /// <summary>
    /// Data Writer
    /// </summary>
    [ComImport]
    [Guid("2735413C-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DDiscFormat2DataEvents
    {
        // Update to current progress
        [DispId(0x200)]     // DISPID_DDISCFORMAT2DATAEVENTS_UPDATE
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);
    }

    [ComVisible(false)]
    [ComEventInterface(typeof(DDiscFormat2DataEvents), typeof(DiscFormat2Data_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DiscFormat2Data_Event
    {
        // Events
        event DiscFormat2Data_EventHandler Update;
    }

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscFormat2Data_EventProvider : DiscFormat2Data_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;


        // Methods
        public DiscFormat2Data_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DDiscFormat2DataEvents).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DiscFormat2Data_EventHandler Update
        {
            add
            {
                lock (this)
                {
                    DiscFormat2Data_SinkHelper helper =
                        new DiscFormat2Data_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DiscFormat2Data_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DiscFormat2Data_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                    }
                }
            }
        }

        ~DiscFormat2Data_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DiscFormat2Data_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DiscFormat2Data_SinkHelper : DDiscFormat2DataEvents
    {
        // Fields
        private int m_dwCookie;
        private DiscFormat2Data_EventHandler m_UpdateDelegate;

        // Methods
        internal DiscFormat2Data_SinkHelper(DiscFormat2Data_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_UpdateDelegate = eventHandler;
        }

        public void Update(object sender, object args)
        {
            m_UpdateDelegate(sender, args);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DiscFormat2Data_EventHandler UpdateDelegate
        {
            get
            {
                return m_UpdateDelegate;
            }
            set
            {
                m_UpdateDelegate = value;
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscFormat2Data_EventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);

    #endregion // DDiscFormat2DataEvents

    #region  DDiscFormat2EraseEvents
    /// <summary>
    /// Provides notification of media erase progress.
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    [Guid("2735413A-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface DDiscFormat2EraseEvents
    {
        // Update to current progress
        [DispId(0x200)]     // DISPID_IDISCFORMAT2ERASEEVENTS_UPDATE 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In] int elapsedSeconds, [In] int estimatedTotalSeconds);
    }

    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComVisible(false)]
    [ComEventInterface(typeof(DDiscFormat2EraseEvents), typeof(DiscFormat2Erase_EventProvider))]
    public interface DiscFormat2Erase_Event
    {
        // Events
        event DiscFormat2Erase_EventHandler Update;
    }

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscFormat2Erase_EventProvider : DiscFormat2Erase_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;

        // Methods
        public DiscFormat2Erase_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DDiscFormat2EraseEvents).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DiscFormat2Erase_EventHandler Update
        {
            add
            {
                lock (this)
                {
                    DiscFormat2Erase_SinkHelper helper =
                        new DiscFormat2Erase_SinkHelper(value);
                    int cookie = -1;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DiscFormat2Erase_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DiscFormat2Erase_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                    }
                }
            }
        }

        ~DiscFormat2Erase_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DiscFormat2Erase_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DiscFormat2Erase_SinkHelper : DDiscFormat2EraseEvents
    {
        // Fields
        private int m_dwCookie;
        private DiscFormat2Erase_EventHandler m_UpdateDelegate;

        public DiscFormat2Erase_SinkHelper(DiscFormat2Erase_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_UpdateDelegate = eventHandler;
        }

        public void Update(object sender, int elapsedSeconds, int estimatedTotalSeconds)
        {
            m_UpdateDelegate(sender, elapsedSeconds, estimatedTotalSeconds);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DiscFormat2Erase_EventHandler UpdateDelegate
        {
            get
            {
                return m_UpdateDelegate;
            }
            set
            {
                m_UpdateDelegate = value;
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscFormat2Erase_EventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In] int elapsedSeconds, [In] int estimatedTotalSeconds);
    #endregion  // DDiscFormat2EraseEvents

    #region DDiscFormat2RawCDEvents

    /// <summary>
    /// CD Disc-At-Once RAW Writer Events
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    [Guid("27354142-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface DDiscFormat2RawCDEvents
    {
        // Update to current progress
        [DispId(0x200)]     // DISPID_DDISCFORMAT2RAWCDEVENTS_UPDATE 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);
    }

    [ComEventInterface(typeof(DDiscFormat2RawCDEvents), typeof(DiscFormat2RawCD_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComVisible(false)]
    public interface DiscFormat2RawCD_Event
    {
        // Events
        event DiscFormat2RawCD_EventHandler Update;
    }

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscFormat2RawCD_EventProvider : DiscFormat2RawCD_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;

        // Methods
        public DiscFormat2RawCD_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DDiscFormat2RawCDEvents).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DiscFormat2RawCD_EventHandler Update
        {
            add
            {
                lock (this)
                {
                    DiscFormat2RawCD_SinkHelper helper =
                        new DiscFormat2RawCD_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DiscFormat2RawCD_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DiscFormat2RawCD_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                    }
                }
            }
        }

        ~DiscFormat2RawCD_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DiscFormat2RawCD_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DiscFormat2RawCD_SinkHelper : DDiscFormat2RawCDEvents
    {
        // Fields
        private int m_dwCookie;
        private DiscFormat2RawCD_EventHandler m_UpdateDelegate;

        public DiscFormat2RawCD_SinkHelper(DiscFormat2RawCD_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_UpdateDelegate = eventHandler;
        }

        public void Update(object sender, object progress)
        {
            m_UpdateDelegate(sender, progress);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DiscFormat2RawCD_EventHandler UpdateDelegate
        {
            get
            {
                return m_UpdateDelegate;
            }
            set
            {
                m_UpdateDelegate = value;
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscFormat2RawCD_EventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);

    #endregion  // DDiscFormat2RawCDEvents

    #region DDiscFormat2TrackAtOnceEvents
    /// <summary>
    /// CD Track-at-Once Audio Writer Events
    /// </summary>
    [ComImport]
    [Guid("2735413F-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DDiscFormat2TrackAtOnceEvents
    {
        // Update to current progress
        [DispId(0x200)]     // DISPID_DDISCFORMAT2TAOEVENTS_UPDATE
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);
    }

    [ComVisible(false)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComEventInterface(typeof(DDiscFormat2TrackAtOnceEvents), typeof(DiscFormat2TrackAtOnce_EventProvider))]
    public interface DiscFormat2TrackAtOnce_Event
    {
        // Events
        event DiscFormat2TrackAtOnce_EventHandler Update;
    }

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscFormat2TrackAtOnce_EventProvider : DiscFormat2TrackAtOnce_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;

        // Methods
        public DiscFormat2TrackAtOnce_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DDiscFormat2TrackAtOnceEvents).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DiscFormat2TrackAtOnce_EventHandler Update
        {
            add
            {
                lock (this)
                {
                    DiscFormat2TrackAtOnce_SinkHelper helper =
                        new DiscFormat2TrackAtOnce_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DiscFormat2TrackAtOnce_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DiscFormat2TrackAtOnce_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                    }
                }
            }
        }

        ~DiscFormat2TrackAtOnce_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DiscFormat2TrackAtOnce_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DiscFormat2TrackAtOnce_SinkHelper : DDiscFormat2TrackAtOnceEvents
    {
        // Fields
        private int m_dwCookie;
        private DiscFormat2TrackAtOnce_EventHandler m_UpdateDelegate;

        public DiscFormat2TrackAtOnce_SinkHelper(DiscFormat2TrackAtOnce_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_UpdateDelegate = eventHandler;
        }

        public void Update(object sender, object progress)
        {
            m_UpdateDelegate(sender, progress);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DiscFormat2TrackAtOnce_EventHandler UpdateDelegate
        {
            get
            {
                return m_UpdateDelegate;
            }
            set
            {
                m_UpdateDelegate = value;
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscFormat2TrackAtOnce_EventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);

    #endregion  // DDiscFormat2TrackAtOnceEvents

    #region DDiscMaster2Events
    /// <summary>
    /// Provides notification of the arrival/removal of CD/DVD (optical) devices.
    /// </summary>
    [ComImport]
    [Guid("27354131-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DDiscMaster2Events
    {
        // A device was added to the system
        [DispId(0x100)]     // DISPID_DDISCMASTER2EVENTS_DEVICEADDED
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NotifyDeviceAdded([In, MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);

        // A device was removed from the system
        [DispId(0x101)]     // DISPID_DDISCMASTER2EVENTS_DEVICEREMOVED
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NotifyDeviceRemoved([In, MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);
    }


    [ComVisible(false)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComEventInterface(typeof(DDiscMaster2Events), typeof(DiscMaster2_EventProvider))]
    public interface DiscMaster2_Event
    {
        // Events
        event DiscMaster2_NotifyDeviceAddedEventHandler NotifyDeviceAdded;
        event DiscMaster2_NotifyDeviceRemovedEventHandler NotifyDeviceRemoved;
    }

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscMaster2_EventProvider : DiscMaster2_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;

        // Methods
        public DiscMaster2_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DDiscMaster2Events).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DiscMaster2_NotifyDeviceAddedEventHandler NotifyDeviceAdded
        {
            add
            {
                lock (this)
                {
                    DiscMaster2_SinkHelper helper =
                        new DiscMaster2_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.NotifyDeviceAddedDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DiscMaster2_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DiscMaster2_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.NotifyDeviceAddedDelegate);
                    }
                }
            }
        }

        public event DiscMaster2_NotifyDeviceRemovedEventHandler NotifyDeviceRemoved
        {
            add
            {
                lock (this)
                {
                    DiscMaster2_SinkHelper helper =
                        new DiscMaster2_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.NotifyDeviceRemovedDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DiscMaster2_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DiscMaster2_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.NotifyDeviceRemovedDelegate);
                    }
                }
            }
        }

        ~DiscMaster2_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DiscMaster2_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscMaster2_NotifyDeviceAddedEventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscMaster2_NotifyDeviceRemovedEventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);

    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DiscMaster2_SinkHelper : DDiscMaster2Events
    {
        // Fields
        private int m_dwCookie;
        private DiscMaster2_NotifyDeviceAddedEventHandler m_AddedDelegate = null;
        private DiscMaster2_NotifyDeviceRemovedEventHandler m_RemovedDelegate = null;

        public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceAddedEventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_AddedDelegate = eventHandler;
        }

        public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceRemovedEventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_RemovedDelegate = eventHandler;
        }

        public void NotifyDeviceAdded(object sender, string uniqueId)
        {
            m_AddedDelegate(sender, uniqueId);
        }

        public void NotifyDeviceRemoved(object sender, string uniqueId)
        {
            m_RemovedDelegate(sender, uniqueId);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DiscMaster2_NotifyDeviceAddedEventHandler NotifyDeviceAddedDelegate
        {
            get
            {
                return m_AddedDelegate;
            }
            set
            {
                m_AddedDelegate = value;
            }
        }

        public DiscMaster2_NotifyDeviceRemovedEventHandler NotifyDeviceRemovedDelegate
        {
            get
            {
                return m_RemovedDelegate;
            }
            set
            {
                m_RemovedDelegate = value;
            }
        }
    }

    #endregion DDiscMaster2Events

    #region DFileSystemImageEvents
    /// <summary>
    /// Provides notification of file system import progress
    /// </summary>
    [ComImport]
    [Guid("2C941FDF-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DFileSystemImageEvents
    {
        // Update to current progress
        [DispId(0x100)]     // DISPID_DFILESYSTEMIMAGEEVENTS_UPDATE 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, string currentFile, [In] int copiedSectors, [In] int totalSectors);
    }

    [ComVisible(false)]
    [ComEventInterface(typeof(DFileSystemImageEvents), typeof(DFileSystemImage_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DFileSystemImage_Event
    {
        // Events
        event DFileSystemImage_EventHandler Update;
    }

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DFileSystemImage_EventProvider : DFileSystemImage_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;


        // Methods
        public DFileSystemImage_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DFileSystemImageEvents).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DFileSystemImage_EventHandler Update
        {
            add
            {
                lock (this)
                {
                    DFileSystemImage_SinkHelper helper = new DFileSystemImage_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DFileSystemImage_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DFileSystemImage_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                    }
                }
            }
        }

        ~DFileSystemImage_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DFileSystemImage_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [ClassInterface(ClassInterfaceType.None), TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DFileSystemImage_SinkHelper : DFileSystemImageEvents
    {
        // Fields
        private int m_dwCookie;
        private DFileSystemImage_EventHandler m_UpdateDelegate;

        public DFileSystemImage_SinkHelper(DFileSystemImage_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_UpdateDelegate = eventHandler;
        }

        public void Update(object sender, string currentFile, int copiedSectors, int totalSectors)
        {
            m_UpdateDelegate(sender, currentFile, copiedSectors, totalSectors);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DFileSystemImage_EventHandler UpdateDelegate
        {
            get
            {
                return m_UpdateDelegate;
            }
            set
            {
                m_UpdateDelegate = value;
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DFileSystemImage_EventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, string currentFile, int copiedSectors, int totalSectors);
    #endregion  // DFileSystemImageEvents

    #region DFileSystemImageImportEvents
    //
    // DFileSystemImageImportEvents
    //
    [ComImport]
    [Guid("D25C30F9-4087-4366-9E24-E55BE286424B")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DFileSystemImageImportEvents
    {
        [DispId(0x101)]     // DISPID_DFILESYSTEMIMAGEIMPORTEVENTS_UPDATEIMPORT 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateImport([In, MarshalAs(UnmanagedType.IDispatch)] object sender, FsiFileSystems fileSystem,
                string currentItem, int importedDirectoryItems, int totalDirectoryItems, int importedFileItems, int totalFileItems);
    }

    [ComVisible(false)]
    [ComEventInterface(typeof(DFileSystemImageImportEvents), typeof(DFileSystemImageImport_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DFileSystemImageImport_Event
    {
        // Events
        event DFileSystemImageImport_EventHandler UpdateImport;
    }


    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DFileSystemImageImport_EventProvider : DFileSystemImageImport_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;


        // Methods
        public DFileSystemImageImport_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DFileSystemImageImportEvents).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DFileSystemImageImport_EventHandler UpdateImport
        {
            add
            {
                lock (this)
                {
                    DFileSystemImageImport_SinkHelper helper = new DFileSystemImageImport_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DFileSystemImageImport_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DFileSystemImageImport_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                    }
                }
            }
        }

        ~DFileSystemImageImport_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DFileSystemImageImport_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DFileSystemImageImport_SinkHelper : DFileSystemImageImportEvents
    {
        // Fields
        private int m_dwCookie;
        private DFileSystemImageImport_EventHandler m_UpdateDelegate;

        public DFileSystemImageImport_SinkHelper(DFileSystemImageImport_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_UpdateDelegate = eventHandler;
        }

        public void UpdateImport(object sender, FsiFileSystems fileSystems, string currentItem,
            int importedDirectoryItems, int totalDirectoryItems, int importedFileItems, int totalFileItems)
        {
            m_UpdateDelegate(sender, fileSystems, currentItem, importedDirectoryItems, totalDirectoryItems,
                importedFileItems, totalFileItems);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DFileSystemImageImport_EventHandler UpdateDelegate
        {
            get
            {
                return m_UpdateDelegate;
            }
            set
            {
                m_UpdateDelegate = value;
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DFileSystemImageImport_EventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender,
        FsiFileSystems fileSystem, string currentItem, int importedDirectoryItems, int totalDirectoryItems, int importedFileItems, int totalFileItems);

    #endregion  // DFileSystemImageImportEvents

    #region DWriteEngine2Events
    /// <summary>
    /// Provides notification of the progress of the WriteEngine2 writing.
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    [Guid("27354137-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface DWriteEngine2Events
    {
        // Update to current progress
        [DispId(0x100)]     // DISPID_DWRITEENGINE2EVENTS_UPDATE 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);
    }

    [ComVisible(false)]
    [ComEventInterface(typeof(DWriteEngine2Events), typeof(DWriteEngine2_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DWriteEngine2_Event
    {
        // Events
        event DWriteEngine2_EventHandler Update;
    }

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DWriteEngine2_EventProvider : DWriteEngine2_Event, IDisposable
    {
        // Fields
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;

        // Methods
        public DWriteEngine2_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid eventsGuid = typeof(DWriteEngine2Events).GUID;
                IConnectionPointContainer connectionPointContainer = pointContainer as IConnectionPointContainer;

                connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
            }
        }

        public event DWriteEngine2_EventHandler Update
        {
            add
            {
                lock (this)
                {
                    DWriteEngine2_SinkHelper helper =
                        new DWriteEngine2_SinkHelper(value);
                    int cookie;

                    m_connectionPoint.Advise(helper, out cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    DWriteEngine2_SinkHelper helper =
                        m_aEventSinkHelpers[value] as DWriteEngine2_SinkHelper;
                    if (helper != null)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                    }
                }
            }
        }

        ~DWriteEngine2_EventProvider()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            Monitor.Enter(this);
            try
            {
                foreach (DWriteEngine2_SinkHelper helper in m_aEventSinkHelpers.Values)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                }

                m_aEventSinkHelpers.Clear();
                Marshal.ReleaseComObject(m_connectionPoint);
            }
            catch (SynchronizationLockException)
            {
                return;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }

    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DWriteEngine2_SinkHelper : DWriteEngine2Events
    {
        // Fields
        private int m_dwCookie;
        private DWriteEngine2_EventHandler m_UpdateDelegate;

        public DWriteEngine2_SinkHelper(DWriteEngine2_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            m_dwCookie = 0;
            m_UpdateDelegate = eventHandler;
        }

        public void Update(object sender, object progress)
        {
            m_UpdateDelegate(sender, progress);
        }

        public int Cookie
        {
            get
            {
                return m_dwCookie;
            }
            set
            {
                m_dwCookie = value;
            }
        }

        public DWriteEngine2_EventHandler UpdateDelegate
        {
            get
            {
                return m_UpdateDelegate;
            }
            set
            {
                m_UpdateDelegate = value;
            }
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DWriteEngine2_EventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress);
    #endregion // DWriteEngine2Events

    #region Interfaces

    /// <summary>
    /// Boot Options
    /// </summary>
    [Guid("2C941FD4-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IBootOptions
    {
        // Get boot image data stream
        [DispId(1)]
        IStream BootImage { get; }

        // Get boot manufacturer
        [DispId(2)]
        string Manufacturer { get; set; }

        // Get boot platform identifier
        [DispId(3)]
        PlatformId PlatformId { get; set; }

        // Get boot emulation type
        [DispId(4)]
        EmulationType Emulation { get; set; }

        // Get boot image size
        [DispId(5)]
        uint ImageSize { get; }

        // Set the boot image data stream, emulation type, and image size
        [DispId(20)]
        void AssignBootImage(IStream newVal);
    }

    /// <summary>
    /// An interface to control burn verification for a burning object
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D2FFD834-958B-426D-8470-2A13879C6A91")]
    public interface IBurnVerification
    {
        // The requested level of burn verification
        [DispId(0x400)]
        IMAPI_BURN_VERIFICATION_LEVEL BurnVerificationLevel { set; get; }
    }

    /// <summary>
    /// Common Disc Format (writer) Operations
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("27354152-8F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscFormat2
    {
        // Determines if the recorder object supports the given format
        [DispId(0x800)]
        bool IsRecorderSupported(IDiscRecorder2 Recorder);

        // Determines if the current media in a supported recorder object supports the given format
        [DispId(0x801)]
        bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

        // Determines if the current media is reported as physically blank by the drive
        [DispId(0x700)]
        bool MediaPhysicallyBlank { get; }

        // Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media)
        [DispId(0x701)]
        bool MediaHeuristicallyBlank { get; }

        // Supported media types
        [DispId(0x702)]
        object[] SupportedMediaTypes { get; }
    }

    /// <summary>
    /// Data Writer
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("27354153-9F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscFormat2Data
    {
        //
        // IDiscFormat2
        //

        // Determines if the recorder object supports the given format
        [DispId(0x800)]
        bool IsRecorderSupported(IDiscRecorder2 Recorder);

        // Determines if the current media in a supported recorder object supports the given format
        [DispId(0x801)]
        bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

        // Determines if the current media is reported as physically blank by the drive
        [DispId(0x700)]
        bool MediaPhysicallyBlank { get; }

        // Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media)
        [DispId(0x701)]
        bool MediaHeuristicallyBlank { get; }

        // Supported media types
        [DispId(0x702)]
        object[] SupportedMediaTypes { get; }

        //
        // IDiscFormat2Data
        //

        // The disc recorder to use
        [DispId(0x100)]
        IDiscRecorder2 Recorder { set; get; }

        // Buffer Underrun Free recording should be disabled
        [DispId(0x101)]
        bool BufferUnderrunFreeDisabled { set; get; }

        // Postgap is included in image
        [DispId(260)]
        bool PostgapAlreadyInImage { set; get; }

        // The state (usability) of the current media
        [DispId(0x106)]
        IMAPI_FORMAT2_DATA_MEDIA_STATE CurrentMediaStatus { get; }

        // The write protection state of the current media
        [DispId(0x107)]
        IMAPI_MEDIA_WRITE_PROTECT_STATE WriteProtectStatus { get; }

        // Total sectors available on the media (used + free).
        [DispId(0x108)]
        int TotalSectorsOnMedia { get; }

        // Free sectors available on the media.
        [DispId(0x109)]
        int FreeSectorsOnMedia { get; }

        // Next writable address on the media (also used sectors)
        [DispId(0x10a)]
        int NextWritableAddress { get; }

        // The first sector in the previous session on the media
        [DispId(0x10b)]
        int StartAddressOfPreviousSession { get; }

        // The last sector in the previous session on the media
        [DispId(0x10c)]
        int LastWrittenAddressOfPreviousSession { get; }

        // Prevent further additions to the file system
        [DispId(0x10d)]
        bool ForceMediaToBeClosed { set; get; }

        // Default is to maximize compatibility with DVD-ROM.  May be disabled to 
        // reduce time to finish writing the disc or increase usable space on the 
        // media for later writing.
        [DispId(270)]
        bool DisableConsumerDvdCompatibilityMode { set; get; }

        // Get the current physical media type
        [DispId(0x10f)]
        IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

        // The friendly name of the client (used to determine recorder reservation conflicts)
        [DispId(0x110)]
        string ClientName { set; get; }

        // The last requested write speed
        [DispId(0x111)]
        int RequestedWriteSpeed { get; }

        // The last requested rotation type
        [DispId(0x112)]
        bool RequestedRotationTypeIsPureCAV { get; }

        // The drive's current write speed
        [DispId(0x113)]
        int CurrentWriteSpeed { get; }

        // The drive's current rotation type.
        [DispId(0x114)]
        bool CurrentRotationTypeIsPureCAV { get; }

        // Gets an array of the write speeds supported for the attached disc recorder and current media
        [DispId(0x115)]
        object[] SupportedWriteSpeeds { get; }

        // Gets an array of the detailed write configurations supported for the attached disc recorder 
        // and current media
        [DispId(0x116)]
        object[] SupportedWriteSpeedDescriptors { get; }

        // Forces the Datawriter to overwrite the disc on overwritable media types
        [DispId(0x117)]
        bool ForceOverwrite { set; get; }

        // Returns the array of available multi-session interfaces. The array shall not be empty
        [DispId(280)]
        object[] MultisessionInterfaces { get; }

        // Writes all the data provided in the IStream to the device
        [DispId(0x200)]
        void Write(IStream data);

        // Cancels the current write operation
        [DispId(0x201)]
        void CancelWrite();

        // Sets the write speed (in sectors per second) of the attached disc recorder
        [DispId(0x202)]
        void SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV);
    }

    /// <summary>
    /// Track-at-once Data Writer
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("2735413D-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscFormat2DataEventArgs
    {
        //
        // IWriteEngine2EventArgs
        //

        // The starting logical block address for the current write operation.
        [DispId(0x100)]
        int StartLba { get; }

        // The number of sectors being written for the current write operation.
        [DispId(0x101)]
        int SectorCount { get; }

        // The last logical block address of data read for the current write operation.
        [DispId(0x102)]
        int LastReadLba { get; }

        // The last logical block address of data written for the current write operation
        [DispId(0x103)]
        int LastWrittenLba { get; }

        // The total bytes available in the system's cache buffer
        [DispId(0x106)]
        int TotalSystemBuffer { get; }

        // The used bytes in the system's cache buffer
        [DispId(0x107)]
        int UsedSystemBuffer { get; }

        // The free bytes in the system's cache buffer
        [DispId(0x108)]
        int FreeSystemBuffer { get; }

        //
        // IDiscFormat2DataEventArgs
        //

        // The total elapsed time for the current write operation
        [DispId(0x300)]
        int ElapsedTime { get; }

        // The estimated time remaining for the write operation.
        [DispId(0x301)]
        int RemainingTime { get; }

        // The estimated total time for the write operation.
        [DispId(770)]
        int TotalTime { get; }

        // The current write action.
        [DispId(0x303)]
        IMAPI_FORMAT2_DATA_WRITE_ACTION CurrentAction { get; }
    }

    [ComImport, Guid("27354156-8F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscFormat2Erase
    {
        //
        // IDiscFormat2
        //

        // Determines if the recorder object supports the given format
        [DispId(0x800)]
        bool IsRecorderSupported(IDiscRecorder2 Recorder);

        // Determines if the current media in a supported recorder object supports the given format
        [DispId(0x801)]
        bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

        // Determines if the current media is reported as physically blank by the drive
        [DispId(0x700)]
        bool MediaPhysicallyBlank { get; }

        // Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media)
        [DispId(0x701)]
        bool MediaHeuristicallyBlank { get; }

        // Supported media types
        [DispId(0x702)]
        object[] SupportedMediaTypes { get; }

        //
        // IDiscFormat2Erase
        //

        // Sets the recorder object to use for an erase operation
        [DispId(0x100)]
        IDiscRecorder2 Recorder { set; get; }

        // 
        [DispId(0x101)]
        bool FullErase { set; get; }

        // Get the current physical media type
        [DispId(0x102)]
        IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

        // The friendly name of the client (used to determine recorder reservation conflicts)
        [DispId(0x103)]
        string ClientName { set; get; }

        // Erases the media in the active disc recorder
        [DispId(0x201)]
        void EraseMedia();
    }


    /// <summary>
    /// CD Disc-At-Once RAW Writer
    /// </summary>
    [ComImport, Guid("27354155-8F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscFormat2RawCD
    {
        //
        // IDiscFormat2
        //

        // Determines if the recorder object supports the given format
        [DispId(0x800)]
        bool IsRecorderSupported(IDiscRecorder2 Recorder);

        // Determines if the current media in a supported recorder object supports the given format
        [DispId(0x801)]
        bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

        // Determines if the current media is reported as physically blank by the drive
        [DispId(0x700)]
        bool MediaPhysicallyBlank { get; }

        // Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media)
        [DispId(0x701)]
        bool MediaHeuristicallyBlank { get; }

        // Supported media types
        [DispId(0x702)]
        object[] SupportedMediaTypes { get; }

        //
        // IDiscFormat2RawCD
        //

        // Locks the current media for use by this writer
        [DispId(0x200)]
        void PrepareMedia();

        // Writes a RAW image that starts at 95:00:00 (MSF) to the currently inserted blank CD media
        [DispId(0x201)]
        void WriteMedia(IStream data);

        // Writes a RAW image to the currently inserted blank CD media.  A stream starting at 95:00:00
        // (-5 minutes) would use 5*60*75 + 150 sectors pregap == 22,650 for the number of sectors
        [DispId(0x202)]
        void WriteMedia2(IStream data, int streamLeadInSectors);

        // Cancels the current write.
        [DispId(0x203)]
        void CancelWrite();

        // Finishes use of the locked media.
        [DispId(0x204)]
        void ReleaseMedia();

        // Sets the write speed (in sectors per second) of the attached disc recorder
        [DispId(0x205)]
        void SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV);

        // The disc recorder to use
        [DispId(0x100)]
        IDiscRecorder2 Recorder { set; get; }

        // Buffer Underrun Free recording should be disabled
        [DispId(0x102)]
        bool BufferUnderrunFreeDisabled { set; get; }

        // The first sector of the next session.  May be negative for blank media
        [DispId(0x103)]
        int StartOfNextSession { get; }

        // The last possible start for the leadout area.  Can be used to 
        // calculate available space on media
        [DispId(260)]
        int LastPossibleStartOfLeadout { get; }

        // Get the current physical media type
        [DispId(0x105)]
        IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

        // Supported data sector types for the current recorder
        [DispId(0x108)]
        object[] SupportedSectorTypes { get; }

        // Requested data sector to use during write of the stream
        [DispId(0x109)]
        IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE RequestedSectorType { set; get; }

        // The friendly name of the client (used to determine recorder reservation conflicts).
        [DispId(0x10a)]
        string ClientName { set; get; }

        // The last requested write speed
        [DispId(0x10b)]
        int RequestedWriteSpeed { get; }

        // The last requested rotation type.
        [DispId(0x10c)]
        bool RequestedRotationTypeIsPureCAV { get; }

        // The drive's current write speed.
        [DispId(0x10d)]
        int CurrentWriteSpeed { get; }

        // The drive's current rotation type
        [DispId(270)]
        bool CurrentRotationTypeIsPureCAV { get; }

        // Gets an array of the write speeds supported for the attached disc 
        // recorder and current media
        [DispId(0x10f)]
        object[] SupportedWriteSpeeds { get; }

        // Gets an array of the detailed write configurations supported for the 
        // attached disc recorder and current media
        [DispId(0x110)]
        object[] SupportedWriteSpeedDescriptors { get; }
    }

    /// <summary>
    /// CD Disc-At-Once RAW Writer Event Arguments
    /// </summary>
    [ComImport, Guid("27354143-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscFormat2RawCDEventArgs
    {
        //
        // IWriteEngine2EventArgs
        //

        // The starting logical block address for the current write operation.
        [DispId(0x100)]
        int StartLba { get; }

        // The number of sectors being written for the current write operation.
        [DispId(0x101)]
        int SectorCount { get; }

        // The last logical block address of data read for the current write operation.
        [DispId(0x102)]
        int LastReadLba { get; }

        // The last logical block address of data written for the current write operation
        [DispId(0x103)]
        int LastWrittenLba { get; }

        // The total bytes available in the system's cache buffer
        [DispId(0x106)]
        int TotalSystemBuffer { get; }

        // The used bytes in the system's cache buffer
        [DispId(0x107)]
        int UsedSystemBuffer { get; }

        // The free bytes in the system's cache buffer
        [DispId(0x108)]
        int FreeSystemBuffer { get; }

        //
        // IDiscFormat2RawCDEventArgs
        //

        // The current write action
        [DispId(0x301)]
        IMAPI_FORMAT2_RAW_CD_WRITE_ACTION CurrentAction { get; }

        // The elapsed time for the current track write or media finishing operation
        [DispId(770)]
        int ElapsedTime { get; }

        // The estimated time remaining for the current track write or media finishing operation
        [DispId(0x303)]
        int RemainingTime { get; }
    }

    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [ComImport]
    [Guid("27354154-8F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscFormat2TrackAtOnce
    {
        //
        // IDiscFormat2
        //

        // Determines if the recorder object supports the given format
        [DispId(0x800)]
        bool IsRecorderSupported(IDiscRecorder2 Recorder);

        // Determines if the current media in a supported recorder object supports the given format
        [DispId(0x801)]
        bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

        // Determines if the current media is reported as physically blank by the drive
        [DispId(0x700)]
        bool MediaPhysicallyBlank { get; }

        // Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media)
        [DispId(0x701)]
        bool MediaHeuristicallyBlank { get; }

        // Supported media types
        [DispId(0x702)]
        object[] SupportedMediaTypes { get; }

        //
        // IDiscFormat2TrackAtOnce
        //

        // Locks the current media for use by this writer.
        [DispId(0x200)]
        void PrepareMedia();

        // Immediately writes a new audio track to the locked media
        [DispId(0x201)]
        void AddAudioTrack(IStream data);

        // Cancels the current addition of a track
        [DispId(0x202)]
        void CancelAddTrack();

        // Finishes use of the locked media
        [DispId(0x203)]
        void ReleaseMedia();

        // Sets the write speed (in sectors per second) of the attached disc recorder
        [DispId(0x204)]
        void SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV);

        // The disc recorder to use
        [DispId(0x100)]
        IDiscRecorder2 Recorder { set; get; }

        // Buffer Underrun Free recording should be disabled
        [DispId(0x102)]
        bool BufferUnderrunFreeDisabled { set; get; }

        // Number of tracks already written to the locked media
        [DispId(0x103)]
        int NumberOfExistingTracks { get; }

        // Total sectors available on locked media if writing one continuous audio track
        [DispId(260)]
        int TotalSectorsOnMedia { get; }

        // Number of sectors available for adding a new track to the media
        [DispId(0x105)]
        int FreeSectorsOnMedia { get; }

        // Number of sectors used on the locked media, including overhead (space between tracks)
        [DispId(0x106)]
        int UsedSectorsOnMedia { get; }

        // Set the media to be left 'open' after writing, to allow multisession discs
        [DispId(0x107)]
        bool DoNotFinalizeMedia { set; get; }

        // Get the current physical media type
        [DispId(0x10a)]
        object[] ExpectedTableOfContents { get; }

        // Get the current physical media type
        [DispId(0x10b)]
        IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

        // The friendly name of the client (used to determine recorder reservation conflicts)
        [DispId(270)]
        string ClientName { set; get; }

        // The last requested write speed
        [DispId(0x10f)]
        int RequestedWriteSpeed { get; }

        // The last requested rotation type.
        [DispId(0x110)]
        bool RequestedRotationTypeIsPureCAV { get; }

        // The drive's current write speed.
        [DispId(0x111)]
        int CurrentWriteSpeed { get; }

        // The drive's current rotation type.
        [DispId(0x112)]
        bool CurrentRotationTypeIsPureCAV { get; }

        // Gets an array of the write speeds supported for the attached disc recorder and current media
        [DispId(0x113)]
        object[] SupportedWriteSpeeds { get; }

        // Gets an array of the detailed write configurations supported for the attached disc recorder and current media
        [DispId(0x114)]
        object[] SupportedWriteSpeedDescriptors { get; }
    }


    /// <summary>
    /// CD Track-at-once Audio Writer Event Arguments
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("27354140-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscFormat2TrackAtOnceEventArgs
    {
        //
        // IWriteEngine2EventArgs
        //

        // The starting logical block address for the current write operation.
        [DispId(0x100)]
        int StartLba { get; }

        // The number of sectors being written for the current write operation.
        [DispId(0x101)]
        int SectorCount { get; }

        // The last logical block address of data read for the current write operation.
        [DispId(0x102)]
        int LastReadLba { get; }

        // The last logical block address of data written for the current write operation
        [DispId(0x103)]
        int LastWrittenLba { get; }

        // The total bytes available in the system's cache buffer
        [DispId(0x106)]
        int TotalSystemBuffer { get; }

        // The used bytes in the system's cache buffer
        [DispId(0x107)]
        int UsedSystemBuffer { get; }

        // The free bytes in the system's cache buffer
        [DispId(0x108)]
        int FreeSystemBuffer { get; }

        //
        // IDiscFormat2TrackAtOnceEventArgs
        //

        // The total elapsed time for the current write operation
        [DispId(0x300)]
        int CurrentTrackNumber { get; }

        // The current write action
        [DispId(0x301)]
        IMAPI_FORMAT2_TAO_WRITE_ACTION CurrentAction { get; }

        // The elapsed time for the current track write or media finishing operation
        [DispId(770)]
        int ElapsedTime { get; }

        // The estimated time remaining for the current track write or media finishing operation
        [DispId(0x303)]
        int RemainingTime { get; }
    }

    /// <summary>
    /// IDiscMaster2 is used to get an enumerator for the set of CD/DVD (optical) devices on the system
    /// </summary>
    [ComImport]
    [Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscMaster2
    {
        // Enumerates the list of CD/DVD devices on the system (VT_BSTR)
        [DispId(-4), TypeLibFunc((short)0x41)]
        IEnumerator GetEnumerator();

        // Gets a single recorder's ID (ZERO BASED INDEX)
        [DispId(0)]
        string this[int index] { get; }

        // The current number of recorders in the system.
        [DispId(1)]
        int Count { get; }

        // Whether IMAPI is running in an environment with optical devices and permission to access them.
        [DispId(2)]
        bool IsSupportedEnvironment { get; }
    }

    /// <summary>
    ///  Represents a single CD/DVD type device, and enables many common operations via a simplified API.
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("27354133-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscRecorder2
    {
        // Ejects the media (if any) and opens the tray
        [DispId(0x100)]
        void EjectMedia();

        // Close the media tray and load any media in the tray.
        [DispId(0x101)]
        void CloseTray();

        // Acquires exclusive access to device.  May be called multiple times.
        [DispId(0x102)]
        void AcquireExclusiveAccess(bool force, string clientName);

        // Releases exclusive access to device.  Call once per AcquireExclusiveAccess().
        [DispId(0x103)]
        void ReleaseExclusiveAccess();

        // Disables Media Change Notification (MCN).
        [DispId(260)]
        void DisableMcn();

        // Re-enables Media Change Notification after a call to DisableMcn()
        [DispId(0x105)]
        void EnableMcn();

        // Initialize the recorder, opening a handle to the specified recorder.
        [DispId(0x106)]
        void InitializeDiscRecorder(string recorderUniqueId);

        // The unique ID used to initialize the recorder.
        [DispId(0)]
        string ActiveDiscRecorder { get; }

        // The vendor ID in the device's INQUIRY data.
        [DispId(0x201)]
        string VendorId { get; }

        // The Product ID in the device's INQUIRY data.
        [DispId(0x202)]
        string ProductId { get; }

        // The Product Revision in the device's INQUIRY data.
        [DispId(0x203)]
        string ProductRevision { get; }

        // Get the unique volume name (this is not a drive letter).
        [DispId(0x204)]
        string VolumeName { get; }

        // Drive letters and NTFS mount points to access the recorder.
        [DispId(0x205)]
        object[] VolumePathNames { [DispId(0x205)] get; }

        // One of the volume names associated with the recorder.
        [DispId(0x206)]
        bool DeviceCanLoadMedia { [DispId(0x206)] get; }

        // Gets the legacy 'device number' associated with the recorder.  This number is not guaranteed to be static.
        [DispId(0x207)]
        int LegacyDeviceNumber { [DispId(0x207)] get; }

        // Gets a list of all feature pages supported by the device
        [DispId(520)]
        object[] SupportedFeaturePages { [DispId(520)] get; }

        // Gets a list of all feature pages with 'current' bit set to true
        [DispId(0x209)]
        object[] CurrentFeaturePages { [DispId(0x209)] get; }

        // Gets a list of all profiles supported by the device
        [DispId(0x20a)]
        object[] SupportedProfiles { [DispId(0x20a)] get; }

        // Gets a list of all profiles with 'currentP' bit set to true
        [DispId(0x20b)]
        object[] CurrentProfiles { [DispId(0x20b)] get; }

        // Gets a list of all MODE PAGES supported by the device
        [DispId(0x20c)]
        object[] SupportedModePages { [DispId(0x20c)] get; }

        // Queries the device to determine who, if anyone, has acquired exclusive access
        [DispId(0x20d)]
        string ExclusiveAccessOwner { [DispId(0x20d)] get; }
    }


    /// <summary>
    /// Represents a single CD/DVD type device, enabling additional commands requiring advanced marshalling code
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
        void GetTrackInformation(uint address, IMAPI_READ_TRACK_ADDRESS_TYPE addressType, out IntPtr trackInformation, ref uint byteSize);

        // Gets a feature's data from a GET_CONFIGURATION command
        void GetFeaturePage(IMAPI_FEATURE_PAGE_TYPE requestedFeature, sbyte currentFeatureOnly, out IntPtr featureData, ref uint byteSize);

        // Gets data from a MODE_SENSE10 command
        void GetModePage(IMAPI_MODE_PAGE_TYPE requestedModePage, IMAPI_MODE_PAGE_REQUEST_TYPE requestType, out IntPtr modePageData, ref uint byteSize);

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
        void GetSupportedModePages(IMAPI_MODE_PAGE_REQUEST_TYPE requestType, out IntPtr modePageTypes, out uint validPages);

        // The byte alignment requirement mask for this device.
        uint GetByteAlignmentMask();

        // The maximum non-page-aligned transfer size for this device.
        uint GetMaximumNonPageAlignedTransferSize();

        // The maximum non-page-aligned transfer size for this device.
        uint GetMaximumPageAlignedTransferSize();
    }

    /// <summary>
    /// FileSystemImage item enumerator
    /// </summary>
    [Guid("2C941FDA-975B-59BE-A960-9A2A262853A5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumFsiItems
    {
        // Note: not listed in COM Interface, but it is in Interop.cs
        void Next(uint celt, out IFsiItem rgelt, out uint pceltFetched);

        // Remoting support for Next (allow NULL pointer for item count when requesting single item)
        void RemoteNext(uint celt, out IFsiItem rgelt, out uint pceltFetched);

        // Skip items in the enumeration
        void Skip(uint celt);

        // Reset the enumerator
        void Reset();

        // Make a copy of the enumerator
        void Clone(out IEnumFsiItems ppEnum);
    }

    /// <summary>
    /// FileSystemImageResult progress item enumerator
    /// </summary>
    [Guid("2C941FD6-975B-59BE-A960-9A2A262853A5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumProgressItems
    {
        // Not in COM, but is in Interop.cs
        void Next(uint celt, out IProgressItem rgelt, out uint pceltFetched);

        // Remoting support for Next (allow NULL pointer for item count when requesting single item)
        void RemoteNext(uint celt, out IProgressItem rgelt, out uint pceltFetched);

        // Skip items in the enumeration
        void Skip(uint celt);

        // Reset the enumerator
        void Reset();

        // Make a copy of the enumerator
        void Clone(out IEnumProgressItems ppEnum);
    }

    /// <summary>
    /// File system image
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("2C941FE1-975B-59BE-A960-9A2A262853A5")]
    public interface IFileSystemImage
    {
        // Root directory item
        [DispId(0)]
        IFsiDirectoryItem Root { get; }

        // Disc start block for the image
        [DispId(1)]
        int SessionStartBlock { get; set; }

        // Maximum number of blocks available for the image
        [DispId(2)]
        int FreeMediaBlocks { get; set; }

        // Set maximum number of blocks available based on the recorder 
        // supported discs. 0 for unknown maximum may be set.
        [DispId(0x24)]
        void SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder);

        // Number of blocks in use
        [DispId(3)]
        int UsedBlocks { get; }

        // Volume name
        [DispId(4)]
        string VolumeName { get; set; }

        // Imported Volume name
        [DispId(5)]
        string ImportedVolumeName { get; }

        // Boot image and boot options
        [DispId(6)]
        IBootOptions BootImageOptions { get; set; }

        // Number of files in the image
        [DispId(7)]
        int FileCount { get; }

        // Number of directories in the image
        [DispId(8)]
        int DirectoryCount { get; }

        // Temp directory for stash files
        [DispId(9)]
        string WorkingDirectory { get; set; }

        // Change point identifier
        [DispId(10)]
        int ChangePoint { get; }

        // Strict file system compliance option
        [DispId(11)]
        bool StrictFileSystemCompliance { get; set; }

        // If true, indicates restricted character set is being used for file and directory names
        [DispId(12)]
        bool UseRestrictedCharacterSet { get; set; }

        // File systems to create
        [DispId(13)]
        FsiFileSystems FileSystemsToCreate { get; set; }

        // File systems supported
        [DispId(14)]
        FsiFileSystems FileSystemsSupported { get; }

        // UDF revision
        [DispId(0x25)]
        int UDFRevision { set; get; }

        // UDF revision(s) supported
        [DispId(0x1f)]
        object[] UDFRevisionsSupported { get; }

        // Select filesystem types and image size based on the current media
        [DispId(0x20)]
        void ChooseImageDefaults(IDiscRecorder2 discRecorder);

        // Select filesystem types and image size based on the media type
        [DispId(0x21)]
        void ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value);

        // ISO compatibility level to create
        [DispId(0x22)]
        int ISO9660InterchangeLevel { set; get; }

        // ISO compatibility level(s) supported
        [DispId(0x26)]
        object[] ISO9660InterchangeLevelsSupported { get; }

        // Create result image stream
        [DispId(15)]
        IFileSystemImageResult CreateResultImage();

        // Check for existance an item in the file system
        [DispId(0x10)]
        FsiItemType Exists(string FullPath);

        // Return a string useful for identifying the current disc
        [DispId(0x12)]
        string CalculateDiscIdentifier();

        // Identify file systems on a given disc
        [DispId(0x13)]
        FsiFileSystems IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder);

        // Identify which of the specified file systems would be imported by default
        [DispId(20)]
        FsiFileSystems GetDefaultFileSystemForImport(FsiFileSystems fileSystems);

        // Import the default file system on the current disc
        [DispId(0x15)]
        FsiFileSystems ImportFileSystem();

        // Import a specific file system on the current disc
        [DispId(0x16)]
        void ImportSpecificFileSystem(FsiFileSystems fileSystemToUse);

        // Roll back to the specified change point
        [DispId(0x17)]
        void RollbackToChangePoint(int ChangePoint);

        // Lock in changes
        [DispId(0x18)]
        void LockInChangePoint();

        // Create a directory item with the specified name
        [DispId(0x19)]
        IFsiDirectoryItem CreateDirectoryItem(string Name);

        // Create a file item with the specified name
        [DispId(0x1a)]
        IFsiFileItem CreateFileItem(string Name);

        // Volume Name UDF
        [DispId(0x1b)]
        string VolumeNameUDF { get; }

        // Volume name Joliet
        [DispId(0x1c)]
        string VolumeNameJoliet { get; }

        // Volume name ISO 9660
        [DispId(0x1d)]
        string VolumeNameISO9660 { get; }

        // Indicates whether or not IMAPI should stage the filesystem before the burn
        [DispId(30)]
        bool StageFiles { get; set; }

        // Get array of available multi-session interfaces.
        [DispId(40)]
        object[] MultisessionInterfaces { get; set; }
    }

    /// <summary>
    /// File system image (rev.2)
    /// </summary>
    [ComImport]
    [Guid("D7644B2C-1537-4767-B62F-F1387B02DDFD")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFileSystemImage2
    {
        //
        // IFileSystemImage
        //

        // Root directory item
        [DispId(0)]
        IFsiDirectoryItem Root { get; }

        // Disc start block for the image
        [DispId(1)]
        int SessionStartBlock { get; set; }

        // Maximum number of blocks available for the image
        [DispId(2)]
        int FreeMediaBlocks { get; set; }

        // Set maximum number of blocks available based on the recorder 
        // supported discs. 0 for unknown maximum may be set.
        [DispId(0x24)]
        void SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder);

        // Number of blocks in use
        [DispId(3)]
        int UsedBlocks { get; }

        // Volume name
        [DispId(4)]
        string VolumeName { get; set; }

        // Imported Volume name
        [DispId(5)]
        string ImportedVolumeName { get; }

        // Boot image and boot options
        [DispId(6)]
        IBootOptions BootImageOptions { get; set; }

        // Number of files in the image
        [DispId(7)]
        int FileCount { get; }

        // Number of directories in the image
        [DispId(8)]
        int DirectoryCount { get; }

        // Temp directory for stash files
        [DispId(9)]
        string WorkingDirectory { get; set; }

        // Change point identifier
        [DispId(10)]
        int ChangePoint { get; }

        // Strict file system compliance option
        [DispId(11)]
        bool StrictFileSystemCompliance { get; set; }

        // If true, indicates restricted character set is being used for file and directory names
        [DispId(12)]
        bool UseRestrictedCharacterSet { get; set; }

        // File systems to create
        [DispId(13)]
        FsiFileSystems FileSystemsToCreate { get; set; }

        // File systems supported
        [DispId(14)]
        FsiFileSystems FileSystemsSupported { get; }

        // UDF revision
        [DispId(0x25)]
        int UDFRevision { set; get; }

        // UDF revision(s) supported
        [DispId(0x1f)]
        object[] UDFRevisionsSupported { get; }

        // Select filesystem types and image size based on the current media
        [DispId(0x20)]
        void ChooseImageDefaults(IDiscRecorder2 discRecorder);

        // Select filesystem types and image size based on the media type
        [DispId(0x21)]
        void ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value);

        // ISO compatibility level to create
        [DispId(0x22)]
        int ISO9660InterchangeLevel { set; get; }

        // ISO compatibility level(s) supported
        [DispId(0x26)]
        object[] ISO9660InterchangeLevelsSupported { get; }

        // Create result image stream
        [DispId(15)]
        IFileSystemImageResult CreateResultImage();

        // Check for existance an item in the file system
        [DispId(0x10)]
        FsiItemType Exists(string FullPath);

        // Return a string useful for identifying the current disc
        [DispId(0x12)]
        string CalculateDiscIdentifier();

        // Identify file systems on a given disc
        [DispId(0x13)]
        FsiFileSystems IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder);

        // Identify which of the specified file systems would be imported by default
        [DispId(20)]
        FsiFileSystems GetDefaultFileSystemForImport(FsiFileSystems fileSystems);

        // Import the default file system on the current disc
        [DispId(0x15)]
        FsiFileSystems ImportFileSystem();

        // Import a specific file system on the current disc
        [DispId(0x16)]
        void ImportSpecificFileSystem(FsiFileSystems fileSystemToUse);

        // Roll back to the specified change point
        [DispId(0x17)]
        void RollbackToChangePoint(int ChangePoint);

        // Lock in changes
        [DispId(0x18)]
        void LockInChangePoint();

        // Create a directory item with the specified name
        [DispId(0x19)]
        IFsiDirectoryItem CreateDirectoryItem(string Name);

        // Create a file item with the specified name
        [DispId(0x1a)]
        IFsiFileItem CreateFileItem(string Name);

        // Volume Name UDF
        [DispId(0x1b)]
        string VolumeNameUDF { get; }

        // Volume name Joliet
        [DispId(0x1c)]
        string VolumeNameJoliet { get; }

        // Volume name ISO 9660
        [DispId(0x1d)]
        string VolumeNameISO9660 { get; }

        // Indicates whether or not IMAPI should stage the filesystem before the burn
        [DispId(30)]
        bool StageFiles { get; set; }

        // Get array of available multi-session interfaces.
        [DispId(40)]
        object[] MultisessionInterfaces { get; set; }

        //
        // IFileSystemImage2
        //

        // Get boot options array for supporting multi-boot
        [DispId(60)]
        object[] BootImageOptionsArray { get; set; }
    }

    /// <summary>
    /// File system image (rev.3)"),
    /// </summary>
    [ComImport]
    [Guid("7CFF842C-7E97-4807-8304-910DD8F7C051")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFileSystemImage3
    {
        //
        // IFileSystemImage
        //

        // Root directory item
        [DispId(0)]
        IFsiDirectoryItem Root { get; }

        // Disc start block for the image
        [DispId(1)]
        int SessionStartBlock { get; set; }

        // Maximum number of blocks available for the image
        [DispId(2)]
        int FreeMediaBlocks { get; set; }

        // Set maximum number of blocks available based on the recorder 
        // supported discs. 0 for unknown maximum may be set.
        [DispId(0x24)]
        void SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder);

        // Number of blocks in use
        [DispId(3)]
        int UsedBlocks { get; }

        // Volume name
        [DispId(4)]
        string VolumeName { get; set; }

        // Imported Volume name
        [DispId(5)]
        string ImportedVolumeName { get; }

        // Boot image and boot options
        [DispId(6)]
        IBootOptions BootImageOptions { get; set; }

        // Number of files in the image
        [DispId(7)]
        int FileCount { get; }

        // Number of directories in the image
        [DispId(8)]
        int DirectoryCount { get; }

        // Temp directory for stash files
        [DispId(9)]
        string WorkingDirectory { get; set; }

        // Change point identifier
        [DispId(10)]
        int ChangePoint { get; }

        // Strict file system compliance option
        [DispId(11)]
        bool StrictFileSystemCompliance { get; set; }

        // If true, indicates restricted character set is being used for file and directory names
        [DispId(12)]
        bool UseRestrictedCharacterSet { get; set; }

        // File systems to create
        [DispId(13)]
        FsiFileSystems FileSystemsToCreate { get; set; }

        // File systems supported
        [DispId(14)]
        FsiFileSystems FileSystemsSupported { get; }

        // UDF revision
        [DispId(0x25)]
        int UDFRevision { set; get; }

        // UDF revision(s) supported
        [DispId(0x1f)]
        object[] UDFRevisionsSupported { get; }

        // Select filesystem types and image size based on the current media
        [DispId(0x20)]
        void ChooseImageDefaults(IDiscRecorder2 discRecorder);

        // Select filesystem types and image size based on the media type
        [DispId(0x21)]
        void ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value);

        // ISO compatibility level to create
        [DispId(0x22)]
        int ISO9660InterchangeLevel { set; get; }

        // ISO compatibility level(s) supported
        [DispId(0x26)]
        object[] ISO9660InterchangeLevelsSupported { get; }

        // Create result image stream
        [DispId(15)]
        IFileSystemImageResult CreateResultImage();

        // Check for existance an item in the file system
        [DispId(0x10)]
        FsiItemType Exists(string FullPath);

        // Return a string useful for identifying the current disc
        [DispId(0x12)]
        string CalculateDiscIdentifier();

        // Identify file systems on a given disc
        [DispId(0x13)]
        FsiFileSystems IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder);

        // Identify which of the specified file systems would be imported by default
        [DispId(20)]
        FsiFileSystems GetDefaultFileSystemForImport(FsiFileSystems fileSystems);

        // Import the default file system on the current disc
        [DispId(0x15)]
        FsiFileSystems ImportFileSystem();

        // Import a specific file system on the current disc
        [DispId(0x16)]
        void ImportSpecificFileSystem(FsiFileSystems fileSystemToUse);

        // Roll back to the specified change point
        [DispId(0x17)]
        void RollbackToChangePoint(int ChangePoint);

        // Lock in changes
        [DispId(0x18)]
        void LockInChangePoint();

        // Create a directory item with the specified name
        [DispId(0x19)]
        IFsiDirectoryItem CreateDirectoryItem(string Name);

        // Create a file item with the specified name
        [DispId(0x1a)]
        IFsiFileItem CreateFileItem(string Name);

        // Volume Name UDF
        [DispId(0x1b)]
        string VolumeNameUDF { get; }

        // Volume name Joliet
        [DispId(0x1c)]
        string VolumeNameJoliet { get; }

        // Volume name ISO 9660
        [DispId(0x1d)]
        string VolumeNameISO9660 { get; }

        // Indicates whether or not IMAPI should stage the filesystem before the burn
        [DispId(30)]
        bool StageFiles { get; set; }

        // Get array of available multi-session interfaces.
        [DispId(40)]
        object[] MultisessionInterfaces { get; set; }

        //
        // IFileSystemImage2
        //

        // Get boot options array for supporting multi-boot
        [DispId(60)]
        object[] BootImageOptionsArray { get; set; }

        //
        // IFileSystemImage3
        //

        // If true, indicates that UDF Metadata and Metadata Mirror files are truly redundant,
        // i.e. reference different extents
        [DispId(0x3d)]
        bool CreateRedundantUdfMetadataFiles { get; set; }

        // Probe if a specific file system on the disc is appendable through IMAPI
        [DispId(70)]
        bool ProbeSpecificFileSystem(FsiFileSystems fileSystemToProbe);
    }

    /// <summary>
    /// FileSystemImage result stream
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("2C941FD8-975B-59BE-A960-9A2A262853A5")]
    public interface IFileSystemImageResult
    {
        // Image stream
        [DispId(1)]
        IStream ImageStream { get; }

        // Progress item block mapping collection
        [DispId(2)]
        IProgressItems ProgressItems { get; }

        // Number of blocks in the result image
        [DispId(3)]
        int TotalBlocks { get; }

        // Number of bytes in a block
        [DispId(4)]
        int BlockSize { get; }

        // Disc Identifier (for identifing imported session of multi-session disc)
        [DispId(5)]
        string DiscId { get; }
    }

    [Guid("2C941FDC-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiDirectoryItem
    {
        //
        // IFsiItem
        //

        // Item name
        [DispId(11)]
        string Name { get; }

        // Full path
        [DispId(12)]
        string FullPath { get; }

        // Date and time of creation
        [DispId(13)]
        DateTime CreationTime { get; set; }

        // Date and time of last access
        [DispId(14)]
        DateTime LastAccessedTime { get; set; }

        // Date and time of last modification
        [DispId(15)]
        DateTime LastModifiedTime { get; set; }

        // Flag indicating if item is hidden
        [DispId(0x10)]
        bool IsHidden { get; set; }

        // Name of item in the specified file system
        [DispId(0x11)]
        string FileSystemName(FsiFileSystems fileSystem);

        // Name of item in the specified file system
        [DispId(0x12)]
        string FileSystemPath(FsiFileSystems fileSystem);

        //
        // IFsiDirectoryItem
        //

        // Get an enumerator for the collection
        [TypeLibFunc((short)0x41), DispId(-4)]
        IEnumerator GetEnumerator();

        // Get the item with the given relative path
        [DispId(0)]
        IFsiItem this[string path] { get; }

        // Number of items in the collection
        [DispId(1)]
        int Count { get; }

        // Get a non-variant enumerator
        [DispId(2)]
        IEnumFsiItems EnumFsiItems { get; }

        // Add a directory with the specified relative path
        [DispId(30)]
        void AddDirectory(string path);

        // Add a file with the specified relative path and data
        [DispId(0x1f)]
        void AddFile(string path, IStream fileData);

        // Add files and directories from the specified source directory
        [DispId(0x20)]
        void AddTree(string sourceDirectory, bool includeBaseDirectory);

        // Add an item
        [DispId(0x21)]
        void Add(IFsiItem Item);

        // Remove an item with the specified relative path
        [DispId(0x22)]
        void Remove(string path);

        // Remove a subtree with the specified relative path
        [DispId(0x23)]
        void RemoveTree(string path);
    }

    /// <summary>
    /// FileSystemImage directory item (rev.2)
    /// </summary>
    [ComImport]
    [Guid("F7FB4B9B-6D96-4D7B-9115-201B144811EF")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiDirectoryItem2 : IFsiDirectoryItem
    {
        // Add files and directories from the specified source directory including named streams
        [DispId(0x24)]
        void AddTreeWithNamedStreams(string sourceDirectory, bool includeBaseDirectory);
    }

    /// <summary>
    /// FileSystemImage file item
    /// </summary>
    [Guid("2C941FDB-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiFileItem
    {
        //
        // IFsiItem
        //

        // Item name
        [DispId(11)]
        string Name { get; }

        // Full path
        [DispId(12)]
        string FullPath { get; }

        // Date and time of creation
        [DispId(13)]
        DateTime CreationTime { get; set; }

        // Date and time of last access
        [DispId(14)]
        DateTime LastAccessedTime { get; set; }

        // Date and time of last modification
        [DispId(15)]
        DateTime LastModifiedTime { get; set; }

        // Flag indicating if item is hidden
        [DispId(0x10)]
        bool IsHidden { get; set; }

        // Name of item in the specified file system
        [DispId(0x11)]
        string FileSystemName(FsiFileSystems fileSystem);

        // Name of item in the specified file system
        [DispId(0x12)]
        string FileSystemPath(FsiFileSystems fileSystem);

        //
        // IFsiFileItem
        //

        // Data byte count
        [DispId(0x29)]
        long DataSize { get; }

        // Lower 32 bits of the data byte count
        [DispId(0x2a)]
        int DataSize32BitLow { get; }

        // Upper 32 bits of the data byte count
        [DispId(0x2b)]
        int DataSize32BitHigh { get; }

        // Data stream
        [DispId(0x2c)]
        IStream Data { get; set; }
    }

    /// <summary>
    /// FileSystemImage file item (rev.2)
    /// </summary>
    [ComImport]
    [Guid("199D0C19-11E1-40EB-8EC2-C8C822A07792")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiFileItem2
    {
        //
        // IFsiItem
        //

        // Item name
        [DispId(11)]
        string Name { get; }

        // Full path
        [DispId(12)]
        string FullPath { get; }

        // Date and time of creation
        [DispId(13)]
        DateTime CreationTime { get; set; }

        // Date and time of last access
        [DispId(14)]
        DateTime LastAccessedTime { get; set; }

        // Date and time of last modification
        [DispId(15)]
        DateTime LastModifiedTime { get; set; }

        // Flag indicating if item is hidden
        [DispId(0x10)]
        bool IsHidden { get; set; }

        // Name of item in the specified file system
        [DispId(0x11)]
        string FileSystemName(FsiFileSystems fileSystem);

        // Name of item in the specified file system
        [DispId(0x12)]
        string FileSystemPath(FsiFileSystems fileSystem);

        //
        // IFsiFileItem
        //

        // Data byte count
        [DispId(0x29)]
        long DataSize { get; }

        // Lower 32 bits of the data byte count
        [DispId(0x2a)]
        int DataSize32BitLow { get; }

        // Upper 32 bits of the data byte count
        [DispId(0x2b)]
        int DataSize32BitHigh { get; }

        // Data stream
        [DispId(0x2c)]
        IStream Data { get; set; }

        //
        // IFsiFileItem2
        //

        // Get the list of the named streams of the file
        [DispId(0x2d)]
        FsiNamedStreams FsiNamedStreams { get; }

        // Flag indicating if file item is a named stream of a file
        [DispId(0x2e)]
        bool IsNamedStream { get; }

        // Add a new named stream to the collection
        [DispId(0x2f)]
        void AddStream(string Name, FsiStream streamData);

        // Remove a specific named stream from the collection
        [DispId(0x30)]
        void RemoveStream(string Name);

        // Flag indicating if file is Real-Time
        [DispId(0x31)]
        bool IsRealTime { get; set; }
    }

    /// <summary>
    /// FileSystemImage item
    /// </summary>
    [Guid("2C941FD9-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiItem
    {
        // Item name
        [DispId(11)]
        string Name { get; }

        // Full path
        [DispId(12)]
        string FullPath { get; }

        // Date and time of creation
        [DispId(13)]
        DateTime CreationTime { get; set; }

        // Date and time of last access
        [DispId(14)]
        DateTime LastAccessedTime { get; set; }

        // Date and time of last modification
        [DispId(15)]
        DateTime LastModifiedTime { get; set; }

        // Flag indicating if item is hidden
        [DispId(0x10)]
        bool IsHidden { get; set; }

        // Name of item in the specified file system
        [DispId(0x11)]
        string FileSystemName(FsiFileSystems fileSystem);

        // Name of item in the specified file system
        [DispId(0x12)]
        string FileSystemPath(FsiFileSystems fileSystem);
    }

    /// <summary>
    /// Named stream collection
    /// </summary>
    [ComImport]
    [Guid("ED79BA56-5294-4250-8D46-F9AECEE23459")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiNamedStreams : IEnumerable
    {
        // Get a named stream from the collection
        [DispId(0)]
        FsiFileItem this[int Index] { get; }

        // Number of named streams in the collection
        [DispId(0x51)]
        int Count { [DispId(0x51)] get; }

        // Get a non-variant enumerator for the named stream collection
        [DispId(0x52)]
        EnumFsiItems EnumNamedStreams { get; }
    }

    /// <summary>
    /// ISO Image Manager: Helper object for ISO image file manipulation
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [Guid("6CA38BE5-FBBB-4800-95A1-A438865EB0D4")]
    public interface IIsoImageManager
    {
        // Path to the ISO image file
        [DispId(0x100)]
        string path { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

        // Stream from the ISO image
        [DispId(0x101)]
        FsiStream Stream { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

        // Set path to the ISO image file, overwrites stream
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetPath(string Val);

        // Set stream from the ISO image, overwrites path
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetStream([In, MarshalAs(UnmanagedType.Interface)] FsiStream Data);

        // Validate if the ISO image file is a valid file
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Validate();
    }

    [ComImport]
    [Guid("27354150-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IMultisession
    {
        // Is it possible to write this multi-session type on the current media in its present state
        [DispId(0x100)]
        bool IsSupportedOnCurrentMediaState { get; }

        // Is this multi-session type the one to use on current media
        [DispId(0x101)]
        bool InUse { set; get; }

        // The disc recorder to use to import previous session(s)
        [DispId(0x102)]
        MsftDiscRecorder2 ImportRecorder { get; }
    }

    [ComImport]
    [Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IMultisessionSequential
    {
        //
        // IMultisession
        //
        // Is it possible to write this multi-session type on the current media in its present state
        [DispId(0x100)]
        bool IsSupportedOnCurrentMediaState { get; }

        // Is this multi-session type the one to use on current media
        [DispId(0x101)]
        bool InUse { set; get; }

        // The disc recorder to use to import previous session(s)
        [DispId(0x102)]
        MsftDiscRecorder2 ImportRecorder { get; }

        //
        // IMultisessionSequential
        //

        // Is this the first data session on the media?
        [DispId(0x200)]
        bool IsFirstDataSession { get; }

        // The first sector in the previous session on the media.
        [DispId(0x201)]
        int StartAddressOfPreviousSession { get; }

        // The last sector in the previous session on the media
        [DispId(0x202)]
        int LastWrittenAddressOfPreviousSession { get; }

        // Next writable address on the media (also used sectors).
        [DispId(0x203)]
        int NextWritableAddress { get; }

        // Free sectors available on the media
        [DispId(0x204)]
        int FreeSectorsOnMedia { get; }
    }

    /// <summary>
    /// FileSystemImageResult progress item
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("2C941FD5-975B-59BE-A960-9A2A262853A5")]
    public interface IProgressItem
    {
        // Progress item description
        [DispId(1)]
        string Description { get; }

        // First block in the range of blocks used by the progress item
        [DispId(2)]
        uint FirstBlock { get; }

        // Last block in the range of blocks used by the progress item
        [DispId(3)]
        uint LastBlock { get; }

        // Number of blocks used by the progress item
        [DispId(4)]
        uint BlockCount { get; }
    }

    /// <summary>
    /// FileSystemImageResult progress item
    /// </summary>
    [Guid("2C941FD7-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IProgressItems
    {
        // Get an enumerator for the collection
        [DispId(-4), TypeLibFunc((short)0x41)]
        IEnumerator GetEnumerator();

        // Find the block mapping from the specified index
        [DispId(0)]
        IProgressItem this[int Index] { get; }

        // Number of items in the collection
        [DispId(1)]
        int Count { get; }

        // Find the block mapping from the specified block
        [DispId(2)]
        IProgressItem ProgressItemFromBlock(uint block);

        // Find the block mapping from the specified item description
        [DispId(3)]
        IProgressItem ProgressItemFromDescription(string Description);

        // Get a non-variant enumerator
        [DispId(4)]
        IEnumProgressItems EnumProgressItems { get; }
    }

    [ComImport]
    [Guid("25983550-9D65-49CE-B335-40630D901227")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IRawCDImageCreator
    {
        // Creates the result stream
        [DispId(0x200)]
        IStream CreateResultImage();

        // Adds a track to the media (defaults to audio, always 2352 bytes/sector)
        [DispId(0x201)]
        int AddTrack(IMAPI_CD_SECTOR_TYPE dataType, [In, MarshalAs(UnmanagedType.Interface)] IStream data);

        // Adds a special pregap to the first track, and implies an audio CD
        [DispId(0x202)]
        void AddSpecialPregap([In, MarshalAs(UnmanagedType.Interface)] IStream data);

        // Adds an R-W subcode generation object to supply R-W subcode (i.e. CD-Text or CD-G).
        [DispId(0x203)]
        void AddSubcodeRWGenerator([In, MarshalAs(UnmanagedType.Interface)] IStream subcode);

        [DispId(0x100)]
        IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE ResultingImageType { set; get; }

        // Equal to (final user LBA+1), defines minimum disc size image can be written to.
        [DispId(0x101)]
        int StartOfLeadout { get; }

        // 
        [DispId(0x102)]
        int StartOfLeadoutLimit { set; get; }

        // Disables gapless recording of consecutive audio tracks
        [DispId(0x103)]
        bool DisableGaplessAudio { set; get; }

        // The Media Catalog Number for the CD image
        [DispId(260)]
        string MediaCatalogNumber { set; get; }

        // The starting track number (only for pure audio CDs)
        [DispId(0x105)]
        int StartingTrackNumber { set; get; }

        [DispId(0x106)]
        IRawCDImageTrackInfo this[int trackIndex] { [DispId(0x106)] get; }

        [DispId(0x107)]
        int NumberOfExistingTracks { get; }

        [DispId(0x108)]
        int LastUsedUserSectorInImage { get; }

        [DispId(0x109)]
        object[] ExpectedTableOfContents { get; }
    }

    [ComImport]
    [Guid("25983551-9D65-49CE-B335-40630D901227")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IRawCDImageTrackInfo
    {
        // The LBA of the first user sector in this track
        [DispId(0x100)]
        int StartingLba { get; }

        // The number of user sectors in this track
        [DispId(0x101)]
        int SectorCount { get; }

        // The track number assigned for this track
        [DispId(0x102)]
        int TrackNumber { get; }

        // The type of data being recorded on the current sector.
        [DispId(0x103)]
        IMAPI_CD_SECTOR_TYPE SectorType { get; }

        // The International Standard Recording Code (ISRC) for this track.
        [DispId(260)]
        string ISRC { get; set; }

        // The digital audio copy setting for this track
        [DispId(0x105)]
        IMAPI_CD_TRACK_DIGITAL_COPY_SETTING DigitalAudioCopySetting { get; set; }

        // The audio provided already has preemphasis applied (rare).
        [DispId(0x106)]
        bool AudioHasPreemphasis { get; set; }

        // The list of current track-relative indexes within the CD track.
        [DispId(0x107)]
        object[] TrackIndexes { get; }

        // Add the specified LBA (relative to the start of the track) as an index.
        [DispId(0x200)]
        void AddTrackIndex(int lbaOffset);

        // Removes the specified LBA (relative to the start of the track) as an index.
        [DispId(0x201)]
        void ClearTrackIndex(int lbaOffset);
    }


    /// <summary>
    /// Write Engine
    /// </summary>
    [ComImport]
    [Guid("27354135-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IWriteEngine2
    {
        // Writes data provided in the IStream to the device
        [DispId(0x200)]
        void WriteSection(IStream data, int startingBlockAddress, int numberOfBlocks);

        // Cancels the current write operation
        [DispId(0x201)]
        void CancelWrite();

        // The disc recorder to use
        [DispId(0x100)]
        IDiscRecorder2Ex Recorder { set; get; }

        // If true, uses WRITE12 with the AV bit set to one; else uses WRITE10
        [DispId(0x101)]
        bool UseStreamingWrite12 { set; get; }

        // The approximate number of sectors per second the device can write at
        // the start of the write process.  This is used to optimize sleep time
        // in the write engine.
        [DispId(0x102)]
        int StartingSectorsPerSecond { set; get; }

        // The approximate number of sectors per second the device can write at
        // the end of the write process.  This is used to optimize sleep time 
        // in the write engine.
        [DispId(0x103)]
        int EndingSectorsPerSecond { set; get; }

        // The number of bytes to use for each sector during writing.
        [DispId(260)]
        int BytesPerSector { set; get; }

        // Simple check to see if the object is currently writing to media.
        [DispId(0x105)]
        bool WriteInProgress { get; }
    }

    /// <summary>
    /// CD Write Engine
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("27354136-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface IWriteEngine2EventArgs
    {
        // The starting logical block address for the current write operation.
        [DispId(0x100)]
        int StartLba { get; }

        // The number of sectors being written for the current write operation.
        [DispId(0x101)]
        int SectorCount { get; }

        // The last logical block address of data read for the current write operation.
        [DispId(0x102)]
        int LastReadLba { get; }

        // The last logical block address of data written for the current write operation
        [DispId(0x103)]
        int LastWrittenLba { get; }

        // The total bytes available in the system's cache buffer
        [DispId(0x106)]
        int TotalSystemBuffer { get; }

        // The used bytes in the system's cache buffer
        [DispId(0x107)]
        int UsedSystemBuffer { get; }

        // The free bytes in the system's cache buffer
        [DispId(0x108)]
        int FreeSystemBuffer { get; }
    }

    /// <summary>
    /// A single optical drive Write Speed Configuration
    /// </summary>
    [ComImport]
    [Guid("27354144-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FDual)]
    public interface IWriteSpeedDescriptor
    {
        // The type of media that this descriptor is valid for
        [DispId(0x101)]
        IMAPI_MEDIA_PHYSICAL_TYPE MediaType { get; }

        // Whether or not this descriptor represents a writing configuration that uses 
        // Pure CAV rotation control
        [DispId(0x102)]
        bool RotationTypeIsPureCAV { get; }

        // The maximum speed at which the media will be written in the write configuration 
        // represented by this descriptor
        [DispId(0x103)]
        int WriteSpeed { get; }
    }


    #endregion // Interfaces

    [ComImport]
    [CoClass(typeof(MsftDiscFormat2DataClass))]
    [Guid("27354153-9F64-5B0F-8F00-5D77AFBE261E")]
    public interface MsftDiscFormat2Data : IDiscFormat2Data, DiscFormat2Data_Event
    {
    }

    [ComImport]
    [ComSourceInterfaces("DDiscFormat2DataEvents\0")]
    [Guid("2735412A-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate), ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscFormat2DataClass
    {
    }

    [ComImport]
    [Guid("27354156-8F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftDiscFormat2EraseClass))]
    public interface MsftDiscFormat2Erase : IDiscFormat2Erase, DiscFormat2Erase_Event
    {
    }

    [ComImport]
    [Guid("2735412B-7F64-5B0F-8F00-5D77AFBE261E")]
    [ComSourceInterfaces("DDiscFormat2EraseEvents\0")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate), ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscFormat2EraseClass
    {
    }

    [ComImport]
    [CoClass(typeof(MsftDiscFormat2RawCDClass))]
    [Guid("27354155-8F64-5B0F-8F00-5D77AFBE261E")]
    public interface MsftDiscFormat2RawCD : IDiscFormat2RawCD, DiscFormat2RawCD_Event
    {
    }

    [ComImport]
    [Guid("27354128-7F64-5B0F-8F00-5D77AFBE261E")]
    [ComSourceInterfaces("DDiscFormat2RawCDEvents\0")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscFormat2RawCDClass
    {
    }

    /// <summary>
    /// Microsoft IMAPIv2 Track-at-Once Audio CD Writer
    /// </summary>
    [ComImport]
    [Guid("27354154-8F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftDiscFormat2TrackAtOnceClass))]
    public interface MsftDiscFormat2TrackAtOnce : IDiscFormat2TrackAtOnce, DiscFormat2TrackAtOnce_Event
    {
    }

    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ComSourceInterfaces("DDiscFormat2TrackAtOnceEvents\0")]
    [Guid("27354129-7F64-5B0F-8F00-5D77AFBE261E")]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscFormat2TrackAtOnceClass
    {
    }


    /// <summary>
    /// Microsoft IMAPIv2 Disc Master
    /// </summary>
    [ComImport]
    [Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftDiscMaster2Class))]
    public interface MsftDiscMaster2 : IDiscMaster2 //, DiscMaster2_Event
    {
    }

    [ComImport, ComSourceInterfaces("DDiscMaster2Events\0")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [Guid("2735412E-7F64-5B0F-8F00-5D77AFBE261E")]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscMaster2Class
    {
    }

    [ComImport]
    [CoClass(typeof(MsftDiscRecorder2Class))]
    [Guid("27354133-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface MsftDiscRecorder2 : IDiscRecorder2
    {
    }


    [ComImport]
    [Guid("2735412D-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscRecorder2Class
    {
    }

    [ComImport]
    [Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftMultisessionSequentialClass))]
    public interface MsftMultisessionSequential : IMultisessionSequential
    {
    }

    [ComImport]
    [Guid("27354122-7F64-5B0F-8F00-5D77AFBE261E")]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftMultisessionSequentialClass
    {
    }

    [ComImport]
    [Guid("25983550-9D65-49CE-B335-40630D901227")]
    [CoClass(typeof(MsftRawCDImageCreatorClass))]
    public interface MsftRawCDImageCreator : IRawCDImageCreator
    {
    }

    [ComImport]
    [Guid("25983561-9D65-49CE-B335-40630D901227")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftRawCDImageCreatorClass
    {
    }

    [ComImport]
    [Guid("27354135-7F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftWriteEngine2Class))]
    public interface MsftWriteEngine2 : IWriteEngine2, DWriteEngine2_Event
    {
    }

    [ComImport]
    [Guid("2735412C-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ComSourceInterfaces("DWriteEngine2Events\0")]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftWriteEngine2Class
    {
    }

    [ComImport]
    [CoClass(typeof(MsftWriteSpeedDescriptorClass))]
    [Guid("27354144-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface MsftWriteSpeedDescriptor : IWriteSpeedDescriptor
    {
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("27354123-7F64-5B0F-8F00-5D77AFBE261E")]
    public class MsftWriteSpeedDescriptorClass
    {
    }

    [ComImport]
    [CoClass(typeof(BootOptionsClass))]
    [Guid("2C941FD4-975B-59BE-A960-9A2A262853A5")]
    public interface BootOptions : IBootOptions
    {
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [Guid("2C941FCE-975B-59BE-A960-9A2A262853A5")]
    public class BootOptionsClass
    {
    }

    [ComImport]
    [Guid("2C941FDA-975B-59BE-A960-9A2A262853A5")]
    [CoClass(typeof(EnumFsiItemsClass))]
    public interface EnumFsiItems : IEnumFsiItems
    {
    }

    [ComImport]
    [Guid("2C941FC6-975B-59BE-A960-9A2A262853A5")]
    [ClassInterface(ClassInterfaceType.None)]
    public class EnumFsiItemsClass
    {
    }

    [ComImport]
    [Guid("2C941FD6-975B-59BE-A960-9A2A262853A5")]
    [CoClass(typeof(EnumProgressItemsClass))]
    public interface EnumProgressItems : IEnumProgressItems
    {
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("2C941FCA-975B-59BE-A960-9A2A262853A5")]
    public class EnumProgressItemsClass
    {
    }

    [ComImport]
    [Guid("2C941FD8-975B-59BE-A960-9A2A262853A5")]
    [CoClass(typeof(FileSystemImageResultClass))]
    public interface FileSystemImageResult : IFileSystemImageResult
    {
    }

    [ComImport]
    [Guid("2C941FCC-975B-59BE-A960-9A2A262853A5")]
    [ClassInterface(ClassInterfaceType.None)]
    public class FileSystemImageResultClass
    {
    }

    [ComImport]
    [Guid("F7FB4B9B-6D96-4D7B-9115-201B144811EF")]
    [CoClass(typeof(FsiDirectoryItemClass))]
    public interface FsiDirectoryItem : IFsiDirectoryItem2
    {
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("2C941FC8-975B-59BE-A960-9A2A262853A5")]
    public class FsiDirectoryItemClass
    {
    }

    [ComImport]
    [CoClass(typeof(FsiFileItemClass))]
    [Guid("199D0C19-11E1-40EB-8EC2-C8C822A07792")]
    public interface FsiFileItem : IFsiFileItem2
    {
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("2C941FC7-975B-59BE-A960-9A2A262853A5")]
    public class FsiFileItemClass
    {
    }

    [ComImport]
    [Guid("ED79BA56-5294-4250-8D46-F9AECEE23459")]
    [CoClass(typeof(FsiNamedStreamsClass))]
    public interface FsiNamedStreams : IFsiNamedStreams
    {
    }

    [ComImport]
    [Guid("C6B6F8ED-6D19-44B4-B539-B159B793A32D")]
    [ClassInterface(ClassInterfaceType.None)]
    public class FsiNamedStreamsClass
    {
    }

    [ComImport]
    [Guid("0000000C-0000-0000-C000-000000000046")]
    [CoClass(typeof(FsiStreamClass))]
    public interface FsiStream : IStream
    {
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("2C941FCD-975B-59BE-A960-9A2A262853A5")]
    public class FsiStreamClass
    {
    }

    [ComImport]
    [CoClass(typeof(MsftFileSystemImageClass))]
    [Guid("2C941FE1-975B-59BE-A960-9A2A262853A5")]
    public interface MsftFileSystemImage : IFileSystemImage, DFileSystemImage_Event
    {
    }

    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [Guid("2C941FC5-975B-59BE-A960-9A2A262853A5")]
    [ComSourceInterfaces("DFileSystemImageEvents\0DFileSystemImageImportEvents\0")]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftFileSystemImageClass
    {
    }

    [ComImport]
    [Guid("6CA38BE5-FBBB-4800-95A1-A438865EB0D4")]
    [CoClass(typeof(MsftIsoImageManagerClass))]
    public interface MsftIsoImageManager : IIsoImageManager
    {
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("CEEE3B62-8F56-4056-869B-EF16917E3EFC")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class MsftIsoImageManagerClass
    {
    }

    [ComImport]
    [Guid("2C941FD5-975B-59BE-A960-9A2A262853A5")]
    [CoClass(typeof(ProgressItemClass))]
    public interface ProgressItem : IProgressItem
    {
    }

    [ComImport]
    [Guid("2C941FCB-975B-59BE-A960-9A2A262853A5")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ProgressItemClass
    {
    }

    [ComImport]
    [Guid("2C941FD7-975B-59BE-A960-9A2A262853A5")]
    [CoClass(typeof(ProgressItemsClass))]
    public interface ProgressItems : IProgressItems
    {
    }

    [ComImport]
    [Guid("2C941FC9-975B-59BE-A960-9A2A262853A5")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ProgressItemsClass
    {
    }
}
