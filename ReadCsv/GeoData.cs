﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCsv
{
    public class GeoData
    {
        public  string name;
        public  string[] columns;
        public  List<string[]> datas;
         // public Way way = new Way(1000, 1000,new double[] { 99.49875,103.8643},new double[] {12.18,16.10 });
        public Way way = new Way(2000, 2000, new double[] { 100.5, 100.8 }, new double[] { 13.68, 13.80 });
        public Taxi tax = new Taxi(30, 30);
        public GeoData(string Name,string[]Columns, List<string[]> Datas)
        {
            name = Name;  columns = Columns;datas = Datas;
            way.Fill(this);
        }
        public void Write()
        {
            way.Ex();
        }
    }

}
