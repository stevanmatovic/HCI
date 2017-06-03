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
using System.Windows.Forms;
using WpfApplication1.DAO;
using System.Collections.ObjectModel;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for TypeWindow.xaml
    /// </summary>
    public partial class TypeWindow : Window
    {
        private string uriLocation;
        private BitmapImage tipImg;
        private string idTipa;
        private string nazivTipa;
        private string opisTipa;

        private MainWindow parent;
        ObservableCollection<TipLokala> listaTipovaParent;

        public DialogResult DialogResult { get; set; }
        
        public TypeWindow(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;

            parent = mw;
            listaTipovaParent = mw.ListaTipova;

        }

        private void slikaTipChooser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName != null)
                {
                    uriLocation = fileDialog.FileName;
                    tipImg = new BitmapImage(new Uri(fileDialog.FileName));
                }
            }
            ucitanaSlikaTipa.Source = tipImg;
        }

        private void ucitanaSlikaTipa_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void sacuvajTip_Click(object sender, RoutedEventArgs e)
        {
            TipDAO dao = new TipDAO();

            idTipa = idTipaLok.Text;
            nazivTipa = nazivTipaLok.Text;
            opisTipa = opisTipaLok.Text;


            if (idTipa.Equals("") || nazivTipa.Equals("") || opisTipa.Equals(""))
            {
                MessageBox mb = new MessageBox("Niste uneli sve podatke");
                mb.Show();

            }
            else
            {
                TipLokala tipL = new TipLokala
                {
                    id = idTipa, 
                    ime = nazivTipa,
                    opis = opisTipa,
                    slikaPath = uriLocation
                };

                ObservableCollection<TipLokala> listaTipova = dao.ucitajListuTipova();
                listaTipova.Add(tipL);
                listaTipovaParent.Add(tipL);
               
                dao.upisiUFajl(listaTipova);

                this.Close();
            }

        
        }

    }
}
