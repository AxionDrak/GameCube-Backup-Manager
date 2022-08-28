using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace GCBM.tools.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscFormat2Erase_EventProvider : DiscFormat2Erase_Event, IDisposable
    {
        // Fields
        private readonly Hashtable m_aEventSinkHelpers = new Hashtable();
        private readonly IConnectionPoint m_connectionPoint;

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
                    if (m_aEventSinkHelpers[value] is DiscFormat2Erase_SinkHelper helper)
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

        ~DiscFormat2Erase_EventProvider()
        {
            Cleanup();
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
}