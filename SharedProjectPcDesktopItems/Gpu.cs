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
    [DataContract(Name = "Gpu", Namespace = "pcDesktopPersonalizzato")]
    public class Gpu : Processore
    {
        [DataMember(Name = "Tflops")]
        public double TFLOPS { get; set; }

        public string Image { get; set; }

        public enum Brand { PALIT, ZOTAC, AMD, NVIDIA, GIGABYTE, MSI, ASUS, ALTRO }

        public Gpu() { }

        public Gpu(string p, string d, double pr, string n, int w, int c, double f, string s, string cpusocket, int thread, double tpd, string img) : base(p, d, pr, n, w, c, f, s) { Image = img; }

        public override string ToString()
        {
            return " GPU: \n" + base.ToString() + "" +
                $" TFLOPS: {TFLOPS}\n" +
                $" Core: {Cores}\n" +
                $" Frequency: {Frequency}\n" +
                $" Serie: {Serie}\n" +
                $" Brand: {Brand.NVIDIA}\n";
        }
    }
}
