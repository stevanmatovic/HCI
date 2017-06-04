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
        ObservableCollection<Resurs> listaResursaParent;

        public ObservableCollection<TipResursa> ListaTipova { get; set; }
        public TipResursa SelectedTip { get; set; }
        private TipDAO dao;

        public DialogResult dialogResult { get; set; }

        private string _id;
        private string _ime;
        private string _opis;
        private string _tip;
        private int _cena;
        private string _uriLocation;
       
        #region fieldProperties
        public int Cena
        {
            get
            {
                return _cena;
            }
            set
            {
                if (value != _cena)
                {
                    _cena = value;
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
            listaResursaParent = mw.ListaResursa;

            dao = new TipDAO();
            ListaTipova = dao.ucitajListuTipova();
            _uriLocation = "";

            daVazan.IsChecked = true;
            daObnovljiv.IsChecked = true;
            daEksploatacija.IsChecked = true;

        }

        private void sacuvajLokal_Click(object sender, RoutedEventArgs e)
        {
            ResursDAO lokalDAO = new ResursDAO();

            TipResursa retTip = (TipResursa)tabelaTipova.SelectedItem;
            String frekvencijaL = frekvencijaCB.Text;
            String meraL = meraCB.Text;
            String vazan;
            String obnovljivL;
            String eksploatacijaL;
            #region setRadioButtons
            if (daVazan.IsChecked == true)
            {
                vazan = "da";
            }
            else if(neVazan.IsChecked == true)
            {
                vazan = "ne";
            } else 
            {
                vazan = "";
            }
            if (daObnovljiv.IsChecked == true)
            {
                obnovljivL = "da";
            }
            else if(neObnovljiv.IsChecked == true)
            {
                obnovljivL = "ne";
            } else 
            {
                obnovljivL = "";
            }
            if (daEksploatacija.IsChecked == true)
            {
                eksploatacijaL = "da";
            }
            else if(neEksploatacija.IsChecked == true)
            {
                eksploatacijaL = "ne";
            } else
            {
                eksploatacijaL = "";
            }
            #endregion
            String dateL = datumOtvaranja.SelectedDate.Value.ToShortDateString();
            String uriLoc = _uriLocation;
            String tipLok = retTip.ime;
           
            if (idResursa.Text.Equals("") || imeResursa.Text.Equals("") || opisResursa.Text.Equals("") || frekvencijaL.Equals("") || vazan.Equals("") || obnovljivL.Equals("")
                                || eksploatacijaL.Equals("") || dateL.Equals("") || _cena.ToString().Equals("") || retTip == null)
            {
                MessageBox mb = new MessageBox("Niste uneli sve podatke");
                mb.Show();              
            }
            else 
            {
                Resurs resurs = new Resurs
                {
                    id = _id,
                    ime = _ime,
                    opis = _opis,
                    tip = tipLok,
                    tipResursa = retTip,
                    frekvencijaCB = frekvencijaL,
                    mera = meraL,
                    strateskiVazan = vazan,
                    obnovljiv = obnovljivL,
                    eksploatacija = eksploatacijaL,/* cenaKategorija = cenaK,*/
                    datumOtkrivanja = dateL,
                    cena = _cena.ToString(),
                    imagePath = _uriLocation
                };
                ObservableCollection<Resurs> listaLokala = lokalDAO.ucitajListuResursa();
                listaLokala.Add(resurs);
                lokalDAO.upisiUFajl(listaLokala);

                ((MainWindow)parent).dodajSliku(_uriLocation,_id);
                
                listaResursaParent.Add(resurs);
                
                this.Close();
            }
        }

        private void izaberiSlikuButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = null;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
            TipResursa izabraniTip = (TipResursa)tabelaTipova.SelectedItem;
            slikaLokala.Source = new BitmapImage(new Uri(izabraniTip.slikaPath));
            this._uriLocation = izabraniTip.slikaPath;
        }

        private void kapacitetBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frekvencijaCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
