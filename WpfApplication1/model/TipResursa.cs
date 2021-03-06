﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    [Serializable]
    public class TipResursa
    {
        public String id { get; set; }
        public String ime { get; set; }
        public String opis { get; set; }
        public String slikaPath { get; set; }
        

        public TipResursa() 
        {
        
        }
        
        public TipResursa(TipResursa tl)
        {
            this.id = tl.id;
            this.ime = tl.ime;
            this.opis = tl.opis;
            this.slikaPath = tl.slikaPath;
        }

        public TipResursa(String id, String ime, String opis, String slikaPath)
        {
            this.id = id;
            this.ime = ime;
            this.opis = opis;
            this.slikaPath = slikaPath;
        }

        public override string ToString()
        {
            return this.ime + " " + this.ime + " " + this.opis + " " + this.slikaPath;
        } 


    }
}
