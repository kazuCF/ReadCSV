using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ReadCsv
{
   public  class Way
    {
        public double[] xs = new double[2] ;
        public double[] ys = new double[2];
        public int[,] isroad;
        public const int xid = 2, yid =1;
        public int xcount, ycount;
        public Way(int Xcount,int Ycount,double[] Xs,double[] Ys)
        {
            xs = Xs;ys = Ys;
            xcount = Xcount;ycount = Ycount;
            isroad = new int[xcount+1, ycount+1];
        }
        public bool Fill(GeoData geo)
        {
            foreach (var i in geo.datas)
            {
               int[]xy= Convert(double.Parse(i[xid]), double.Parse(i[yid]));
                if (xy[0] > xcount || xy[0] < 0 || xy[1] < 0 || xy[1] > ycount) { continue; }
                isroad[xy[0], xy[1]]++;
            }
            
            return true;
        }
        public int[]  Convert(double x,double y)
        {
            double[] dx = new double[] { xs[1] - xs[0], x - xs[0] };
            double[] dy = new double[] { ys[1] - ys[0], y - ys[0] };
            double[] scale = new double[] { dx[0] / xcount, dy[0] / ycount };
           int newx = (int)(dx[1] / scale[0]),  newy = (int)(dy[1] / scale[1]);
            return new int[] { newx, newy };
        }
        public void Ex()
        {
            StreamWriter writer = new StreamWriter("s.txt");
            for (int i = 0; i < ycount; i++)
            {
                for (int k = 0; k < xcount; k++)
                {
                    if (isroad[k, i] > 0) { writer.Write("●"); }
                    else {writer.Write(" "); }
                }
                writer.Write("\r\n");
            }
            writer.Close();
        }
    }
}
