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
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PcDesktopPersonalizzato
{
    public class Alimentatore : Componente
    {
        //[DataMember]
        public enum FormFactor { ATX, LPX, SFX }
        //[DataMember]
        public enum Modular { Modular, NotModular, SemiModular }

        [XmlAttribute("NConnettoriCpu")]
        public int NConnettoriCpu { get; set; }
        public int NConnettoriMobo { get; set; }
        public int NPciExpress { get; set; }
        public int NSata { get; set; }

        public string Image { get; set; }

        public Alimentatore() { }

        public Alimentatore(string p, string d, double pr, string n, int w, int ncpu, int nmobo, int npcie, int nsata, string img) : base(p, d, pr, n, w)
        {
            NConnettoriCpu = ncpu;
            NConnettoriMobo = nmobo;
            NPciExpress = npcie;
            NSata = nsata;
            Image = img;
        }

        public override string ToString()
        {
            return " ALIMENTATORE: \n" + base.ToString() + "\n" + 
                $" Numero connettori cpu: {NConnettoriCpu}\n" +
                $" Numero connettori mobo: {NConnettoriMobo}\n" +
                $" Numero Pci Express: {NPciExpress}\n" +
                $" Numero connettori sata: {NSata}\n";
        }
        
    }
    
}
