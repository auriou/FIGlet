using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace FIGlet.Net
{
    public static class ExtendSystem
    {
        public static Stream GetResourceStream(this object obj, string resourceName)
        {
            var assem = obj.GetType().Assembly;
            return assem.GetManifestResourceStream(resourceName);
        }
        public static int GetIntValue(this string[] arrayStrings, int posi)
        {
            var val = 0;
            if (arrayStrings.Length > posi)
            {
                int.TryParse(arrayStrings[posi], out val);
            }
            return val;
        }
        public static int StartIndexOf(this string[] chaines, string[] findChaines, int posiInChaine, int startErrorPossible)
        {
            int posi = -1;
            var taille = Math.Min(chaines.Length, findChaines.Length);
            for (int i = 0; i < taille; i++)
            {
                var posiEncours = chaines[i].StartsWidthLastIndex(findChaines[i], posiInChaine, startErrorPossible);
                if (posiEncours < 0)
                    return -1;
                posi = Math.Max(posi, posiEncours);
            }
            return posi;
        }

        public static int StartsWidthLastIndex(this string chaine, string findChaine, int posiInChaine, int startErrorPossible)
        {
            var posi = 0;
            if (chaine == findChaine)
                return posi;
            var ok = chaine.Remove(0, posiInChaine).StartsWith(findChaine);
            while (!ok && posi <= startErrorPossible)
            {
                posi++;
                try
                {
                    ok = chaine.Remove(0, posiInChaine + posi).StartsWith(findChaine);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error : " + ex.Message);
                    ok = false;
                }
            }
            return ok ? posiInChaine + posi + findChaine.Length : -1;
        }
    }
}
