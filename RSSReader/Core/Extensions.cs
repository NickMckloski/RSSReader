using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Core
{
    public static class Extensions
    {
        public static string TrimEnd(this string input, char toRemove)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == toRemove)
                {
                    return input.Substring(0, i);
                }
            }
            return input;
        }
    }
}
