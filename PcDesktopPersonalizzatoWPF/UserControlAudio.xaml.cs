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
    /// Logica di interazione per UserControlAudio.xaml
    /// </summary>
    public partial class UserControlAudio : UserControl
    {
        public UserControlAudio()
        {
            InitializeComponent();
            var products = GetAudio();
            if (products.Count > 0)
                ListViewproducts.ItemsSource = products;
        }

        public List<SchedaAudio> GetAudio()
        {
            return new List<SchedaAudio>()
            {
                new SchedaAudio("Scheda audio 1", "nope", 150.89,"no",90,4,8,"pulga","/Components/audio.png"),
                new SchedaAudio("Scheda audio 2", "nope", 89.92,"no",90,4,8,"pulga","/Components/audio.png"),
                new SchedaAudio("Scheda audio 3", "nope", 59.89,"no",90,4,8,"pulga","/Components/audio.png"),
            };
        }
    }
}
