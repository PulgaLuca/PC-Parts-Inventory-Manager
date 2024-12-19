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
    [DataContract(Name = "Cpu", Namespace = "pcDesktopPersonalizzato")]
    public class Cpu : Processore
    {
        public enum Brand { AMD, INTEL, APPLE, ALTRO}
        [DataMember(Name = "CpuSockets")]
        public string CpuSockets { get; set; }
        [DataMember(Name = "Thread")]
        public int Thread { get; set; }
        [DataMember(Name = "Tpd")]
        public double TPD { get; set; } // Thermal power design.


        public string Image { get; set; }

        public Cpu() { }

        public Cpu(string p, string d, double pr, string n, int w, int c, double f, string s, string cpusocket, int thread, double tpd,string img) : base(p, d, pr, n, w, c,f,s)
        {
            CpuSockets = cpusocket;
            Thread = thread;
            TPD = tpd;
            Image = img;
        }

        public override string ToString()
        {
            return " CPU: \n" + base.ToString() + "" +
                $" Brand: {Brand.ALTRO}\n" +
                $" Cpu sockets: {CpuSockets}\n" +
                $" Thread: {Thread}\n" +
                $" TPD: {TPD}\n";
        }
    }
}
