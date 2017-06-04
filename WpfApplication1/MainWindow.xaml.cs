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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
        public ResursDAO daoResurs;

        public ObservableCollection<TipResursa> ListaTipova { get; set; }
        public TipDAO daoTip;

        public ObservableCollection<Etiketa> ListaEtiketa { get; set; }
        public EtiketaDAO daoEtiketa;

        public List<Tacke> positions = new List<Tacke>();

        public static Dictionary<Image, Resurs> lokaliNaMapi { get; set; }

        public static Dictionary<String, Canvas> skladiste = new Dictionary<String, Canvas>();

        private MapaDAO mapaDao;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            slikaIzabranogLokala.Source = null;
            imeIzabranogLokala.Text = "";
            tipIzabranogLokala.Text = "";

            daoResurs = new ResursDAO();
            ListaResursa = daoResurs.ucitajListuResursa();

            daoTip = new TipDAO();
            ListaTipova = daoTip.ucitajListuTipova();

            daoEtiketa = new EtiketaDAO();
            ListaEtiketa = daoEtiketa.ucitajListuEtiketa();
          
            EtiketeIzabranog = new ObservableCollection<Etiketa>();

            lokaliNaMapi = new Dictionary<Image, Resurs>();


            mapaDao = new MapaDAO();

            ucitajMapu();
           
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
            Resurs r = (Resurs)lokalDataGrid.SelectedItem;
            IzmeniPodatkeResursa ipl = new IzmeniPodatkeResursa(this);
            ipl.inicijalizujResursZaEdit(r);
            Resurs ret = ipl.vratiIzmenjen();

            if (r != null)
            {
                for (int i = 0; i < ListaResursa.Count; i++)
                {
                    if (ListaResursa[i].id == r.id)
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
            daoResurs.upisiUFajl(ListaResursa);
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



        public void ucitajMapu() {

            foreach (Resurs r in ListaResursa) {

                ImageBrush image = new ImageBrush();
                image.ImageSource = new BitmapImage(new Uri(r.imagePath, UriKind.Relative));

                Canvas c1 = new Canvas();
                c1.Background = image;
                c1.Width = 25;
                c1.Height = 25;

                c1.AllowDrop = true;

                Canvas.SetTop(c1, r.pozicijaY);
                Canvas.SetLeft(c1, r.pozicijaX);

                mapa.Children.Add(c1);

                skladiste.Add(r.id, c1);
            }

        }


        internal void dodajSliku(Resurs r)
        {
          
            
            
            ImageBrush image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri(r.imagePath, UriKind.Relative));

            Canvas c1 = new Canvas();
            c1.Background = image;
            c1.Width = 25;
            c1.Height = 25;

            skladiste.Add(r.id, c1);

            Random rand = new Random();
            double y = rand.NextDouble() * (mapa.Height - 230);
            double x = rand.NextDouble() * (mapa.Width - 229);
            r.pozicijaX = x;
            r.pozicijaY = y;
            

            Canvas.SetTop(c1, y);
            Canvas.SetLeft(c1, x);
            

            mapa.Children.Add(c1);

            mapaDao.sacuvajMapu(mapa);
            c1.AllowDrop = true;
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
            daoResurs.upisiUFajl(ListaResursa);
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

            daoResurs.upisiUFajl(ListaResursa);

            for (int i = 0; i < EtiketeIzabranog.Count; i++)        //brisi iz viewa DATAGRID
            {
                if (EtiketeIzabranog[i].id == idEtik)
                {
                    EtiketeIzabranog.RemoveAt(i);
                }
            }
        }


        Point startPosition; //tacka koja predstavlja startnu poziciju kliknutog widgeta
        private Canvas draggedImage;
        private Point mousePosition;
        

        private void mapa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = e.Source as Canvas;

            if (image != null && mapa.CaptureMouse())
            {
                mousePosition = e.GetPosition(mapa);
                draggedImage = image;
                Panel.SetZIndex(draggedImage, 1);
            }
        }

        private void mapa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedImage != null)
            {
                mapa.ReleaseMouseCapture();
                Panel.SetZIndex(draggedImage, 0);
               

                String id = skladiste.FirstOrDefault(x => x.Value == draggedImage).Key;

                

                foreach (Resurs r in ListaResursa)
                {
                    if (r.id == id)
                    {
                        r.pozicijaX = Canvas.GetLeft(draggedImage);
                        r.pozicijaY = Canvas.GetTop(draggedImage);
                    }
                }
                daoResurs.upisiUFajl(ListaResursa);

                draggedImage = null;
            }
            
            

        }

        private void mapa_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedImage != null)
            {
                double canvasHeight = mapa.ActualHeight;
                double canvasWidth = mapa.ActualWidth;
                var position = e.GetPosition(mapa);
                var offset = position - startPosition;
                startPosition = position;

                double newLeft = position.X;
                double newTop = position.Y;

                if (newLeft < 0)
                    newLeft = 0;
                else if (newLeft + draggedImage.ActualWidth > canvasWidth)
                    newLeft = canvasWidth - draggedImage.ActualWidth;

                if (newTop < 0)
                    newTop = 0;
                else if (newTop + draggedImage.ActualHeight > canvasHeight)
                    newTop = canvasHeight - draggedImage.ActualHeight;

                Canvas.SetLeft(draggedImage, newLeft);
                Canvas.SetTop(draggedImage, newTop);


            }
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        


        Point startPoint = new Point();

        private void mapa_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void mapa_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void mapa_MouseMove_1(object sender, MouseEventArgs e)
        {

        }
    }

}
