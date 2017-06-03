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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for UpozorenjeZaBrisanjeTipa.xaml
    /// </summary>
    public partial class UpozorenjeZaBrisanjeTipa : Window
    {

        MainWindow parentMW;
        TipLokala tipL;
        List<string> lokaliID;
        
        public UpozorenjeZaBrisanjeTipa(MainWindow mw, TipLokala tl, List<string> listaID, int zavisnih)
        {
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            parentMW = mw;
            tipL = tl;
            lokaliID = listaID;
            tekstUpozorenje.Content = "Ako obrisete izabrani tip lokala, bice izbrisan" + (zavisnih == 1 ? " " : "o ") + "i " + zavisnih + " lokal" + (zavisnih == 1 ? " \n" : "a \n") + " koji " + (zavisnih == 1 ? "je" : "su") + " izabranog tipa. \nNastavite sa brisanjem?";
        }

        private void izbrisiTipButton_Click(object sender, RoutedEventArgs e)
        {
            parentMW.izbrisiTipIzListe(tipL);

            for (int i = 0; i < parentMW.ListaLokala.Count; i++)
            {
                foreach (string id in lokaliID)
                {
                    if ((parentMW.ListaLokala[i].id).Equals(id))
                    {
                        parentMW.izbrisiLokalIzListe(id);
                    }
                }
            }
            
            //
            this.Close();
        }

        private void odustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
