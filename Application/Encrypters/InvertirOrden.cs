using Application.Interfaces;
using System.Linq;

namespace Application.Encrypters
{
    public class InvertirOrden : ISecurityElement
    {
        public string Decrypt(string text)
        {
            return InvertirOrdenDeCaracteres(text);
        }

        public string Encrypt(string text)
        {
            return InvertirOrdenDeCaracteres(text);
        }


        private string InvertirOrdenDeCaracteres(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            int n = text.Length;
            char[] arrayText = text.ToArray();
            char[] result = new char[n];

            for (int i = 0; i < n; i++)
            {
                int position = n - 1 - i; // TODO: revisar valor de i
                result[position] = text[i];
            }

            return new string(result);
        }

    }
}
