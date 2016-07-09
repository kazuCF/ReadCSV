using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ReadCsv
{
    public static class Readcsv
    {
        public static StreamReader reader;
        public static IEnumerable<string> strs;
        public static List<GeoData> geos = new List<GeoData>();
        public static void ReadGeo(string filename,bool iscolumn=true)//一つの地点
        {
            string[] columns=new string[1];
            List<string[]> datas=new List<string[]>();
            reader = new StreamReader(filename);
            if (iscolumn)
            {
                string str = reader.ReadLine();
                columns = str.Split(',');
            }
            
            while(!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                datas.Add(str.Split(','));
            }
            geos.Add(new GeoData(filename, columns, datas));

        }
        
    }
}
