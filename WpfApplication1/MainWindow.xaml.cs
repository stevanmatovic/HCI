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
        public Resurs izabraniResurs { get; set; }
        public ObservableCollection<Etiketa> EtiketeIzabranog { get; set; }

        public ObservableCollection<Resurs> ListaResursa { get; set; }
        public ResursDAO daoLokal;

        public ObservableCollection<TipResursa> ListaTipova { get; set; }
        public TipDAO daoTip;

        public ObservableCollection<Etiketa> ListaEtiketa { get; set; }
        public EtiketaDAO daoEtiketa;

        public static Dictionary<Image, Resurs> lokaliNaMapi { get; set; }

        Point startPoint = new Point();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            slikaIzabranogLokala.Source = null;
            imeIzabranogLokala.Text = "";
            tipIzabranogLokala.Text = "";

            daoLokal = new ResursDAO();
            ListaResursa = daoLokal.ucitajListuResursa();

            daoTip = new TipDAO();
            ListaTipova = daoTip.ucitajListuTipova();

            daoEtiketa = new EtiketaDAO();
            ListaEtiketa = daoEtiketa.ucitajListuEtiketa();
          
            EtiketeIzabranog = new ObservableCollection<Etiketa>();

            lokaliNaMapi = new Dictionary<Image, Resurs>();
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

        private void dodajResursButton_Click(object sender, RoutedEventArgs e)
        {
            EntryWindow ew = new EntryWindow(this);
            ew.Show();
        }

        private void izmeniResursButton_Click(object sender, RoutedEventArgs e)
        {
            Resurs l = (Resurs)lokalDataGrid.SelectedItem;
            IzmeniPodatkeResursa ipl = new IzmeniPodatkeResursa(this);
            ipl.inicijalizujLokalZaEdit(l);
            Resurs ret = ipl.vratiIzmenjen();

            if (l != null)
            {
                for (int i = 0; i < ListaResursa.Count; i++)
                {
                    if (ListaResursa[i].id == l.id)
                    {
                        ListaResursa.RemoveAt(i);
                        ListaResursa.Insert(i, ret);
                    }
                }
            }
        }

        private void izbrisiResursButton_Click(object sender, RoutedEventArgs e)
        {
            Resurs l = (Resurs)lokalDataGrid.SelectedItem;
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
            if (ListaResursa != null)
            {
                if (!id.Equals(""))
                {
                    for (int i = 0; i < ListaResursa.Count; i++)
                    {
                        if ((ListaResursa[i].id).Equals(id))
                        {
                            ListaResursa.RemoveAt(i);
                        }
                    }
                }
            }
            daoLokal.upisiUFajl(ListaResursa);
        }

        private void dodajTipButton_Click(object sender, RoutedEventArgs e)
        {
            TypeWindow tw = new TypeWindow(this);
            tw.Show();
        }

        private void izmeniTipButton_Click(object sender, RoutedEventArgs e)
        {
            TipResursa tipIzmena = (TipResursa)tipoviDataGrid.SelectedItem;
            IzmeniTipLokala itl = new IzmeniTipLokala(this);
            itl.inicijalizujTipZaEdit(tipIzmena);
            TipResursa ret = itl.vratiIzmenjen();
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
            
            TipResursa tl = (TipResursa)tipoviDataGrid.SelectedItem;
            string idTipa = tl.id;
            if (tl != null)
            {
                for (int i = 0; i < ListaResursa.Count; i++)
                {
                    string idTipaLokala = ListaResursa[i].tipResursa.id;
                    if (idTipaLokala.Equals(idTipa))
                    {
                        counter++;
                        idLokalaZaBrisanje.Add(ListaResursa[i].id);
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

        public void izbrisiTipIzListe(TipResursa tl)
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

                    for (int i = 0; i < ListaResursa.Count; i++) //svaki lokal               // j - indeks etikete lokala
                    {
                        for (int j = 0; j < ListaResursa[i].listaEtiketaResursa.Count; j++)   //svaka lista etiketa lokala        //ako sadrzi tu etiketu makni                                                                                     
                        {
                            if (ListaResursa[i].listaEtiketaResursa[j].id == e.id)
                            {
                                ListaResursa[i].listaEtiketaResursa.RemoveAt(j);
                            }
                        }
                    }
                }
            }

            daoEtiketa.upisiUFajl(ListaEtiketa);
            daoLokal.upisiUFajl(ListaResursa);
        }

        // KAD JE LOKAL IZABRAN
        private void lokalDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EtiketeIzabranog.Clear();
            izabraniResurs = (Resurs)lokalDataGrid.SelectedItem;

            if (izabraniResurs == null)
            {
                slikaIzabranogLokala.Source = null;
                imeIzabranogLokala.Text = "";
                tipIzabranogLokala.Text = "";
            }
            else
            {
                if (izabraniResurs.listaEtiketaResursa.Count > 0)
                {
                    foreach (Etiketa etik in izabraniResurs.listaEtiketaResursa)
                    {
                        EtiketeIzabranog.Add(new Etiketa(etik));
                    }
                }

                BitmapImage img = new BitmapImage(new Uri(izabraniResurs.imagePath));
                slikaIzabranogLokala.Source = img;
                imeIzabranogLokala.Text = izabraniResurs.ime;
                tipIzabranogLokala.Text = izabraniResurs.tip;
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
            for (int i = 0; i < ListaResursa.Count; i++)     //brisi iz liste etiketa lokala
            {
                if (ListaResursa[i].id == izabraniResurs.id)
                {
                    for (int j = 0; j < ListaResursa[i].listaEtiketaResursa.Count; j++)
                    {
                        if (ListaResursa[i].listaEtiketaResursa[j].id == idEtik)
                        {
                            ListaResursa[i].listaEtiketaResursa.RemoveAt(j);
                        }
                    }
                }
            }

            daoLokal.upisiUFajl(ListaResursa);

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
            Resurs l = ListaResursa.ElementAt(lokalDataGrid.SelectedIndex);

            if (!lokaliNaMapi.ContainsKey(imageControl))
            {
                Canvas.SetLeft(imageControl, e.GetPosition(this.mapa).X - imageControl.Width / 2);
                Canvas.SetTop(imageControl, e.GetPosition(this.mapa).Y - imageControl.Height / 2);
                daoLokal.remove(l);
                ListaResursa = daoLokal.ucitajListuResursa();
                l.naMapi = true;
                l.left = e.GetPosition(this.mapa).X - imageControl.Width / 2;
                l.top = e.GetPosition(this.mapa).Y - imageControl.Height / 2;
                lokaliNaMapi.Remove(imageControl);
                lokaliNaMapi.Add(imageControl,l);
                daoLokal.write(l);
                ListaResursa = daoLokal.ucitajListuResursa();
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
                ListaResursa = daoLokal.ucitajListuResursa();
                l.naMapi = true;
                l.left = e.GetPosition(this.mapa).X - imageControl.Width / 2;
                l.top = e.GetPosition(this.mapa).Y - imageControl.Height / 2;
                lokaliNaMapi.Add(imageControl, l);
                daoLokal.write(l);
                ListaResursa = daoLokal.ucitajListuResursa();
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
            Resurs l = lokaliNaMapi[image];
            int indeks = -1;
            foreach (Resurs lokal in ListaResursa) {
                if (lokal.id == l.id) {
                    indeks = ListaResursa.IndexOf(lokal);
                    break;
                }
            }
            //TODO
            lokalDataGrid.SelectedIndex = ListaResursa.Count -  indeks - 1;
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    

}
