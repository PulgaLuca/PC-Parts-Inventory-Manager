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
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PcDesktopPersonalizzato
{
    internal class PcDesktopPersonalizzatoConsole
    {
        #region No resize mode.
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        // Significa che il metodo dichiarato sottostante non fa parte del .NET, ma è esterno e nativo di un file dll.
        [DllImport("user32.dll")] // Per accedere a impostazioni di sistema di windows, rendendole integrabili nel codice.
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        // Indica che una DLL (Dynamic Link Library) [user32.dll] non gestita espone il metodo dell'attributo come punto di ingresso statico.
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        // Indica che una DLL (Dynamic Link Library) [kernel32.dll] non gestita espone il metodo dell'attributo come punto di ingresso statico.
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        #endregion

        #region Cdc.
        public static List<Alimentatore> alimentatori = new List<Alimentatore>();
        public static List<Case> cases = new List<Case>();
        public static List<Cpu> cpus = new List<Cpu>();
        public static List<Gpu> gpus = new List<Gpu>();
        public static List<Hdd> hdds = new List<Hdd>();
        public static List<Ssd> ssds = new List<Ssd>();
        public static List<Ram> rams = new List<Ram>();
        public static List<SchedaAudio> schedeAudio = new List<SchedaAudio>();
        public static List<SchedaMadre> schedeMadri = new List<SchedaMadre>();
        public static List<Componente> componenti = new List<Componente>();

        // Usati per la serializzazione.
        public static List<Alimentatore> alimentatoriSer = new List<Alimentatore>();
        public static List<Case> casesSer = new List<Case>();
        public static List<Cpu> cpusSer = new List<Cpu>();
        public static List<Gpu> gpusSer = new List<Gpu>();
        public static List<Hdd> hddsSer = new List<Hdd>();
        public static List<Ssd> ssdsSer = new List<Ssd>();
        public static List<Ram> ramsSer = new List<Ram>();
        public static List<SchedaAudio> schedeAudioSer = new List<SchedaAudio>();
        public static List<SchedaMadre> schedeMadriSer = new List<SchedaMadre>();
        public static List<Componente> componentiSer = new List<Componente>();
        #endregion

        static void Main(string[] args)
        {
            #region No resize mode.
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                // DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND); // Previene la chiusura della console dall'utente.
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND); // Previene che l'utente minimizzi la finstra.
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND); // Previene che l'utente maximizzi la finstra.
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND); // Previene il resizing della finestra.
            }
            #endregion

            #region Deserializzazione.
            #region Alimentatori.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls2 = new XmlSerializer(typeof(List<Alimentatore>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\alimentatori.xml"))
            {
                alimentatoriSer = (List<Alimentatore>)xmls2.Deserialize(tr);
            }
            alimentatori.AddRange(alimentatoriSer); // Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Cpu.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls3 = new XmlSerializer(typeof(List<Cpu>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\cpu.xml"))
            {
                cpusSer = (List<Cpu>)xmls3.Deserialize(tr);
            }
            cpus.AddRange(cpusSer); // Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Gpu.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls4 = new XmlSerializer(typeof(List<Gpu>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\gpu.xml"))
            {
                gpusSer = (List<Gpu>)xmls4.Deserialize(tr);
            }
            gpus.AddRange(gpusSer); // Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Case.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls5 = new XmlSerializer(typeof(List<Case>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\case.xml"))
            {
                casesSer = (List<Case>)xmls5.Deserialize(tr);
            }
            cases.AddRange(casesSer);// Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Hdd.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls6 = new XmlSerializer(typeof(List<Hdd>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\hdd.xml"))
            {
                hddsSer = (List<Hdd>)xmls6.Deserialize(tr);
            }
            hdds.AddRange(hddsSer);// Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Ssd.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls7 = new XmlSerializer(typeof(List<Ssd>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\ssd.xml"))
            {
                ssdsSer = (List<Ssd>)xmls7.Deserialize(tr);
            }
            ssds.AddRange(ssdsSer);// Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Ram.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls8 = new XmlSerializer(typeof(List<Ram>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\ram.xml"))
            {
                ramsSer = (List<Ram>)xmls8.Deserialize(tr);
            }
            rams.AddRange(ramsSer);// Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Schede audio.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls9 = new XmlSerializer(typeof(List<SchedaAudio>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\schedaAudio.xml"))
            {
                schedeAudioSer = (List<SchedaAudio>)xmls9.Deserialize(tr);
            }
            schedeAudio.AddRange(schedeAudioSer);// Aggiungo alla lista esistente i componetni deserializzati.

            #endregion

            #region Schede madri.
            // Deserializzazione FILE → OGGETTO.
            XmlSerializer xmls0 = new XmlSerializer(typeof(List<SchedaMadre>));
            using (TextReader tr = new StreamReader(@"..\..\xmlproducts\schedaMadre.xml"))
            {
                schedeMadriSer = (List<SchedaMadre>)xmls0.Deserialize(tr);
            }
            schedeMadri.AddRange(schedeMadriSer);// Aggiungo alla lista esistente i componetni deserializzati.
            #endregion

            #region Componenti.
            //// Deserializzazione FILE → OGGETTO.
            //XmlSerializer xmls11 = new XmlSerializer(typeof(List<Componente>));
            //using (TextReader tr = new StreamReader(@"..\..\xmlproducts\componenti.xml"))
            //{

            //    componentiSer = (List<Componente>)xmls11.Deserialize(tr);
            //}
            //componenti.AddRange(componentiSer); // Aggiungo alla lista esistente i componetni deserializzati.
            #endregion
            #endregion

            char opz = ' ';
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 46); // Dimensione finestra all'avvio.
            Console.Title = "PC DESKTOP PERSONALIZZATO by Pulga Luca 4 ^ L";

            Menu();

            while (true)
            {
                Scelta(out opz); // Richiede l'opzione.

                switch (opz) // Esegue l'opzione scelta.
                {
                    #region Aggiungi componente.
                    case 'A':
                        Console.Title = "Aggiungi componente pc desktop personalizzato";
                        AggiungiComponente();
                        break;
                    #endregion

                    #region Modifica componente.
                    case 'M':
                        Console.Title = "Modifica componente pc desktop personalizzato";
                        ModificaComponente();
                        break;
                    #endregion

                    #region Elimina componente.
                    case 'E':
                        Console.Title = "Elimina componente pc desktop personalizzato";
                        EliminaComponente();
                        break;
                    #endregion

                    #region Scelta componenti per il pc.
                    case 'S':
                        Console.Title = "Scelta componenti pc desktop personalizzato";
                        SceltaComponenti();
                        break;
                    #endregion

                    #region Visualizzazione finale.
                    case 'V':
                        Console.Title = "Visualizzazione componenti pc desktop personalizzato";
                        VisualizzaFinale();
                        break;
                    #endregion

                    #region Uscita app.
                    case 'X':
                        Console.Title = "Salvataggio e uscita app pc desktop personalizzato";
                        Esci();
                        break;
                        #endregion
                }
            }
        }

        #region Scelta opzione.
        /// <summary>
        /// Visualizza il menù e richiede l'opzione.
        /// </summary>
        /// <returns>Scelta dell'utente.</returns>
        public static void Scelta(out char ch)
        {
            do // Legge e controlla l'opzione scelta.
            {
                ch = Console.ReadKey(true).KeyChar;
                ch = char.ToUpper(ch);
            }
            while (!((ch == 'A') || (ch == 'M') || (ch == 'E') || (ch == 'S') || (ch == 'V') || (ch == 'X'))); // Controllo scelta.
        }
        #endregion

        #region Menu.
        /// <summary>
        /// Menu dei comandi.
        /// </summary>
        static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = 40;
            Console.WriteLine("PC DESKTOP PERSONALIZZATO by Pulga Luca 4^L.");
            Console.WriteLine(" - [A]ggiungi componente"); // Aggiunge auto a sinistra in coda.
            Console.WriteLine(" - [M]odifica componente"); // Aggiunge camion a sinistra in coda.
            Console.WriteLine(" - [E]limina componente"); // Aggiunge auto a destra in coda.
            Console.WriteLine(" - [S]celta componenti per il PC"); // Aggiunge auto a destra in coda.
            Console.WriteLine(" - [V]isualizzazione finale"); // Avvia la simulazione.
            Console.WriteLine(" - [X]Esci dalla app\n"); // Esce dal programma.
            Console.ResetColor();
        }
        #endregion

        #region Aggiungi componente.
        /// <summary>
        /// Aggiunge un componente.
        /// </summary>
        public static void AggiungiComponente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Sezione: [A]ggiungi componente\n");
            Console.WriteLine(@"
        - [A]limentatore
        - [C]ase
        - C[p]u
        - [G]pu
        - [R]am
        - [H]dd
        - [S]sd
        - Sch[e]da Audio
        - Scheda [M]adre
        - [X]Torna indietro");
            char ch = ' ';
            do // Legge e controlla l'opzione scelta.
            {
                ch = Console.ReadKey(true).KeyChar;
                ch = char.ToUpper(ch);
            }
            while (!((ch == 'A') || (ch == 'C') || (ch == 'P') || (ch == 'G') || (ch == 'R') || (ch == 'H') || (ch == 'S') || (ch == 'E') || (ch == 'M') || (ch == 'X'))); // Controllo scelta.
            if (ch == 'A')
            {
                #region Aggiungi alimentatore.
                Alimentatore alimentatore = new Alimentatore();
                Console.WriteLine("\n\t - AGGIUNGI ALIMENTATORE\n");

                Console.Write("\t Dimensione: ");
                alimentatore.Dimensione = Console.ReadLine();

                Console.Write("\t Numero di serie: ");
                alimentatore.NumeroDiSerie = Console.ReadLine();

                Console.Write("\t Produttore: ");
                alimentatore.Produttore = Console.ReadLine();

                // Controllo prezzo.
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        alimentatore.Prezzo = prezzo;
                } while (!okPrezzo);

                // Controllo watt.
                bool okWatt;
                do
                {
                    Console.Write("\t Wattaggio: ");
                    int watt;
                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                    if (!okWatt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        alimentatore.Wattaggio = watt;
                } while (!okWatt);

                // Controllo  n connettori cpu
                bool okConCpu;
                do
                {
                    Console.Write("\t Connettori cpu: ");
                    int connettoriCpu;
                    okConCpu = int.TryParse(Console.ReadLine(), out connettoriCpu);
                    if (!okConCpu)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI CONNETTORI CPU");
                        Console.ResetColor();
                    }
                    else
                        alimentatore.NConnettoriCpu = connettoriCpu;
                } while (!okConCpu);

                // Controllo  n connettori mobo
                bool okNConnettoriMobo;
                do
                {
                    Console.Write("\t Connettori mobo: ");
                    int NConnettoriMobo;
                    okNConnettoriMobo = int.TryParse(Console.ReadLine(), out NConnettoriMobo);
                    if (!okNConnettoriMobo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI CONNETTORI MOTHERBOARD");
                        Console.ResetColor();
                    }
                    else
                        alimentatore.NConnettoriMobo = NConnettoriMobo;
                } while (!okNConnettoriMobo);

                // Controllo  n connettori pcie
                bool okNPciExpress;
                do
                {
                    Console.Write("\t Pci Express: ");
                    int NPciExpress;
                    okNPciExpress = int.TryParse(Console.ReadLine(), out NPciExpress);
                    if (!okNPciExpress)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DEI PCI EXPRESS");
                        Console.ResetColor();
                    }
                    else
                        alimentatore.NPciExpress = NPciExpress;
                } while (!okNPciExpress);


                // Controllo  n connettori sata
                bool okNSata;
                do
                {
                    Console.Write("\t Numero Connettori sata: ");
                    int NSata;
                    okNSata = int.TryParse(Console.ReadLine(), out NSata);
                    if (!okNSata)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI CONNETTORI SATA");
                        Console.ResetColor();
                    }
                    else
                        alimentatore.NSata = NSata;
                } while (!okNSata);

                alimentatori.Add(alimentatore);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tALIMENTATORE SALVATO CORRETTAMENTE!");
                Console.ResetColor();
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'C')
            {
                #region Aggiungi case.
                Case newCase = new Case();
                Console.WriteLine("\n\t - AGGIUNGI CASE\n");

                Console.Write("\t Colore: ");
                newCase.Colore = Console.ReadLine();

                Console.Write("\t Dimensione: ");
                newCase.Dimensione = Console.ReadLine();

                Console.Write("\t Numero di serie: ");
                newCase.NumeroDiSerie = Console.ReadLine();

                // Controllo  n ventole.
                bool OkVentole;
                do
                {
                    int ventole;
                    Console.Write("\t Ventole: ");
                    OkVentole = int.TryParse(Console.ReadLine(), out ventole);
                    if (!OkVentole)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI VENTOLE\n");
                        Console.ResetColor();
                    }
                    else
                        newCase.nVentole = ventole;
                } while (!OkVentole);

                // Controllo  prezzo.
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        newCase.Prezzo = prezzo;
                } while (!okPrezzo);

                Console.Write("\t Produttore: ");
                newCase.Produttore = Console.ReadLine();

                cases.Add(newCase);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t CASE SALVATO CORRETTAMENTE!");
                Console.ResetColor();
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'P')
            {
                #region Aggiunti cpu.
                Cpu cpu = new Cpu();
                Console.WriteLine("\n\t - AGGIUNGI CPU\n");

                // Controllo  n cores
                bool okCores;
                do
                {
                    int cores;
                    Console.Write("\t Numero cores: ");
                    okCores = int.TryParse(Console.ReadLine(), out cores);
                    if (!okCores)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI CORE\n");
                        Console.ResetColor();
                    }
                    else
                        cpu.Cores = cores;
                } while (!okCores);

                // Controllo  frequenza
                bool okFreq;
                do
                {
                    int freq;
                    Console.Write("\t Frequenza [Hz]: ");
                    okFreq = int.TryParse(Console.ReadLine(), out freq);
                    if (!okFreq)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA FREQUENZA\n");
                        Console.ResetColor();
                    }
                    else
                        cpu.Frequency = freq;
                } while (!okFreq);

                Console.Write("\t Serie: ");
                cpu.Serie = Console.ReadLine();

                Console.Write("\t Sockets: ");
                cpu.CpuSockets = Console.ReadLine();

                // Controllo  n thread
                bool okThead;
                do
                {
                    int thread;
                    Console.Write("\t Numero di thread: ");
                    okThead = int.TryParse(Console.ReadLine(), out thread);
                    if (!okThead)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI THREAD\n");
                        Console.ResetColor();
                    }
                    else
                        cpu.Thread = thread;
                } while (!okThead);

                // Controllo  tpd
                bool Oktpd;
                do
                {
                    double tpd;
                    Console.Write("\t TPD: ");
                    Oktpd = double.TryParse(Console.ReadLine(), out tpd);
                    if (!Oktpd)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL TPD\n");
                        Console.ResetColor();
                    }
                    else
                        cpu.TPD = tpd;
                } while (!Oktpd);

                Console.Write("\t Dimensione [cm]: ");
                cpu.Dimensione = Console.ReadLine();

                Console.Write("\t Numero di serie: ");
                cpu.NumeroDiSerie = Console.ReadLine();

                // Controllo  prezzo.
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        cpu.Prezzo = prezzo;
                } while (!okPrezzo);

                Console.Write("\t Produttore: ");
                cpu.Produttore = Console.ReadLine();

                cpus.Add(cpu);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tCPU SALVATA CORRETTAMENTE!");
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'G')
            {
                #region Aggiugni gpu.
                Gpu gpu = new Gpu();
                Console.WriteLine("\n\t - AGGIUNGI GPU\n");

                // Controllo  n cores
                bool okCores;
                do
                {
                    int cores;
                    Console.Write("\t Numero cores: ");
                    okCores = int.TryParse(Console.ReadLine(), out cores);
                    if (!okCores)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI CORE\n");
                        Console.ResetColor();
                    }
                    else
                        gpu.Cores = cores;
                } while (!okCores);

                Console.Write("\t Dimensione [cm]: ");
                gpu.Dimensione = Console.ReadLine();

                // Controllo  frequenza
                bool okFreq;
                do
                {
                    int freq;
                    Console.Write("\t Frequenza [Hz]: ");
                    okFreq = int.TryParse(Console.ReadLine(), out freq);
                    if (!okFreq)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA FREQUENZA\n");
                        Console.ResetColor();
                    }
                    else
                        gpu.Frequency = freq;
                } while (!okFreq);

                Console.WriteLine("\t Numero di serie: ");
                gpu.NumeroDiSerie = Console.ReadLine();

                // Controllo  prezzo.
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        gpu.Prezzo = prezzo;
                } while (!okPrezzo);

                Console.WriteLine("\t Produttore: ");
                gpu.Produttore = Console.ReadLine();

                // Controllo  tflops
                bool okTflops;
                do
                {
                    double tflops;
                    Console.Write("\t TFLOPS: ");
                    okTflops = double.TryParse(Console.ReadLine(), out tflops);
                    if (!okTflops)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI TFLOPS\n");
                        Console.ResetColor();
                    }
                    else
                        gpu.TFLOPS = tflops;
                } while (!okTflops); ;

                // Controllo  watt
                bool okWatt;
                do
                {
                    Console.Write("\t Wattaggio: ");
                    int watt;
                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                    if (!okWatt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        gpu.Wattaggio = watt;
                } while (!okWatt);

                gpus.Add(gpu);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tGPU SALVATA CORRETTAMENTE!");
                Console.ResetColor();
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'R')
            {
                #region Aggiungi ram.
                Ram ram = new Ram();
                Console.Write("\n\t - AGGIUNGI RAM\n");

                Console.Write("\t Dimensione: ");
                ram.Dimensione = Console.ReadLine();

                Console.Write("\t Numero di serie: ");
                ram.NumeroDiSerie = Console.ReadLine();

                // Controllo  prezzo
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        ram.Prezzo = prezzo;
                } while (!okPrezzo);

                Console.Write("\t Produttore: ");
                ram.Produttore = Console.ReadLine();

                // Controllo  watt
                bool okWatt;
                do
                {
                    Console.Write("\t Wattaggio: ");
                    int watt;
                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                    if (!okWatt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        ram.Wattaggio = watt;
                } while (!okWatt);

                // Controllo  volt
                bool okVolt;
                do
                {
                    Console.Write("\t Voltaggio: ");
                    int volt;
                    okVolt = int.TryParse(Console.ReadLine(), out volt);
                    if (!okVolt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL VOLTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        ram.Voltaggio = volt;
                } while (!okVolt);

                // Controllo  frequenza
                bool okFreq;
                do
                {
                    Console.Write("\t Frequenza: ");
                    int freq;
                    okFreq = int.TryParse(Console.ReadLine(), out freq);
                    if (!okFreq)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA FREQUENZA");
                        Console.ResetColor();
                    }
                    else
                        ram.Frequenza = freq;
                } while (!okFreq);

                // Controllo  capacità
                bool okCap;
                do
                {
                    Console.Write("\t Capacità: ");
                    int cap;
                    okCap = int.TryParse(Console.ReadLine(), out cap);
                    if (!okCap)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO  DELLA CAPACITA'");
                        Console.ResetColor();
                    }
                    else
                        ram.Capacità = cap;
                } while (!okCap);

                rams.Add(ram);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tRAM SALVATA CORRETTAMENTE!");
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'H')
            {
                #region Aggiungi hdd.
                Hdd hdd = new Hdd();
                Console.WriteLine("\n\t - AGGIUNGI HDD\n");

                // Controllo  diametro disco
                bool okDiametroDisco;
                do
                {
                    double diametroDisco;
                    Console.Write("\t Diametro disco: ");
                    okDiametroDisco = double.TryParse(Console.ReadLine(), out diametroDisco);
                    if (!okDiametroDisco)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL DIAMETRO DEL DISCO\n");
                        Console.ResetColor();
                    }
                    else
                        hdd.DiametroDisco = diametroDisco;
                } while (!okDiametroDisco);

                Console.Write("\t Dimensione: ");
                hdd.Dimensione = Console.ReadLine();

                Console.Write("\t Numero di serie: ");
                hdd.NumeroDiSerie = Console.ReadLine();

                // Controllo  prezzo
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        hdd.Prezzo = prezzo;
                } while (!okPrezzo);

                Console.Write("\t Produttore: ");
                hdd.Produttore = Console.ReadLine();

                // Controllo  rpm
                bool okRpm;
                do
                {
                    int rpm;
                    Console.Write("\t Prezzo: ");
                    okRpm = int.TryParse(Console.ReadLine(), out rpm);
                    if (!okRpm)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEGLI RPM\n");
                        Console.ResetColor();
                    }
                    else
                        hdd.Rpm = rpm;
                } while (!okRpm);

                // Controllo  spazio di archiviazione
                bool okSpazio;
                do
                {
                    int SpazioDiArchiviazione;
                    Console.Write("\t Spazio di archiviazione: ");
                    okSpazio = int.TryParse(Console.ReadLine(), out SpazioDiArchiviazione);
                    if (!okSpazio)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLO SPAZIO DI ARCHIVIAZIONE\n");
                        Console.ResetColor();
                    }
                    else
                        hdd.SpazioDiArchiviazione = SpazioDiArchiviazione;
                } while (!okSpazio);

                // Controllo  velocità dati
                bool velDati;
                do
                {
                    int VelocitàTrasferimentoDati;
                    Console.Write("\t Velocità trasferimento dati: ");
                    velDati = int.TryParse(Console.ReadLine(), out VelocitàTrasferimentoDati);
                    if (!velDati)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA VELOCITA' DI TRASFERIMENTO DATI\n");
                        Console.ResetColor();
                    }
                    else
                        hdd.VelocitàTrasferimentoDati = VelocitàTrasferimentoDati;
                } while (!velDati);

                // Controllo  volume
                bool okVolume;
                do
                {
                    int Volume;
                    Console.Write("\t Volume: ");
                    okVolume = int.TryParse(Console.ReadLine(), out Volume);
                    if (!okVolume)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL VOLUME\n");
                        Console.ResetColor();
                    }
                    else
                        hdd.Volume = Volume;
                } while (!okVolume);

                // Controllo  watt
                bool okWatt;
                do
                {
                    Console.Write("\t Wattaggio: ");
                    int watt;
                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                    if (!okWatt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        hdd.Wattaggio = watt;
                } while (!okWatt);


                hdds.Add(hdd);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tHDD SALVATO CORRETTAMENTE!");
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'S')
            {
                #region Aggiungi ssd.
                Ssd ssd = new Ssd();
                Console.WriteLine("\n\t - AGGIUNGI SSD\n");
                // Controllo  diametro disco
                bool okDiametroDisco;
                do
                {
                    double diametroDisco;
                    Console.Write("\t Diametro disco: ");
                    okDiametroDisco = double.TryParse(Console.ReadLine(), out diametroDisco);
                    if (!okDiametroDisco)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL DIAMETRO DEL DISCO\n");
                        Console.ResetColor();
                    }
                    else
                        ssd.DiametroDisco = diametroDisco;
                } while (!okDiametroDisco);

                Console.Write("\t Dimensione: ");
                ssd.Dimensione = Console.ReadLine();

                Console.Write("\t Numero di serie: ");
                ssd.NumeroDiSerie = Console.ReadLine();

                // Controllo  prezzo
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        ssd.Prezzo = prezzo;
                } while (!okPrezzo);

                Console.Write("\t Produttore: ");
                ssd.Produttore = Console.ReadLine();

                // Controllo  spazio 
                bool okSpazio;
                do
                {
                    int SpazioDiArchiviazione;
                    Console.Write("\t Spazio di archiviazione: ");
                    okSpazio = int.TryParse(Console.ReadLine(), out SpazioDiArchiviazione);
                    if (!okSpazio)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLO SPAZIO DI ARCHIVIAZIONE\n");
                        Console.ResetColor();
                    }
                    else
                        ssd.SpazioDiArchiviazione = SpazioDiArchiviazione;
                } while (!okSpazio);

                // Controllo  velocità dati
                bool velDati;
                do
                {
                    int VelocitàTrasferimentoDati;
                    Console.Write("\t Velocità trasferimento dati: ");
                    velDati = int.TryParse(Console.ReadLine(), out VelocitàTrasferimentoDati);
                    if (!velDati)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA VELOCITA' DI TRASFERIMENTO DATI\n");
                        Console.ResetColor();
                    }
                    else
                        ssd.VelocitàTrasferimentoDati = VelocitàTrasferimentoDati;
                } while (!velDati);

                // Controllo  volume
                bool okVolume;
                do
                {
                    int Volume;
                    Console.Write("\t Volume: ");
                    okVolume = int.TryParse(Console.ReadLine(), out Volume);
                    if (!okVolume)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL VOLUME\n");
                        Console.ResetColor();
                    }
                    else
                        ssd.Volume = Volume;
                } while (!okVolume);

                // Controllo  watt
                bool okWatt;
                do
                {
                    Console.Write("\t Wattaggio: ");
                    int watt;
                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                    if (!okWatt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        ssd.Wattaggio = watt;
                } while (!okWatt);


                ssds.Add(ssd);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tSSD SALVATO CORRETTAMENTE!");
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'E')
            {
                #region Aggiungi scheda audio.
                SchedaAudio schedaAudio = new SchedaAudio();
                Console.WriteLine("\n\t - AGGIUNGI SCHEDA AUDIO\n");
                // Controllo  prezzo
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        schedaAudio.Prezzo = prezzo;
                } while (!okPrezzo);

                // Controllo  bitrate
                bool okBit;
                do
                {
                    double BitRate;
                    Console.Write("\t Bit rate: ");
                    okBit = double.TryParse(Console.ReadLine(), out BitRate);
                    if (!okBit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL BIT RATE\n");
                        Console.ResetColor();
                    }
                    else
                        schedaAudio.BitRate = BitRate;
                } while (!okBit);

                // Controllo  db
                bool okDb;
                do
                {
                    double Db;
                    Console.Write("\t Db erogati: ");
                    okDb = double.TryParse(Console.ReadLine(), out Db);
                    if (!okDb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI DB EROGATI\n");
                        Console.ResetColor();
                    }
                    else
                        schedaAudio.Db = Db;
                } while (!okDb);

                Console.Write("\t Dimensione: ");
                schedaAudio.Dimensione = Console.ReadLine();

                Console.Write("\t Impianto: ");
                schedaAudio.Impianto = Console.ReadLine();

                Console.Write("\t Numero di serie: ");
                schedaAudio.NumeroDiSerie = Console.ReadLine();

                Console.Write("\t Produttore: ");
                schedaAudio.Produttore = Console.ReadLine();

                // Controllo  watt
                bool okWatt;
                do
                {
                    Console.Write("\t Wattaggio: ");
                    int watt;
                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                    if (!okWatt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        schedaAudio.Wattaggio = watt;
                } while (!okWatt);

                schedeAudio.Add(schedaAudio);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tSCHEDA AUDIO SALVATA CORRETTAMENTE!");
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'M')
            {
                #region Aggiungi scheda madre.
                SchedaMadre schedaMadre = new SchedaMadre();
                Console.Write("\n\t - AGGIUNGI SCHEDA MADRE\n");

                // Controllo  audio integrato
                string sn;
                do
                {
                    Console.Write("\t Audio integrato:(s/n) ");
                    sn = Console.ReadLine().ToLower();
                    if (sn == "s")
                        schedaMadre.AudioIntegrato = true;
                    else if (sn == "n")
                        schedaMadre.AudioIntegrato = false;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t INSERIRE \"s\" o \"n\".");
                        Console.ResetColor();
                    }
                } while (sn != "s" && sn != "n");


                Console.Write("\t Chipset: ");
                schedaMadre.Chipset = Console.ReadLine();

                Console.Write("\t Dimensione: ");
                schedaMadre.Dimensione = Console.ReadLine();
                // Controllo  n slot ram
                bool okSlot;
                do
                {
                    int NSlotRam;
                    Console.Write("\t Numero slot ram: ");
                    okSlot = int.TryParse(Console.ReadLine(), out NSlotRam);
                    if (!okSlot)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI SLOT RAM\n");
                        Console.ResetColor();
                    }
                    else
                        schedaMadre.NSlotRam = NSlotRam;
                } while (!okSlot);

                Console.Write("\t Numero di serie: ");
                schedaMadre.NumeroDiSerie = Console.ReadLine();

                // Controllo  prezzo
                bool okPrezzo;
                do
                {
                    double prezzo;
                    Console.Write("\t Prezzo: ");
                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                    if (!okPrezzo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                        Console.ResetColor();
                    }
                    else
                        schedaMadre.Prezzo = prezzo;
                } while (!okPrezzo);

                Console.Write("\t Produttore: ");
                schedaMadre.Produttore = Console.ReadLine();

                Console.Write("\t Tipologia rete: ");
                schedaMadre.Rete = Console.ReadLine();

                // Controllo  scheda video integrata
                do
                {
                    Console.Write("\t Scheda video integrata:(s/n) ");
                    sn = Console.ReadLine().ToLower();
                    if (sn == "s")
                        schedaMadre.SchedaVideoIntegrata = true;
                    else if (sn == "n")
                        schedaMadre.SchedaVideoIntegrata = false;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t INSERIRE \"s\" o \"n\".");
                        Console.ResetColor();
                    }
                } while (sn != "s" && sn != "n");

                // Controllo  watt
                bool okWatt;
                do
                {
                    Console.Write("\t Wattaggio: ");
                    int watt;
                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                    if (!okWatt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                        Console.ResetColor();
                    }
                    else
                        schedaMadre.Wattaggio = watt;
                } while (!okWatt);

                schedeMadri.Add(schedaMadre);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tSCHEDA MADRE SALVATA CORRETTAMENTE!");
                Thread.Sleep(1500);
                AggiungiComponente();
                #endregion
            }
            else if (ch == 'X')
            {
                #region Chiudi finestra.
                Console.Clear();
                Menu();
                #endregion
            }
        }
        #endregion

        #region Modifica componente.
        /// <summary>
        /// Modifica un componente.
        /// </summary>
        public static void ModificaComponente()
        {
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Sezione: [M]odifica componente\n");
            Console.WriteLine(@"
        - [A]limentatore
        - [C]ase
        - C[p]u
        - [G]pu
        - [R]am
        - [H]dd
        - [S]sd
        - Sch[e]da Audio
        - Scheda [M]adre
        - [X]Torna indietro");
            char ch = ' ';
            do // Legge e controlla l'opzione scelta.
            {
                ch = Console.ReadKey(true).KeyChar;
                ch = char.ToUpper(ch);
            }
            while (!((ch == 'A') || (ch == 'C') || (ch == 'P') || (ch == 'G') || (ch == 'R') || (ch == 'H') || (ch == 'S') || (ch == 'E') || (ch == 'M') || (ch == 'X'))); // Controllo scelta.

            switch (ch)
            {
                case 'A':
                    #region Modifica alimentatore.
                    if (alimentatori.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN ALIMENTATORE DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaAlimentatori(); // Visualizza gli alimentatori disponibili per la modifica
                        bool okindiceAli;
                        int indice;
                        do
                        {
                            Console.Write("Inserisci l'indice dell'alimentatore da modificare dall'archivio: ");
                            okindiceAli = int.TryParse(Console.ReadLine(), out indice);
                            if ((!okindiceAli) || (indice >= alimentatori.Count) || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Alimentatore vecchio: ", indice);
                                Console.WriteLine(alimentatori[indice].ToString());
                                alimentatori.RemoveAt(indice); // rimuovo alimentatore vecchio di indice scelto

                                Alimentatore alimentatore = new Alimentatore();
                                Console.WriteLine("\n\t - MODIFICA ALIMENTATORE\n");

                                Console.Write("\t Dimensione: ");
                                alimentatore.Dimensione = Console.ReadLine();

                                Console.Write("\t Numero di serie: ");
                                alimentatore.NumeroDiSerie = Console.ReadLine();

                                Console.Write("\t Produttore: ");
                                alimentatore.Produttore = Console.ReadLine();

                                // RIASSEGNO TUTTI I VALORI COME NEL CASO DI AGGIUGNI 

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        alimentatore.Prezzo = prezzo;
                                } while (!okPrezzo);

                                bool okWatt;
                                do
                                {
                                    Console.Write("\t Wattaggio: ");
                                    int watt;
                                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                                    if (!okWatt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                                        Console.ResetColor();
                                    }  
                                    else
                                        alimentatore.Wattaggio = watt;
                                } while (!okWatt);

                                bool okConCpu;
                                do
                                {
                                    Console.Write("\t Connettori cpu: ");
                                    int connettoriCpu;
                                    okConCpu = int.TryParse(Console.ReadLine(), out connettoriCpu);
                                    if (!okConCpu)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI CONNETTORI CPU");
                                        Console.ResetColor();
                                    }
                                    else
                                        alimentatore.NConnettoriCpu = connettoriCpu;
                                } while (!okConCpu);

                                bool okNConnettoriMobo;
                                do
                                {
                                    Console.Write("\t Connettori mobo: ");
                                    int NConnettoriMobo;
                                    okNConnettoriMobo = int.TryParse(Console.ReadLine(), out NConnettoriMobo);
                                    if (!okNConnettoriMobo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI CONNETTORI MOTHERBOARD");
                                        Console.ResetColor();
                                    }
                                    else
                                        alimentatore.NConnettoriMobo = NConnettoriMobo;
                                } while (!okNConnettoriMobo);

                                bool okNPciExpress;
                                do
                                {
                                    Console.Write("\t Pci Express: ");
                                    int NPciExpress;
                                    okNPciExpress = int.TryParse(Console.ReadLine(), out NPciExpress);
                                    if (!okNPciExpress)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DEI PCI EXPRESS");
                                        Console.ResetColor();
                                    }
                                    else
                                        alimentatore.NPciExpress = NPciExpress;
                                } while (!okNPciExpress);

                                bool okNSata;
                                do
                                {
                                    Console.Write("\t Numero Connettori sata: ");
                                    int NSata;
                                    okNSata = int.TryParse(Console.ReadLine(), out NSata);
                                    if (!okNSata)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI CONNETTORI SATA");
                                        Console.ResetColor();
                                    }
                                    else
                                        alimentatore.NSata = NSata;
                                } while (!okNSata);

                                // Inserisco all'inidce di prima ma modificato.
                                alimentatori.Insert(indice, alimentatore);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tALIMENTATORE AGGIORNATO CORRETTAMENTE!");
                                Console.ResetColor();
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindiceAli && indice >= alimentatori.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'C':
                    #region Modifica case.
                    if (cases.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN CASE DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaCase(); // Visualizza gli case disponibili per la modifica
                        bool okindicecase;
                        int indice;
                        do
                        {
                            // COntrollo inidice per scelta componete da aliminare
                            Console.Write("Inserisci l'indice del case da eliminare dall'archivio: ");
                            okindicecase = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicecase || (indice >= cases.Count) || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Case vecchio: ", indice);
                                Console.WriteLine(cases[indice].ToString());
                                cases.RemoveAt(indice);

                                Case newCase = new Case();
                                Console.WriteLine("\n\t - MODIFICA CASE\n");

                                Console.Write("\t Colore: ");
                                newCase.Colore = Console.ReadLine();

                                Console.Write("\t Dimensione: ");
                                newCase.Dimensione = Console.ReadLine();

                                Console.Write("\t Numero di serie: ");
                                newCase.NumeroDiSerie = Console.ReadLine();

                                //RIASSEGNO TUTTO COME NEL CASO DI AGGIUNGI CON RELATIVI CONTROLLI

                                bool OkVentole;
                                do
                                {
                                    int ventole;
                                    Console.Write("\t Ventole: ");
                                    OkVentole = int.TryParse(Console.ReadLine(), out ventole);
                                    if (!OkVentole)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI VENTOLE\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        newCase.nVentole = ventole;
                                } while (!OkVentole);

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        newCase.Prezzo = prezzo;
                                } while (!okPrezzo);

                                Console.Write("\t Produttore: ");
                                newCase.Produttore = Console.ReadLine();

                                cases.Insert(indice, newCase); // Inserisco all'inidce di prima ma modificato.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t CASE AGGIORNATO CORRETTAMENTE!");
                                Console.ResetColor();
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindicecase && (indice >= cases.Count) && indice < 0);
                    }
                    #endregion
                    break;

                case 'P':
                    #region Modifica cpu.
                    if (cpus.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA CPU DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaCpu(); // Visualizza le cpu disponibili per la modifica
                        bool okindicecpu;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE DEL COMPOENTNE DA MODIFICARE
                            Console.Write("Inserisci l'indice della cpu da eliminare dall'archivio: ");
                            okindicecpu = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicecpu || (indice >= cpus.Count) || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Cpu vecchia: ", indice);
                                Console.WriteLine(cpus[indice].ToString());
                                cpus.RemoveAt(indice); // RIMUOVO TEMPORANEAMNETE VECCHIO COMPONENTE

                                Cpu cpu = new Cpu();
                                Console.WriteLine("\n\t - MODIFICA CPU\n");

                                // COMNTROLLO TUTTI I PARAMETRI DEL COMPONETNE COME IN AGGIUGNI

                                bool okCores;
                                do
                                {
                                    int cores;
                                    Console.Write("\t Numero cores: ");
                                    okCores = int.TryParse(Console.ReadLine(), out cores);
                                    if (!okCores)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI CORE\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        cpu.Cores = cores;
                                } while (!okCores);

                                bool okFreq;
                                do
                                {
                                    int freq;
                                    Console.Write("\t Frequenza [Hz]: ");
                                    okFreq = int.TryParse(Console.ReadLine(), out freq);
                                    if (!okFreq)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA FREQUENZA\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        cpu.Frequency = freq;
                                } while (!okCores);

                                Console.Write("\t Serie: ");
                                cpu.Serie = Console.ReadLine();

                                Console.Write("\t Sockets: ");
                                cpu.CpuSockets = Console.ReadLine();

                                bool okThead;
                                do
                                {
                                    int thread;
                                    Console.Write("\t Numero di thread: ");
                                    okThead = int.TryParse(Console.ReadLine(), out thread);
                                    if (!okThead)
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI THREAD\n");
                                    else
                                        cpu.Thread = thread;
                                } while (!okThead);

                                bool Oktpd;
                                do
                                {
                                    double tpd;
                                    Console.Write("\t TPD: ");
                                    Oktpd = double.TryParse(Console.ReadLine(), out tpd);
                                    if (!Oktpd)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL TPD\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        cpu.TPD = tpd;
                                } while (!Oktpd);

                                Console.Write("\t Dimensione [cm]: ");
                                cpu.Dimensione = Console.ReadLine();

                                Console.Write("\t Numero di serie: ");
                                cpu.NumeroDiSerie = Console.ReadLine();

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        cpu.Prezzo = prezzo;
                                } while (!okPrezzo);

                                Console.Write("\t Produttore: ");
                                cpu.Produttore = Console.ReadLine();

                                cpus.Insert(indice, cpu); // Inserisco all'inidce di prima ma modificato.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tCPU AGGIORNATA CORRETTAMENTE!");
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindicecpu && (indice >= cpus.Count) && indice < 0);
                    }
                    #endregion
                    break;

                case 'G':
                    #region Modifica gpu.
                    if (gpus.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA GPU DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaGpu(); // Visualizza le gpu disponibili per la modifica
                        bool okindicegpu;
                        int indice;
                        do
                        {
                            // CONTROLLO INDICE COMPOENTE DA MODIFICARE
                            Console.Write("Inserisci l'indice della gpu da eliminare dall'archivio: ");
                            okindicegpu = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicegpu || (indice >= gpus.Count) || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Gpu vecchia: ", indice);
                                Console.WriteLine(gpus[indice].ToString());
                                gpus.RemoveAt(indice); // TOLGO TEMPORANEAMENTE IL VECCHIO COMPONENTE

                                Gpu gpu = new Gpu();
                                Console.WriteLine("\n\t - MODIFICA GPU\n");


                                // CONTROLLO DEL COMPOENTNE COME IN AGGIUGNI 
                                bool okCores;
                                do
                                {
                                    int cores;
                                    Console.Write("\t Numero cores: ");
                                    okCores = int.TryParse(Console.ReadLine(), out cores);
                                    if (!okCores)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI CORE\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        gpu.Cores = cores;
                                } while (!okCores);

                                Console.Write("\t Dimensione [cm]: ");
                                gpu.Dimensione = Console.ReadLine();

                                bool okFreq;
                                do
                                {
                                    int freq;
                                    Console.Write("\t Frequenza [Hz]: ");
                                    okFreq = int.TryParse(Console.ReadLine(), out freq);
                                    if (!okFreq)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA FREQUENZA\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        gpu.Frequency = freq;
                                } while (!okCores);

                                Console.WriteLine("\t Numero di serie: ");
                                gpu.NumeroDiSerie = Console.ReadLine();

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        gpu.Prezzo = prezzo;
                                } while (!okPrezzo);

                                Console.WriteLine("\t Produttore: ");
                                gpu.Produttore = Console.ReadLine();

                                bool okTflops;
                                do
                                {
                                    double tflops;
                                    Console.Write("\t Prezzo: ");
                                    okTflops = double.TryParse(Console.ReadLine(), out tflops);
                                    if (!okTflops)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI TFLOPS\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        gpu.TFLOPS = tflops;
                                } while (!okTflops); ;

                                bool okWatt;
                                do
                                {
                                    Console.Write("\t Wattaggio: ");
                                    int watt;
                                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                                    if (!okWatt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                                        Console.ResetColor();
                                    }
                                    else
                                        gpu.Wattaggio = watt;
                                } while (!okWatt);

                                gpus.Insert(indice, gpu); // Inserisco all'inidce di prima ma modificato.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tGPU AGIORNATA CORRETTAMENTE!");
                                Console.ResetColor();
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindicegpu && (indice >= gpus.Count) && indice < 0);
                    }
                    #endregion
                    break;

                case 'R':
                    #region Modifica ram.
                    if (rams.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA RAM DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaRam(); // Visualizza le ram disponibili per la modifica
                        bool okindiceram;
                        int indice;
                        do
                        {
                            // CONTROLLO INDICE DEL COMPONETNE DA MODIFICARE
                            Console.Write("Inserisci l'indice della ram da eliminare dall'archivio: ");
                            okindiceram = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindiceram || (indice >= rams.Count) || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Ram vecchia: ", indice);
                                Console.WriteLine(rams[indice].ToString());
                                rams.RemoveAt(indice); // RIMUOVO TEMPORANEAMNETE IL VECCHIO COMPONENTE DA MODIFICARE


                                //CONTROLLLI SPECIFICHE COMPONENTE COME IN AGGIUGNI
                                Ram ram = new Ram();
                                Console.Write("\n\t - MODIFICA RAM\n");

                                Console.Write("\t Dimensione: ");
                                ram.Dimensione = Console.ReadLine();

                                Console.Write("\t Numero di serie: ");
                                ram.NumeroDiSerie = Console.ReadLine();

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        ram.Prezzo = prezzo;
                                } while (!okPrezzo);

                                Console.Write("\t Produttore: ");
                                ram.Produttore = Console.ReadLine();

                                bool okWatt;
                                do
                                {
                                    Console.Write("\t Wattaggio: ");
                                    int watt;
                                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                                    if (!okWatt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                                        Console.ResetColor();
                                    }
                                    else
                                        ram.Wattaggio = watt;
                                } while (!okWatt);

                                bool okVolt;
                                do
                                {
                                    Console.Write("\t Voltaggio: ");
                                    int volt;
                                    okVolt = int.TryParse(Console.ReadLine(), out volt);
                                    if (!okVolt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL VOLTAGGIO");
                                        Console.ResetColor();
                                    }
                                    else
                                        ram.Voltaggio = volt;
                                } while (!okVolt);

                                bool okFreq;
                                do
                                {
                                    Console.Write("\t Frequenza: ");
                                    int freq;
                                    okFreq = int.TryParse(Console.ReadLine(), out freq);
                                    if (!okFreq)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA FREQUENZA");
                                        Console.ResetColor();
                                    }
                                    else
                                        ram.Frequenza = freq;
                                } while (!okFreq);


                                bool okCap;
                                do
                                {
                                    Console.Write("\t Capacità: ");
                                    int cap;
                                    okCap = int.TryParse(Console.ReadLine(), out cap);
                                    if (!okCap)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO  DELLA CAPACITA'");
                                        Console.ResetColor();
                                    }
                                    else
                                        ram.Capacità = cap;
                                } while (!okCap);

                                rams.Insert(indice, ram); // Inserisco all'inidce di prima ma modificato.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tRAM AGGIORNATA CORRETTAMENTE!");
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindiceram && (indice >= rams.Count) && indice < 0);
                    }
                    #endregion
                    break;

                case 'H':
                    #region Modifica hdd.
                    if (hdds.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN HDD DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaHdd(); // Visualizza gli hdd disponibili per la modifica
                        bool okindicehdd;
                        int indice;
                        do
                        {
                            // CONTROLLO INDICE DEL COMPOENTE DA MODIFICARE
                            Console.Write("Inserisci l'indice del'hdd da eliminare dall'archivio: ");
                            okindicehdd = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicehdd || (indice >= hdds.Count) || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - hdd vecchio: ", indice);
                                Console.WriteLine(hdds[indice].ToString());
                                hdds.RemoveAt(indice);// RIMUOVO TEMPORANEAMENTE IL COMPONETNE


                                // CONTROLLO SPECIFICHE COME IN AGGIUGNI
                                Hdd hdd = new Hdd();
                                Console.WriteLine("\n\t - AGGIUNGI HDD\n");
                                bool okDiametroDisco;
                                do
                                {
                                    double diametroDisco;
                                    Console.Write("\t Diametro disco: ");
                                    okDiametroDisco = double.TryParse(Console.ReadLine(), out diametroDisco);
                                    if (!okDiametroDisco)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL DIAMETRO DEL DISCO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        hdd.DiametroDisco = diametroDisco;
                                } while (!okDiametroDisco);

                                Console.Write("\t Dimensione: ");
                                hdd.Dimensione = Console.ReadLine();

                                Console.Write("\t Numero di serie: ");
                                hdd.NumeroDiSerie = Console.ReadLine();

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        hdd.Prezzo = prezzo;
                                } while (!okPrezzo);

                                Console.Write("\t Produttore: ");
                                hdd.Produttore = Console.ReadLine();

                                bool okRpm;
                                do
                                {
                                    int rpm;
                                    Console.Write("\t RPM: ");
                                    okRpm = int.TryParse(Console.ReadLine(), out rpm);
                                    if (!okRpm)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEGLI RPM\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        hdd.Rpm = rpm;
                                } while (!okRpm);

                                bool okSpazio;
                                do
                                {
                                    int SpazioDiArchiviazione;
                                    Console.Write("\t Spazio di archiviazione: ");
                                    okSpazio = int.TryParse(Console.ReadLine(), out SpazioDiArchiviazione);
                                    if (!okSpazio)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLO SPAZIO DI ARCHIVIAZIONE\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        hdd.SpazioDiArchiviazione = SpazioDiArchiviazione;
                                } while (!okSpazio);

                                bool velDati;
                                do
                                {
                                    int VelocitàTrasferimentoDati;
                                    Console.Write("\t Velocità trasferimento dati: ");
                                    velDati = int.TryParse(Console.ReadLine(), out VelocitàTrasferimentoDati);
                                    if (!velDati)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA VELOCITA' DI TRASFERIMENTO DATI\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        hdd.VelocitàTrasferimentoDati = VelocitàTrasferimentoDati;
                                } while (!velDati);

                                bool okVolume;
                                do
                                {
                                    int Volume;
                                    Console.Write("\t Volume: ");
                                    okVolume = int.TryParse(Console.ReadLine(), out Volume);
                                    if (!okVolume)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL VOLUME\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        hdd.Volume = Volume;
                                } while (!okVolume);

                                bool okWatt;
                                do
                                {
                                    Console.Write("\t Wattaggio: ");
                                    int watt;
                                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                                    if (!okWatt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                                        Console.ResetColor();
                                    }
                                    else
                                        hdd.Wattaggio = watt;
                                } while (!okWatt);


                                hdds.Insert(indice, hdd);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tHDD AGGIORNATO CORRETTAMENTE!");
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindicehdd && (indice >= hdds.Count) && indice < 0);
                    }
                    #endregion
                    break;

                case 'S':
                    #region Modifica ssd.
                    if (ssds.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN SSD DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaSsd(); // Visualizza gli ssd disponibili per la modifica
                        bool okindicessd;
                        int indice;
                        do
                        {
                            // CONTROLLO INDICE DEL COMPOENNTE DA MODIFICARE
                            Console.Write("Inserisci l'indice dell'ssd da eliminare dall'archivio: ");
                            okindicessd = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicessd || indice >= ssds.Count || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Ssd vecchio: ", indice);
                                Console.WriteLine(ssds[indice].ToString());
                                ssds.RemoveAt(indice); // RIMUOVO TEMPORANEAMNETE IL COMPONETNE


                                //CONTROLLO SPECIFICHE COMPONETNE COME IN AGGIUGNI
                                Ssd ssd = new Ssd();
                                Console.WriteLine("\n\t - MODIFICA SSD\n");
                                bool okDiametroDisco;
                                do
                                {
                                    double diametroDisco;
                                    Console.Write("\t Diametro disco: ");
                                    okDiametroDisco = double.TryParse(Console.ReadLine(), out diametroDisco);
                                    if (!okDiametroDisco)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL DIAMETRO DEL DISCO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        ssd.DiametroDisco = diametroDisco;
                                } while (!okDiametroDisco);

                                Console.Write("\t Dimensione: ");
                                ssd.Dimensione = Console.ReadLine();

                                Console.Write("\t Numero di serie: ");
                                ssd.NumeroDiSerie = Console.ReadLine();

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        ssd.Prezzo = prezzo;
                                } while (!okPrezzo);

                                Console.Write("\t Produttore: ");
                                ssd.Produttore = Console.ReadLine();

                                bool okSpazio;
                                do
                                {
                                    int SpazioDiArchiviazione;
                                    Console.Write("\t Spazio di archiviazione: ");
                                    okSpazio = int.TryParse(Console.ReadLine(), out SpazioDiArchiviazione);
                                    if (!okSpazio)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLO SPAZIO DI ARCHIVIAZIONE\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        ssd.SpazioDiArchiviazione = SpazioDiArchiviazione;
                                } while (!okSpazio);

                                bool velDati;
                                do
                                {
                                    int VelocitàTrasferimentoDati;
                                    Console.Write("\t Velocità trasferimento dati: ");
                                    velDati = int.TryParse(Console.ReadLine(), out VelocitàTrasferimentoDati);
                                    if (!velDati)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DELLA VELOCITA' DI TRASFERIMENTO DATI\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        ssd.VelocitàTrasferimentoDati = VelocitàTrasferimentoDati;
                                } while (!velDati);

                                bool okVolume;
                                do
                                {
                                    int Volume;
                                    Console.Write("\t Volume: ");
                                    okVolume = int.TryParse(Console.ReadLine(), out Volume);
                                    if (!okVolume)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL VOLUME\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        ssd.Volume = Volume;
                                } while (!okVolume);

                                bool okWatt;
                                do
                                {
                                    Console.Write("\t Wattaggio: ");
                                    int watt;
                                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                                    if (!okWatt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                                        Console.ResetColor();
                                    }
                                    else
                                        ssd.Wattaggio = watt;
                                } while (!okWatt);


                                ssds.Insert(indice, ssd); // Inserisco all'inidce di prima ma modificato.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tSSD AGGIORNATO CORRETTAMENTE!");
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindicessd && indice >= ssds.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'E':
                    #region Modifica scheda audio.
                    if (schedeAudio.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA SCHEDA AUDIO DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaSchedaAudio(); // Visualizza le schede audio disponibili per la modifica
                        bool okindiceaudio;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE DEL COMPONENTE DA MOPDIFICARE
                            Console.Write("Inserisci l'indice delle schede audio da eliminare dall'archivio: ");
                            okindiceaudio = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindiceaudio || indice >= schedeAudio.Count || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Scheda audio vecchia: ", indice);
                                Console.WriteLine(schedeAudio[indice].ToString());
                                schedeAudio.RemoveAt(indice); // RIMUOVO TEMPORANEAMNETE L'INDICE

                                // CONTROLLO SPECIFICHE COMPONENTE COME I AGGIUGNI
                                SchedaAudio schedaAudio = new SchedaAudio();
                                Console.WriteLine("\n\t - MODIFICA SCHEDA AUDIO\n");
                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        schedaAudio.Prezzo = prezzo;
                                } while (!okPrezzo);

                                bool okBit;
                                do
                                {
                                    double BitRate;
                                    Console.Write("\t Bit rate: ");
                                    okBit = double.TryParse(Console.ReadLine(), out BitRate);
                                    if (!okBit)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL BIT RATE\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        schedaAudio.BitRate = BitRate;
                                } while (!okBit);

                                bool okDb;
                                do
                                {
                                    double Db;
                                    Console.Write("\t Db erogati: ");
                                    okDb = double.TryParse(Console.ReadLine(), out Db);
                                    if (!okDb)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEI DB EROGATI\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        schedaAudio.Db = Db;
                                } while (!okDb);

                                Console.Write("\t Dimensione: ");
                                schedaAudio.Dimensione = Console.ReadLine();

                                Console.Write("\t Impianto: ");

                                Console.Write("\t Numero di serie: ");
                                schedaAudio.NumeroDiSerie = Console.ReadLine();

                                Console.Write("\t Produttore: ");
                                schedaAudio.Produttore = Console.ReadLine();

                                bool okWatt;
                                do
                                {
                                    Console.Write("\t Wattaggio: ");
                                    int watt;
                                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                                    if (!okWatt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                                        Console.ResetColor();
                                    }
                                    else
                                        schedaAudio.Wattaggio = watt;
                                } while (!okWatt);

                                schedeAudio.Insert(indice, schedaAudio); // Inserisco all'inidce di prima ma modificato.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tSCHEDA AUDIO AGGIORNATA CORRETTAMENTE!");
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindiceaudio && indice >= schedeAudio.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'M':
                    #region Modifica scheda madre.
                    if (schedeMadri.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA SCHEDA MADRE DA MODIFICARE.");
                        Thread.Sleep(2000);
                        ModificaComponente();
                    }
                    else
                    {
                        VisualizzaSchedaMadre(); // Visualizza le schede madri disponibili per la modifica
                        bool okindicemadre;
                        int indice;
                        do
                        {
                            // CONTROLLO INDICE DEL COMPONENTE DA MODIFICARE
                            Console.Write("Inserisci l'indice della scheda madre da eliminare dall'archivio: ");
                            okindicemadre = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicemadre || indice >= schedeMadri.Count || indice < 0)
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                            else
                            {
                                Console.WriteLine("{0} - Scheda madre vecchia: ", indice);
                                Console.WriteLine(schedeMadri[indice].ToString());
                                schedeMadri.RemoveAt(indice); // RIMUOVO TEMPORANEAMENTE IL COMPONETE
                                // CONTROLLO LE SPECIFICHE DEI COMPONENTI COME IN AGGIUGNI
                                SchedaMadre schedaMadre = new SchedaMadre();
                                Console.Write("\n\t - MODIFICA SCHEDA MADRE\n");
                                string sn;
                                do
                                {
                                    Console.Write("\t Audio integrato:(s/n) ");
                                    sn = Console.ReadLine().ToLower();
                                    if (sn == "s")
                                        schedaMadre.AudioIntegrato = true;
                                    else if (sn == "n")
                                        schedaMadre.AudioIntegrato = false;
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t INSERIRE \"s\" o \"n\".");
                                        Console.ResetColor();
                                    }
                                } while (sn == "s" || sn == "n");


                                Console.Write("\t Chipset: ");
                                schedaMadre.Chipset = Console.ReadLine();

                                Console.Write("\t Dimensione: ");
                                schedaMadre.Dimensione = Console.ReadLine();

                                bool okSlot;
                                do
                                {
                                    int NSlotRam;
                                    Console.Write("\t Numero slot ram: ");
                                    okSlot = int.TryParse(Console.ReadLine(), out NSlotRam);
                                    if (!okSlot)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL NUMERO DI SLOT RAM\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        schedaMadre.NSlotRam = NSlotRam;
                                } while (!okSlot);

                                Console.Write("\t Numero di serie: ");
                                schedaMadre.NumeroDiSerie = Console.ReadLine();

                                bool okPrezzo;
                                do
                                {
                                    double prezzo;
                                    Console.Write("\t Prezzo: ");
                                    okPrezzo = double.TryParse(Console.ReadLine(), out prezzo);
                                    if (!okPrezzo)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL PREZZO\n");
                                        Console.ResetColor();
                                    }
                                    else
                                        schedaMadre.Prezzo = prezzo;
                                } while (!okPrezzo);

                                Console.Write("\t Produttore: ");
                                schedaMadre.Produttore = Console.ReadLine();

                                Console.Write("\t Tipologia rete: ");
                                schedaMadre.Rete = Console.ReadLine();

                                do
                                {
                                    Console.Write("\t Scheda video integrata:(s/n) ");
                                    sn = Console.ReadLine().ToLower();
                                    if (sn == "s")
                                        schedaMadre.SchedaVideoIntegrata = true;
                                    else if (sn == "n")
                                        schedaMadre.SchedaVideoIntegrata = false;
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t INSERIRE \"s\" o \"n\".");
                                        Console.ResetColor();
                                    }
                                } while (sn == "s" || sn == "n");


                                bool okWatt;
                                do
                                {
                                    Console.Write("\t Wattaggio: ");
                                    int watt;
                                    okWatt = int.TryParse(Console.ReadLine(), out watt);
                                    if (!okWatt)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\tERRORE NELL'INSERIMENTO DEL WATTAGGIO");
                                        Console.ResetColor();
                                    }
                                    else
                                        schedaMadre.Wattaggio = watt;
                                } while (!okWatt);

                                schedeMadri.Insert(indice, schedaMadre); // Inserisco all'inidce di prima ma modificato.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tSCHEDA MADRE AGGIORNATA CORRETTAMENTE!");
                                Thread.Sleep(1500);
                                ModificaComponente();
                            }
                        } while (!okindicemadre && indice >= schedeMadri.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'X':
                    Menu();
                    break;
            }
        }
        #endregion

        #region Elimina componente.
        /// <summary>
        /// Elimina un componente.
        /// </summary>
        public static void EliminaComponente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Sezione: [E]limina componente\n");
            Console.WriteLine(@"
        - [A]limentatore
        - [C]ase
        - C[p]u
        - [G]pu
        - [R]am
        - [H]dd
        - [S]sd
        - Sch[e]da Audio
        - Scheda [M]adre
        - [X]Torna indietro");
            char ch = ' ';
            do // Legge e controlla l'opzione scelta.
            {
                ch = Console.ReadKey(true).KeyChar;
                ch = char.ToUpper(ch);
            }
            while (!((ch == 'A') || (ch == 'C') || (ch == 'P') || (ch == 'G') || (ch == 'R') || (ch == 'H') || (ch == 'S') || (ch == 'E') || (ch == 'M') || (ch == 'X'))); // Controllo scelta.
            switch (ch)
            {
                case 'A':
                    #region Elimina alimentatore.
                    if (alimentatori.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN ALIMENTATORE DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaAlimentatori();
                        bool okindiceAli;
                        int indice;
                        // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                        do
                        {
                            Console.Write("Inserisci l'indice dell'alimentatore da eliminare dall'archivio: ");
                            okindiceAli = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindiceAli || alimentatori.Count <= indice || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                alimentatori.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t ALIMENTATORE RIMOSSO.");
                                EliminaComponente();
                            }
                        } while (!okindiceAli && indice >= alimentatori.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'C':
                    #region Elimina case.
                    if (cases.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN CASE DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaCase();
                        bool okindicecase;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice del case da eliminare dall'archivio: ");
                            okindicecase = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicecase || indice >= cases.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                cases.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t CASE RIMOSSO.");
                                EliminaComponente();
                            }
                        } while (!okindicecase && indice >= cases.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'P':
                    #region Elimina cpu.
                    if (cpus.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA CPU DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaCpu();
                        bool okindicecpu;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice della cpu da eliminare dall'archivio: ");
                            okindicecpu = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicecpu || indice >= cpus.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                cpus.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t CPU RIMOSSA.");
                                EliminaComponente();
                            }
                        } while (!okindicecpu && indice >= cpus.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'G':
                    #region Elimina gpu.
                    if (gpus.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA GPU DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaGpu();
                        bool okindicegpu;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice della gpu da eliminare dall'archivio: ");
                            okindicegpu = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicegpu || indice >= gpus.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                gpus.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t GPU RIMOSSA.");
                                EliminaComponente();
                            }
                        } while (!okindicegpu && indice >= gpus.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'R':
                    #region Elimina ram.
                    if (rams.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA RAM DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaRam();
                        bool okindiceram;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice della ram da eliminare dall'archivio: ");
                            okindiceram = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindiceram || indice >= rams.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                rams.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t RAM RIMOSSA.");
                                EliminaComponente();
                            }
                        } while (!okindiceram && indice >= rams.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'H':
                    #region Elimina hdd.
                    if (hdds.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN HDD DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaHdd();
                        bool okindicehdd;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice del'hdd da eliminare dall'archivio: ");
                            okindicehdd = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicehdd || indice >= hdds.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                hdds.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t HDD RIMOSSO.");
                                EliminaComponente();
                            }
                        } while (!okindicehdd && indice >= hdds.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'S':
                    #region Elimina ssd.
                    if (ssds.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUN SSD DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaSsd();
                        bool okindicessd;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice dell'ssd da eliminare dall'archivio: ");
                            okindicessd = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicessd || indice >= ssds.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                ssds.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t SSD RIMOSSO.");
                                EliminaComponente();
                            }
                        } while (!okindicessd && indice >= ssds.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'E':
                    #region Elimina scheda audio.
                    if (schedeAudio.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA SCHEDA AUDIO DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaSchedaAudio();
                        bool okindiceaudio;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice delle schede audio da eliminare dall'archivio: ");
                            okindiceaudio = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindiceaudio || indice >= schedeAudio.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                schedeAudio.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t SCHEDA AUDIO RIMOSSA.");
                                EliminaComponente();
                            }
                        } while (!okindiceaudio && indice >= schedeAudio.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'M':
                    #region Elimina scehda madre.
                    if (schedeMadri.Count <= 0)
                    {
                        Console.WriteLine("\t\t NESSUNA SCHEDA MADRE DA ELIMINARE.");
                        Thread.Sleep(2000);
                        EliminaComponente();
                    }
                    else
                    {
                        VisualizzaSchedaMadre();
                        bool okindicemadre;
                        int indice;
                        do
                        {
                            // CONTROLLO INIDCE ED ELIMINO COMPONENTI A QUEL DETERMINATO INDICE DELL'UTENTE
                            Console.Write("Inserisci l'indice della scheda madre da eliminare dall'archivio: ");
                            okindicemadre = int.TryParse(Console.ReadLine(), out indice);
                            if (!okindicemadre || indice >= schedeMadri.Count || indice < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ELIMINARE.");
                                Console.ResetColor();
                            }
                            else
                            {
                                schedeMadri.RemoveAt(indice);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t SCHEDA MADRE RIMOSSA.");
                                EliminaComponente();
                            }
                        } while (!okindicemadre && indice >= schedeMadri.Count && indice < 0);
                    }
                    #endregion
                    break;

                case 'X':
                    Menu();
                    break;
            }
        }
        #endregion

        #region Scelta componenti.
        /// <summary>
        /// Scelta dei componenti.
        /// </summary>
        public static void SceltaComponenti()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" Sezione: [S]celta componente\n");
                Console.WriteLine(@"
        - [A]limentatore
        - [C]ase
        - C[p]u
        - [G]pu
        - [R]am
        - [H]dd
        - [S]sd
        - Sch[e]da Audio
        - Scheda [M]adre
        - [X]Torna indietro");

                #region Componenti acquistati.
                if (componenti.Count <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" NON SONO PRESENTI COMPONENTI ACQUISTATI.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" COMPONENTI GIA' IN ARCHIVIO:");
                    foreach (Componente a in componenti)
                        Console.WriteLine(a);
                }
                #endregion

                char ch = ' ';
                do // Legge e controlla l'opzione scelta.
                {
                    ch = Console.ReadKey(true).KeyChar;
                    ch = char.ToUpper(ch);
                }
                while (!((ch == 'A') || (ch == 'C') || (ch == 'P') || (ch == 'G') || (ch == 'R') || (ch == 'H') || (ch == 'S') || (ch == 'E') || (ch == 'M') || (ch == 'X'))); // Controllo scelta.

                switch (ch)
                {
                    case 'A':
                        #region Scegli alimentatore.
                        if (alimentatori.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUN ALIMENTATORE DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaAlimentatori();
                            bool okindiceAli;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice dell'alimentatore da acquistare dall'archivio: ");
                                okindiceAli = int.TryParse(Console.ReadLine(), out indice);
                                if ((!okindiceAli) || (indice >= alimentatori.Count) || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(alimentatori[indice]);
                                    alimentatori.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tALIMENTATORE ACQUISTATO CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                    
                                }
                            } while (!okindiceAli && indice >= alimentatori.Count && indice < 0);
                        }
                        #endregion
                        break;

                    case 'C':
                        #region Scegli case.
                        if (cases.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUN CASE DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaCase();
                            bool okindicecase;
                            int indice; 
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice del case da acquistare dall'archivio: ");
                                okindicecase = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindicecase || (indice >= cases.Count) || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(cases[indice]);
                                    cases.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\t CASE ACQUISTATO CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindicecase && (indice >= cases.Count) && indice < 0);
                        }
                        #endregion
                        break;

                    case 'P':
                        #region Scegli cpu.
                        if (cpus.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUNA CPU DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaCpu();
                            bool okindicecpu;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice della cpu da ascquistare dall'archivio: ");
                                okindicecpu = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindicecpu || (indice >= cpus.Count) || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(cpus[indice]);
                                    cpus.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tCPU ACQUISTATA CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindicecpu && (indice >= cpus.Count) && indice < 0);
                        }
                        #endregion
                        break;

                    case 'G':
                        #region Scegli gpu.
                        if (gpus.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUNA GPU DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaGpu();
                            bool okindicegpu;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice della gpu da acquistare dall'archivio: ");
                                okindicegpu = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindicegpu || (indice >= gpus.Count) || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(gpus[indice]);
                                    gpus.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tGPU ACQUISTATA CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindicegpu && (indice >= gpus.Count) && indice < 0);
                        }
                        #endregion
                        break;

                    case 'R':
                        #region Scegli ram.
                        if (rams.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUNA RAM DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaRam();
                            bool okindiceram;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice della ram da acquistare dall'archivio: ");
                                okindiceram = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindiceram || (indice >= rams.Count) || indice < 0) 
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(rams[indice]);
                                    rams.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tRAM ACQUISTATA CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindiceram && (indice >= rams.Count) && indice < 0);
                        }
                        #endregion
                        break;

                    case 'H':
                        #region Scegli hdd.
                        if (hdds.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUN HDD DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaHdd();
                            bool okindicehdd;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice del'hdd da acquistare dall'archivio: ");
                                okindicehdd = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindicehdd || (indice >= hdds.Count) || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(hdds[indice]);
                                    hdds.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tHDD ACQUISTATO CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindicehdd && (indice >= hdds.Count) && indice < 0);
                        }
                        #endregion
                        break;

                    case 'S':
                        #region Scegli ssd.
                        if (ssds.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUN SSD DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaSsd();
                            bool okindicessd;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice dell'ssd da acquistare dall'archivio: ");
                                okindicessd = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindicessd || indice >= ssds.Count || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(ssds[indice]);
                                    ssds.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tSSD ACQUISTATO CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindicessd && indice >= ssds.Count && indice < 0);
                        }
                        #endregion
                        break;

                    case 'E':
                        #region Scegli scheda audio.
                        if (schedeAudio.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUNA SCHEDA AUDIO DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaSchedaAudio();
                            bool okindiceaudio;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice delle schede audio da acquistare dall'archivio: ");
                                okindiceaudio = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindiceaudio || indice >= schedeAudio.Count || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(schedeAudio[indice]);
                                    schedeAudio.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tSCHEDA AUDIO ACQUISTATA CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindiceaudio && indice >= schedeAudio.Count && indice < 0);
                        }
                        #endregion
                        break;

                    case 'M':
                        #region Scegli scheda madre.
                        if (schedeMadri.Count <= 0)
                        {
                            Console.WriteLine("\t\t NESSUNA SCHEDA MADRE DA ACQUISTARE.");
                            Thread.Sleep(2000);
                            SceltaComponenti();
                        }
                        else
                        {
                            VisualizzaSchedaMadre();
                            bool okindicemadre;
                            int indice;
                            do
                            {
                                // SCELTA COMPONENTE TOLTO DALLA LISTA GENERALE E AGGIUTNO AGLI OGGETTI COMPRATI
                                Console.Write("Inserisci l'indice della scheda madre da acquistare dall'archivio: ");
                                okindicemadre = int.TryParse(Console.ReadLine(), out indice);
                                if (!okindicemadre || indice >= schedeMadri.Count || indice < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t ERRORE NELL'INSERIMENTO DELL'INDICE DELL'ELEMENTO DA ACQUISTARE.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    componenti.Add(schedeMadri[indice]);
                                    schedeMadri.RemoveAt(indice);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tSCHEDA MADRE ACQUISTATA CORRETTAMENTE!");
                                    Console.ResetColor();
                                    Thread.Sleep(1500);
                                    SceltaComponenti();
                                }
                            } while (!okindicemadre && indice >= schedeMadri.Count && indice < 0);
                        }
                        #endregion
                        break;

                    case 'X':
                        Menu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t ERRORE NEL CARICAMENTO DEL FILE PER LETTURA DEI COMPONENTI: " + ex.Message);
                Console.ResetColor();
                Thread.Sleep(2000);
                Menu();
            }
        }
        #endregion

        #region Visualizzazione finale.
        /// <summary>
        /// Visualizzazione dei componenti comprati.
        /// </summary>
        public static void VisualizzaFinale()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t\t VISUALIZZAZIONE FINALE COMPONENTI:\n");
            Console.ResetColor();
            
            #region Alimentatori.
            if (alimentatori.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI ALIMENTATORI NUOVI.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" ALIMENTATORI GIA' IN ARCHIVIO:");
                foreach (Alimentatore a in alimentatori)
                    Console.WriteLine(a);
            }
            #endregion

            #region Cpu.
            if (cpus.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI CPU.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" CPU GIA' IN ARCHIVIO:");
                foreach (Cpu c in cpus)
                    Console.WriteLine(c);
            }
            #endregion

            #region Gpu.
            if (gpus.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI GPU.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" GPU GIA' IN ARCHIVIO:");
                foreach (Gpu x in gpus)
                    Console.WriteLine(x);
            }
            #endregion

            #region Case.
            if (cases.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI CASE.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" CASE GIA' IN ARCHIVIO:");
                foreach (Case x in cases)
                    Console.WriteLine(x);

            }
            #endregion

            #region Hdd.
            if (hdds.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI HDD.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" HDD GIA' IN ARCHIVIO:");
                foreach (Hdd x in hdds)
                    Console.WriteLine(x);
            }
            #endregion

            #region Ssd.
            if (ssds.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI SSD.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" SSD GIA' IN ARCHIVIO:");
                foreach (Ssd x in ssds)
                    Console.WriteLine(x);
            }
            #endregion

            #region Ram.
            if (rams.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI RAM.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" RAM GIA' IN ARCHIVIO:");
                foreach (Ram x in rams)
                    Console.WriteLine(x);
            }
            #endregion

            #region Schede audio.
            if (schedeAudio.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI SCHEDE AUDIO.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" SCHEDE AUDIO GIA' IN ARCHIVIO:");
                foreach (SchedaAudio x in schedeAudio)
                    Console.WriteLine(x);
            }
            #endregion

            #region Schede madri.
            if (schedeMadri.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" NON SONO PRESENTI SCHEDE MADRI.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" SCHEDE MADRI GIA' IN ARCHIVIO:");
                foreach (SchedaMadre x in schedeMadri)
                    Console.WriteLine(x);
            }
            #endregion
            
        }
        #endregion

        #region Esci.
        /// <summary>
        /// Salvataggio e uscita.
        /// </summary>
        public static void Esci()
        {
            try
            {
                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls1 = new XmlSerializer(typeof(List<Alimentatore>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\alimentatori.xml"))
                {
                    xmls1.Serialize(tw, alimentatori);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls2 = new XmlSerializer(typeof(List<Case>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\case.xml"))
                {
                    xmls2.Serialize(tw, cases);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls3 = new XmlSerializer(typeof(List<Cpu>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\cpu.xml"))
                {
                    xmls3.Serialize(tw, cpus);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls4 = new XmlSerializer(typeof(List<Gpu>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\gpu.xml"))
                {
                    xmls4.Serialize(tw, gpus);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls5 = new XmlSerializer(typeof(List<Hdd>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\hdd.xml"))
                {
                    xmls5.Serialize(tw, hdds);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls6 = new XmlSerializer(typeof(List<Ram>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\ram.xml"))
                {
                    xmls6.Serialize(tw, rams);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls7 = new XmlSerializer(typeof(List<SchedaAudio>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\schedaAudio.xml"))
                {
                    xmls7.Serialize(tw, schedeAudio);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls8 = new XmlSerializer(typeof(List<SchedaMadre>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\schedaMadre.xml"))
                {
                    xmls8.Serialize(tw, schedeMadri);
                }

                // Serializzazione OGGETTO → FILE.
                XmlSerializer xmls9 = new XmlSerializer(typeof(List<Ssd>));
                using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\ssd.xml"))
                {
                    xmls9.Serialize(tw, ssds);
                }

                // Serializzazione OGGETTO → FILE.
                //XmlSerializer xmls10 = new XmlSerializer(typeof(List<Componente>));
                //using (TextWriter tw = new StreamWriter(@"..\..\xmlproducts\componenti.xml"))
                //{
                //    xmls10.Serialize(tw, componenti);
                //}

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t\t TUTTI I COMPONENTI SONO STATI SALVATI CORRETTAMENTE!");
                Thread.Sleep(2000);

                Environment.Exit(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\t\t ERRORE NEL CARICAMENTO DEL FILE PER LETTURA DEI COMPONENTI: " + ex.Message);
                return;
            }
        }
        #endregion

        #region Visualizza ogni singolo componente.
        #region Visualizza alimentatori.
        /// <summary>
        /// vISUALIZZA ALIMENTATORI
        /// </summary>
        public static void VisualizzaAlimentatori()
        {
            Console.WriteLine("\t ALIMENTATORI:\n");
            for (int i = 0; i < alimentatori.Count; i++) Console.WriteLine("{0}° - Alimentatore:{1}\n", i, alimentatori[i].ToString());
        }
        #endregion

        #region Visualizza case.
        /// <summary>
        /// vISUALIZZA CASE
        /// </summary>
        public static void VisualizzaCase()
        {
            Console.WriteLine("\t CASE:\n");
            for (int i = 0; i < cases.Count; i++) Console.WriteLine("{0} - Case:{1}\n", i, cases[i].ToString());
        }
        #endregion

        #region Visualizza cpu.
        /// <summary>
        /// vISUALIZZA CPU
        /// </summary>
        public static void VisualizzaCpu()
        {
            Console.WriteLine("\t CPU:\n");
            for (int i = 0; i < cpus.Count; i++) Console.WriteLine("{0} - Cpu:{1}\n", i, cpus[i].ToString());
        }
        #endregion

        #region Visualizza gpu.
        /// <summary>
        /// vISUALIZZA GPU
        /// </summary>
        public static void VisualizzaGpu()
        {
            Console.WriteLine("\t GPU:\n");
            for (int i = 0; i < gpus.Count; i++) Console.WriteLine("{0} - Gpu:{1}\n", i, gpus[i].ToString());
        }
        #endregion

        #region Visualizza hdd.
        /// <summary>
        /// vISUALIZZA HDD
        /// </summary>
        public static void VisualizzaHdd()
        {
            Console.WriteLine("\t HDD:\n");
            for (int i = 0; i < hdds.Count; i++) Console.WriteLine("{0} - hdd:{1}\n", i, hdds[i].ToString());
        }
        #endregion

        #region Visualizza ram.
        /// <summary>
        /// vISUALIZZA RAM
        /// </summary>
        public static void VisualizzaRam()
        {
            Console.WriteLine("\t RAM:\n");
            for (int i = 0; i < rams.Count; i++) Console.WriteLine("{0} - Ram:{1}\n", i, rams[i].ToString());
        }
        #endregion

        #region Visualizza scheda audio.
        /// <summary>
        /// vISUALIZZA SCHEDA AUDIO
        /// </summary>
        public static void VisualizzaSchedaAudio()
        {
            Console.WriteLine("\t SCHEDE AUDIO:\n");
            for (int i = 0; i < schedeAudio.Count; i++) Console.WriteLine("{0} - Scheda audio:{1}\n", i, schedeAudio[i].ToString());
        }
        #endregion

        #region Visualizza scheda madre.
        /// <summary>
        /// vISUALIZZA SCHEDA MADRE
        /// </summary>
        public static void VisualizzaSchedaMadre()
        {
            Console.WriteLine("\t SCHEDE MADRI:\n");
            for (int i = 0; i < schedeMadri.Count; i++) Console.WriteLine("{0} - Scheda madre:{1}\n", i, schedeMadri[i].ToString());
        }
        #endregion

        #region Visualizza ssd.
        /// <summary>
        /// vISUALIZZA SSD
        /// </summary>
        public static void VisualizzaSsd()
        {
            Console.WriteLine("\t SSD:\n");
            for (int i = 0; i < ssds.Count; i++) Console.WriteLine("{0} - Ssd:{1}\n", i, ssds[i].ToString());
        }
        #endregion
        #endregion


    }
}
