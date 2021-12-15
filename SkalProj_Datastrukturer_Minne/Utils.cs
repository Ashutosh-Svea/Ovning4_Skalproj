using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    internal class Utils
    {
        public static bool IsEmptyString(string? str)
        {
            if (str is null)
                return false;

            if (str.Equals(String.Empty))
                return true;
            else
                return false;
        }

        public static bool IsStringAtleastGivenCharacters(string? str, int atleastThis)
        {
            if (str is null)
                return false;

            if (str.Length < atleastThis)
                return false;
            else
                return true;
        }

    }
}
