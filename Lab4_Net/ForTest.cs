using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Net
{
    public class ForTest
    {
        public int CezarKey { get; set; }
        public string CezarPhraze { get; set; } = String.Empty;
        public string CezarEncryptedPhraze { get; set; } = String.Empty;
        public string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        List<string> CryptSystem = new List<string>();
        public string MessageForEncrypt { get; set; } = String.Empty;
        public string MessageForDecrypt { get; set; } = String.Empty;
        public string EncryptedMessage { get; set; } = String.Empty;
        public string CryptoSystemMessage { get; set; } = String.Empty;

        public string EncryptCezar()
        {
            StringBuilder encryptMessage = new StringBuilder();
            for (int i = 0; i < CezarPhraze.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    int index = j + CezarKey;

                    if (index > Alphabet.Length)
                        index -= Alphabet.Length;

                    if (CezarPhraze[i] == Alphabet[j])
                        encryptMessage.Append(Alphabet[index]);
                }
            }
            CezarEncryptedPhraze = encryptMessage.ToString();
            return encryptMessage.ToString();
        }

    }
}
