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
    /// Interaction logic for Tipovi.xaml
    /// </summary>
    public partial class Tipovi : Window
    {
        public ObservableCollection<TipLokala> ListaTipova { get; set; }
        public TipLokala SelectedTip { get; set; }
        public TipDAO dao;
        
        public Tipovi()
        {
            InitializeComponent();
            this.DataContext = this;
            dao = new TipDAO();

            ListaTipova = dao.ucitajListuTipova();
        }

        private void izmeniTipButton_Click(object sender, RoutedEventArgs e)
        {
            TipLokala tipIzmena = (TipLokala)tabelaTipova.SelectedItem;
            IzmeniTipLokala itl = new IzmeniTipLokala(this);
            itl.inicijalizujTipZaEdit(tipIzmena);
            TipLokala ret = itl.vratiIzmenjen();
            if (tipIzmena != null)
            {
                for (int i = 0; i < ListaTipova.Count; i++)
                {
                    if (ListaTipova[i].id == tipIzmena.id)
                    {
                        ListaTipova.RemoveAt(i);
                        ListaTipova.Insert(i, ret);
                    }
                }
            }

        }

        private void izbrisiTipButton_Click(object sender, RoutedEventArgs e)
        {
            TipLokala tl = (TipLokala)tabelaTipova.SelectedItem;
            if (tl != null)
            {
                izbrisiTipIzListe(tl);
            }
            else
            {
                MessageBox mb = new MessageBox("Morate izabrati tip za brisanje!");
                mb.Show();
            }
        }

        private void izbrisiTipIzListe(TipLokala tl)
        {
            if (ListaTipova != null)
            {
                if (tl != null)
                {
                    for (int i = 0; i < ListaTipova.Count; i++)
                    {
                        if (ListaTipova[i].id == tl.id)
                        {
                            ListaTipova.RemoveAt(i);
                        }
                    }
                }
            }
            dao.upisiUFajl(ListaTipova);
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
