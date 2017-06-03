using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication1
{
    [Serializable]
    public class Etiketa
    {
        public String id { get; set; }
        public String boja { get; set; }
        public String opis { get; set; }
        public bool selected { get; set; }

        public Etiketa()
        {
            this.selected = false;
        }

        public Etiketa(Etiketa e)
        {
            this.id = e.id;
            this.boja = e.boja;
            this.opis = e.opis;
            this.selected = e.selected;
        }

        public Etiketa(String id, String boja, String opis, bool sel)
        {
            this.id = id;
            this.boja = boja;
            this.opis = opis;
            this.selected = sel;
        }

        
    }
}
