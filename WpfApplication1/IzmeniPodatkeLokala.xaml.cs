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
    public partial class IzmeniPodatkeLokala : Window, INotifyPropertyChanged
    {

        private Lokal retLokal;
        private TabelarniPrikaz parent;
        private MainWindow parentMW;
        
        private string _ime;
        private string _id;
        private string _opis;
        private string _tip;
        private string _alkohol;
        private string _cenaKat;
        private string _kapacitet;
        private string _invalidi;
        private string _pusenje;
        private string _rezervacije;
        private string _datumOtvaranja;
        private string _uriLocation;

        private TipDAO dao;
        public ObservableCollection<TipLokala> ListaTipova { get; set; }
        public TipLokala SelectedTip { get; set; }

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
                return _alkohol;
            }
            set
            {
                if (!value.Equals(_alkohol))
                {
                    _alkohol = value;
                    OnPropertyChanged("Alkohol");
                }
            }
        }
        public string Kapacitet
        {
            get
            {
                return _kapacitet;
            }
            set
            {
                if (!value.Equals(_kapacitet))
                {
                    _kapacitet = value;
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

        public IzmeniPodatkeLokala(TabelarniPrikaz tp)
        {
            InitializeComponent();
            this.DataContext = this;

            retLokal = new Lokal();
            parent = tp;
            dao = new TipDAO();
            ListaTipova = dao.ucitajListuTipova();
        }
  

        public IzmeniPodatkeLokala(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;

            parentMW = mw;
            dao = new TipDAO();
            ListaTipova = dao.ucitajListuTipova();
        }

        public void inicijalizujLokalZaEdit(Lokal izabraniLokal)
        {
            retLokal = izabraniLokal;
            if (izabraniLokal == null)
            {
                MessageBox mb = new MessageBox("Morate izabrati lokal za izmenu.");
                mb.Show();
            }
            else
            {

                this._id = izabraniLokal.id;
                this._ime = izabraniLokal.ime;
                this._opis = izabraniLokal.opis;
                this._kapacitet = izabraniLokal.kapacitet;
                this._uriLocation = izabraniLokal.imagePath;
                
                this._tip = izabraniLokal.tip;
    
                this._alkohol = izabraniLokal.alkoholCB;
                this._cenaKat = izabraniLokal.cenaKategorija;

                #region setCBParams
                if (_alkohol.Equals("Sluzi kasno nocu"))
                {
                    sluziKasno.IsSelected = true;
                }
                else if (_alkohol.Equals("Sluzi do 23:00"))
                {
                    sluzi23.IsSelected = true;
                }
                else
                {
                    neSluzi.IsSelected = true;
                }


                if (_cenaKat.Equals("Niske cene"))
                {
                    niskeCene.IsSelected = true;
                }
                else if (_cenaKat.Equals("Srednje cene"))
                {
                    srednjeCene.IsSelected = true;
                }
                else if (_cenaKat.Equals("Visoke cene"))
                {
                    visokeCene.IsSelected = true;
                }
                else 
                {
                    izuzetnoVisokeCene.IsSelected = true;
                }
                #endregion

                this._invalidi = izabraniLokal.invalidiOK;
                this._pusenje = izabraniLokal.pusenjeOK;
                this._rezervacije = izabraniLokal.rezervacijeOK;
                #region setRadioParams
                if (_invalidi.Equals("da"))
                {
                    daInvalidi.IsChecked = true;
                }
                else 
                {
                    neInvalidi.IsChecked = true;
                }


                if (_pusenje.Equals("da"))
                {
                    daPusenje.IsChecked = true;
                }
                else
                {
                    nePusenje.IsChecked = true;
                }


                if (_rezervacije.Equals("da"))
                {
                    daRezervacije.IsChecked = true;
                }
                else
                {
                    neRezervacije.IsChecked = true;
                }
                #endregion

                this._datumOtvaranja = izabraniLokal.datumOtvaranja;

                datumOtvaranja.SelectedDate = DateTime.Parse(_datumOtvaranja);

                izmenjenaSlikaLokala.Source = new BitmapImage(new Uri(_uriLocation));
               
                this.Show();

            }
        }
        public Lokal vratiIzmenjen()
        {
            return retLokal;
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
                retLokal.id = _id;
                retLokal.ime = _ime;
                retLokal.opis = _opis;
                retLokal.tip = _tip;
                retLokal.kapacitet = _kapacitet;
                retLokal.imagePath = _uriLocation;

                int day = datumOtvaranja.SelectedDate.Value.Day;
                int month = datumOtvaranja.SelectedDate.Value.Month;
                int year = datumOtvaranja.SelectedDate.Value.Year;

                retLokal.datumOtvaranja = "" + day + "." + month + "." + year; 
                
                #region setRadioButtons
                if (daInvalidi.IsChecked == true)
                {
                    retLokal.invalidiOK = "da";
                }
                else
                {
                    retLokal.invalidiOK = "ne";
                }

                if (daPusenje.IsChecked == true)
                {
                    retLokal.pusenjeOK = "da";
                }
                else
                {
                    retLokal.pusenjeOK = "ne";
                }

                if (daRezervacije.IsChecked == true)
                {
                    retLokal.rezervacijeOK = "da";
                }
                else
                {
                    retLokal.rezervacijeOK = "ne";
                }
                #endregion
                #region setCB

                if (neSluzi.IsSelected == true)
                {
                    retLokal.alkoholCB = "Ne sluzi";
                }
                else if (sluzi23.IsSelected == true)
                {
                    retLokal.alkoholCB = "Sluzi do 23:00";
                }
                else
                {
                    retLokal.alkoholCB = "Sluzi kasno nocu";
                }

                if (niskeCene.IsSelected == true)
                {
                    retLokal.cenaKategorija = "Niske cene";
                }
                else if (srednjeCene.IsSelected == true)
                {
                    retLokal.cenaKategorija = "Srednje cene";
                }
                else if (visokeCene.IsSelected == true)
                {
                    retLokal.cenaKategorija = "Visoke cene";
                }
                else
                {
                    retLokal.cenaKategorija = "Izuzetno visoke cene";
                }
                #endregion

                for (int i = 0; i < parentMW.ListaLokala.Count; i++)
                {
                    if (parentMW.ListaLokala[i].id == retLokal.id)
                    {
                        parentMW.ListaLokala.RemoveAt(i);
                        parentMW.ListaLokala.Insert(i, retLokal);
                    }
                }
                parentMW.daoLokal.upisiUFajl(parentMW.ListaLokala);

                this.Close();           
        }

        private void idLokala_TextChanged(object sender, TextChangedEventArgs e)
        {
            
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
            TipLokala tl = (TipLokala)tabelaTipova.SelectedItem;
            izmenjenaSlikaLokala.Source = new BitmapImage(new Uri(tl.slikaPath));
            this._uriLocation = tl.slikaPath;
        }
    }
}
