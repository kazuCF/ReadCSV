using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCsv
{
    public class Taxi
    {
        public int x { get; private set; }
        public int y { get; private set; }
        bool occupyed = false;
        double earned = 0;
        public List<int> root = new List<int>();//4 0 5
                                                //3   1
                                                //7 2 6
        public Taxi(int X, int Y, bool Occupyed = false, double Earned = 0)
        {
            x = X; y = Y; occupyed = Occupyed; earned = Earned;
        }
        public void Move(int sx, int sy)
        {
            x += sx; y += sy;
        }
        public  int Simulate(Way way,int goalx,int goaly)
        {

            if (way.isroad[goalx, goaly] == 0) { return -1; }
            Queue<ForSimulate> que = new Queue<ForSimulate>();
            que.Enqueue(new ForSimulate(x, y,new List<int[]>()));
            while (que.Count > 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    ForSimulate now = que.Dequeue();
                    now.arrived.Add(new int[] { now.x, now.y });
                    int newx = now.x, newy = now.y;
                    switch (i)
                    {
                        case 0:
                            newy--;
                            break;
                        case 1:
                            newx++;
                            break;
                        case 2:
                            newy++;
                            break;
                        case 3:
                            newx--;
                            break;
                        case 4:
                            newx--;newy++;
                            break;
                        case 5:
                            newx++;newy--;
                            break;
                        case 6:
                            newx++;newy++;
                            break;
                        case 7:
                            newx--;newy++;
                            break;
                        default:
                            break;
                    }

                    if (!now.arrived.Any(c => c[0] == newx && c[1] == newy) && way.isroad[newx, newy] > 0)
                    {
                        ForSimulate next = new ForSimulate(newx, newy, now.arrived);
                        next.arrived.Add(new int[] { newx, newy });
                        que.Enqueue(next);
                    }
                }
            }
            return -1;
        }
        public class ForSimulate
        {
            public List<int[]> arrived = new List<int[]>();
            public int x, y;
            public ForSimulate(int X, int Y, List<int[]> Arrived)
            {
                x = X;
                y = Y;
                arrived = Arrived;
            }
        }
    }
}
