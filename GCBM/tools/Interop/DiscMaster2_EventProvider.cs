using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace GCBM.tools.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscMaster2_EventProvider : DiscMaster2_Event, IDisposable
    {
        // Fields
        private readonly Hashtable m_aEventSinkHelpers = new Hashtable();
        private readonly IConnectionPoint m_connectionPoint;

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

                    m_connectionPoint.Advise(helper, out int cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.NotifyDeviceAddedDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    if (m_aEventSinkHelpers[value] is DiscMaster2_SinkHelper helper)
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

                    m_connectionPoint.Advise(helper, out int cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.NotifyDeviceRemovedDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    if (m_aEventSinkHelpers[value] is DiscMaster2_SinkHelper helper)
                    {
                        m_connectionPoint.Unadvise(helper.Cookie);
                        m_aEventSinkHelpers.Remove(helper.NotifyDeviceRemovedDelegate);
                    }
                }
            }
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        ~DiscMaster2_EventProvider()
        {
            Cleanup();
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