/*
 * Autore: Pulga Luca;
 * Classe: 4^L;
 * Data di inizio: 03/03/2021
 * Data di consegna: 21/04/2021
 * Scopo: Due App per la scelta dei componenti e la configurazione di un PC Desktop, una console e una WPF con le librerie condivise.
Le App e le librerie nella medesima soluzione Visual Studio.

Funzionalità per l'utente:
* Inserimento articolo
* Modifica dati articolo
* Elimina articolo
* Scelta componenti per il PC e visualizzazione finale

Specifiche sulle classi:
Previsti almeno due livelli di ereditarietà per alcuni oggetti, per pochi tre livelli di ereditarietà a scelta a discrezione del programmatore.
*/
using PcDesktopPersonalizzatoWPF.ViewModel;
using PcDesktopPersonalizzato;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using PcDesktopPersonalizzatoWPF.Properties;

namespace PcDesktopPersonalizzatoWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
            #region Menu items.
            var menuAlimentatore = new List<SubItem>();
            menuAlimentatore.Add(new SubItem("ALIMENTATORI", new UserControlAlimentatore()));
            var item5 = new ItemMenu("   Alimentatore", menuAlimentatore, PackIconKind.Abacus);

            var menuCase = new List<SubItem>();
            menuCase.Add(new SubItem("CASE", new UserControlCase()));
            var item6 = new ItemMenu("   Case", menuCase, PackIconKind.Abacus);

            var menuProcessori = new List<SubItem>();
            menuProcessori.Add(new SubItem("CPU", new UserControlCpu()));
            menuProcessori.Add(new SubItem("GPU", new UserControlGpu()));
            var item1 = new ItemMenu("   Processori", menuProcessori, PackIconKind.Menu);

            var menuMobo = new List<SubItem>();
            menuMobo.Add(new SubItem("MOTHERBOARD", new UserControlMobo()));
            var item0 = new ItemMenu("   MotherBoard", menuMobo, PackIconKind.Menu);

            var menuRam = new List<SubItem>();
            menuRam.Add(new SubItem("RAM", new UserControlRam()));
            var item2 = new ItemMenu("   Ram", menuRam, PackIconKind.Menu);

            var menuMemDiMassa = new List<SubItem>();
            menuMemDiMassa.Add(new SubItem("HDD", new UserControlHdd()));
            menuMemDiMassa.Add(new SubItem("SSD", new UserControlSsd()));
            var item3 = new ItemMenu("   Memoria di massa", menuMemDiMassa, PackIconKind.Menu);

            var menuSchedaAudio = new List<SubItem>();
            menuSchedaAudio.Add(new SubItem("SCHEDA AUDIO", new UserControlAudio()));
            var item4 = new ItemMenu("   Scheda audio", menuSchedaAudio, PackIconKind.Menu);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));
            Menu.Children.Add(new UserControlMenuItem(item6, this));
            #endregion

        }

        #region Switch Menu Screen.
        internal void SwitchScreen(object sender)
        {
            var screen = (UserControl)sender;
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
        #endregion

        #region Window events.
        private void btnOnOff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void panelheader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        #endregion
    }
}
