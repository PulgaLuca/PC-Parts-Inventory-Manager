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

namespace PcDesktopPersonalizzatoWPF
{
    /// <summary>
    /// Logica di interazione per UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;
        public UserControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();
            _context = context;
            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
        }
    }
}
