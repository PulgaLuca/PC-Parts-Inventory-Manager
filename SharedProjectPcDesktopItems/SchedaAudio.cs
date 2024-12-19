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
    [DataContract(Name = "SchedaAudio", Namespace = "pcDesktopPersonalizzato")]
    public class SchedaAudio : Componente
    {
        [DataMember(Name = "BitRate")]
        public double BitRate { get; set; }
        [DataMember(Name = "Decibel")]
        public double Db { get; set; }
        [DataMember(Name = "Impianto")]
        public string Impianto { get; set; }

        public string Image { get; set; }

        public SchedaAudio() { }

        public SchedaAudio(string p, string d, double pr, string n, int w, double bit, double db, string impianto, string img) : base(p, d, pr, n, w)
        {
            BitRate = bit;
            Db = db;
            Impianto = impianto;
            Image = img;
        }

        public override string ToString()
        {
            return " SCHEDA AUDIO: \n" + base.ToString() + "\n" +
                $" Bit rate: {BitRate}\n" +
                $" Db: {Db}\n" +
                $" Impianto: {Impianto}\n";
        }
    }
}
