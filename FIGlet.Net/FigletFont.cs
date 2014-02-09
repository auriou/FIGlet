using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FIGlet.Net
{
    public class FigletFont
    {
        public string Signature { get; private set; }
        public string HardBlank { get; private set; }
        public int Height { get; private set; }
        public int BaseLine { get; private set; }
        public int MaxLenght { get; private set; }
        public int OldLayout { get; private set; }
        public int CommentLines { get; private set; }
        public int PrintDirection { get; private set; }
        public int FullLayout { get; set; }
        public int CodeTagCount { get; set; }
        public List<string> Lines { get; set; }

        public FigletFont(string flfFontFile)
        {
            LoadFont(flfFontFile);
        }

        public FigletFont()
        {
            LoadFont();
        }

        private void LoadLines(List<string> fontLines)
        {
            Lines = fontLines;
            var configString = Lines.First();
            var configArray = configString.Split(' ');
            Signature = configArray.First().Remove(configArray.First().Length - 1);
            if (Signature == "flf2a")
            {
                HardBlank = configArray.First().Last().ToString();
                Height = configArray.GetIntValue(1);
                BaseLine = configArray.GetIntValue(2);
                MaxLenght = configArray.GetIntValue(3);
                OldLayout = configArray.GetIntValue(4);
                CommentLines = configArray.GetIntValue(5);
                PrintDirection = configArray.GetIntValue(6);
                FullLayout = configArray.GetIntValue(7);
                CodeTagCount = configArray.GetIntValue(8);
            }
        }

        private void LoadFont()
        {
            using (var stream = this.GetResourceStream("FIGlet.Net.Fonts.standard.flf"))
            {
                LoadFont(stream);
            }
        }

        private void LoadFont(string flfFontFile)
        {
            using (var fso = File.Open(flfFontFile, FileMode.Open))
            {
                LoadFont(fso);
            }
        }

        private void LoadFont(Stream fontStream)
        {
            var _fontData = new List<string>();
            using (var reader = new StreamReader(fontStream))
            {
                while (!reader.EndOfStream)
                {
                    _fontData.Add(reader.ReadLine());
                }
            }
            LoadLines(_fontData);
        }

    }
}