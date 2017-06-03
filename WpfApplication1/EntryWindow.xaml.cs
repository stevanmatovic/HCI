using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Globalization;
using System.ComponentModel;
using WpfApplication1.DAO;
using System.Collections.ObjectModel;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for EntryWindow.xaml
    /// </summary>
    public partial class EntryWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        MainWindow parent;
        ObservableCollection<Lokal> listaLokalaParent;

        public ObservableCollection<TipLokala> ListaTipova { get; set; }
        public TipLokala SelectedTip { get; set; }
        private TipDAO dao;

        public DialogResult DialogResult { get; set; }

        private string _id;
        private string _ime;
        private string _opis;
        private string _tip;
        private int _kapacitet;
        private string _uriLocation;
       
        #region fieldProperties
        public int Kapacitet
        {
            get
            {
                return _kapacitet;
            }
            set
            {
                if (value != _kapacitet)
                {
                    _kapacitet = value;
                    OnPropertyChanged("Kapacitet");
                }
            }
        }
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (!value.Equals(_ime))
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (!value.Equals(_id))
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (!value.Equals(_opis))
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (!value.Equals(_tip))
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }
    #endregion


        public EntryWindow(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;

            parent = mw;
            listaLokalaParent = mw.ListaLokala;

            dao = new TipDAO();
            ListaTipova = dao.ucitajListuTipova();
            _uriLocation = "";

        }

        private void sacuvajLokal_Click(object sender, RoutedEventArgs e)
        {
            LokalDAO lokalDAO = new LokalDAO();

            TipLokala retTip = (TipLokala)tabelaTipova.SelectedItem;
            String alkL = alkOK.Text;
            String cenaK = cenaKat.Text;
            String invL;
            String pusL;
            String rezL;
            #region setRadioButtons
            if (daInvalidi.IsChecked == true)
            {
                invL = "da";
            }
            else if(neInvalidi.IsChecked == true)
            {
                invL = "ne";
            } else 
            {
                invL = "";
            }
            if (daPusenje.IsChecked == true)
            {
                pusL = "da";
            }
            else if(nePusenje.IsChecked == true)
            {
                pusL = "ne";
            } else 
            {
                pusL = "";
            }
            if (daRezervacije.IsChecked == true)
            {
                rezL = "da";
            }
            else if(neRezervacije.IsChecked == true)
            {
                rezL = "ne";
            } else
            {
                rezL = "";
            }
            #endregion
            String dateL = datumOtvaranja.ToString();
            String uriLoc = _uriLocation;
            String tipLok = retTip.ime;
           
            if (idLokala.Text.Equals("") || imeLokala.Text.Equals("") || opisLokala.Text.Equals("") || alkL.Equals("") || invL.Equals("") || pusL.Equals("")
                                || rezL.Equals("") || dateL.Equals("") || _kapacitet.ToString().Equals("") || retTip == null)
            {
                MessageBox mb = new MessageBox("Niste uneli sve podatke");
                mb.Show();              
            }
            else 
            {
                Lokal lokal = new Lokal
                {
                    id = _id,
                    ime = _ime,
                    opis = _opis,
                    tip = tipLok,
                    tipLokala = retTip,
                    alkoholCB = alkL,
                    cenaKategorija = cenaK,
                    invalidiOK = invL,
                    pusenjeOK = pusL,
                    rezervacijeOK = rezL,/* cenaKategorija = cenaK,*/
                    datumOtvaranja = dateL,
                    kapacitet = _kapacitet.ToString(),
                    imagePath = _uriLocation
                };
                ObservableCollection<Lokal> listaLokala = lokalDAO.ucitajListuLokala();
                listaLokala.Add(lokal);
                lokalDAO.upisiUFajl(listaLokala);

                listaLokalaParent.Add(lokal);

                //id
                
                this.Close();
            }
        }

        private void izaberiSlikuButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = null;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName != null)
                {
                    _uriLocation = fileDialog.FileName;
                    image = new BitmapImage(new Uri(fileDialog.FileName));
                }
            }
            slikaLokala.Source = image;
        }

        private void tabelaTipova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipLokala izabraniTip = (TipLokala)tabelaTipova.SelectedItem;
            slikaLokala.Source = new BitmapImage(new Uri(izabraniTip.slikaPath));
            this._uriLocation = izabraniTip.slikaPath;
        }      
    }

}
