using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace GCBM.tools.Interop;

[ClassInterface(ClassInterfaceType.None)]
internal sealed class DiscFormat2RawCD_EventProvider : DiscFormat2RawCD_Event, IDisposable
{
    // Fields
    private readonly Hashtable m_aEventSinkHelpers = new();
    private readonly IConnectionPoint m_connectionPoint;

    // Methods
    public DiscFormat2RawCD_EventProvider(object pointContainer)
    {
        lock (this)
        {
            var eventsGuid = typeof(DDiscFormat2RawCDEvents).GUID;
            var connectionPointContainer = pointContainer as IConnectionPointContainer;

            connectionPointContainer.FindConnectionPoint(ref eventsGuid, out m_connectionPoint);
        }
    }

    public event DiscFormat2RawCD_EventHandler Update
    {
        add
        {
            lock (this)
            {
                var helper =
                    new DiscFormat2RawCD_SinkHelper(value);

                m_connectionPoint.Advise(helper, out var cookie);
                helper.Cookie = cookie;
                m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
            }
        }

        remove
        {
            lock (this)
            {
                if (m_aEventSinkHelpers[value] is DiscFormat2RawCD_SinkHelper helper)
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

    ~DiscFormat2RawCD_EventProvider()
    {
        Cleanup();
    }

    private void Cleanup()
    {
        Monitor.Enter(this);
        try
        {
            foreach (DiscFormat2RawCD_SinkHelper helper in m_aEventSinkHelpers.Values)
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