using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using WpfApplication1.DAO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for IzaberiEtikete.xaml
    /// </summary>
    public partial class IzaberiEtikete : Window
    {
        public ObservableCollection<Etiketa> ListaEtiketaWind { get; set; }
        public EtiketaDAO dao;

        MainWindow parentMW;

        public IzaberiEtikete(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            parentMW = mw;
      
            dao = new EtiketaDAO();
            ListaEtiketaWind = new ObservableCollection<Etiketa>();

 /*           foreach (Etiketa e in parentMW.ListaEtiketa)
            {
                
            } 
  */
  //          List<Etiketa> tempList = new List<Etiketa>();
            if (parentMW.izabraniLokal.listaEtiketaLokala.Count < 1)
            {
                foreach (Etiketa e in parentMW.ListaEtiketa)
                {
                    ListaEtiketaWind.Add(new Etiketa(e));
                } 
            }
            else
            {
                foreach (Etiketa e in parentMW.ListaEtiketa)
                {
                    foreach (Etiketa izabE in parentMW.izabraniLokal.listaEtiketaLokala)
                    {
                        if (izabE.id != e.id)
                        {
                            ListaEtiketaWind.Add(new Etiketa(e));
                        }
                    }
                } 
            }                   
        }

        private void izaberiButton_Click(object sender, RoutedEventArgs e)
        {
            List<Etiketa> tempLista = new List<Etiketa>();
            
            for (int i = 0; i < ListaEtiketaWind.Count; i++)    
            {
                if (ListaEtiketaWind[i].selected == true)
                {
                    parentMW.EtiketeIzabranog.Add(new Etiketa(ListaEtiketaWind[i]));  
                    tempLista.Add(new Etiketa(ListaEtiketaWind[i]));
                }
            }

            for (int i = 0; i < parentMW.ListaLokala.Count; i++)
            {
                if (parentMW.izabraniLokal.id == parentMW.ListaLokala[i].id)
                {
                    parentMW.ListaLokala[i].listaEtiketaLokala.InsertRange(parentMW.ListaLokala[i].listaEtiketaLokala.Count, tempLista);
                }
            }

            parentMW.daoLokal.upisiUFajl(parentMW.ListaLokala);

            this.Close();
        }    
    }
}
