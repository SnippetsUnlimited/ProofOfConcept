using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DiagnosticsUtils
{
    public class ExecutionStopwatch
    {
        private TimeSpan m_endTimeStamp = TimeSpan.Zero;
        private TimeSpan m_startTimeStamp = TimeSpan.Zero;

        public void Start()
        {
            TimeSpan timestamp = Process.GetCurrentProcess().TotalProcessorTime;
            m_startTimeStamp = timestamp;
        }

        public void Stop()
        {
            TimeSpan timestamp = Process.GetCurrentProcess().TotalProcessorTime;
            m_endTimeStamp = timestamp;
        }

        public long ElapsedTicks
        {
            get
            {
                long elapsed = m_endTimeStamp.Subtract(m_startTimeStamp).Ticks;
                return elapsed;
            }
        }

    }
}