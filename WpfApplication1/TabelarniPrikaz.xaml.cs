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
        ObservableCollection<Resurs> listaResursaParent;
        
        public ObservableCollection<Resurs> ListaResursa { get; set; }
        public Resurs SelectedResurs { get; set; }
        public ResursDAO dao;

        public TabelarniPrikaz(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            dao = new ResursDAO();
 
            ListaResursa = dao.ucitajListuResursa();
            listaResursaParent = mw.ListaResursa;
        }


        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
       
            Resurs l = (Resurs)resursiGrid.SelectedItem;
            if (l != null)
            {
                izbrisiResursIzListe(l);
            }
            else
            {
                MessageBox mb = new MessageBox("Morate izabrati resurs za brisanje.");
                mb.Show();
            }
                   
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            Resurs l = (Resurs)resursiGrid.SelectedItem;
            IzmeniPodatkeResursa ipl = new IzmeniPodatkeResursa(this);
            ipl.inicijalizujResursZaEdit(l);
            Resurs ret = ipl.vratiIzmenjen();

            if (l != null)
            {
                for (int i = 0; i < ListaResursa.Count; i++)
                {
                    if (ListaResursa[i].id == l.id)
                    {
                        ListaResursa.RemoveAt(i);                       
                        ListaResursa.Insert(i, ret);
                        listaResursaParent.RemoveAt(i);
                        listaResursaParent.Insert(i, ret);
                    }
                }
            }           
        }

        private void izbrisiResursIzListe(Resurs l)
        {
            if (ListaResursa != null)
            {
                if (l != null)
                {
                    for (int i = 0; i < ListaResursa.Count; i++)
                    {
                        if (ListaResursa[i].id == l.id)
                        {
                            ListaResursa.RemoveAt(i);
                        }
                    }
                }
            }
            dao.upisiUFajl(ListaResursa);             
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
