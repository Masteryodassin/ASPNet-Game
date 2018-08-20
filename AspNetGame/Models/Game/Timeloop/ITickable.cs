﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Models.Game.Timeloop
{
    public interface ITickable
    {
        void Tick(long count);
    }
}
