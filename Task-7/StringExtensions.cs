using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_7
{
    internal static class StringExtensions
    {
        public static bool isValidNameFormat(this string name) => (name.Length >= 3 && !string.IsNullOrWhiteSpace(name)) ? true : false;
  
    }
}
