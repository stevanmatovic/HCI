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
using System.Windows.Forms;

namespace WpfApplication1
{
    /// <summary>
    /// </summary>
    public partial class IzmeniTipResursa : Window, INotifyPropertyChanged
    {
        private MainWindow parentMW;

        private string _ime;
        private string _id;
        private string _opis;
        private string _uriLocation;

        private TipResursa retTip;

        private Tipovi parent;

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
        #endregion

        public IzmeniTipResursa(Tipovi t)
        {
            InitializeComponent();
            this.DataContext = this;
            
            parent = t;
        }

        public IzmeniTipResursa(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            retTip = new TipResursa();
            parentMW = mw;
        }

        public void inicijalizujTipZaEdit(TipResursa izabraniTip)
        {
            retTip = izabraniTip;
            if (izabraniTip == null)
            {
                MessageBox mb = new MessageBox("Morate izabrati tip za izmenu!");
                mb.Show();
            }
            else
            {
                this._id = izabraniTip.id;
                this._ime = izabraniTip.ime;
                this._opis = izabraniTip.opis;
                this._uriLocation = izabraniTip.slikaPath;

                ucitanaSlikaTipa.Source = new BitmapImage(new Uri(_uriLocation));

                this.Show();    
            }  
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void sacuvajTip_Click(object sender, RoutedEventArgs e)
        {
            retTip.id = _id;
            retTip.ime = _ime;
            retTip.opis = _opis;
            retTip.slikaPath = _uriLocation;

            for (int i = 0; i < parentMW.ListaTipova.Count; i++)
            {
                 if (parentMW.ListaTipova[i].id == retTip.id)
                    {
                        parentMW.ListaTipova.RemoveAt(i);
                        parentMW.ListaTipova.Insert(i, retTip);
                    }
            }
           // parent.dao.upisiUFajl(parent.ListaTipova);
            parentMW.daoTip.upisiUFajl(parentMW.ListaTipova);

            this.Close();           
        }

        public TipResursa vratiIzmenjen()
        {
            return retTip;
        }

        private void slikaTipChooser_Click(object sender, RoutedEventArgs e)
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
            ucitanaSlikaTipa.Source = image;
        }

        private void ucitanaSlikaTipa_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void idTipaLok_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

     
    }
}
