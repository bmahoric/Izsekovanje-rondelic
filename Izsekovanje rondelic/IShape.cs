using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izsekovanje_rondelic
{
    interface IShape
    {
        int Area { get; }
        int NetArea { get; }
        int NetWidth { get; }
        int NetLength { get; }
    }
}
