using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace GCBM.tools.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DWriteEngine2_EventProvider : DWriteEngine2_Event, IDisposable
    {
        // Fields
        private readonly Hashtable m_aEventSinkHelpers = new Hashtable();
        private readonly IConnectionPoint m_connectionPoint;

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

                    m_connectionPoint.Advise(helper, out int cookie);
                    helper.Cookie = cookie;
                    m_aEventSinkHelpers.Add(helper.UpdateDelegate, helper);
                }
            }

            remove
            {
                lock (this)
                {
                    if (m_aEventSinkHelpers[value] is DWriteEngine2_SinkHelper helper)
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

        ~DWriteEngine2_EventProvider()
        {
            Cleanup();
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