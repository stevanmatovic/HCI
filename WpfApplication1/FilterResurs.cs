using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class FilterResurs
    {
        public string id { get; set; }
        public string ime { get; set; }
        public string tip { get; set; }
        public string alkohol { get; set; }
        public string invalid { get; set; }
        public string pusenje { get; set; }
        public string rezervacije { get; set; }
        public string cenaKategorija { get; set; }

        public FilterResurs(string newId, string newIme, string newTip, string newAlkohol, string newInvalid,
                            string newPusenje, string newRezervacije, string newCenaKategorija)
        {
            id = newId;
            ime = newIme;
            tip = newTip;
            alkohol = newAlkohol;
            invalid = newInvalid;
            pusenje = newPusenje;
            rezervacije = newRezervacije;
            cenaKategorija = newCenaKategorija;
        }

    }
}
