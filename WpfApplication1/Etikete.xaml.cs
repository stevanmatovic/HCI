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
    /// Interaction logic for Etikete.xaml
    /// </summary>
    public partial class Etikete : Window
    {
        public ObservableCollection<Etiketa> ListaEtiketa { get; set; }
        public Etiketa SelectedEtiketa { get; set; }
        public EtiketaDAO dao;
        
        public Etikete()
        {
            InitializeComponent();
            this.DataContext = this;
            dao = new EtiketaDAO();

            ListaEtiketa = dao.ucitajListuEtiketa();
        }

        private void izmeniEtiketuButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void izbrisiEtiketuButton_Click(object sender, RoutedEventArgs e)
        {

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
