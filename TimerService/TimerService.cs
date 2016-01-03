using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using UF.Training.Common; 

namespace UF.Training.TimerService
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "Service1" sowohl im Code als auch in der Konfigurationsdatei ändern.
    public class TimerService : ITimerService
    {
        private static ConcurrentDictionary<string, Timer> Timers = new ConcurrentDictionary<string, Timer>();

        private string ErrorMessage(string txt)
        {
            return "Error: " + txt; 
        }

        private string NoError()
        {
            return string.Empty; 
        }

        public string Init()
        {
            string result = this.ErrorMessage("Can't create timer"); 

            try
            {
                string guid = Guid.NewGuid().ToString();
                Timer t = new Timer();
                Timers[guid] = t;

                result = guid;
            }
            catch (Exception e)
            {
                result = this.ErrorMessage(e.Message); 
            }

            return result; 
        }

        public string Start(string id)
        {
            string result = ErrorMessage(Constants.ErrorStart);

            try
            {
                Timer t = Timers[id];
                t.Start(); 

                result = this.NoError();
            }
            catch (Exception e)
            {
                result = this.ErrorMessage(e.Message);
            }

            return result;
        }

    
        public string Stop(string id)
        {
            string result = this.ErrorMessage(Constants.ErrorStop);

            try
            {
                Timer t = Timers[id];
                t.Stop();

                result = this.NoError();
            }
            catch (Exception e)
            {
                result = this.ErrorMessage(e.Message);
            }

            return result;
        }

        public string LapStop(string id)
        {
            string result = this.ErrorMessage(Constants.ErrorLapStop);

            try
            {
                Timer t = Timers[id];
                t.LapStop();

                result = this.NoError();
            }
            catch (Exception e)
            {
                result = this.ErrorMessage(e.Message);
            }

            return result;
        }

        public List<DateTime> GetTimes(string id)
        {
            List<DateTime> laplist = null;

            try
            {
                laplist = Timers[id].GetTimes();
            }
            catch (Exception e)
            {
                laplist = new LapList();
            }

            return laplist; 
        }


        public string Close(string id)
        {
            string result = this.ErrorMessage(Constants.ErrorClose); 
            Timer t = null;

            if (Timers.TryRemove(id, out t))
            {
                result = this.NoError(); 
            }
            else
            {
                result = this.ErrorMessage(Constants.ErrorClose + $" (ID={id})"); 
            }

            return result; 
        }
    }
}
