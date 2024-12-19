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
    [DataContract(Name = "Ram", Namespace = "pcDesktopPersonalizzato")]
    public class Ram : MemoriaVolatile
    {

        [DataMember(Name = "Wattaggio")]
        public double Capacità { get; set; }
        [DataMember(Name = "Wattaggio")]
        public double Frequenza { get; set; }
        [DataMember(Name = "Wattaggio")]
        public double Voltaggio { get; set; }

        public enum Dissipatore { lowProfile, highprofile}
        public enum Modulo { DIMM, SODIMM }
        public enum Tipologia { SRAM, DRAM, SDRAM, FeRAM}

        public string Image { get; set; }

        public Ram() { }

        public Ram(string p, string d, double pr, string n, int w, double capacita, double frequenza, double volt, string img) : base(p, d, pr, n, w)
        {
            Capacità = capacita;
            Frequenza = frequenza;
            Voltaggio = volt;
            Image = img;
        }


        public override string ToString()
        {
            return " RAM: \n" + base.ToString() + "\n" +
                $" Capacità: {Capacità}\n" +
                $" Frequenza: {Frequenza}\n" +
                $" Voltaggio: {Voltaggio}\n" +
                $" Dissipatore: {Dissipatore.highprofile}\n" +
                $" Tipologia: {Tipologia.DRAM}\n";
        }
    }
}
