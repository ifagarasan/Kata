using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Cycles
{
    public class Builder: IBuilder
    {
        public List<ICycle> Build()
        {
            List<ICycle> result = new List<ICycle>();

            for (int i = 0; i < 7; ++i)
                result.Add(Create(i));

            result.Add(new LongPause());

            return result;
        }

        static ICycle Create(int index)
        {
            ICycle cycle;

            if (index == 7)
                cycle = new LongPause();

            if (index % 2 == 0)
                cycle = new Pomodoro();
            else
                cycle = new ShortPause();

            return cycle;
        }
    }
}
