using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    [Serializable]
    public class Tacke
    {
        public double X { get; set; }
        public double Y { get; set; }
        public String oznakaSpomenika { get; set; }

        public Tacke(double X, double Y, String oznakaSpomenika)
        {

            this.X = X;
            this.Y = Y;
            this.oznakaSpomenika = oznakaSpomenika;



        }
    }
}
