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
using PcDesktopPersonalizzato;
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
    /// Logica di interazione per UserControlCpu.xaml
    /// </summary>
    public partial class UserControlCpu : UserControl
    {
        public UserControlCpu()
        {
            InitializeComponent();
            var products = GetCpu();
            if (products.Count > 0)
                ListViewproducts.ItemsSource = products;
        }

        public List<Cpu> GetCpu()
        {
            return new List<Cpu>()
            {
                new Cpu("Cpu 1", "nope", 500.89,"no",90,4,8000,"pulga","mine",8,60,"/Components/cpu.png"),
                new Cpu("Cpu 2", "nope", 1356.89,"no",90,4,8000,"pulga","mine",8,60,"/Components/cpu.png"),
                new Cpu("Cpu 3", "nope", 200.89,"no",90,4,8000,"pulga","mine",8,60,"/Components/cpu.png"),
            };
        }
    }
}
