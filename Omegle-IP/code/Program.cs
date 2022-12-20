using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace OmegleIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string version = "1.0";

            Console.Title = $"Omegle IP Grabber [v{version}]";

            bool confirmed = false;
            string userInput;

            string apiKey = "apiKey";
            string apiKeyCode = $"let apiKey = \"APIKEY\";";

            WebClient webClient = new WebClient();
            string asciiArt = webClient.DownloadString("https://raw.githubusercontent.com/ImEonXD/Omegle-IP/main/Omegle-IP/art.txt");
            string codeJS = webClient.DownloadString("https://raw.githubusercontent.com/ImEonXD/Omegle-IP/main/Omegle-IP/code/mainCode.js");

            string rootPath = Directory.GetCurrentDirectory();
            string codeFileRoot = Path.Combine(rootPath, "code.txt");

            Console.Write($"{asciiArt}");
            Console.WriteLine();
            Console.WriteLine("Welcome to Omegle IP Grabber!");
            Console.WriteLine("Created by ImEon - github.com/ImEonXD");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");

            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("You will need to open IPGeolocation and enter your API key.");
            Console.WriteLine("Would you like to open it now? [Y/N]");

            while (confirmed == false)
            {
                userInput = Console.ReadLine();

                if (userInput == "Y" || userInput == "y")
                {
                    Process.Start("https://ipgeolocation.io/");
                    confirmed = true;
                }
                else if (userInput == "N" || userInput == "n")
                {
                    confirmed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid answer.");
                    confirmed = false;
                }
            }
            Console.WriteLine();
            Console.Write("Enter your API key: ");
            userInput = Console.ReadLine();
            apiKey = userInput;

            confirmed = false;
            Console.WriteLine();
            Console.WriteLine("Is your API key correct? (No spaces, etc.) [Y/N]");
            Console.WriteLine($"API key entered: [{apiKey}]");

            while (confirmed == false)
            {
                userInput = Console.ReadLine();

                if (userInput == "Y" || userInput == "y")
                {
                    confirmed = true;
                }
                else if (userInput == "N" || userInput == "n")
                {
                    confirmed = true;

                    Console.WriteLine();
                    Console.WriteLine("MAKE SURE YOU ENTER THE CORRECT API KEY, YOU CANNOT CHANGE IT AFTER THIS");
                    Console.Write("Enter your API key: ");
                    userInput = Console.ReadLine();
                    apiKey = userInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid answer.");
                    confirmed = false;
                }
            }

            apiKeyCode = $"let apiKey = \"{apiKey}\";";

            string[] lines =
            {
            $"{apiKeyCode}", "", $"{codeJS}"
            };

            File.WriteAllLines(codeFileRoot, lines);

            Process.Start(codeFileRoot);

            Console.WriteLine();
            Console.WriteLine("The code should have opened in another window, if it did not, it can be found in \"code.txt\" next to this EXE.");
            Console.WriteLine();
            Console.WriteLine("1. Open Omegle and start searching.");
            Console.WriteLine("2. Open Google Chrome console by pressing CTRL + Shift + I and select \"Console\" at the top.");
            Console.WriteLine("3. Copy and paste the code into the console and press Enter.");
            Console.WriteLine();
            Console.WriteLine("Note: It will not show until the next stranger.");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
