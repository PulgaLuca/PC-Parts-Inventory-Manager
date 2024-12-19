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
using System.Threading;
using System.Xml.Serialization;

namespace PcDesktopPersonalizzato
{
    [XmlRoot(ElementName = "Componente")]
    public class Componente
    {
        [DataMember(Name = "Produttore")]
        public  string Produttore { get; set; }
        [DataMember(Name = "Dimensione")]
        public  string Dimensione { get; set; }
        [DataMember(Name = "Prezzo")]
        public  double Prezzo { get; set; }
        [DataMember(Name = "Numero di serie")]
        public  string NumeroDiSerie { get; set; }
        [DataMember(Name = "Wattaggio")]
        public  int Wattaggio { get; set; }

        #region Per bind proprietà wpf.
        Alimentatore Alimentatore;
        Case Case;
        Cpu Cpu;
        Gpu Gpu;
        Hdd Hdd;
        Ram Ram;
        SchedaAudio SchedaAudio;
        SchedaMadre SchedaMadre;
        Ssd Ssd;
        #endregion

        public Componente() { }

        public Componente(string p, string d, double pr, string n, int w)
        {
            Produttore = p;
            Dimensione = d;
            Prezzo = pr;
            NumeroDiSerie = n;
            Wattaggio = w;
        }

        public override string ToString()
        {
            return $"" +
                $" Produttore: {Produttore}\n" +
                $" Numero di serie: {NumeroDiSerie}\n" +
                $" Dimesione: {Dimensione}\n" +
                $" Wattaggio: {Wattaggio}\n" +
                $" Prezzo: {Prezzo}";
        }

        #region Alimentatore.
        /// <summary>
        /// Returna proprietà dell'alimentatore corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetAlimentatore()
        {
            //Alimentatore = new Alimentatore();
            string[] proprietà = new string[6];
            proprietà[0] = Alimentatore.NConnettoriCpu.ToString();
            proprietà[1] = Alimentatore.NConnettoriMobo.ToString();
            proprietà[2] = Alimentatore.NPciExpress.ToString();
            proprietà[3] = Alimentatore.NSata.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà alimentatore.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetAlimentatore(string[] proprietà)
        {
            Alimentatore = new Alimentatore();
            Alimentatore.NConnettoriCpu = int.Parse(proprietà[0]);
            Alimentatore.NConnettoriMobo = int.Parse(proprietà[1]);
            Alimentatore.NPciExpress = int.Parse(proprietà[2]);
            Alimentatore.NSata = int.Parse(proprietà[3]);
        }
        #endregion

        #region Case.
        /// <summary>
        /// Returna proprietà del case corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetCase()
        {
            //Case = new Case();
            string[] proprietà = new string[6];
            proprietà[0] = Case.Colore.ToString();
            proprietà[1] = Case.nVentole.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà case.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetCase(string[] proprietà)
        {
            Case = new Case();
            Case.Colore = proprietà[0];
            Case.nVentole = int.Parse(proprietà[1]);
        }
        #endregion

        #region Cpu.
        /// <summary>
        /// Returna proprietà della cpu corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetCpu()
        {
            //Cpu = new Cpu();
            string[] proprietà = new string[6];
            proprietà[0] = Cpu.Cores.ToString();
            proprietà[1] = Cpu.CpuSockets.ToString();
            proprietà[2] = Cpu.Frequency.ToString();
            proprietà[3] = Cpu.Serie.ToString();
            proprietà[4] = Cpu.Thread.ToString();
            proprietà[5] = Cpu.TPD.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà cpu.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetCpu(string[] proprietà)
        {
            Cpu = new Cpu();
            Cpu.Cores = int.Parse(proprietà[0]);
            Cpu.CpuSockets = proprietà[1];
            Cpu.Frequency = int.Parse(proprietà[2]);
            Cpu.Serie = proprietà[3];
            Cpu.Thread = int.Parse(proprietà[4]);
            Cpu.TPD = int.Parse(proprietà[5]);
        }
        #endregion

        #region Gpu.
        /// <summary>
        /// Returna proprietà della gpu corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetGpu()
        {
            //Gpu = new Gpu();
            string[] proprietà = new string[6];
            proprietà[0] = Gpu.Cores.ToString();
            proprietà[1] = Gpu.Frequency.ToString();
            proprietà[2] = Gpu.Serie.ToString();
            proprietà[3] = Gpu.TFLOPS.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà gpu.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetGpu(string[] proprietà)
        {
            Gpu = new Gpu();
            Gpu.Cores = int.Parse(proprietà[0]);
            Gpu.Frequency = int.Parse(proprietà[1]);
            Gpu.Serie = proprietà[2];
            Gpu.TFLOPS = int.Parse(proprietà[3]);
        }
        #endregion

        #region Hdd.
        /// <summary>
        /// Returna proprietà dell'hdd corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetHdd()
        {
            //Hdd = new Hdd();
            string[] proprietà = new string[6];
            proprietà[0] = Hdd.DiametroDisco.ToString();
            proprietà[1] = Hdd.Rpm.ToString();
            proprietà[2] = Hdd.SpazioDiArchiviazione.ToString();
            proprietà[3] = Hdd.VelocitàTrasferimentoDati.ToString();
            proprietà[4] = Hdd.Volume.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà hdd.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetHdd(string[] proprietà)
        {
            Hdd = new Hdd();
            Hdd.DiametroDisco = int.Parse(proprietà[0]);
            Hdd.Rpm = int.Parse(proprietà[1]);
            Hdd.SpazioDiArchiviazione = int.Parse(proprietà[2]);
            Hdd.VelocitàTrasferimentoDati = int.Parse(proprietà[3]);
            Hdd.Volume = int.Parse(proprietà[4]);
        }
        #endregion

        #region Ssd.
        /// <summary>
        /// Returna proprietà del ssd corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetSsd()
        {
            //Ssd = new Ssd();
            string[] proprietà = new string[6];
            proprietà[0] = Ssd.DiametroDisco.ToString();
            proprietà[1] = Ssd.SpazioDiArchiviazione.ToString();
            proprietà[2] = Ssd.VelocitàTrasferimentoDati.ToString();
            proprietà[3] = Ssd.Volume.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà ssd.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetSsd(string[] proprietà)
        {
            Ssd = new Ssd();
            Ssd.DiametroDisco = int.Parse(proprietà[0]);
            Ssd.SpazioDiArchiviazione = int.Parse(proprietà[1]);
            Ssd.VelocitàTrasferimentoDati = int.Parse(proprietà[2]);
            Ssd.Volume = int.Parse(proprietà[3]);
        }
        #endregion

        #region Ram.
        /// <summary>
        /// Returna proprietà della ram corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetRam()
        {
            //Ram = new Ram();
            string[] proprietà = new string[6];
            proprietà[0] = Ram.Capacità.ToString();
            proprietà[1] = Ram.Frequenza.ToString();
            proprietà[2] = Ram.Voltaggio.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà ram.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetRam(string[] proprietà)
        {
            Ram = new Ram();
            Ram.Capacità = int.Parse(proprietà[0]);
            Ram.Frequenza = int.Parse(proprietà[1]);
            Ram.Voltaggio = int.Parse(proprietà[2]);
        }
        #endregion

        #region Scheda audio.
        /// <summary>
        /// Returna proprietà dell'audio corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetAudio()
        {
            //SchedaAudio = new SchedaAudio();
            string[] proprietà = new string[6];
            proprietà[0] = SchedaAudio.BitRate.ToString();
            proprietà[1] = SchedaAudio.Db.ToString();
            proprietà[2] = SchedaAudio.Impianto.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà audio.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetAudio(string[] proprietà)
        {
            SchedaAudio = new SchedaAudio();
            SchedaAudio.BitRate = int.Parse(proprietà[0]);
            SchedaAudio.Db = int.Parse(proprietà[1]);
            SchedaAudio.Impianto = proprietà[2];
        }
        #endregion

        #region Scheda madre.
        /// <summary>
        /// Returna proprietà della mobo corrente.
        /// </summary>
        /// <returns></returns>
        public string[] GetMobo()
        {
            //SchedaMadre = new SchedaMadre();
            string[] proprietà = new string[6];
            proprietà[0] = SchedaMadre.AudioIntegrato.ToString();
            proprietà[1] = SchedaMadre.Chipset.ToString();
            proprietà[2] = SchedaMadre.NSlotRam.ToString();
            proprietà[3] = SchedaMadre.Rete.ToString();
            proprietà[4] = SchedaMadre.SchedaVideoIntegrata.ToString();
            Thread.Sleep(100);
            return proprietà;
        }
        /// <summary>
        /// Set proprietà mobo.
        /// </summary>
        /// <param name="proprietà"></param>
        public void SetMobo(string[] proprietà)
        {
            SchedaMadre = new SchedaMadre();
            SchedaMadre.AudioIntegrato = bool.Parse(proprietà[0]);
            SchedaMadre.Chipset = proprietà[1];
            SchedaMadre.NSlotRam = int.Parse(proprietà[2]);
            SchedaMadre.Rete = proprietà[3];
            SchedaMadre.SchedaVideoIntegrata = bool.Parse(proprietà[4]);
        }
        #endregion
    }
}
