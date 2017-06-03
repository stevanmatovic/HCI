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
        ObservableCollection<Lokal> listaLokalaParent;
        
        public ObservableCollection<Lokal> ListaLokala { get; set; }
        public Lokal SelectedLokal { get; set; }
        public LokalDAO dao;

        public TabelarniPrikaz(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            dao = new LokalDAO();
 
            ListaLokala = dao.ucitajListuLokala();
            listaLokalaParent = mw.ListaLokala;
        }


        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
       
            Lokal l = (Lokal)lokaliGrid.SelectedItem;
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
            Lokal l = (Lokal)lokaliGrid.SelectedItem;
            IzmeniPodatkeLokala ipl = new IzmeniPodatkeLokala(this);
            ipl.inicijalizujLokalZaEdit(l);
            Lokal ret = ipl.vratiIzmenjen();

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

        private void izbrisiLokalIzListe(Lokal l)
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
