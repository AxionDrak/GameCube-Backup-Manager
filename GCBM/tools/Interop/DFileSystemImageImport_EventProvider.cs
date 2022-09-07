using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace GCBM.tools.Interop;

[ClassInterface(ClassInterfaceType.None)]
internal sealed class DFileSystemImageImport_EventProvider : DFileSystemImageImport_Event, IDisposable
{
    // Fields
    private readonly Hashtable m_aEventSinkHelpers = new();
    private readonly IConnectionPoint m_connectionPoint;


    // Methods
    public DFileSystemImageImport_EventProvider(object pointContainer)
    {
        lock (this)
        {
            var eventsGuid = typeof(DFileSystemImageImportEvents).GUID;
            var connectionPointContainer = pointContainer as IConnectionPointContainer;

            connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
        }
    }

    public event DFileSystemImageImport_EventHandler UpdateImport
    {
        add
        {
            lock (this)
            {
                var helper = new DFileSystemImageImport_SinkHelper(value);

                m_connectionPoint.Advise(helper, out var cookie);
                helper.Cookie = cookie;
                m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
            }
        }

        remove
        {
            lock (this)
            {
                if (m_aEventSinkHelpers[value] is DFileSystemImageImport_SinkHelper helper)
                {
                    m_connectionPoint.Unadvise(helper.Cookie);
                    m_aEventSinkHelpers.Remove(helper.UpdateDelegate);
                }
            }
        }
    }

    public void Dispose()
    {
        Cleanup();
        GC.SuppressFinalize(this);
    }

    ~DFileSystemImageImport_EventProvider()
    {
        Cleanup();
    }

    private void Cleanup()
    {
        Monitor.Enter(this);
        try
        {
            foreach (DFileSystemImageImport_SinkHelper helper in m_aEventSinkHelpers.Values)
                m_connectionPoint.Unadvise(helper.Cookie);

            m_aEventSinkHelpers.Clear();
            _ = Marshal.ReleaseComObject(m_connectionPoint);
        }
        catch (SynchronizationLockException)
        {
        }
        finally
        {
            Monitor.Exit(this);
        }
    }
}