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
    [DataContract(Name = "Hdd", Namespace = "pcDesktopPersonalizzato")]
    public class Hdd : MemoriaDiMassa
    {
        [DataMember(Name = "Rpm")]
        public int? Rpm { get; set; }

        public enum Interface { IDE, EIDE, SCSI, FireWire, SATA, USB }


        public string Image { get; set; }

        public Hdd() { }

        public Hdd(string p, string d, double pr, string n, int w, int spazio, double velocita, double diametro, double volume, int rpm, string img) : base(p, d, pr, n, w, spazio, velocita, diametro, volume)
        {
            Rpm = rpm;
            Image = img;
        }

        public override string ToString()
        {
            return " HDD: \n" + base.ToString() + "\n" +
                $" Rpm: {Rpm}\n" + 
                $" Interface: {Interface.SATA}\n";
        }
    }
}
