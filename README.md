FIGlet
======

library write in C# for generating Ascii-Art text and recognize this characters. 

example:


 __  __  _                                  __  _       _   _        _
|  \/  |(_)  ___  _ __   ___   ___   ___   / _|| |_    | \ | |  ___ | |_
| |\/| || | / __|| '__| / _ \ / __| / _ \ | |_ | __|   |  \| | / _ \| __|
| |  | || || (__ | |   | (_) |\__ \| (_) ||  _|| |_  _ | |\  ||  __/| |_
|_|  |_||_| \___||_|    \___/ |___/ \___/ |_|   \__|(_)|_| \_| \___| \__|


OCR-ArtASCII: Microsoft.Net


Code :

            var fig = new Figlet();
            //Load specific font (Figlet format)
            //fig.LoadFont(@"D:\FIGLET\FONTS\standard.flf");
            //Generate ASCII-Art Text
            var asciiart = fig.ToAsciiArt("Microsoft.Net");
            Console.WriteLine(asciiart);


            //Prepare alphabet for reconize 
            fig.PrepareAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.");
            //Reconize Ascii-Art
            var reconize = fig.ReconizeAsciiArt(asciiart);
            Console.WriteLine("OCR-ArtASCII: {0}", reconize);
            Console.ReadLine();
