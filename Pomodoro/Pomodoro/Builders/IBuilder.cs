﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Cycles
{
    public interface IBuilder
    {
        List<ICycle> Build();
    }
}
