using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace Spotify_Adblocker
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Simple Spotify AdBlocker - made by rubby");
            Console.WriteLine("Detecting spotify installs..");
            string spotifyPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\";
            bool isInstalled = Directory.Exists(spotifyPath);
            if (isInstalled)
            {
                string config = File.ReadAllText(spotifyPath + "crash_reporter.cfg");
                if (config.Contains("ProductVersion=1.0.96.181")) //easiest way to check, im lazy to think of something else
                {
                    Console.WriteLine("You have spotify installed and you're using the correct version. Applying hosts..");
                    string hostsLoc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
                    string hosts = new WebClient().DownloadString("https://raw.githubusercontent.com/rubby-c/text-stuff/main/spotify-hosts");
                    File.WriteAllText(hostsLoc, hosts);
                    Console.WriteLine("Done! You can now close the program. Enjoy your ad-free music!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You have spotify installed but you're using a newer version that the hosts trick doesn't work on.");
                    Console.WriteLine("Do you want to download a working older version (1.0.96.181)? [y] [n] (I've got a mega.nz link!)");
                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.Y:
                            Process.Start("https://mega.nz/file/NURTVIQC#yTw7rAbjxREEFmTHZdufO0ZrSsAN82fDq3Ry8ZzJRjw");
                            Console.WriteLine("\r\nUninstall your old spotify version, download this one and install it, then re-launch this app.");
                            Console.ReadLine();
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("\r\nOkay then.");
                            Thread.Sleep(2000);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Looks like you don't have spotify installed. The new versions patched this method so you gotta get an old one (1.0.96.181).");
                Console.WriteLine("Do you want to download it (64 MB)? [y] [n] (I've got a mega.nz link!)");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        Process.Start("https://mega.nz/file/NURTVIQC#yTw7rAbjxREEFmTHZdufO0ZrSsAN82fDq3Ry8ZzJRjw");
                        Console.WriteLine("\r\nDownload this version and install it, then re-launch this app.");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("\r\nOkay then.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}
