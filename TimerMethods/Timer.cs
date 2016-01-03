using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF.Training.Timer
{
    public class Timer
    {
        private enum TimerStatus { running, stopped };

        private Common.LapList laplist = new Common.LapList();
        TimerStatus status = TimerStatus.stopped; 

        public static Timer Init()
        {
            Timer t = new Timer(); 
            t.status = TimerStatus.stopped;

            return t; 
        }


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

        public void Reset()
        {
            this.status = TimerStatus.stopped;
            this.Start(); 
        }

        public void LapStop()
        {
            if (this.status == TimerStatus.stopped)
            {
                // ignore for stopped timer
                return;
            }
            this.laplist.Add(DateTime.Now);
        }


        public Common.LapList GetTimes()
        {
            return this.laplist; 
        }


    }
}
