using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIGlet.Net
{
    public class SampleClient
    {
        public static void TestUsage()
        { 
            var fig = new Figlet();
            //Chargement d'une font spécifique au format Figlet
            //fig.LoadFont(@"D:\FIGLET\FONTS\standard.flf");
            //Génération et affichage du texte  Art ASCII
            var asciiart = fig.ToAsciiArt("Microsoft.Net");
            Console.WriteLine(asciiart);


            //Préparation d'un alphabet pour la reconnaissance de l'image Art ASCII
            fig.PrepareAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.");
            //Reconnaissance de l'image et affichage du texte résultaant
            var recognize = fig.RecognizeAsciiArt(asciiart);
            Console.WriteLine("OCR-ArtASCII: {0}", recognize);
        }
    }
}
