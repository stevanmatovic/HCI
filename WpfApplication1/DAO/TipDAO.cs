using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApplication1.DAO
{
    public class TipDAO
    {

        public TipDAO()
        { 
        
        }

        public ObservableCollection<TipResursa> ucitajListuTipova()
        {
            ObservableCollection<TipResursa> listaTipova = new ObservableCollection<TipResursa>();
            String dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.podaci");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(dat))
            {
                try
                {
                    stream = File.Open(dat, FileMode.Open);
                    listaTipova = (ObservableCollection<TipResursa>)formatter.Deserialize(stream);
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
                listaTipova = new ObservableCollection<TipResursa>();
            }
            return listaTipova;
        }

        public void upisiUFajl(ObservableCollection<TipResursa> list)
        {
            string dat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.podaci");
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
