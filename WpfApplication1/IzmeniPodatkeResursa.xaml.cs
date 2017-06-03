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
using System.ComponentModel;
using WpfApplication1.DAO;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for IzmeniPodatkeLokala.xaml
    /// </summary>
    public partial class IzmeniPodatkeResursa : Window, INotifyPropertyChanged
    {

        private Resurs retResurs;
        private TabelarniPrikaz parent;
        private MainWindow parentMW;
        
        private string _ime;
        private string _id;
        private string _opis;
        private string _tip;
        private string _frekvencija;
        private string _mera;
        private string _cena;
        private string _strateski;
        private string _obnovljiv;
        private string _eksploatacija;
        private string _datumOtkrivanja;
        private string _uriLocation;

        private TipDAO dao;
        public ObservableCollection<TipResursa> ListaTipova { get; set; }
        public TipResursa SelectedTip { get; set; }

        public DialogResult DialogResult { get; set; }

        #region setProperties
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
        public string Alkohol
        {
            get
            {
                return _frekvencija;
            }
            set
            {
                if (!value.Equals(_frekvencija))
                {
                    _frekvencija = value;
                    OnPropertyChanged("Alkohol");
                }
            }
        }
        public string Kapacitet
        {
            get
            {
                return _cena;
            }
            set
            {
                if (!value.Equals(_cena))
                {
                    _cena = value;
                    OnPropertyChanged("Kapacitet");
                }
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public IzmeniPodatkeResursa(TabelarniPrikaz tp)
        {
            InitializeComponent();
            this.DataContext = this;

            retResurs = new Resurs();
            parent = tp;
            dao = new TipDAO();
            ListaTipova = dao.ucitajListuTipova();
        }
  

        public IzmeniPodatkeResursa(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;

            parentMW = mw;
            dao = new TipDAO();
            ListaTipova = dao.ucitajListuTipova();
        }

        public void inicijalizujLokalZaEdit(Resurs izabraniResurs)
        {
            retResurs = izabraniResurs;
            if (izabraniResurs == null)
            {
                MessageBox mb = new MessageBox("Morate izabrati lokal za izmenu.");
                mb.Show();
            }
            else
            {

                this._id = izabraniResurs.id;
                this._ime = izabraniResurs.ime;
                this._opis = izabraniResurs.opis;
                this._cena = izabraniResurs.cena;
                this._uriLocation = izabraniResurs.imagePath;
                
                this._tip = izabraniResurs.tip;
    
                this._frekvencija = izabraniResurs.frekvencijaCB;
                this._mera = izabraniResurs.mera;

                #region setCBParams
                if (_frekvencija.Equals("Sluzi kasno nocu"))
                {
                    sluziKasno.IsSelected = true;
                }
                else if (_frekvencija.Equals("Sluzi do 23:00"))
                {
                    sluzi23.IsSelected = true;
                }
                else
                {
                    neSluzi.IsSelected = true;
                }


                if (_mera.Equals("Niske cene"))
                {
                    niskeCene.IsSelected = true;
                }
                else if (_mera.Equals("Srednje cene"))
                {
                    srednjeCene.IsSelected = true;
                }
                else if (_mera.Equals("Visoke cene"))
                {
                    visokeCene.IsSelected = true;
                }
                else 
                {
                    izuzetnoVisokeCene.IsSelected = true;
                }
                #endregion

                this._strateski = izabraniResurs.strateskiVazan;
                this._obnovljiv = izabraniResurs.obnovljiv;
                this._eksploatacija = izabraniResurs.eksploatacija;
                #region setRadioParams
                if (_strateski.Equals("da"))
                {
                    daInvalidi.IsChecked = true;
                }
                else 
                {
                    neInvalidi.IsChecked = true;
                }


                if (_obnovljiv.Equals("da"))
                {
                    daPusenje.IsChecked = true;
                }
                else
                {
                    nePusenje.IsChecked = true;
                }


                if (_eksploatacija.Equals("da"))
                {
                    daRezervacije.IsChecked = true;
                }
                else
                {
                    neRezervacije.IsChecked = true;
                }
                #endregion

                this._datumOtkrivanja = izabraniResurs.datumOtkrivanja;

                datumOtvaranja.SelectedDate = DateTime.Parse(_datumOtkrivanja);

                izmenjenaSlikaLokala.Source = new BitmapImage(new Uri(_uriLocation));
               
                this.Show();

            }
        }
        public Resurs vratiIzmenjen()
        {
            return retResurs;
        }
       
        private void tipLokala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void sacuvajLokal_Click(object sender, RoutedEventArgs e)
        {
                retResurs.id = _id;
                retResurs.ime = _ime;
                retResurs.opis = _opis;
                retResurs.tip = _tip;
                retResurs.cena = _cena;
                retResurs.imagePath = _uriLocation;

                int day = datumOtvaranja.SelectedDate.Value.Day;
                int month = datumOtvaranja.SelectedDate.Value.Month;
                int year = datumOtvaranja.SelectedDate.Value.Year;

                retResurs.datumOtkrivanja = "" + day + "." + month + "." + year; 
                
                #region setRadioButtons
                if (daInvalidi.IsChecked == true)
                {
                    retResurs.strateskiVazan = "da";
                }
                else
                {
                    retResurs.strateskiVazan = "ne";
                }

                if (daPusenje.IsChecked == true)
                {
                    retResurs.obnovljiv = "da";
                }
                else
                {
                    retResurs.obnovljiv = "ne";
                }

                if (daRezervacije.IsChecked == true)
                {
                    retResurs.eksploatacija = "da";
                }
                else
                {
                    retResurs.eksploatacija = "ne";
                }
                #endregion
                #region setCB

                if (neSluzi.IsSelected == true)
                {
                    retResurs.frekvencijaCB = "Ne sluzi";
                }
                else if (sluzi23.IsSelected == true)
                {
                    retResurs.frekvencijaCB = "Sluzi do 23:00";
                }
                else
                {
                    retResurs.frekvencijaCB = "Sluzi kasno nocu";
                }

                if (niskeCene.IsSelected == true)
                {
                    retResurs.mera = "Niske cene";
                }
                else if (srednjeCene.IsSelected == true)
                {
                    retResurs.mera = "Srednje cene";
                }
                else if (visokeCene.IsSelected == true)
                {
                    retResurs.mera = "Visoke cene";
                }
                else
                {
                    retResurs.mera = "Izuzetno visoke cene";
                }
                #endregion

                for (int i = 0; i < parentMW.ListaResursa.Count; i++)
                {
                    if (parentMW.ListaResursa[i].id == retResurs.id)
                    {
                        parentMW.ListaResursa.RemoveAt(i);
                        parentMW.ListaResursa.Insert(i, retResurs);
                    }
                }
                parentMW.daoLokal.upisiUFajl(parentMW.ListaResursa);

                this.Close();           
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
            izmenjenaSlikaLokala.Source = image;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tabelaTipova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipResursa tl = (TipResursa)tabelaTipova.SelectedItem;
            izmenjenaSlikaLokala.Source = new BitmapImage(new Uri(tl.slikaPath));
            this._uriLocation = tl.slikaPath;
        }

        private void idResursa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
