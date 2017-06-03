using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    [Serializable]
    public class Lokal
    {
        public String id { get; set; }
        public String ime { get; set; }
        public String opis { get; set; }
        public String tip { get; set; }
        public TipLokala tipLokala;
        public String imagePath { get; set; }
        public String alkoholCB { get; set; }
        public String invalidiOK { get; set; }
        public String pusenjeOK { get; set; }
        public String rezervacijeOK { get; set; }
        public String cenaKategorija { get; set; }
        public String kapacitet { get; set; }
        public String datumOtvaranja { get; set; }
        public bool naMapi { get; set; }
        public double left { get; set; }
        public double top { get; set; }

        public List<Etiketa> listaEtiketaLokala;

        public Lokal()
        {
            listaEtiketaLokala = new List<Etiketa>();
        }

        public Lokal(Lokal l)
        {
            this.id = l.id;
            this.ime = l.ime;
            this.opis = l.opis;
            this.imagePath = l.imagePath;
            this.tipLokala = l.tipLokala;
            this.tip = this.tipLokala.ime;
            this.alkoholCB = l.alkoholCB;
            this.invalidiOK = l.invalidiOK;
            this.pusenjeOK = l.pusenjeOK;
            this.rezervacijeOK = l.rezervacijeOK;
            this.cenaKategorija = l.cenaKategorija;
            this.kapacitet = l.kapacitet;
            this.datumOtvaranja = l.datumOtvaranja;
            this.listaEtiketaLokala = l.listaEtiketaLokala;
        }


        public Lokal(String id, String ime, String opis, String imgPath, String tip, String alk, String inv, String pus, String rez, String cena, String kap, String dat, TipLokala tl)
        {
            this.id = id;
            this.ime = ime;
            this.opis = opis;
            this.tipLokala = tl;
            this.tip = this.tipLokala.ime;
            this.alkoholCB = alk;
            this.invalidiOK = inv;
            this.pusenjeOK = pus;
            this.rezervacijeOK = rez;
            this.cenaKategorija = cena;
            this.kapacitet = kap;
            this.datumOtvaranja = dat;
            this.imagePath = imgPath;
        }



        



    }
}
