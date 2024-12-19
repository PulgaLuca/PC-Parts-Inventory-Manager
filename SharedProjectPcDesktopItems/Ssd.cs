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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PcDesktopPersonalizzato
{
    [DataContract(Name = "Ssd", Namespace = "pcDesktopPersonalizzato")]
    public class Ssd : MemoriaDiMassa
    {

        public string Image { get; set; }

        public Ssd() { }

        public Ssd(string p, string d, double pr, string n, int w, int spazio, double velocita, double diametro, double volume, string img) : base(p, d, pr, n, w, spazio, velocita, diametro, volume) { Image = img;  }

        public override string ToString()
        {
            return " SSD: \n" + base.ToString() + "\n";
        }
    }
}
