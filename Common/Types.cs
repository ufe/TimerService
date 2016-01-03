using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF.Training.Common
{
    public class LapList : List<DateTime>
    {
    //    private List<DateTime> l = new List<DateTime>(); 

    //    public LapList(DateTime dt)
    //    {
    //        l.Add(dt); 
    //    }

    //    public void Clear()
    //    {
    //        l = new List<DateTime>();
    //    }

    //    public List<DateTime> GetLapList()
    //    {
    //        return l.; 
    //    }
    }

    public class Timer
    {
        /// <summary>
        /// The list of lap times.
        /// </summary>
        private Common.LapList laplist = new Common.LapList();

        /// <summary>
        /// The status of the timer
        /// </summary>
        private TimerStatus status = TimerStatus.stopped;

        /// <summary>
        /// The possible status of the timer.
        /// </summary>
        private enum TimerStatus
        {
            running,
            stopped
        }

        /// <summary>
        /// Creates a new Timer and an unique timer ID. 
        /// The timer ID has to be used on all following calls to address the timer. 
        /// </summary>
        /// <returns>The timer ID as string.</returns>
        public static Timer Init()
        {
            Timer t = new Timer();
            t.status = TimerStatus.stopped;

            return t;
        }

        /// <summary>
        /// Starts the timer. 
        /// This resets the lap list. 
        /// </summary>
        public void Start()
        {
            if (this.status == TimerStatus.running)
            {
                // ignore duplicate start command
                return;
            }

            this.status = TimerStatus.running;
            this.laplist = new Common.LapList();
            this.laplist.Add(DateTime.Now);
        }

        /// <summary>
        /// Stop the timer. 
        /// Adds a new entry to the lap list. 
        /// </summary>
        public void Stop()
        {
            if (this.status == TimerStatus.stopped)
            {
                // ignore duplicate stop command
                return;
            }

            this.status = TimerStatus.stopped;
            this.laplist.Add(DateTime.Now);
        }

        /// <summary>
        /// Add new entry to lap list.
        /// </summary>
        public void LapStop()
        {
            if (this.status == TimerStatus.stopped)
            {
                // ignore for stopped timer
                return;
            }

            this.laplist.Add(DateTime.Now);
        }

        /// <summary>
        /// Get the lap times
        /// </summary>
        /// <returns>A LapList</returns>
        public Common.LapList GetTimes()
        {
            return this.laplist;
        }
    }
}
