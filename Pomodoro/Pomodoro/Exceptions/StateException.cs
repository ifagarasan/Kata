using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Exceptions
{
    public class StateException: Exception
    {
        public StateException() { }

        public StateException(string message): base(message) { }
    }
}
