using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;


namespace Gideon
{
    class Program
    {
        private static CultureInfo ci = new CultureInfo("en-us");

        private static SpeechSynthesizer synth = new SpeechSynthesizer();

        private static SpeechRecognitionEngine rec = new SpeechRecognitionEngine(ci);

        static void Main(string[] args)
        {

            #region Speech Rec

            //speech recognition

            Choices commands = new Choices();
            commands.Add(new string[] { "Help", "CPU", "Memory", "Disk", "Open", "Internet Explorer", "Firefox", "Notepad", "Calculator", "Time", "Name", "Thanks", "Thank you", "Exit", "Voice Stop", "Version"});
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);
            rec.LoadGrammarAsync(grammar);
            rec.SetInputToDefaultAudioDevice();
            rec.SpeechRecognized += Rec_SpeechRecognized;

            #endregion

            #region Randomizer

            //list of responses

            List<string> thankyouReplyMessages = new List<string>();
            thankyouReplyMessages.Add("You are welcome!");
            thankyouReplyMessages.Add("Any time!");
            thankyouReplyMessages.Add("I am here to help!");
            thankyouReplyMessages.Add("That's why I am here!");
            thankyouReplyMessages.Add("No worries!");

            //random object

            Random rand = new Random();

            #endregion

            #region Initialisation

            //start of program

            Console.WriteLine("Initialising.");
            string initialiseVocalMessage = String.Format("Initialising.");
            GideonVoice(initialiseVocalMessage, VoiceGender.Female, 2);
            Console.WriteLine("Welcome back! How are you today?");
            string welcomeVocalMessage = String.Format("Welcome back! How are you today?");
            GideonVoice(welcomeVocalMessage, VoiceGender.Female, 2);                       
            Console.WriteLine("Type Help to see a list of commands you can use.");
            string introduction1VocalMessage = String.Format("Type Help to see a list of commands you can use.");
            GideonVoice(introduction1VocalMessage, VoiceGender.Female, 2);
            Console.WriteLine("You can turn on vocal commands by typing the command Voice.");
            string introduction2VocalMessage = String.Format("You can turn on vocal commands by typing the command Voice.");
            GideonVoice(introduction2VocalMessage, VoiceGender.Female, 2);
            Console.WriteLine();

            #endregion

            #region Performance Counters 

            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
            perfCpuCount.NextValue();

            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
            perfMemCount.NextValue();

            //in seconds
            PerformanceCounter perfTimeCount = new PerformanceCounter("System", "System Up Time");
            perfTimeCount.NextValue();

            PerformanceCounter perfDiskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total");
            perfDiskCounter.NextValue();

            #endregion

            #region Commands
            string line = Console.ReadLine();
            while (true)
            {

                #region Convertors

                int currentCpuLoad = (int)perfCpuCount.NextValue();
                int currentMemAvailable = (int)perfMemCount.NextValue();
                int currentDiskLoad = (int)perfDiskCounter.NextValue();

                #endregion

                //processes

                Process notepad = new Process();
                notepad.StartInfo.FileName = "notepad.exe";

                Process calc = new Process();
                calc.StartInfo.FileName = "calc.exe";

                Process chrome = new Process();
                chrome.StartInfo.FileName = "chrome.exe";

                Process iexplorer = new Process();
                iexplorer.StartInfo.FileName = "iexplore.exe";

                Process firefox = new Process();
                firefox.StartInfo.FileName = "firefox.exe";

                //help commands

                if (line == "Help" || line == "help")
                {
                    Console.WriteLine("Available commands are Voice, Voice Stop, CPU, Memory, Disk, Start Alerts, Open, Name, Time.");
                    string helpVocalMessage = String.Format("Available commands are Voice, Voice Stop, CPU, Memory, Disk, Start Alerts, Open, Name, Time.");
                    GideonVoice(helpVocalMessage, VoiceGender.Female, 2);
                    Console.WriteLine("You can exit the program by typing Exit.");
                    string exitVocalMessage = String.Format("You can exit the program by typing Exit.");
                    GideonVoice(exitVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //version

                if (line == "Version" || line == "version")
                {
                    Console.WriteLine("I am currently running version v1.0");
                    string versionVocalMessage = String.Format("I am currently running version one point oh.");
                    GideonVoice(versionVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //voice recognition enable

                if (line == "Voice" || line == "voice")
                {
                    rec.RecognizeAsync(RecognizeMode.Multiple);
                    Console.WriteLine("Vocal commands have been turned on.");
                    string onVocalMessage = String.Format("Vocal commands have been turned on.");
                    GideonVoice(onVocalMessage, VoiceGender.Female, 2);
                    Console.WriteLine("They can be turned off using the command Voice Stop.");
                    string stopVocalMessage = String.Format("They can be turned off using the command Voice Stop.");
                    GideonVoice(stopVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                // stops voice recognition

                if (line == "Voice Stop" || line == "voice stop")
                {
                    rec.RecognizeAsyncStop();
                    Console.WriteLine("Vocal commands are now off.");
                    string offVocalMessage = String.Format("Vocal commands are now off.");
                    GideonVoice(offVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //cpu status

                if (line == "CPU" || line == "cpu")
                {
                    
                    Console.WriteLine("CPU Load: {0}%", currentCpuLoad);
                    string cpuLoadVocalMessage = String.Format("The current CPU load is {0} percent", currentCpuLoad);
                    GideonVoice(cpuLoadVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //memory status

                if (line == "Memory" || line == "memory")
                {
                    
                    Console.WriteLine("Available Memory: {0}MB", currentMemAvailable);
                    string memAvailableVocalMessage = String.Format("The available memory is at {0} megabytes", currentMemAvailable);
                    GideonVoice(memAvailableVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                if (line == "Disk" || line == "disk")
                {
                    Console.WriteLine("Disk Free Space: {0}%", currentDiskLoad);
                    string diskLoadVocalMessage = String.Format("The current disk free space is {0} percent", currentDiskLoad);
                    GideonVoice(diskLoadVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //starting alerts

                if (line == "Start Alerts" || line == "start alerts")
                {
                    Console.WriteLine("Input the number of tests you want to make.");
                    string alertStartMessage = String.Format("Input the number of tests you want to make.");
                    GideonVoice(alertStartMessage, VoiceGender.Female, 2);
                    int x;
                    line = Console.ReadLine();
                    x = Convert.ToInt32(line);


                    for (int i = 1; i <= x; i++)
                    {
                        int alertCpuLoad = (int)perfCpuCount.NextValue();
                        int alertMemAvailable = (int)perfMemCount.NextValue();

                        Thread.Sleep(100);
                        
                        //cpu alerts

                        if (alertCpuLoad > 90)
                        {
                            if (alertCpuLoad == 100)
                            {
                                string cpuWarningMessage = String.Format("WARNING: CPU has reached maximum load.");
                                GideonVoice(cpuWarningMessage, VoiceGender.Female, 2);

                            }
                            else
                            {
                                string cpuWarningMessage = String.Format("CPU load reaching critical values.");
                                GideonVoice(cpuWarningMessage, VoiceGender.Female, 2);

                            }
                        }

                        //memory alert

                        if (alertMemAvailable < 1024)
                        {
                            string memWarningMessage = String.Format("Available memory running low");
                            GideonVoice(memWarningMessage, VoiceGender.Female, 2);

                        }

                    }

                    line = Console.ReadLine();
                 }

                //start process

                if (line == "Open" || line == "open")
                {
                    Console.WriteLine("Choose what program to start: Chrome, Internet Explorer, Firefox, Notepad, Calculator");
                    string programStartMessage = String.Format("Choose what program to start: Chrome, Internet Explorer, Firefox, Notepad, Calculator");
                    GideonVoice(programStartMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();

                    //chrome

                    if (line == "Chrome" || line == "chrome")
                    {
                        Console.WriteLine("Do you have a certain URL?");
                        string certainInputMessage = String.Format("Do you have a certain URL?");
                        GideonVoice(certainInputMessage, VoiceGender.Female, 2);
                        line = Console.ReadLine();
                        
                        if (line == "Yes" || line == "yes")
                        {
                            Console.WriteLine("Input a URL");
                            string urlInputMessage = String.Format("Input a URL");
                            GideonVoice(urlInputMessage, VoiceGender.Female, 2);
                            line = Console.ReadLine();
                            OpenWebsiteChrome(line);
                            line = Console.ReadLine();
                        }

                        if (line == "No" || line == "no")
                        {
                            chrome.Start();
                            line = Console.ReadLine();
                        }

                        
                    }

                    //ie

                    if (line == "Internet Explorer" || line == "internet explorer")
                    {
                        Console.WriteLine("Do you have a certain URL?");
                        string certainInputMessage = String.Format("Do you have a certain URL?");
                        GideonVoice(certainInputMessage, VoiceGender.Female, 2);
                        line = Console.ReadLine();

                        if (line == "Yes" || line == "yes")
                        {
                            Console.WriteLine("Input a URL");
                            string urlInputMessage = String.Format("Input a URL");
                            GideonVoice(urlInputMessage, VoiceGender.Female, 2);
                            line = Console.ReadLine();
                            OpenWebsiteIE(line);
                            line = Console.ReadLine();
                        }

                        if (line == "No" || line == "no")
                        {
                            iexplorer.Start();
                            line = Console.ReadLine();
                        }
                    }

                    //firefox

                    if (line == "Firefox" || line == "firefox")
                    {
                        Console.WriteLine("Do you have a certain URL?");
                        string certainInputMessage = String.Format("Do you have a certain URL?");
                        GideonVoice(certainInputMessage, VoiceGender.Female, 2);
                        line = Console.ReadLine();

                        if (line == "Yes" || line == "yes")
                        {
                            Console.WriteLine("Input a URL");
                            string urlInputMessage = String.Format("Input a URL");
                            GideonVoice(urlInputMessage, VoiceGender.Female, 2);
                            line = Console.ReadLine();
                            OpenWebsiteFirefox(line);
                            line = Console.ReadLine();
                        }

                        if (line == "No" || line == "no")
                        {
                            firefox.Start();
                            line = Console.ReadLine();
                        }
                    }

                    //notepad

                    if (line == "Notepad" || line == "notepad")
                    {
                        notepad.Start();
                        line = Console.ReadLine();
                    }

                    //calc

                    if (line == "Calculator" || line == "calculator")
                    {
                        calc.Start();
                        line = Console.ReadLine();
                    }
                }

                //system uptime

                if (line == "Time" || line == "time")
                {
                    TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfTimeCount.NextValue());
                    Console.WriteLine("The current system up time is {0} days {1} hours {2} minutes {3} seconds.",
                        (int)uptimeSpan.TotalDays,
                        (int)uptimeSpan.Hours,
                        (int)uptimeSpan.Minutes,
                        (int)uptimeSpan.Seconds);
                    string systemUptimeMessage = String.Format("The current system up time is {0} days {1} hours {2} minutes {3} seconds.",
                        (int)uptimeSpan.TotalDays,
                        (int)uptimeSpan.Hours,
                        (int)uptimeSpan.Minutes,
                        (int)uptimeSpan.Seconds);
                    GideonVoice(systemUptimeMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //app presentation

                if (line == "Name" || line == "name")
                {
                    Console.WriteLine("My name is Gideon and I am a personal assistant. I can display information about your PC and help you manage apps easily.");
                    string nameVocalMessage = String.Format("My name is Gideon and I am a personal assistant. I can display information about your PC and help you manage apps easily.");
                    GideonVoice(nameVocalMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //informal reply

                if (line == "Thanks" || line == "thanks")
                {
                    string reply = thankyouReplyMessages[rand.Next(5)];
                    Console.WriteLine(reply);
                    string welcomeReplyMessage = reply;
                    GideonVoice(welcomeReplyMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //formal reply

                if (line == "Thank you" || line == "thank you")
                {
                    string reply = thankyouReplyMessages[rand.Next(5)];
                    Console.WriteLine(reply);
                    string welcomeReplyMessage = reply;
                    GideonVoice(welcomeReplyMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

                //closing the app

                if (line == "Exit" || line == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    string goodbyeVocalMessage = String.Format("Goodbye!");
                    GideonVoice(goodbyeVocalMessage, VoiceGender.Female, 2);
                    break;
                }

                //invalid command introduced

                if (line != "Help" && line != "CPU" && line != "Memory" && line != "Disk" && line != "Start Alerts" && line != "Open" && line != "Time" && line != "Thanks" && line != "Thank you" && line != "Exit" && line != "Voice" && line != "Voice Stop" && line != "help" && line != "cpu" && line != "memory" && line != "disk" && line != "start alerts" && line != "open" && line != "time" && line != "thanks" && line != "thank you" && line != "exit" && line != "voice" && line != "voice stop")
                {
                    Console.WriteLine("That is not a valid command.");
                    string invalidCommandMessage = String.Format("That is not a valid command.");
                    GideonVoice(invalidCommandMessage, VoiceGender.Female, 2);
                    line = Console.ReadLine();
                }

            }
            #endregion

        }

        #region Functions

        //voice recognized

        public static void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            #region Performance Counters 

            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            perfCpuCount.NextValue();

            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
            perfMemCount.NextValue();

            //in seconds
            PerformanceCounter perfTimeCount = new PerformanceCounter("System", "System Up Time");
            perfTimeCount.NextValue();

            PerformanceCounter perfDiskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total");
            perfDiskCounter.NextValue();

            #endregion

            Thread.Sleep(100);

            #region Converters

            int currentCpuLoad = (int)perfCpuCount.NextValue();
            int currentMemAvailable = (int)perfMemCount.NextValue();
            int currentDiskLoad = (int)perfDiskCounter.NextValue();

            #endregion

           

            #region Processes

            Process notepad = new Process();
            notepad.StartInfo.FileName = "notepad.exe";

            Process calc = new Process();
            calc.StartInfo.FileName = "calc.exe";

            Process chrome = new Process();
            chrome.StartInfo.FileName = "chrome.exe";

            Process iexplorer = new Process();
            iexplorer.StartInfo.FileName = "iexplore.exe";

            Process firefox = new Process();
            firefox.StartInfo.FileName = "firefox.exe";

            #endregion

            //list of responses

            List<string> thankyouReplyMessages = new List<string>();
            thankyouReplyMessages.Add("You are welcome!");
            thankyouReplyMessages.Add("Any time!");
            thankyouReplyMessages.Add("I am here to help!");
            thankyouReplyMessages.Add("That's why I am here!");
            thankyouReplyMessages.Add("No worries!");

            //random object

            Random rand = new Random();

            switch (e.Result.Text)
            {
                case "Help":
                    Console.WriteLine("Available commands are Voice Stop, CPU, Memory, Disk, Open Chrome, Open Internet Explorer, Open Firefox, Open Notepad, Open Calculator, Name, Time.");
                    string helpVocalMessage = String.Format("Available commands are Voice Stop, CPU, Memory, Disk, Open Chrome, Open Internet Explorer, Open Firefox, Open Notepad, Open Calculator, Name, Time.");
                    GideonVoice(helpVocalMessage, VoiceGender.Female, 2);
                    Console.WriteLine("You can exit the program by saying Exit.");
                    string exitVocalMessage = String.Format("You can exit the program by saying Exit.");
                    GideonVoice(exitVocalMessage, VoiceGender.Female, 2);
                    break;
                case "Version":
                    Console.WriteLine("I am currently running version v1.0");
                    string versionVocalMessage = String.Format("I am currently running version one point oh.");
                    GideonVoice(versionVocalMessage, VoiceGender.Female, 2);
                    break;
                case "CPU":
                    Console.WriteLine("CPU Load: {0}%", currentCpuLoad);
                    string cpuLoadVocalMessage = String.Format("The current CPU load is {0} percent", currentCpuLoad);
                    GideonVoice(cpuLoadVocalMessage, VoiceGender.Female, 2);
                    break;
                case "Memory":
                    Console.WriteLine("Available Memory: {0}MB", currentMemAvailable);
                    string memAvailableVocalMessage = String.Format("The available memory is at {0} megabytes", currentMemAvailable);
                    GideonVoice(memAvailableVocalMessage, VoiceGender.Female, 2);
                    break;
                case "Disk":
                    Console.WriteLine("Disk Free Space: {0}%", currentDiskLoad);
                    string diskLoadVocalMessage = String.Format("The current disk free space is {0} percent", currentDiskLoad);
                    GideonVoice(diskLoadVocalMessage, VoiceGender.Female, 2);
                    break;
                case "Open":
                    Console.WriteLine("Choose what program to start: Chrome, Internet Explorer, Firefox, Notepad, Calculator");
                    string programStartMessage = String.Format("Choose what program to start: Chrome, Internet Explorer, Firefox, Notepad, Calculator");
                    GideonVoice(programStartMessage, VoiceGender.Female, 2);
                    break;
                case "Chrome":
                    chrome.Start();
                    break;
                case "Internet Explorer":
                    iexplorer.Start();
                    break;
                case "Firefox":
                    firefox.Start();
                    break;
                case "Notepad":
                    notepad.Start();
                    break;
                case "Calculator":
                    calc.Start();
                    break;                           
                case "Time":
                    TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfTimeCount.NextValue());
                    Console.WriteLine("The current system up time is {0} days {1} hours {2} minutes {3} seconds.",
                        (int)uptimeSpan.TotalDays,
                        (int)uptimeSpan.Hours,
                        (int)uptimeSpan.Minutes,
                        (int)uptimeSpan.Seconds);
                    string systemUptimeMessage = String.Format("The current system up time is {0} days {1} hours {2} minutes {3} seconds.",
                        (int)uptimeSpan.TotalDays,
                        (int)uptimeSpan.Hours,
                        (int)uptimeSpan.Minutes,
                        (int)uptimeSpan.Seconds);
                    GideonVoice(systemUptimeMessage, VoiceGender.Female, 2);
                    break;
                case "Name":
                    Console.WriteLine("My name is Gideon and I am a personal assistant.");
                    string nameVocalMessage = String.Format("My name is Gidion and I am a personal assistant.");
                    GideonVoice(nameVocalMessage, VoiceGender.Female, 2);
                    break;
                case "Thanks":
                    string replyinf = thankyouReplyMessages[rand.Next(5)];
                    Console.WriteLine(replyinf);
                    string infwelcomeReplyMessage = replyinf;
                    GideonVoice(infwelcomeReplyMessage, VoiceGender.Female, 2);
                    break;
                case "Thank you":
                    string replyform = thankyouReplyMessages[rand.Next(5)];
                    Console.WriteLine(replyform);
                    string formwelcomeReplyMessage = replyform;
                    GideonVoice(formwelcomeReplyMessage, VoiceGender.Female, 2);
                    break;
                case "Exit":
                    Console.WriteLine("Goodbye!");
                    string goodbyeVocalMessage = String.Format("Goodbye!");
                    GideonVoice(goodbyeVocalMessage, VoiceGender.Female, 2);
                    Environment.Exit(0);                   
                    break;
                case "Voice Stop":
                    rec.RecognizeAsyncStop();
                    Console.WriteLine("Vocal commands are now off.");
                    string offVocalMessage = String.Format("Vocal commands are now off.");
                    GideonVoice(offVocalMessage, VoiceGender.Female, 2);
                    break;
            }
                            
            }

        
        //custom voice api

        public static void GideonVoice(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(voiceGender);
            synth.Speak(message);
        }

        //custom voice api with rate

        public static void GideonVoice(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            GideonVoice(message, voiceGender);
        }

        //open chrome with url

        public static void OpenWebsiteChrome(string URL)
        {
            Process chrome = new Process();
            chrome.StartInfo.FileName = "chrome.exe";
            chrome.StartInfo.Arguments = URL;
            chrome.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            chrome.Start();
        }

        //open internet explorer with url

        public static void OpenWebsiteIE(string URL)
        {
            Process iexplorer = new Process();
            iexplorer.StartInfo.FileName = "iexplore.exe";
            iexplorer.StartInfo.Arguments = URL;
            iexplorer.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            iexplorer.Start();
        }

        //open firefox with url

        public static void OpenWebsiteFirefox(string URL)
        {
            Process firefox = new Process();
            firefox.StartInfo.FileName = "firefox.exe";
            firefox.StartInfo.Arguments = URL;
            firefox.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            firefox.Start();
        }
      
        #endregion
    }
}
