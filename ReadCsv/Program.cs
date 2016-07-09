using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            Readcsv.ReadGeo("gps.csv",false);
            Readcsv.geos[0].Write();
        }
    }
}
