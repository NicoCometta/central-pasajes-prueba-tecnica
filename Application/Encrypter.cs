using Application.Encrypters;
using Application.Enums;
using Application.Interfaces;
using System;
using System.Collections.Generic;

namespace Application
{
    public class Encrypter
    {
        private Dictionary<int, ISecurityElement> _securityElements;
        private int[] _encryptOrder;
        private int[] _decryptOrder;
        public Encrypter()
        {
            InitializeAlgorithms();
            InitializeExecutionOrder();
        }

        public string Encrypt(string text)
        {
            string result = text;
            foreach (var item in _encryptOrder)
            {
                if (_securityElements.ContainsKey(item))
                {
                    result = _securityElements[item].Encrypt(result);
                }
            }
            return result;
        }
        public string Decrypt(string text)
        {
            string result = text;
            foreach (var item in _decryptOrder)
            {
                if (_securityElements.ContainsKey(item))
                {
                    result = _securityElements[item].Decrypt(result);
                }                
            }
            return result;
        }

        private void InitializeAlgorithms()
        {
            Func<char, char> encryptionAlgorithm = EncryptionAlgorithm(1);
            Func<char, char> dencryptionAlgorithm = DecryptionAlgorithm(1);

            _securityElements = new Dictionary<int, ISecurityElement>();

            _securityElements.Add((int)EncryptionAlgorithmType.InverterOrder, new InvertirOrden());
            _securityElements.Add((int)EncryptionAlgorithmType.ApplyFunction, new AplicarFuncion(encryptionAlgorithm, dencryptionAlgorithm));
            _securityElements.Add((int)EncryptionAlgorithmType.RecursiveLinQ, new LinqRecursividad());
        }

        private void InitializeExecutionOrder()
        {
            _encryptOrder = new int[]
            {
                (int)EncryptionAlgorithmType.InverterOrder, (int)EncryptionAlgorithmType.ApplyFunction, (int)EncryptionAlgorithmType.RecursiveLinQ
            };

            _decryptOrder = new int[]
            {
                (int)EncryptionAlgorithmType.RecursiveLinQ, (int)EncryptionAlgorithmType.ApplyFunction, (int)EncryptionAlgorithmType.InverterOrder
            };
        }

        private Func<char, char> EncryptionAlgorithm(int value)
        {
            return c => (char)((int)c + value);
        }

        private Func<char, char> DecryptionAlgorithm(int value)
        {
            return c => (char)((int)c - value);
        }
    }
}
