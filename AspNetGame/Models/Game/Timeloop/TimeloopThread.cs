using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AspNetGame.Models.Game.Timeloop
{
    public class TimeloopThread
    {
        private readonly Thread thread;
        private readonly ITickableProvider provider;
        private readonly long periodicity;

        public TimeloopThread(ITickableProvider provider, long periodicity)
        {
            this.periodicity = periodicity;
            this.provider = provider;
            thread = new Thread(new ThreadStart(Tick));
        }

        private async void Tick()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep((int) periodicity * 1000);

                foreach (var tickable in await provider.Provide())
                {
                    tickable.Tick(1);
                }
            }
        }

        internal void Stop()
        {
            thread.Abort();
        }

        internal void Start()
        {
            thread.Start();
        }


    }
}