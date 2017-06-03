using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApplication1.DAO
{
    public class EtiketeLokalaDAO
    {
        public EtiketeLokalaDAO()
        { 
        
        }

        public Dictionary<string, ObservableCollection<Etiketa>> ucitajListuEtiketaLokala()
        {
            Dictionary<string, ObservableCollection<Etiketa>> dictEtiketaLokala = new Dictionary<string, ObservableCollection<Etiketa>>();
            String dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etiketeLokala.podaci");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(dat))
            {
                try
                {
                    stream = File.Open(dat, FileMode.Open);
                    dictEtiketaLokala = (Dictionary<string, ObservableCollection<Etiketa>>)formatter.Deserialize(stream);
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
                dictEtiketaLokala = new Dictionary<string, ObservableCollection<Etiketa>>();
            }
            return dictEtiketaLokala;
        }

        public void upisiUFajl(Dictionary<string, ObservableCollection<Etiketa>> dict)
        {
            string dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etiketeLokala.podaci");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(dat, FileMode.OpenOrCreate);
                formatter.Serialize(stream, dict);
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
