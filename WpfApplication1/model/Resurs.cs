using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    [Serializable]
    public class Resurs
    {
        bool naMapi { get; set; }

        public String id { get; set; }
        public String ime { get; set; }
        public String opis { get; set; }
        public String tip { get; set; }

        public TipResursa tipResursa;
        public String imagePath { get; set; }
        public String frekvencijaCB { get; set; }
        public String strateskiVazan { get; set; }
        public String obnovljiv { get; set; }
        public String eksploatacija { get; set; }
        public String mera { get; set; }
        public String cena { get; set; }
        public String datumOtkrivanja { get; set; }

        public double pozicijaX { get; set; }
        public double pozicijaY { get; set; }
 

        public List<Etiketa> listaEtiketaResursa;

        public Resurs()
        {
            listaEtiketaResursa = new List<Etiketa>();
        }

        public Resurs(Resurs l)
        {
            this.id = l.id;
            this.ime = l.ime;
            this.opis = l.opis;
            this.imagePath = l.imagePath;
            this.tipResursa = l.tipResursa;
            this.tip = this.tipResursa.ime;
            this.frekvencijaCB = l.frekvencijaCB;
            this.strateskiVazan = l.strateskiVazan;
            this.obnovljiv = l.obnovljiv;
            this.eksploatacija = l.eksploatacija;
            this.mera = l.mera;
            this.cena = l.cena;
            this.datumOtkrivanja = l.datumOtkrivanja;
            this.listaEtiketaResursa = l.listaEtiketaResursa;
            this.naMapi = l.naMapi;
            
        }


        public Resurs(String id, String ime, String opis, String imgPath, String tip, String alk, String inv, String pus, String rez, String cena, String kap, String dat, TipResursa tl)
        {
            this.id = id;
            this.ime = ime;
            this.opis = opis;
            this.tipResursa = tl;
            this.tip = this.tipResursa.ime;
            this.frekvencijaCB = alk;
            this.strateskiVazan = inv;
            this.obnovljiv = pus;
            this.eksploatacija = rez;
            this.mera = cena;
            this.cena = kap;
            this.datumOtkrivanja = dat;
            this.imagePath = imgPath;
           
        }



        



    }
}
