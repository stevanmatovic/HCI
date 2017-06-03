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
    /// Interaction logic for TabelarniPrikaz.xaml
    /// </summary>
    public partial class TabelarniPrikaz : Window
    {
        ObservableCollection<Resurs> listaLokalaParent;
        
        public ObservableCollection<Resurs> ListaLokala { get; set; }
        public Resurs SelectedLokal { get; set; }
        public ResursDAO dao;

        public TabelarniPrikaz(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            dao = new ResursDAO();
 
            ListaLokala = dao.ucitajListuResursa();
            listaLokalaParent = mw.ListaResursa;
        }


        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
       
            Resurs l = (Resurs)lokaliGrid.SelectedItem;
            if (l != null)
            {
                izbrisiLokalIzListe(l);
            }
            else
            {
                MessageBox mb = new MessageBox("Morate izabrati lokal za brisanje.");
                mb.Show();
            }
                   
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            Resurs l = (Resurs)lokaliGrid.SelectedItem;
            IzmeniPodatkeResursa ipl = new IzmeniPodatkeResursa(this);
            ipl.inicijalizujLokalZaEdit(l);
            Resurs ret = ipl.vratiIzmenjen();

            if (l != null)
            {
                for (int i = 0; i < ListaLokala.Count; i++)
                {
                    if (ListaLokala[i].id == l.id)
                    {
                        ListaLokala.RemoveAt(i);                       
                        ListaLokala.Insert(i, ret);
                        listaLokalaParent.RemoveAt(i);
                        listaLokalaParent.Insert(i, ret);
                    }
                }
            }           
        }

        private void izbrisiLokalIzListe(Resurs l)
        {
            if (ListaLokala != null)
            {
                if (l != null)
                {
                    for (int i = 0; i < ListaLokala.Count; i++)
                    {
                        if (ListaLokala[i].id == l.id)
                        {
                            ListaLokala.RemoveAt(i);
                        }
                    }
                }
            }
            dao.upisiUFajl(ListaLokala);             
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
