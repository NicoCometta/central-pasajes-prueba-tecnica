using Application.Interfaces;
using System;
using System.Linq;

namespace Application.Encrypters
{
    internal class AplicarFuncion : ISecurityElement
    {
        private Func<char, char> _encrypt;
        private Func<char, char> _decrypt;

        public AplicarFuncion(Func<char, char> encrypt, Func<char, char> decrypt)
        {
            _encrypt = encrypt;
            _decrypt = decrypt;
        }

        public string Decrypt(string text)
        {
            var result = text.ToArray();
            for (int i = 0; i < text.Length; i++)
            {
                result[i] = _decrypt(text[i]);
            }
            return string.Join(string.Empty, result);
        }

        public string Encrypt(string text)
        {
            var result = text.ToArray();
            for (int i = 0; i < text.Length; i++)
            {
                result[i] = _encrypt(text[i]);
            }
            return string.Join(string.Empty, result);
        }
    }
}
