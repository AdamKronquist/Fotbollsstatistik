using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotboll_statistik
{
    class Winnings
    {
        public string Spelare { get; set; }
        public int Vinster { get; set; }
        public int Förluster { get; set; }
        public int Oavgjorda { get; set; }
        public int Vinstprocent { get; set; }
        public int Vinstdifferens { get; set; }
    }
}
