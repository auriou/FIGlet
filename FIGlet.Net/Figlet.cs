using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FIGlet.Net
{
    public class Figlet
    {
        private Dictionary<char, string[]> _alphabet;
        private FigletFont _font;

        public Figlet()
        {
            _font = new FigletFont();
        }

        public void LoadFont(string flfFontFile)
        {
            _font = new FigletFont(flfFontFile);
        }

        public string ToAsciiArt(string strText)
        {
            var res = "";
            for (int i = 1; i <= _font.Height; i++)
            {
                foreach (var car in strText)
                {
                    res += this.GetCharacter(car, i);
                }
                res += Environment.NewLine;
            }
            return res;
        }
        public string GetCharacter(char car, int line)
        {
            var start = _font.CommentLines + ((Convert.ToInt32(car) - 32) * _font.Height);
            var temp = _font.Lines[start + line];
            var lineending = temp[temp.Length - 1];
            var rx = new Regex(@"\" + lineending + "{1,2}$");
            temp = rx.Replace(temp, "");
            return temp.Replace(_font.HardBlank, " ");
        }
        public void PrepareAlphabet(string chaine)
        {
            _alphabet = new Dictionary<char, string[]>();
            foreach (var car in chaine)
            {
                var res = "";
                for (int i = 1; i <= _font.Height; i++)
                {
                    res += this.GetCharacter(car, i) + Environment.NewLine;
                }
                _alphabet.Add(car, res.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            }
        }
        public string RecognizeAsciiArt(string asciiArt)
        {
            var chaine = asciiArt.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (chaine.Length < 1)
                return "";
            var maxChaine = chaine[0].Length;
            var posi = 0;
            var res = "";
            while (posi < maxChaine)
            {
                var newposi = posi;
                foreach (var alpha in _alphabet)
                {
                    var decal = chaine.StartIndexOf(alpha.Value, posi, 1);
                    if (decal > 0)//trouvé
                    {
                        newposi = decal;
                        res += alpha.Key;
                        break;
                    }
                }
                if (newposi == posi)
                {
                    if (newposi < maxChaine)
                    {
                        newposi += 1;
                        res += " ";
                    }//non trouvé
                }
                posi = newposi;
            }
            return res;
        }
    }
}