using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class Filtracija
    {
        private FiltracijaProzor parentMW;
        
        private FilterResurs podaciZaFiltriranje;
        public List<Resurs> listaResursaFilter;
        List<Resurs> temp;
        public Filtracija(FiltracijaProzor fp, FilterResurs fl)
        {
            parentMW = fp;


            listaResursaFilter = new List<Resurs>();

            for (int i = 0; i < parentMW.listaResursa.Count; i++)
            {
                listaResursaFilter.Add(new Resurs(parentMW.listaResursa[i]));
            }

            temp = new List<Resurs>();
            for (int i = 0; i < listaResursaFilter.Count; i++)
            {
                temp.Add(new Resurs(listaResursaFilter[i]));
            }

            this.podaciZaFiltriranje = fl;
        }

        public List<Resurs> filtriraj()
        {
            if (!(podaciZaFiltriranje.id).Equals(""))   //znaci uneseno je nesto
            {
                string id = podaciZaFiltriranje.id.Trim();

                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if (!(listaResursaFilter[i].id).Equals(id))
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }
            }

            if (!(podaciZaFiltriranje.ime).Equals(""))
            {
                string ime = podaciZaFiltriranje.ime.Trim();


                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if ((listaResursaFilter[i].ime).IndexOf(ime) == -1)
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }
            }

            if (!(podaciZaFiltriranje.tip).Equals(""))
            {
                string tip = podaciZaFiltriranje.tip.Trim();


                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if ((listaResursaFilter[i].tip).IndexOf(tip) == -1)
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }
            }

            if (!(podaciZaFiltriranje.alkohol).Equals(""))
            {
                string izbor = podaciZaFiltriranje.alkohol;

                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if (!(listaResursaFilter[i].frekvencijaCB).Equals(izbor))
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }

            }

            if (!(podaciZaFiltriranje.cenaKategorija).Equals(""))
            {
                string izbor = podaciZaFiltriranje.cenaKategorija;

                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if (!(listaResursaFilter[i].mera).Equals(izbor))
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }
            }

            if (!(podaciZaFiltriranje.invalid).Equals("nema"))
            {
                string izbor = podaciZaFiltriranje.invalid;

                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if (!(listaResursaFilter[i].strateskiVazan).Equals(izbor))
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }
            }

            if (!(podaciZaFiltriranje.pusenje).Equals("nema"))
            {
                string izbor = podaciZaFiltriranje.pusenje;

                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if (!(listaResursaFilter[i].obnovljiv).Equals(izbor))
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }
            }

            if (!(podaciZaFiltriranje.rezervacije).Equals("nema"))
            {
                string izbor = podaciZaFiltriranje.rezervacije;

                for (int i = listaResursaFilter.Count - 1; i > -1; i--)
                {
                    if (!(listaResursaFilter[i].eksploatacija).Equals(izbor))
                    {
                        temp.RemoveAt(i);
                    }
                }

                listaResursaFilter.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    listaResursaFilter.Add(new Resurs(temp[i]));
                }
            }

            return temp;
        }
    }
}
