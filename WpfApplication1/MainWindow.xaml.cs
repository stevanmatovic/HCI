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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using WpfApplication1.DAO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Lokal izabraniLokal { get; set; }
        public ObservableCollection<Etiketa> EtiketeIzabranog { get; set; }

        public ObservableCollection<Lokal> ListaLokala { get; set; }
        public LokalDAO daoLokal;

        public ObservableCollection<TipLokala> ListaTipova { get; set; }
        public TipDAO daoTip;

        public ObservableCollection<Etiketa> ListaEtiketa { get; set; }
        public EtiketaDAO daoEtiketa;

        public static Dictionary<Image, Lokal> lokaliNaMapi { get; set; }

        Point startPoint = new Point();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            slikaIzabranogLokala.Source = null;
            imeIzabranogLokala.Text = "";
            tipIzabranogLokala.Text = "";

            daoLokal = new LokalDAO();
            ListaLokala = daoLokal.ucitajListuLokala();

            daoTip = new TipDAO();
            ListaTipova = daoTip.ucitajListuTipova();

            daoEtiketa = new EtiketaDAO();
            ListaEtiketa = daoEtiketa.ucitajListuEtiketa();
          
            EtiketeIzabranog = new ObservableCollection<Etiketa>();

            lokaliNaMapi = new Dictionary<Image, Lokal>();
        }
  
        private void tabelarniPrikaz_Click(object sender, RoutedEventArgs e)
        {
            TabelarniPrikaz tabela = new TabelarniPrikaz(this);
            tabela.Show();
        }

        private void noviLokalItem_Click(object sender, RoutedEventArgs e)
        {
            EntryWindow ew = new EntryWindow(this);
            ew.Show();
        }

        private void noviTipLokalaItem_Click(object sender, RoutedEventArgs e)
        {
            TypeWindow tw = new TypeWindow(this);
            tw.Show();
        }

        private void novaEtiketaItem_Click(object sender, RoutedEventArgs e)
        {
            EtiqWindow et = new EtiqWindow(this);
            et.Show();
        }
        private void tipPrikaz_Click(object sender, RoutedEventArgs e)
        {
            Tipovi tipTab = new Tipovi();
            tipTab.Show();
        }

        private void dodajLokalButton_Click(object sender, RoutedEventArgs e)
        {
            EntryWindow ew = new EntryWindow(this);
            ew.Show();
        }

        private void izmeniLokalButton_Click(object sender, RoutedEventArgs e)
        {
            Lokal l = (Lokal)lokalDataGrid.SelectedItem;
            IzmeniPodatkeLokala ipl = new IzmeniPodatkeLokala(this);
            ipl.inicijalizujLokalZaEdit(l);
            Lokal ret = ipl.vratiIzmenjen();

            if (l != null)
            {
                for (int i = 0; i < ListaLokala.Count; i++)
                {
                    if (ListaLokala[i].id == l.id)
                    {
                        ListaLokala.RemoveAt(i);
                        ListaLokala.Insert(i, ret);
                    }
                }
            }
        }

        private void izbrisiLokalButton_Click(object sender, RoutedEventArgs e)
        {
            Lokal l = (Lokal)lokalDataGrid.SelectedItem;
            if (l != null)
            {
                izbrisiLokalIzListe(l.id);
            }
            else
            {
                MessageBox mb = new MessageBox("Morate izabrati lokal za brisanje.");
                mb.Show();
            }
        }

        public void izbrisiLokalIzListe(string id)
        {
            if (ListaLokala != null)
            {
                if (!id.Equals(""))
                {
                    for (int i = 0; i < ListaLokala.Count; i++)
                    {
                        if ((ListaLokala[i].id).Equals(id))
                        {
                            ListaLokala.RemoveAt(i);
                        }
                    }
                }
            }
            daoLokal.upisiUFajl(ListaLokala);
        }

        private void dodajTipButton_Click(object sender, RoutedEventArgs e)
        {
            TypeWindow tw = new TypeWindow(this);
            tw.Show();
        }

        private void izmeniTipButton_Click(object sender, RoutedEventArgs e)
        {
            TipLokala tipIzmena = (TipLokala)tipoviDataGrid.SelectedItem;
            IzmeniTipLokala itl = new IzmeniTipLokala(this);
            itl.inicijalizujTipZaEdit(tipIzmena);
            TipLokala ret = itl.vratiIzmenjen();
            if (tipIzmena != null)
            {
                for (int i = 0; i < ListaTipova.Count; i++)
                {
                    if ((ListaTipova[i].id).Equals(tipIzmena.id))
                    {
                        ListaTipova.RemoveAt(i);
                        ListaTipova.Insert(i, ret);
                    }
                }
            }
        }

        private void izbrisiTipButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> idLokalaZaBrisanje = new List<string>();
            int counter = 0;
            
            TipLokala tl = (TipLokala)tipoviDataGrid.SelectedItem;
            string idTipa = tl.id;
            if (tl != null)
            {
                for (int i = 0; i < ListaLokala.Count; i++)
                {
                    string idTipaLokala = ListaLokala[i].tipLokala.id;
                    if (idTipaLokala.Equals(idTipa))
                    {
                        counter++;
                        idLokalaZaBrisanje.Add(ListaLokala[i].id);
                    } 
                }

                if (counter > 0)
                {
                    UpozorenjeZaBrisanjeTipa warning = new UpozorenjeZaBrisanjeTipa(this, tl, idLokalaZaBrisanje, counter);
                    warning.Show();    
                }  
                else
                {
                    izbrisiTipIzListe(tl);
                }                         
            }
            else
            {
                MessageBox mb = new MessageBox("Morate izabrati tip za brisanje!");
                mb.Show();
            }
        }

        public void izbrisiTipIzListe(TipLokala tl)
        {
            if (ListaTipova != null)
            {
                if (tl != null)
                {
                    for (int i = 0; i < ListaTipova.Count; i++)
                    {
                        if (ListaTipova[i].id == tl.id)
                        {
                            ListaTipova.RemoveAt(i);
                        }
                    }            
                }
            }
            daoTip.upisiUFajl(ListaTipova);
        }

        private void dodajEtiketuButton_Click(object sender, RoutedEventArgs e)
        {
            EtiqWindow et = new EtiqWindow(this);
            et.Show();
        }

        private void izmeniEtiketuButton_Click(object sender, RoutedEventArgs e)
        {
            Etiketa etiketaIzmena = (Etiketa)etiketeDataGrid.SelectedItem;
            IzmeniEtiketu ie = new IzmeniEtiketu(this);
            ie.inicijalizujEtiketuZaEdit(etiketaIzmena);
            Etiketa ret = ie.vratiIzmenjen();
            if (etiketaIzmena != null)
            {
                for (int i = 0; i < ListaEtiketa.Count; i++)
                {
                    if (ListaEtiketa[i].id == etiketaIzmena.id)
                    {
                        ListaEtiketa.RemoveAt(i);
                        ListaEtiketa.Insert(i, ret);
                    }
                }
            }
        }

        private void izbrisiEtiketuButton_Click(object sender, RoutedEventArgs e)
        {
            Etiketa etik = (Etiketa)etiketeDataGrid.SelectedItem;
            if (etik != null)
            {
                izbrisiEtiketuIzListe(etik);
            }
            else 
            {
                MessageBox mb = new MessageBox("Morate izabrati etiketu za brisanje!");
                mb.Show();
            }
        }

        private void izbrisiEtiketuIzListe(Etiketa e)
        {
            if (ListaEtiketa != null)
            {
                if (e != null)
                {
                    for (int i = 0; i < ListaEtiketa.Count; i++)
                    {
                        if (ListaEtiketa[i].id == e.id)
                        {
                            ListaEtiketa.RemoveAt(i);
                        }
                    }

                    for (int i = 0; i < EtiketeIzabranog.Count; i++)
                    {
                        if (EtiketeIzabranog[i].id == e.id)
                        {
                            EtiketeIzabranog.RemoveAt(i);
                        }
                    }

                    for (int i = 0; i < ListaLokala.Count; i++) //svaki lokal               // j - indeks etikete lokala
                    {
                        for (int j = 0; j < ListaLokala[i].listaEtiketaLokala.Count; j++)   //svaka lista etiketa lokala        //ako sadrzi tu etiketu makni                                                                                     
                        {
                            if (ListaLokala[i].listaEtiketaLokala[j].id == e.id)
                            {
                                ListaLokala[i].listaEtiketaLokala.RemoveAt(j);
                            }
                        }
                    }
                }
            }

            daoEtiketa.upisiUFajl(ListaEtiketa);
            daoLokal.upisiUFajl(ListaLokala);
        }

        // KAD JE LOKAL IZABRAN
        private void lokalDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EtiketeIzabranog.Clear();
            izabraniLokal = (Lokal)lokalDataGrid.SelectedItem;

            if (izabraniLokal == null)
            {
                slikaIzabranogLokala.Source = null;
                imeIzabranogLokala.Text = "";
                tipIzabranogLokala.Text = "";
            }
            else
            {
                if (izabraniLokal.listaEtiketaLokala.Count > 0)
                {
                    foreach (Etiketa etik in izabraniLokal.listaEtiketaLokala)
                    {
                        EtiketeIzabranog.Add(new Etiketa(etik));
                    }
                }

                BitmapImage img = new BitmapImage(new Uri(izabraniLokal.imagePath));
                slikaIzabranogLokala.Source = img;
                imeIzabranogLokala.Text = izabraniLokal.ime;
                tipIzabranogLokala.Text = izabraniLokal.tip;
            }
        }

        private void dodajEtiketuIzabranomLokalu_Click(object sender, RoutedEventArgs e)
        {
            IzaberiEtikete ie = new IzaberiEtikete(this);
            ie.Show();
        }

        private void izbrisiEtiketuIzabranomLokalu_Click(object sender, RoutedEventArgs e)
        {
            Etiketa eZaBrisanje = (Etiketa)dataGridIzabranogLokala.SelectedItem;
            if (eZaBrisanje != null)
            {
                izbrisiEtiketuIzListe(eZaBrisanje.id);
            }
            else
            {
                MessageBox mb = new MessageBox("Morate izabrati etiketu za brisanje.");
                mb.Show();
            }
        }

        private void izbrisiEtiketuIzListe(string idEtik)
        {
            for (int i = 0; i < ListaLokala.Count; i++)     //brisi iz liste etiketa lokala
            {
                if (ListaLokala[i].id == izabraniLokal.id)
                {
                    for (int j = 0; j < ListaLokala[i].listaEtiketaLokala.Count; j++)
                    {
                        if (ListaLokala[i].listaEtiketaLokala[j].id == idEtik)
                        {
                            ListaLokala[i].listaEtiketaLokala.RemoveAt(j);
                        }
                    }
                }
            }

            daoLokal.upisiUFajl(ListaLokala);

            for (int i = 0; i < EtiketeIzabranog.Count; i++)        //brisi iz viewa DATAGRID
            {
                if (EtiketeIzabranog[i].id == idEtik)
                {
                    EtiketeIzabranog.RemoveAt(i);
                }
            }
        }

        private void slikaIzabranogLokala_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Get the dragged ListViewItem
                Image image = sender as Image;
                //DataGridTemplateColumn dataGridTemplateColumn =
                // FindAncestor<DataGridTemplateColumn>((DependencyObject)e.OriginalSource);


                // Find the data behind the ListViewItem
                //Image image = (Image)image.ItemContainerGenerator.
                // ItemFromContainer(dataGridTemplateColumn);

                // Initialize the drag & drop operation
                /*if (image.Source != null)
                {*/
                DataObject dragData = new DataObject("myFormat", image.Source);
                DragDrop.DoDragDrop(image, dragData, DragDropEffects.Link);
                //}
            }
        }

        private void slikaIzabranogLokala_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void mapa_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void mapa_Drop(object sender, DragEventArgs e)
        {
            Image imageControl = new Image();
            if (e.Data.GetDataPresent("myFormat"))
            {
                ImageSource image = e.Data.GetData("myFormat") as ImageSource;
                imageControl = new Image() { Width = 50, Height = 30, Source = image };



                /*if (Tabela.SelectedIndex > -1)
                {
                    Spomenik s = spomenici.ElementAt(Tabela.SelectedIndex);
                    r.Obrisi(s);
                    spomenici.Clear();
                    UcitajSpomenike();
                }*/


            }
            else
            {
                Image image = e.Data.GetData(typeof(Image)) as Image;
                imageControl = image;
                if (this.mapa.Children.Contains(imageControl))
                {
                    this.mapa.Children.Remove(imageControl);
                }
            }
            //Spomenik s = spomenici.ElementAt(Tabela.SelectedIndex);
            Lokal l = ListaLokala.ElementAt(lokalDataGrid.SelectedIndex);

            if (!lokaliNaMapi.ContainsKey(imageControl))
            {
                Canvas.SetLeft(imageControl, e.GetPosition(this.mapa).X - imageControl.Width / 2);
                Canvas.SetTop(imageControl, e.GetPosition(this.mapa).Y - imageControl.Height / 2);
                daoLokal.remove(l);
                ListaLokala = daoLokal.ucitajListuLokala();
                l.naMapi = true;
                l.left = e.GetPosition(this.mapa).X - imageControl.Width / 2;
                l.top = e.GetPosition(this.mapa).Y - imageControl.Height / 2;
                lokaliNaMapi.Remove(imageControl);
                lokaliNaMapi.Add(imageControl,l);
                daoLokal.write(l);
                ListaLokala = daoLokal.ucitajListuLokala();
                imageControl.PreviewMouseLeftButtonDown += imageControl_PreviewMouseLeftButtonDown;
                imageControl.MouseLeftButtonDown += imageControl_MouseLeftButtonDown;
                imageControl.MouseRightButtonDown += imageControl_MouseRightButtonDown;
                this.mapa.Children.Add(imageControl);
            }
            else if (lokaliNaMapi.ContainsKey(imageControl))
            {
                lokaliNaMapi.Remove(imageControl);
                Canvas.SetLeft(imageControl, e.GetPosition(this.mapa).X - imageControl.Width / 2);
                Canvas.SetTop(imageControl, e.GetPosition(this.mapa).Y - imageControl.Height / 2);
                daoLokal.remove(l);
                ListaLokala = daoLokal.ucitajListuLokala();
                l.naMapi = true;
                l.left = e.GetPosition(this.mapa).X - imageControl.Width / 2;
                l.top = e.GetPosition(this.mapa).Y - imageControl.Height / 2;
                lokaliNaMapi.Add(imageControl, l);
                daoLokal.write(l);
                ListaLokala = daoLokal.ucitajListuLokala();
                /*imageControl.PreviewMouseLeftButtonDown += imageControl_PreviewMouseLeftButtonDown;
                imageControl.MouseLeftButtonDown += imageControl_MouseLeftButtonDown;
                imageControl.MouseRightButtonDown += imageControl_MouseRightButtonDown;*/
                this.mapa.Children.Add(imageControl);
            }
        }

        private void imageControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //messageboxresult dialogresult = messagebox.show("da li zelite da obrisete spomenik?", "brisanje spomenika sa mape", messageboxbutton.yesno);
            //if (dialogresult == messageboxresult.yes)
            //{
            //    image image = e.source as image;
            //    this.mapa.children.remove(image);
            //    messagebox.show("spomenik je obrisan");
            //    spomenik s = spomenicinamapi[image];
            //    r.obrisi(s);
            //    s.namapi = false;
            //    r.dodaj(s);
            //    spomenicinamapi.clear();
            //    ucitajmapu();
            //}
            //else if (dialogresult == messageboxresult.no)
            //{
            //    return;
            //}
        }

        private void imageControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(Image), image);
            DragDrop.DoDragDrop(image, data, DragDropEffects.Move);
        }

        private void imageControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            Lokal l = lokaliNaMapi[image];
            int indeks = -1;
            foreach (Lokal lokal in ListaLokala) {
                if (lokal.id == l.id) {
                    indeks = ListaLokala.IndexOf(lokal);
                    break;
                }
            }
            //TODO
            lokalDataGrid.SelectedIndex = ListaLokala.Count -  indeks - 1;
        }
    }

    

}
