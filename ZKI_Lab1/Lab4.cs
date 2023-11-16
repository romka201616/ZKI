using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKI_Lab1
{
    internal class Lab4
    {

        public int CaesarKey { get; set; }
        public string CaesarPhrase { get; set; } = String.Empty;
        public string CaesarEncryptedPhrase { get; set; } = String.Empty;

        private char CaesarCipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }

        public string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += CaesarCipher(ch, key);

            return output;
        }
    }
}
