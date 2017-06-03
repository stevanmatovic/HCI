using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace WpfApplication1.DAO
{
    public class LokalDAO
    {
        public LokalDAO()
        { 
        
        }

        public ObservableCollection<Lokal> ucitajListuLokala()
        {
            ObservableCollection<Lokal> listaLok = new ObservableCollection<Lokal>();
            String dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lokali.podaci");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(dat))
            {
                try
                {
                    stream = File.Open(dat, FileMode.Open);
                    listaLok = (ObservableCollection<Lokal>)formatter.Deserialize(stream);
                }
                catch
                {
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                    }
                }
            }
            else
            {
                listaLok = new ObservableCollection<Lokal>();
            }
            return listaLok;
        }

        public void upisiUFajl(ObservableCollection<Lokal> lista)
        {
            System.IO.File.WriteAllText("lokali.podaci", string.Empty);
            String dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lokali.podaci");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(dat, FileMode.OpenOrCreate);
                formatter.Serialize(stream, lista);
            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        public void remove(Lokal l)
        {
            ObservableCollection<Lokal> lista = ucitajListuLokala();
            Lokal zaBrisanje = null;
            foreach (Lokal lok in lista) {
                if (lok.id == l.id) {
                    zaBrisanje = lok;
                }
            }
            if (zaBrisanje != null)
                lista.Remove(zaBrisanje);
            
           upisiUFajl(lista);
        }

        public void write(Lokal l) {
            ObservableCollection<Lokal> lista = ucitajListuLokala();
            lista.Add(l);
            upisiUFajl(lista);
        }
    }
}
