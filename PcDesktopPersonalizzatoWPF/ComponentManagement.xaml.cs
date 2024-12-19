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
using PcDesktopPersonalizzato;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PcDesktopPersonalizzatoWPF
{
    /// <summary>
    /// Logica di interazione per ComponentManagement.xaml
    /// </summary>
    public partial class ComponentManagement : Window
    {
        public ComponentManagement()
        {
            InitializeComponent();
        }

        List<Componente> components = new List<Componente>(); // Lista di componenti.
        
        #region lstItems (TODO).
        /// <summary>
        /// Lista di tutti i componenti disponibili.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstItems.SelectedIndex != -1) 
            {
                Componente c = (Componente)lstItems.SelectedItem; // Componente selezionato.
                DynamicBind(c.ToString().Split()[0]);

                txtDimensione.Text = c.Dimensione.ToString();
                txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                txtPrezzo.Text = c.Prezzo.ToString();
                txtProduttore.Text = c.Produttore.ToString();
                txtWattaggio.Text = c.Wattaggio.ToString();
                string[] proprietà = new string[7]; // Per proprietà dinamiche.
                string componente = cbxComponents.SelectedItem.ToString().Split()[1]; // Tipo di componente.

                switch (componente)
                {
                    // Assegnazione proprietà dinamiche cpu.
                    case "Cpu":
                        proprietà = c.GetCpu();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        txt4.Text = proprietà[3];
                        txt5.Text = proprietà[4];
                        txt6.Text = proprietà[5];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche gpu.
                    case "Gpu":
                        proprietà = c.GetGpu();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        txt4.Text = proprietà[3];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche hdd.
                    case "Hdd":
                        proprietà = c.GetHdd();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        txt4.Text = proprietà[3];
                        txt5.Text = proprietà[4];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche ssd.
                    case "Ssd":
                        proprietà = c.GetSsd();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        txt4.Text = proprietà[3];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche ram.
                    case "Ram":
                        proprietà = c.GetRam();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche scheda madre.
                    case "SchedaMadre":
                        proprietà = c.GetMobo();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        txt4.Text = proprietà[3];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche audio.
                    case "SchedaAudio":
                        proprietà = c.GetAudio();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche alimentatore.
                    case "Alimentatore":
                        proprietà = c.GetAlimentatore();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        txt3.Text = proprietà[2];
                        txt4.Text = proprietà[3];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche case.
                    case "Case":
                        proprietà = c.GetCase();
                        txt1.Text = proprietà[0];
                        txt2.Text = proprietà[1];
                        Thread.Sleep(100);
                        break;

                    // Assegnazione proprietà dinamiche all per ogni tipo di componente.
                    case "All":
                        if (c is Cpu)
                        {
                            DynamicBind("Cpu");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetCpu(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            txt4.Text = proprietà[3];
                            txt5.Text = proprietà[4];
                            txt6.Text = proprietà[5];
                            Thread.Sleep(100);
                        }
                        else if (c is Gpu)
                        {
                            DynamicBind("Gpu");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetGpu(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            txt4.Text = proprietà[3];
                            Thread.Sleep(100);
                        }
                        else if (c is Hdd)
                        {
                            DynamicBind("Hdd");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetHdd(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            txt4.Text = proprietà[3];
                            txt5.Text = proprietà[4];
                            Thread.Sleep(100);
                        }
                        else if (c is Ssd)
                        {
                            DynamicBind("Ssd");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetSsd(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            txt4.Text = proprietà[3];
                            Thread.Sleep(100);
                        }
                        else if (c is Ram)
                        {
                            DynamicBind("Ram");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetRam(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            Thread.Sleep(100);
                        }
                        else if (c is SchedaMadre)
                        {
                            DynamicBind("SchedaMadre");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetMobo(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            txt4.Text = proprietà[3];
                            Thread.Sleep(100);
                        }
                        else if (c is SchedaAudio)
                        {
                            DynamicBind("SchedaAudio");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetAudio(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            Thread.Sleep(100);

                        }
                        else if (c is Case)
                        {
                            DynamicBind("Case");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetCase(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            Thread.Sleep(100);
                        }
                        else if (c is Alimentatore)
                        {
                            DynamicBind("Alimentatore");
                            txtDimensione.Text = c.Dimensione.ToString();
                            txtNumeroDiSerie.Text = c.NumeroDiSerie.ToString();
                            txtPrezzo.Text = c.Prezzo.ToString();
                            txtProduttore.Text = c.Produttore.ToString();
                            txtWattaggio.Text = c.Wattaggio.ToString();
                            proprietà = c.GetAlimentatore(); // Prendo proprietà dinamiche.
                            txt1.Text = proprietà[0];
                            txt2.Text = proprietà[1];
                            txt3.Text = proprietà[2];
                            txt4.Text = proprietà[3];
                            Thread.Sleep(100);
                        }
                        break;
                }
            }
        }
        #endregion

        #region lstComprati (DONE).
        /// <summary>
        /// Lista dei componenti comprati.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstComprati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstComprati.SelectedIndex != -1)
            {
                lstItems.SelectedItem = lstComprati.SelectedItem; // Focus su entrambi le liste del componente.
            }
        }
        #endregion

        #region cbxComponents (DONE).
        /// <summary>
        /// Tipologia di componenti disponibili.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] proprieta = new string[6];
            if (cbxComponents.SelectedIndex != -1)
            {
                ClearText();
                string componente = cbxComponents.SelectedItem.ToString().Split()[1]; // Tipo di componente.
                if (cbxComponents.SelectedIndex == 0) // Se il componente è "ALL"
                {
                    lstItems.Items.Clear();
                    foreach (Componente c in components) // Per ogni componente, aggiungo alla listbox.
                        lstItems.Items.Add(c);
                }
                else
                {
                    lstItems.Items.Clear();
                    foreach (Componente c in components)
                        if (c.GetType().ToString().Split('.')[1] == componente)  // Specifico per ogni tipo di componente.
                            lstItems.Items.Add(c);
                }
                DynamicBind(componente); // Configurazione dinamica della gui per ogni tipo di componente.
            }
        }
        #endregion

        #region btnAdd (DONE).
        /// <summary>
        /// Aggiungi componente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Controllo textbox vuote.
                if (txtDimensione.Text.Length == 0 || txtNumeroDiSerie.Text.Length == 0 || txtPrezzo.Text.Length == 0 || txtProduttore.Text.Length == 0)
                    throw new Exception("Inserire tutti i campi obbligatori.\n - Dimensione\n - Numero di serie\n - Prezzo\n - Produttore\n ");
                // Controllo inserimento corretto valori.
                if (!double.TryParse(txtPrezzo.Text, out double prezzo) || !int.TryParse(txtWattaggio.Text, out int watt))
                    throw new Exception("Inserire valori numerici nei campi prezzo e wattaggio.");
                string comp = cbxComponents.Items[cbxComponents.SelectedIndex].ToString().Split()[1]; // tipo di componente.
                
                switch (comp)
                {
                    case "Cpu":
                        Cpu cpu = new Cpu();
                        cpu.Dimensione = txtDimensione.Text;
                        cpu.NumeroDiSerie = txtNumeroDiSerie.Text;
                        cpu.Prezzo = double.Parse(txtPrezzo.Text);
                        cpu.Produttore = txtProduttore.Text;
                        cpu.Wattaggio = int.Parse(txtWattaggio.Text);

                        cpu.Cores = int.Parse(txt1.Text);
                        cpu.CpuSockets = txt2.Text;
                        cpu.Frequency = int.Parse(txt3.Text);
                        cpu.Serie = txt4.Text;
                        cpu.Thread = int.Parse(txt5.Text);
                        cpu.TPD = int.Parse(txt6.Text);
                        // Assegnazione proprietà dinamiche cpu e aggiunta alla lista.
                        cpu.SetCpu(new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text });
                        components.Add(cpu);
                        break;

                    case "Gpu":
                        Gpu gpu = new Gpu();
                        gpu.Dimensione = txtDimensione.Text;
                        gpu.NumeroDiSerie = txtNumeroDiSerie.Text;
                        gpu.Prezzo = double.Parse(txtPrezzo.Text);
                        gpu.Produttore = txtProduttore.Text;
                        gpu.Wattaggio = int.Parse(txtWattaggio.Text);

                        gpu.Cores = int.Parse(txt1.Text);
                        gpu.TFLOPS = int.Parse(txt2.Text);
                        gpu.Frequency = int.Parse(txt3.Text);
                        gpu.Serie = txt4.Text;
                        // Assegnazione proprietà dinamiche gpu e aggiunta alla lista.
                        gpu.SetGpu(new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text});
                        components.Add(gpu);
                        break;

                    case "Hdd":
                        Hdd hdd = new Hdd();
                        hdd.Dimensione = txtDimensione.Text;
                        hdd.NumeroDiSerie = txtNumeroDiSerie.Text;
                        hdd.Prezzo = double.Parse(txtPrezzo.Text);
                        hdd.Produttore = txtProduttore.Text;
                        hdd.Wattaggio = int.Parse(txtWattaggio.Text);

                        hdd.DiametroDisco = int.Parse(txt1.Text);
                        hdd.Rpm = int.Parse(txt2.Text);
                        hdd.SpazioDiArchiviazione = int.Parse(txt3.Text);
                        hdd.VelocitàTrasferimentoDati = int.Parse(txt4.Text);
                        hdd.Volume = int.Parse(txt5.Text);
                        // Assegnazione proprietà dinamiche hdd e aggiunta alla lista.
                        hdd.SetHdd(new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text});
                        components.Add(hdd);
                        break;

                    case "Ssd":
                        Ssd ssd = new Ssd();
                        ssd.Dimensione = txtDimensione.Text;
                        ssd.NumeroDiSerie = txtNumeroDiSerie.Text;
                        ssd.Prezzo = double.Parse(txtPrezzo.Text);
                        ssd.Produttore = txtProduttore.Text;
                        ssd.Wattaggio = int.Parse(txtWattaggio.Text);

                        ssd.DiametroDisco = int.Parse(txt1.Text);
                        ssd.SpazioDiArchiviazione = int.Parse(txt2.Text);
                        ssd.VelocitàTrasferimentoDati = int.Parse(txt3.Text);
                        ssd.Volume = int.Parse(txt4.Text);
                        // Assegnazione proprietà dinamiche ssd e aggiunta alla lista.
                        ssd.SetSsd(new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text});
                        components.Add(ssd);
                        break;

                    case "Ram":
                        Ram ram = new Ram();
                        ram.Dimensione = txtDimensione.Text;
                        ram.NumeroDiSerie = txtNumeroDiSerie.Text;
                        ram.Prezzo = double.Parse(txtPrezzo.Text);
                        ram.Produttore = txtProduttore.Text;
                        ram.Wattaggio = int.Parse(txtWattaggio.Text);

                        ram.Capacità = int.Parse(txt1.Text);
                        ram.Frequenza = int.Parse(txt2.Text);
                        ram.Voltaggio = int.Parse(txt3.Text);
                        // Assegnazione proprietà dinamiche ram e aggiunta alla lista.
                        ram.SetRam(new string[] { txt1.Text, txt2.Text, txt3.Text });
                        components.Add(ram);
                        break;

                    case "SchedaMadre":
                        SchedaMadre mobo = new SchedaMadre();
                        mobo.Dimensione = txtDimensione.Text;
                        mobo.NumeroDiSerie = txtNumeroDiSerie.Text;
                        mobo.Prezzo = double.Parse(txtPrezzo.Text);
                        mobo.Produttore = txtProduttore.Text;
                        mobo.Wattaggio = int.Parse(txtWattaggio.Text);

                        mobo.AudioIntegrato = bool.Parse(txt1.Text);
                        mobo.Chipset = txt2.Text;
                        mobo.NSlotRam = int.Parse(txt3.Text);
                        mobo.Rete = txt4.Text;
                        mobo.SchedaVideoIntegrata = bool.Parse(txt5.Text);
                        // Assegnazione proprietà dinamiche mobo e aggiunta alla lista.
                        mobo.SetMobo(new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text});
                        components.Add(mobo);
                        break;

                    case "SchedaAudio":
                        SchedaAudio audio = new SchedaAudio();
                        audio.Dimensione = txtDimensione.Text;
                        audio.NumeroDiSerie = txtNumeroDiSerie.Text;
                        audio.Prezzo = double.Parse(txtPrezzo.Text);
                        audio.Produttore = txtProduttore.Text;
                        audio.Wattaggio = int.Parse(txtWattaggio.Text);

                        audio.BitRate = int.Parse(txt1.Text);
                        audio.Db = int.Parse(txt2.Text);
                        audio.Impianto = txt3.Text;
                        // Assegnazione proprietà dinamiche audio e aggiunta alla lista.
                        audio.SetAudio(new string[] { txt1.Text, txt2.Text, txt3.Text});
                        components.Add(audio);
                        break;

                    case "Alimentatore":
                        Alimentatore alimentatore = new Alimentatore();
                        alimentatore.Dimensione = txtDimensione.Text;
                        alimentatore.NumeroDiSerie = txtNumeroDiSerie.Text;
                        alimentatore.Prezzo = double.Parse(txtPrezzo.Text);
                        alimentatore.Produttore = txtProduttore.Text;
                        alimentatore.Wattaggio = int.Parse(txtWattaggio.Text);

                        alimentatore.NConnettoriCpu = int.Parse(txt1.Text);
                        alimentatore.NConnettoriMobo = int.Parse(txt2.Text);
                        alimentatore.NPciExpress = int.Parse(txt3.Text);
                        alimentatore.NSata = int.Parse(txt4.Text);
                        // Assegnazione proprietà dinamiche alimentatore e aggiunta alla lista.
                        alimentatore.SetAlimentatore(new string[] { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text});
                        components.Add(alimentatore);
                        break;

                    case "Case":
                        Case @case = new Case();
                        @case.Dimensione = txtDimensione.Text;
                        @case.NumeroDiSerie = txtNumeroDiSerie.Text;
                        @case.Prezzo = double.Parse(txtPrezzo.Text);
                        @case.Produttore = txtProduttore.Text;
                        @case.Wattaggio = int.Parse(txtWattaggio.Text);

                        @case.Colore = txt1.Text;
                        @case.nVentole = int.Parse(txt2.Text);
                        // Assegnazione proprietà dinamiche case e aggiunta alla lista.
                        @case.SetCase(new string[] { txt1.Text, txt2.Text});
                        components.Add(@case);
                        break;
                }
                lstItems.Items.Clear();
                if (cbxComponents.SelectedItem.ToString().Split()[1] == "All") // Se tipo selezionato è all mostro tutti.
                    foreach (Componente c in components)
                        lstItems.Items.Add(c);
                else
                    foreach (Componente c in components)
                        if (c.ToString().Split()[0] == cbxComponents.SelectedItem.ToString().Split()[1]) // Categoria e visualizzazione suddivisa in tipologia di componente
                            lstItems.Items.Add(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore:\n" + ex.Message, "Purchaising components", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region btnDelete (DONE).
        /// <summary>
        /// Rimozione del componente modificato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                components.Remove((Componente)lstItems.SelectedItem); // Rimozione del componente dalla lista.
                lstItems.Items.Clear();
                if (cbxComponents.SelectedItem.ToString().Split()[1] == "All") // Se tipologia selezionata "all", mostro tutti aggiornati.
                    foreach (Componente c in components)
                        lstItems.Items.Add(c);
                else
                    foreach (Componente c in components)
                        if (c.ToString().Split()[0] == cbxComponents.SelectedItem.ToString().Split()[1]) // Specifico per ogni tipo di componente.
                            lstItems.Items.Add(c);
                ClearText(); // Pulizia textboxes.
            }
        }
        #endregion

        #region btnModify (DONE).
        /// <summary>
        /// Modifica del componente selezionato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstItems.SelectedIndex != -1)
                {
                    Componente componente = (Componente)lstItems.SelectedItem; // Componente selezionato.
                    int index = components.IndexOf(componente); // Indice nella lista del componente da modificare.

                    switch (componente.GetType().ToString().Split('.')[1]) // TIpologia di componente.
                    {
                        case "Cpu":
                            Cpu cpu = new Cpu();
                            cpu.Dimensione = txtDimensione.Text;
                            cpu.NumeroDiSerie = txtNumeroDiSerie.Text;
                            cpu.Prezzo = double.Parse(txtPrezzo.Text);
                            cpu.Produttore = txtProduttore.Text;
                            cpu.Wattaggio = int.Parse(txtWattaggio.Text);

                            cpu.Cores = int.Parse(txt1.Text);
                            cpu.CpuSockets = txt2.Text;
                            cpu.Frequency = int.Parse(txt3.Text);
                            cpu.Serie = txt4.Text;
                            cpu.Thread = int.Parse(txt5.Text);
                            cpu.TPD = int.Parse(txt6.Text);
                            DynamicBind("Cpu");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, cpu);
                            break;

                        case "Gpu":
                            Gpu gpu = new Gpu();
                            gpu.Dimensione = txtDimensione.Text;
                            gpu.NumeroDiSerie = txtNumeroDiSerie.Text;
                            gpu.Prezzo = double.Parse(txtPrezzo.Text);
                            gpu.Produttore = txtProduttore.Text;
                            gpu.Wattaggio = int.Parse(txtWattaggio.Text);

                            gpu.Cores = int.Parse(txt1.Text);
                            gpu.TFLOPS = int.Parse(txt2.Text);
                            gpu.Frequency = int.Parse(txt3.Text);
                            gpu.Serie = txt4.Text;
                            DynamicBind("Gpu");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, gpu);
                            break;

                        case "Hdd":
                            Hdd hdd = new Hdd();
                            hdd.Dimensione = txtDimensione.Text;
                            hdd.NumeroDiSerie = txtNumeroDiSerie.Text;
                            hdd.Prezzo = double.Parse(txtPrezzo.Text);
                            hdd.Produttore = txtProduttore.Text;
                            hdd.Wattaggio = int.Parse(txtWattaggio.Text);

                            hdd.DiametroDisco = int.Parse(txt1.Text);
                            hdd.Rpm = int.Parse(txt2.Text);
                            hdd.SpazioDiArchiviazione = int.Parse(txt3.Text);
                            hdd.VelocitàTrasferimentoDati = int.Parse(txt4.Text);
                            hdd.Volume = int.Parse(txt5.Text);
                            DynamicBind("Hdd");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, hdd);
                            break;

                        case "Ssd":
                            Ssd ssd = new Ssd();
                            ssd.Dimensione = txtDimensione.Text;
                            ssd.NumeroDiSerie = txtNumeroDiSerie.Text;
                            ssd.Prezzo = double.Parse(txtPrezzo.Text);
                            ssd.Produttore = txtProduttore.Text;
                            ssd.Wattaggio = int.Parse(txtWattaggio.Text);

                            ssd.DiametroDisco = int.Parse(txt1.Text);
                            ssd.SpazioDiArchiviazione = int.Parse(txt2.Text);
                            ssd.VelocitàTrasferimentoDati = int.Parse(txt3.Text);
                            ssd.Volume = int.Parse(txt4.Text);
                            DynamicBind("Ssd");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, ssd);
                            break;

                        case "Ram":
                            Ram ram = new Ram();
                            ram.Dimensione = txtDimensione.Text;
                            ram.NumeroDiSerie = txtNumeroDiSerie.Text;
                            ram.Prezzo = double.Parse(txtPrezzo.Text);
                            ram.Produttore = txtProduttore.Text;
                            ram.Wattaggio = int.Parse(txtWattaggio.Text);

                            ram.Capacità = int.Parse(txt1.Text);
                            ram.Frequenza = int.Parse(txt2.Text);
                            ram.Voltaggio = int.Parse(txt3.Text);
                            DynamicBind("Ram");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, ram);
                            break;

                        case "SchedaMadre":
                            SchedaMadre mobo = new SchedaMadre();
                            mobo.Dimensione = txtDimensione.Text;
                            mobo.NumeroDiSerie = txtNumeroDiSerie.Text;
                            mobo.Prezzo = double.Parse(txtPrezzo.Text);
                            mobo.Produttore = txtProduttore.Text;
                            mobo.Wattaggio = int.Parse(txtWattaggio.Text);

                            mobo.AudioIntegrato = bool.Parse(txt1.Text);
                            mobo.Chipset = txt2.Text;
                            mobo.NSlotRam = int.Parse(txt3.Text);
                            mobo.Rete = txt4.Text;
                            mobo.SchedaVideoIntegrata = bool.Parse(txt5.Text);
                            DynamicBind("Motherboard");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, mobo);
                            break;

                        case "SchedaAudio":
                            SchedaAudio audio = new SchedaAudio();
                            audio.Dimensione = txtDimensione.Text;
                            audio.NumeroDiSerie = txtNumeroDiSerie.Text;
                            audio.Prezzo = double.Parse(txtPrezzo.Text);
                            audio.Produttore = txtProduttore.Text;
                            audio.Wattaggio = int.Parse(txtWattaggio.Text);

                            audio.BitRate = int.Parse(txt1.Text);
                            audio.Db = int.Parse(txt2.Text);
                            audio.Impianto = txt3.Text;
                            DynamicBind("Audio");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, audio);
                            break;

                        case "Alimentatore":
                            Alimentatore alimentatore = new Alimentatore();
                            alimentatore.Dimensione = txtDimensione.Text;
                            alimentatore.NumeroDiSerie = txtNumeroDiSerie.Text;
                            alimentatore.Prezzo = double.Parse(txtPrezzo.Text);
                            alimentatore.Produttore = txtProduttore.Text;
                            alimentatore.Wattaggio = int.Parse(txtWattaggio.Text);

                            alimentatore.NConnettoriCpu = int.Parse(txt1.Text);
                            alimentatore.NConnettoriMobo = int.Parse(txt2.Text);
                            alimentatore.NPciExpress = int.Parse(txt3.Text);
                            alimentatore.NSata = int.Parse(txt4.Text);
                            DynamicBind("PowerSupply");
                            // Inserimento nuovo componente aggiornato all'index prefissato precedentemente.
                            components.Insert(index, alimentatore);
                            break;
                    }
                    components.RemoveAt(index + 1);
                    lstItems.Items.Clear();
                    if (cbxComponents.SelectedItem.ToString().Split()[1] == "All") // Per tutti i componenti.
                        foreach (Componente c in components)
                            lstItems.Items.Add(c);
                    else
                        foreach (Componente c in components)
                            if (c.ToString().Split()[0] == cbxComponents.SelectedItem.ToString().Split()[1]) // Specifico per ogni categoria di componenti.
                                lstItems.Items.Add(c);
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nell'inserimento delle specifiche:\n" + ex.Message, "Modify component", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        #endregion

        #region btnSelect (DONE).
        /// <summary>
        /// Seleziona l'elemento da comprare.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                lstComprati.Items.Add((Componente)lstItems.SelectedItem); // Aggiugno al carrello, il componente selezionato.
            }
        }
        #endregion

        #region btnDeselect (DONE).
        /// <summary>
        /// Deseleziona dal carrello.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeselect_Click(object sender, RoutedEventArgs e)
        {
            if (lstComprati.SelectedIndex != -1)
            {
                lstComprati.Items.Remove(lstComprati.SelectedItem); // Tolgo dal carrello, il componente selezionato.
            }
        }
        #endregion

        #region Checkout (DONE).
        /// <summary>
        /// Costo totale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            double totalCost = 0;
            foreach (Componente c in lstComprati.Items) // Per ogni componente acquistato, aggiungo il prezzo.
            {
                totalCost = totalCost + c.Prezzo;
            }
            MessageBox.Show($"Total cost: {totalCost}€", "Checkout", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion

        #region btnUndo (DONE).
        /// <summary>
        /// Indietro alla home.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
        #endregion

        #region btnOnOff (DONE).
        /// <summary>
        /// Salvataggio e chiusura app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnOff_Click(object sender, RoutedEventArgs e)
        {
            SaveComponents(components); // Salvataggio componenti.
            //Serialize();
            this.Close();
        }
        #endregion

        #region WindowMove (DONE).
        /// <summary>
        /// Movimento della window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove(); // Movimento della window.
        }
        #endregion

        #region ClearTextBoxes (DONE).
        /// <summary>
        /// Pulitura textboxes.
        /// </summary>
        private void ClearText()
        {
            txtDimensione.Clear();
            txtNumeroDiSerie.Clear();
            txtPrezzo.Clear();
            txtProduttore.Clear();
            txtWattaggio.Clear();
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            txt6.Clear();
        }
        #endregion

        #region HideTextBoxes (DONE.)
        /// <summary>
        /// Nascondi textboxes.
        /// </summary>
        private void HideTextBoxes()
        {
            lbl1.Visibility = Visibility.Collapsed;
            lbl2.Visibility = Visibility.Collapsed;
            lbl3.Visibility = Visibility.Collapsed;
            lbl4.Visibility = Visibility.Collapsed;
            lbl5.Visibility = Visibility.Collapsed;
            lbl6.Visibility = Visibility.Collapsed;

            txt1.Visibility = Visibility.Collapsed;
            txt2.Visibility = Visibility.Collapsed;
            txt3.Visibility = Visibility.Collapsed;
            txt4.Visibility = Visibility.Collapsed;
            txt5.Visibility = Visibility.Collapsed;
            txt6.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region DynamicBind (DONE).
        /// <summary>
        /// Bind dinamico a seconda del componente passato come parametro.
        /// </summary>
        /// <param name="c">Tipo di componente.</param>
        private void DynamicBind(string c)
        {
            switch (c)
            {
                case "Cpu":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Cores:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "Cpu sockets:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Frequenza:";
                    txt3.Visibility = Visibility.Visible;

                    lbl4.Visibility = Visibility.Visible;
                    lbl4.Content = "Serie:";
                    txt4.Visibility = Visibility.Visible;

                    lbl5.Visibility = Visibility.Visible;
                    lbl5.Content = "Thread:";
                    txt5.Visibility = Visibility.Visible;

                    lbl6.Visibility = Visibility.Visible;
                    lbl6.Content = "TPD:";
                    txt6.Visibility = Visibility.Visible;
                    break;

                case "Gpu":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Cores:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "TFLOPS:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Frequenza:";
                    txt3.Visibility = Visibility.Visible;

                    lbl4.Visibility = Visibility.Visible;
                    lbl4.Content = "Serie:";
                    txt4.Visibility = Visibility.Visible;
                    break;

                case "Hdd":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Diametro disco:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "RPM:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Spazio di archiviazione:";
                    txt3.Visibility = Visibility.Visible;

                    lbl4.Visibility = Visibility.Visible;
                    lbl4.Content = "Velocità trasferimento dati:";
                    txt4.Visibility = Visibility.Visible;

                    lbl5.Visibility = Visibility.Visible;
                    lbl5.Content = "Volume:";
                    txt5.Visibility = Visibility.Visible;

                    break;

                case "Ssd":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Diametro disco:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "Spazio di archiviazione:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Velocità trasferimento dati:";
                    txt3.Visibility = Visibility.Visible;

                    lbl4.Visibility = Visibility.Visible;
                    lbl4.Content = "Volume:";
                    txt4.Visibility = Visibility.Visible;
                    break;

                case "Ram":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Capacità:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "Frequenza:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Voltaggio:";
                    txt3.Visibility = Visibility.Visible;
                    break;

                case "SchedaAudio":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Bit rate:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "Db:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Impianto:";
                    txt3.Visibility = Visibility.Visible;
                    break;

                case "SchedaMadre":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Audio integrato:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "Chipset:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Numero slot ram:";
                    txt3.Visibility = Visibility.Visible;

                    lbl4.Visibility = Visibility.Visible;
                    lbl4.Content = "Tipologia rete:";
                    txt4.Visibility = Visibility.Visible;

                    lbl5.Visibility = Visibility.Visible;
                    lbl5.Content = "Scheda video integrata:";
                    txt5.Visibility = Visibility.Visible;
                    break;

                case "Alimentatore":
                    ClearText();
                    HideTextBoxes();
                    lbl1.Visibility = Visibility.Visible;
                    lbl1.Content = "Numero connettori cpu:";
                    txt1.Visibility = Visibility.Visible;

                    lbl2.Visibility = Visibility.Visible;
                    lbl2.Content = "Numero connettori motherboard:";
                    txt2.Visibility = Visibility.Visible;

                    lbl3.Visibility = Visibility.Visible;
                    lbl3.Content = "Numero pci express:";
                    txt3.Visibility = Visibility.Visible;

                    lbl4.Visibility = Visibility.Visible;
                    lbl4.Content = "Numero sata:";
                    txt4.Visibility = Visibility.Visible;
                    break;
            }
        }
        #endregion

        #region MainWindowLoaded (DONE).
        /// <summary>
        /// Apertura window e caricamento componenti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //components.AddRange(LoadComponents());
            //components = Deserialize();
            cbxComponents.SelectedIndex = 0;
        }
        #endregion

        #region Serializer (DONE).
        /// <summary>
        /// Serializzazione.
        /// </summary>
        private void Serialize()
        {
            try
            {
                // Creates XmlSerializer of the List<COmponente> type
                XmlSerializer serializer = new XmlSerializer(components.GetType());
                // Creates a stream using which we'll serialize
                using (StreamWriter sw = new StreamWriter("components.xml"))
                {
                    // We call the Serialize() method and pass the stream created above as the first parameter
                    // The second parameter is the object which we want to serialize
                    serializer.Serialize(sw, components);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chiusura app." + ex.Message);
            }
        }
        #endregion

        #region Deserializer (DONE).
        /// <summary>
        /// Deserializzazione.
        /// </summary>
        /// <returns>Lista dei componenti.</returns>
        private List<Componente> Deserialize()
        {
            try
            {
                if (File.Exists("components.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(components.GetType());
                    using (StreamReader sr = new StreamReader("components.xml"))
                    {
                        components = (List<Componente>)serializer.Deserialize(sr);
                    }
                }
                else
                {
                    throw new FileNotFoundException("File not found");
                }
                return components;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion

        #region Save components.
        /// <summary>
        /// Salvataggio componenti su file.
        /// </summary>
        /// <param name="com"></param>
        private void SaveComponents(List<Componente> com)
        {
            StreamWriter sr = null;
            try
            {
                sr = new StreamWriter(@"..\..\Components.txt", false);
                string[] proprietà;
                foreach (Componente c in com)
                {
                    if(c is Cpu)
                    {
                        proprietà = new string[6];
                        sr.WriteLine("CPU:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetCpu();
                        sr.WriteLine("Cores: " + proprietà[0]);
                        sr.WriteLine("Cpu Sockets: " + proprietà[1]);
                        sr.WriteLine("Frequenza: " + proprietà[2]);
                        sr.WriteLine("Serie: " + proprietà[3]);
                        sr.WriteLine("Thread: " + proprietà[4]);
                        sr.WriteLine("TPD: " + proprietà[5]);
                    }
                    else if (c is Gpu)
                    {
                        sr.WriteLine("GPU:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetGpu();
                        sr.WriteLine("Cores: " + proprietà[0]);
                        sr.WriteLine("Frequenza: " + proprietà[1]);
                        sr.WriteLine("Serie: " + proprietà[2]);
                        sr.WriteLine("TFLOPS: " + proprietà[3]);
                    }
                    else if (c is Hdd)
                    {
                        sr.WriteLine("HDD:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetHdd();
                        sr.WriteLine("Diametro disco: " + proprietà[0]);
                        sr.WriteLine("Rpm: " + proprietà[1]);
                        sr.WriteLine("Spazio di archiviazione: " + proprietà[2]);
                        sr.WriteLine("Velocità traferimento dati: " + proprietà[3]);
                        sr.WriteLine("Volume: " + proprietà[4]);
                    }
                    else if (c is Ssd)
                    {
                        sr.WriteLine("SSD:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetSsd();
                        sr.WriteLine("Diametro disco: " + proprietà[0]);
                        sr.WriteLine("Spazio di archiviazione: " + proprietà[1]);
                        sr.WriteLine("Velocità traferimento dati: " + proprietà[2]);
                        sr.WriteLine("Volume: " + proprietà[3]);
                    }
                    else if (c is Ram)
                    {
                        sr.WriteLine("RAM:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetRam();
                        sr.WriteLine("Capacità: " + proprietà[0]);
                        sr.WriteLine("Frequenza: " + proprietà[1]);
                        sr.WriteLine("Voltaggio: " + proprietà[2]);
                    }
                    else if (c is SchedaMadre)
                    {
                        sr.WriteLine("SCHEDA MADRE:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetMobo();
                        sr.WriteLine("Audio integrato: " + proprietà[0]);
                        sr.WriteLine("Chipset: " + proprietà[1]);
                        sr.WriteLine("Numero slot ram: " + proprietà[2]);
                        sr.WriteLine("Rete: " + proprietà[3]);
                        sr.WriteLine("Scheda video integrata: " + proprietà[4]);
                    }
                    else if (c is SchedaAudio)
                    {
                        sr.WriteLine("SCHEDA AUDIO:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetAudio();
                        sr.WriteLine("Bit rate: " + proprietà[0]);
                        sr.WriteLine("Db: " + proprietà[1]);
                        sr.WriteLine("Impianto: " + proprietà[2]);
                    }
                    else if (c is Case)
                    {
                        sr.WriteLine("CASE:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetCase();
                        sr.WriteLine("Colore: " + proprietà[0]);
                        sr.WriteLine("Numero ventole: " + proprietà[1]);
                    }
                    else if (c is Alimentatore)
                    {
                        sr.WriteLine("ALIMENTATORE:");
                        sr.WriteLine("Dimensione: " + c.Dimensione);
                        sr.WriteLine("Numero Di Serie: " + c.NumeroDiSerie);
                        sr.WriteLine("Prezzo: " + c.Prezzo);
                        sr.WriteLine("Produttore: " + c.Produttore);
                        sr.WriteLine("Wattaggio: " + c.Wattaggio);
                        proprietà = c.GetAlimentatore();
                        sr.WriteLine("Numero connettori cpu: " + proprietà[0]);
                        sr.WriteLine("Numero connettori motherboard: " + proprietà[1]);
                        sr.WriteLine("Numero connettori pciexpress: " + proprietà[2]);
                        sr.WriteLine("Numero connettori sata: " + proprietà[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel salvataggio del file dei componenti.\n" + ex.Message,"Save components",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }
        #endregion

        #region Load components.
        /// <summary>
        /// Caricamento componenti da file.
        /// </summary>
        /// <returns></returns>
        private List<Componente> LoadComponents()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(@"..\..\Components.txt");
                List<Componente> comps = new List<Componente>();
                for(int i = 0; !sr.EndOfStream; i++)
                {
                    if (comps[i] is Cpu)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetCpu(new string[6] { sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()});
                    }
                    else if (comps[i] is Gpu)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetGpu(new string[4] { sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()});
                    }
                    else if (comps[i] is Hdd)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetHdd(new string[5] { sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()});
                    }
                    else if (comps[i] is Ssd)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetSsd(new string[4] { sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()});
                    }
                    else if (comps[i] is Ram)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetRam(new string[3] { sr.ReadLine(), sr.ReadLine(), sr.ReadLine()});
                    }
                    else if (comps[i] is SchedaMadre)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetMobo(new string[5] {sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine() });
                    }
                    else if (comps[i] is SchedaAudio)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetAudio(new string[3] {sr.ReadLine(), sr.ReadLine(), sr.ReadLine() });

                    }
                    else if (comps[i] is Case)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetCase(new string[2] { sr.ReadLine(), sr.ReadLine() });
                    }
                    else if (comps[i] is Alimentatore)
                    {
                        string componente = sr.ReadLine();
                        string dimensione = sr.ReadLine();
                        string numeroDiSerie = sr.ReadLine();
                        double prezzo = double.Parse(sr.ReadLine());
                        string produttore = sr.ReadLine();
                        int watt = int.Parse(sr.ReadLine());
                        comps[i].SetAlimentatore(new string[4] {sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine() });
                    }
                    lstItems.Items.Add(comps[i]);
                }
                return comps;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel salvataggio del file dei componenti.\n" + ex.Message, "Save components", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }
        #endregion
    }
}
