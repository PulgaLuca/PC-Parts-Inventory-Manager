/*
 * Autore: Pulga Luca;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcDesktopPersonalizzatoWPF.ViewModel
{
    public class Product
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string Image { get; set; }
        public Product(string n, double v, string i)
        {
            Name = n;
            Value = v;
            Image = i;
        }
    }
}
