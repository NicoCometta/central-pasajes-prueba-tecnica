using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Encrypters
{
    internal class LinqRecursividad : ISecurityElement
    {
        private readonly char _separator = '*'; //"*CENTRAL_PASAJES*";

        public string Decrypt(string text)
        {
            var result = text.Split(_separator);
            return result[0];
        }

        public string Encrypt(string text)
        {
            var results = text.Where(c => IsNumber(c.ToString())).ToList();

            var sum = SumRecursive(results, results.Count, 0);

            return $"{text}{_separator}{sum}";
        }

        private int SumRecursive(List<char> results, int count, int position)
        {
            if (count == position)
                return 0; 

            int numValue;
            bool isNumber = int.TryParse(results[position].ToString(), out numValue);
            if (isNumber)
            {
                return numValue + SumRecursive(results, count, ++position);
            }
            else
            {
                return 0;
            }
        }

        private bool IsNumber(string caracter)
        {
            int numValue;
            bool isNumber = int.TryParse(caracter, out numValue);
            return isNumber;
        }
    }
}
