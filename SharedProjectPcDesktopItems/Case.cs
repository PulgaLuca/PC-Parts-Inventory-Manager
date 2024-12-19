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
    [DataContract(Name = "Case", Namespace = "pcDesktopPersonalizzato")]
    public class Case : Componente
    {

        [DataMember(Name = "NumeroDiVentole")]
        public int nVentole { get; set; }
        [DataMember(Name = "Colore")]
        public string Colore { get; set; }

        public enum TipoDiCase { microtower, minitower, midTower, fullTower }
        public string Image { get; set; }

        public Case() { }

        public Case(string p, string d, double pr, string n, int w, int nventole, string colore, string img) : base(p, d, pr, n, w)
        {
            nVentole = nventole;
            Colore = colore;
            Image = img;
        }

        public override string ToString()
        {
            return " CASE: \n" + base.ToString() + "\n" +
                $" Numero ventole: {nVentole}\n" +
                $" Colore: {Colore}\n" +
                $" Tipologia: {TipoDiCase.fullTower}\n";
        }
    }
}
