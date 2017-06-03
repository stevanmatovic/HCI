using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApplication1.DAO
{
    public class EtiketaDAO
    {
        public EtiketaDAO()
        { 
        
        }

        public ObservableCollection<Etiketa> ucitajListuEtiketa()
        {
            ObservableCollection<Etiketa> listaEtiketa = new ObservableCollection<Etiketa>();
            String dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.podaci");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(dat))
            {
                try
                {
                    stream = File.Open(dat, FileMode.Open);
                    listaEtiketa = (ObservableCollection<Etiketa>)formatter.Deserialize(stream);
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
                listaEtiketa = new ObservableCollection<Etiketa>();
            }
            return listaEtiketa;
        }

        public void upisiUFajl(ObservableCollection<Etiketa> list)
        {
            string dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.podaci");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(dat, FileMode.OpenOrCreate);
                formatter.Serialize(stream, list);
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
    }
}
