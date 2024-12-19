﻿/*
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
    [DataContract(Name = "SchedaMadre", Namespace = "pcDesktopPersonalizzato")]
    public class SchedaMadre : Componente
    {
        public enum Socket { LGA, PGA }

        [DataMember(Name = "NumeroSlotRam")]
        public int NSlotRam { get; set; }
        [DataMember(Name = "Chipset")]
        public string Chipset { get; set; }
        [DataMember(Name = "SchedaVideoIntegrata")]
        public bool SchedaVideoIntegrata { get; set; }
        [DataMember(Name = "AudioIntegrato")]
        public bool AudioIntegrato { get; set; }
        [DataMember(Name = "Rete")]
        public string Rete { get; set; } // LAN: 1000BASE-T Tecnologia: Realtek RTL8118 ASH-CG //Velocità di trasferimento dei dati: fino a 10/100/1000 Mb/s //Standard di trasmissione: 1000BASE-T Ethernet

        public string Image { get; set; }

        public SchedaMadre() { }

        public SchedaMadre(string p, string d, double pr, string n, int w, int nslotram, string chipset, bool schedavideointergrata, bool audiointegrato, string rete, string img) : base(p, d, pr, n, w)
        {
            NSlotRam = nslotram;
            Chipset = chipset;
            SchedaVideoIntegrata = schedavideointergrata;
            AudioIntegrato = audiointegrato;
            Rete = rete;
            Image = img;
        }

        public override string ToString()
        {
            return " SCHEDA MADRE: \n" + base.ToString() + "\n" +
                $" Socket: {Socket.LGA}\n" +
                $" Numero slot ram: {NSlotRam}\n" +
                $" Chipset: {Chipset}\n" +
                $" Scheda Video Integrata: {SchedaVideoIntegrata}\n" +
                $" Audio Integrato: {AudioIntegrato}\n" +
                $" Rete: {Rete}\n";
        }
    }
}
