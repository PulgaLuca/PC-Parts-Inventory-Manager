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
    [DataContract(Name = "MemoriaDiMassa", Namespace = "pcDesktopPersonalizzato")]
    public  class MemoriaDiMassa : Componente
    {

        [DataMember(Name = "SpazioDiArchiviazione")]
        public  int SpazioDiArchiviazione { get; set; }
        [DataMember(Name = "VelocitàTrasferiementoDati")]
        public  double VelocitàTrasferimentoDati { get; set; }
        [DataMember(Name = "DiametroDisco")]
        public  double DiametroDisco { get; set; }
        [DataMember(Name = "Volume")]
        public double Volume { get; set; }


        public enum Porta {sata, pata, usb}

        public MemoriaDiMassa() { }

        public MemoriaDiMassa(string p, string d, double pr, string n, int w, int spazio, double velocita, double diametro, double volume) : base(p, d, pr, n, w)
        {
            SpazioDiArchiviazione = spazio;
            VelocitàTrasferimentoDati = velocita;
            DiametroDisco = diametro;
            Volume = volume;
        }

        public override string ToString()
        {
            return " " + base.ToString() + $"" +
                $" Spazio di archiviazione: {SpazioDiArchiviazione}\n" +
                $" Porta: {Porta.sata}\n" +
                $" Velocità trasferimento dati: {VelocitàTrasferimentoDati}\n" +
                $" Diametro disco: {DiametroDisco}\n" +
                $" Volume: {Volume}\n";
        }
    }
}
