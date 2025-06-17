using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakEnhanced.Utils
{
    public static class InputValidator
    {
        public static bool IsGameNameValid(string gameName)
        {
            return !string.IsNullOrWhiteSpace(gameName) && gameName != "Enter name";
        }
    }
}
