using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTackToe
{
    public class BoardData
    {
        public BoardData()
        {
            Winners = new List<char>();
        }

        public List<char> Winners { get; private set; }
    }
}
