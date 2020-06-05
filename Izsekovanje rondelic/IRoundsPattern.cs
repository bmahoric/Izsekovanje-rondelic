using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izsekovanje_rondelic
{
    public interface IRoundsPattern
    {
        Tape _Tape { get; set; }
        Round _Round { get; set; }
        int CalcNoOfRounds();
        string PrintRoundLocations();
    }
}
