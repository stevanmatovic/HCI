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
        TipResursa tipL;
        List<string> resursiID;
        
        public UpozorenjeZaBrisanjeTipa(MainWindow mw, TipResursa tl, List<string> listaID, int zavisnih)
        {
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            parentMW = mw;
            tipL = tl;
            resursiID = listaID;
            tekstUpozorenje.Content = "Ako obrisete izabrani tip resursa, bice izbrisani svi resursi tog tipa";
        }

        private void izbrisiTipButton_Click(object sender, RoutedEventArgs e)
        {
            parentMW.izbrisiTipIzListe(tipL);

            for (int i = 0; i < parentMW.ListaResursa.Count; i++)
            {
                foreach (string id in resursiID)
                {
                    if ((parentMW.ListaResursa[i].id).Equals(id))
                    {
                        parentMW.izbrisiResursIzListe(id);
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
