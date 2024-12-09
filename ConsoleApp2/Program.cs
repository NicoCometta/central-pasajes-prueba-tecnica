using Application;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to Central de Pasajes!");
            //string text = "AB12cd34e5f6ghIJ";
            string text = "AB12";
            var encrypter = new Encrypter();

            Console.WriteLine("Text: " + text);
            var textEncrypted = encrypter.Encrypt(text);
            Console.WriteLine("Result Encrypt: " + textEncrypted);
            Console.WriteLine("Result Decrypt: " + encrypter.Decrypt(textEncrypted));
        }
    }
}
