using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGame.Models.Game.Timeloop
{
    public class TimeloopService : ITimeloopService
    {
        static readonly long TICK_SIZE = 5;

        private GameDbContext Context = IoC.Resolve<GameDbContext>();
        private PlayerRepository PlayerRepository = IoC.Resolve<PlayerRepository>();

        private readonly TimeloopThread thread;
        private readonly ITickableProvider provider;


        private async Task<Boolean> HasLastTimestamp()
        {
            Param timestamp = await Context.Params.FindAsync(ParamKey.TIMESTAMP.ToString());
            return timestamp != null;
        }

        private async Task<long> GetLastTimestamp()
        {
            if (await HasLastTimestamp())
            {
                return (await Context.Params.FindAsync(ParamKey.TIMESTAMP.ToString())).AsLong();
            }
            return 0;
        }

        private async void WriteLastTimestamp()
        {
            Param param = Context.Params.Find(ParamKey.TIMESTAMP.ToString());
            if (param != null)
            {
                param.Value = Convert.ToString(GetActualTimestamp());

            } else
            {
                param = new Param(ParamKey.TIMESTAMP, GetActualTimestamp());
            }

            //Context.Params.Add(param);
            Context.SaveChanges();
        }

        public TimeloopService(): this(new GameTickableProvider())
        {
        }

        public TimeloopService(ITickableProvider provider)
        {
            thread = new TimeloopThread(this);
            this.provider = provider;
        }
        public void Pause()
        {
            WriteLastTimestamp();
        }

        public async void Resume()
        {
            if (await HasLastTimestamp())
            {
                long tickCount = (GetActualTimestamp() - await GetLastTimestamp()) / TICK_SIZE;

                foreach (ITickable tickable in await PlayerRepository.GetAll())
                {
                    tickable.Tick(tickCount);
                    WriteLastTimestamp();
                }
            }

            StartTickThread();
        }

        private void StartTickThread()
        {
            thread.Start();
        }

        private long GetActualTimestamp()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

        private class TimeloopThread
        {
            private readonly Thread thread;
            private readonly TimeloopService service;

            internal TimeloopThread(TimeloopService service)
            {
                this.service = service;
                thread = new Thread(new ThreadStart(Tick));
            }

            private async void Tick()
            {
                while (Thread.CurrentThread.IsAlive)
                {
                    Thread.Sleep((int)TICK_SIZE * 1000);

                    foreach (var tickable in await service.provider.Provide())
                    {
                        tickable.Tick(1);
                        service.WriteLastTimestamp();
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
}