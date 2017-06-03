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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for IzmeniEtiketu.xaml
    /// </summary>
    public partial class IzmeniEtiketu : Window, INotifyPropertyChanged
    {
        private MainWindow parentMW;

        private string _id;
        private string _opis;
        private string _boja;

        #region setProperties
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

        private Etiketa retEtiketa;
        
        public IzmeniEtiketu(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;

            parentMW = mw;
        }


        public void inicijalizujEtiketuZaEdit(Etiketa izabranaEtiketa)
        {
            retEtiketa = izabranaEtiketa;
            if (izabranaEtiketa == null)
            {
                MessageBox mb = new MessageBox("Morate izabrati etiketu za izmenu!");
                mb.Show();
            }
            else
            {
                this._id = izabranaEtiketa.id;
                this._opis = izabranaEtiketa.opis;
                this._boja = izabranaEtiketa.boja;

                colorPicker.SelectedColor = (Color)ColorConverter.ConvertFromString(_boja);

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

        private void sacuvajButton_Click(object sender, RoutedEventArgs e)
        {
            retEtiketa.id = _id;
            retEtiketa.opis = _opis;
            retEtiketa.boja = colorPicker.SelectedColor.ToString();

            for (int i = 0; i < parentMW.ListaEtiketa.Count; i++)
            {
                if (parentMW.ListaEtiketa[i].id == retEtiketa.id)
                {
                    parentMW.ListaEtiketa.RemoveAt(i);
                    parentMW.ListaEtiketa.Insert(i, retEtiketa);
                }
            }

            parentMW.daoEtiketa.upisiUFajl(parentMW.ListaEtiketa);

            this.Close();
        }

        public Etiketa vratiIzmenjen()
        {
            return retEtiketa;
        }


    }
}
