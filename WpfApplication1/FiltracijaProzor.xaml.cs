using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApplication1.DAO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for FiltracijaProzor.xaml
    /// </summary>
    /// 
    public partial class FiltracijaProzor : Window
    {

        private ResursDAO resursDao = new ResursDAO();
        public ObservableCollection<Resurs> listaResursa { get; set; }

        private MainWindow parent;

        public FiltracijaProzor(MainWindow parent)
        {
            listaResursa = new ObservableCollection<Resurs>();
            listaResursa = resursDao.ucitajListuResursa();
            InitializeComponent();
            this.DataContext = this;
            this.parent = parent;
            
        }

        private void filtrirajButton_Click(object sender, RoutedEventArgs e)
        {
            #region setRadio
            string vaz;
            if (rbVazanDa.IsChecked == true)
            {
                vaz = "da";
            }
            else if (rbVazanNe.IsChecked == true)
            {
                vaz = "ne";
            }
            else
            {
                vaz = "nema";
            }

            string obn;
            if (rbObnovljivDa.IsChecked == true)
            {
                obn = "da";
            }
            else if (rbObnovljivNe.IsChecked == true)
            {
                obn = "ne";
            }
            else
            {
                obn = "nema";
            }

            string eksp = null;
            if (rbEksploatacijaDa.IsChecked == true)
            {
                eksp = "da";
            }
            else if (rbEksploatacijaNe.IsChecked == true)
            {
                eksp = "ne";
            }
            else
            {
                eksp = "nema";
            }
            #endregion

            FilterResurs podaciFilter = new FilterResurs(idFilter.Text, imeFilter.Text, cbTip.Text, cbFrekvencija.Text,
                                                          vaz, obn, eksp, cbMera.Text);
            Filtracija fil = new Filtracija(this, podaciFilter);
            List<Resurs> temp = new List<Resurs>();
            temp = fil.filtriraj();

            listaResursa.Clear();

            foreach (Resurs res in temp)
            {
                listaResursa.Add(new Resurs(res));
            }
        }

        private void ponistiButton_Click(object sender, RoutedEventArgs e)
        {
            listaResursa.Clear();
            foreach (Resurs r in resursDao.ucitajListuResursa()) {
                listaResursa.Add(r);
            }

            rbEksploatacijaDa.IsChecked = false;
            rbEksploatacijaNe.IsChecked = false;
            rbObnovljivDa.IsChecked = false;
            rbObnovljivNe.IsChecked = false;
            rbVazanDa.IsChecked = false;
            rbVazanNe.IsChecked = false;
            imeFilter.Text = "";
            idFilter.Text = "";
            cbFrekvencija.SelectedIndex = 0;
            cbMera.SelectedIndex = 0;
            cbTip.SelectedIndex = 0;

        }
    }
}
