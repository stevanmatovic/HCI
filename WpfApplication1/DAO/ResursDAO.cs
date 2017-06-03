using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace WpfApplication1.DAO
{
    public class ResursDAO
    {
        public ResursDAO()
        { 
        
        }

        public ObservableCollection<Resurs> ucitajListuResursa()
        {
            ObservableCollection<Resurs> listaResursa = new ObservableCollection<Resurs>();
            String dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resursi.podaci");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(dat))
            {
                try
                {
                    stream = File.Open(dat, FileMode.Open);
                    listaResursa = (ObservableCollection<Resurs>)formatter.Deserialize(stream);
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
                listaResursa = new ObservableCollection<Resurs>();
            }
            return listaResursa;
        }

        public void upisiUFajl(ObservableCollection<Resurs> lista)
        {
            System.IO.File.WriteAllText("resursi.podaci", string.Empty);
            String dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resursi.podaci");
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

        public void remove(Resurs r)
        {
            ObservableCollection<Resurs> lista = ucitajListuResursa();
            Resurs zaBrisanje = null;
            foreach (Resurs res in lista) {
                if (res.id == r.id) {
                    zaBrisanje = res;
                }
            }
            if (zaBrisanje != null)
                lista.Remove(zaBrisanje);
            
           upisiUFajl(lista);
        }

        public void write(Resurs r) {
            ObservableCollection<Resurs> lista = ucitajListuResursa();
            lista.Add(r);
            upisiUFajl(lista);
        }
    }
}
