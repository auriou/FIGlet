using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIGlet.Net;

namespace FIGlet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClient.TestUsage();
            var value = "";
            var fig = new Figlet();
            fig.PrepareAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.");
            while (value.ToLower() != "quit")
            {
                System.Console.Write("Enter text to be converted (Quit for exit) :");
                value = System.Console.ReadLine();
                var asciiart = fig.ToAsciiArt(value);
                System.Console.WriteLine(asciiart);

                var reconize = fig.ReconizeAsciiArt(asciiart);
                System.Console.WriteLine("OCR-ArtASCII: {0}", reconize);
            }
        }
    }
}
