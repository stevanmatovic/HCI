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
using Xceed.Wpf.Toolkit;
using System.ComponentModel;
using WpfApplication1.DAO;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for EtiqWindow.xaml
    /// </summary>
    public partial class EtiqWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        MainWindow parentMW;
        ObservableCollection<Etiketa> listaEtiketaParent;

        private string _id;
        private string _opis;
        private string _boja;


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


        public EtiqWindow(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;

            parentMW = mw;
            listaEtiketaParent = mw.ListaEtiketa;
     
        }

        private void sacuvajButton_Click(object sender, RoutedEventArgs e)
        {
            EtiketaDAO dao = new EtiketaDAO();

            _id = idEtikete.Text;
            _opis = opisEtikete.Text;
            _boja = colorPicker.SelectedColor.ToString();

            if (_id.Equals("") || _opis.Equals("") || _boja.Equals(""))
            {
                MessageBox mb = new MessageBox("Niste uneli sve podatke");
                mb.Show();
            }
            else
            {
                Etiketa etik = new Etiketa
                {
                    id = _id,
                    opis = _opis,
                    boja = _boja
                };

                ObservableCollection<Etiketa> listaEtiketa = dao.ucitajListuEtiketa();
                listaEtiketa.Add(etik);
                listaEtiketaParent.Add(etik);

                dao.upisiUFajl(listaEtiketa);

                this.Close();
            
            }
        }

      
    }

    
}
