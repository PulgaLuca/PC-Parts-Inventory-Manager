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
    [DataContract(Name = "Processore", Namespace = "pcDesktopPersonalizzato")]
    public  class Processore : Componente
    {

        [DataMember(Name = "Core")]
        public  int Cores { get; set; }
        [DataMember(Name = "Frequenza")]
        public  double Frequency { get; set; }
        [DataMember(Name = "Serie")]
        public  string Serie { get; set; }

        public Processore() { }

        public Processore(string p, string d, double pr, string n, int w, int c, double f, string s) : base(p, d, pr, n, w)
        {
            Cores = c;
            Frequency = f;
            Serie = s;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + 
                $" Cores: {Cores}\n" +
                $" Frequency: {Frequency}\n" +
                $" Serie: {Serie}\n";
        }
    }
}
