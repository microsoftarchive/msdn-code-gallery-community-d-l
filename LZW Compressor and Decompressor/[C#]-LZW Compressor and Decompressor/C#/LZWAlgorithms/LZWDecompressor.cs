using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LZWAlgorithms
{
    class LZWDecompressor
    {
        public string Decompressor(
            Dictionary<int, string> dictionary, List<int> indices)
        {
            string s = string.Empty;

            foreach (int index in indices)
            {
                foreach (KeyValuePair<int, string> kvp in dictionary)
                {
                    if (kvp.Key == index)
                    {
                        s += kvp.Value;
                        break;
                    }
                }
            }

            return s;
        }
    }
}
