using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UF.Training.Common;
using UF.Training.TimerService;

namespace UF.Training.TimerService.UnitTests
{

    [TestFixture]
    public class CommonTests
    {
        public Timer GetTimer()
        {
            return Timer.Init();
        }

        [Test]
        public void Timer_AfterInit_NotStarted()
        {
            const int Expected = 0;
            Timer t = this.GetTimer();
            Assert.IsNotNull(t, "failed to create timer");

            int count = t.GetTimes().Count;
            Assert.IsTrue(Expected == count, String.Format("count should be {0}, but is {1}", Expected, count)); 
        }

        [Test]
        public void Timer_AfterStart_IsStarted()
        {
            const int Expected = 1;
            Timer t = this.GetTimer();
            Assert.IsNotNull(t, "failed to create timer");

            t.Start(); 
            int count = t.GetTimes().Count;
            Assert.IsTrue(Expected == count, String.Format("count should be {0}, but is {1}", Expected, count));
        }

        [Test]
        public void Timer_AfterStop_HasStopped()
        {
            const int Expected = 2;
            Timer t = this.GetTimer(); 
            Assert.IsNotNull(t, "failed to create timer");

            t.Start();
            t.Stop(); 
            int count = t.GetTimes().Count;
            Assert.IsTrue(Expected == count, String.Format("count should be {0}, but is {1}.", Expected, count));

            t.Stop();
            count = t.GetTimes().Count;
            Assert.IsTrue(Expected == count, "count changed after another stop command. Has " + count.ToString() + " entries now.");
        }

        [Test]
        public void Timer_AfterLapStop_IsRunning()
        {
            const int Expected = 2; 
            Timer t = this.GetTimer();
            Assert.IsNotNull(t, "failed to create timer");

            t.Start();
            t.LapStop(); 

            int count = t.GetTimes().Count;
            Assert.IsTrue(Expected == count, string.Format("count should be {0}, but is {1}", Expected, count));

            t.Stop();
            count = t.GetTimes().Count;
            Assert.IsFalse(Expected == count, "count did not increment after stop command. Timer seems stopped by LapStop command.");
        }

        [Test]
        public void Timer_After5Laps_LapsAreNoted()
        {
            const int Expected = 6;
            Timer t = this.GetTimer();
            Assert.IsNotNull(t, "failed to create timer");

            t.Start();      // 1
            t.LapStop();    // 2
            t.LapStop();    // 3
            t.LapStop();    // 4
            t.LapStop();    // 5
            t.LapStop();    // 6

            int count = t.GetTimes().Count;
            Assert.IsTrue(Expected == count, $"count should be {Expected}, but is {count}.");
            // Assert.IsTrue(Expected == count, string.Format("count should be {0}, but is {1}.", Expected, count));
        }
    }
}
