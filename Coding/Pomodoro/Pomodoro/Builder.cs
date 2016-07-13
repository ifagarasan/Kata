using System;
using System.Collections.Generic;

namespace Pomodoro
{
    public class Builder : IBuilder
    {
        public List<ICycle> Build()
        {
            List<ICycle> results = new List<ICycle>();

            for (int i = 0; i < 8; ++i)
            {
                if (i % 2 == 0)
                    results.Add(new PomodoroCycle());
                else
                    results.Add(new ShortPause());
            }

            return results;
        }
    }
}