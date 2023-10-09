using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Arrays2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Завдання 3: Шифрування та розшифрування рядка за допомогою шифру Цезаря
            Console.Write("Введіть рядок для шифрування: ");
            string inputText = Console.ReadLine();

            int shift = 3; // кількість позицій зсуву

            string encryptedText = Encrypt(inputText, shift);
            Console.WriteLine($"Зашифрований рядок: {encryptedText}");

            string decryptedText = Decrypt(encryptedText, shift);
            Console.WriteLine($"Розшифрований рядок: {decryptedText}");

            // Завдання 5: Підрахунок результату арифметичного виразу
            Console.Write("Введіть арифметичний вираз (+ та -): ");
            string arithmeticExpression = Console.ReadLine();

            DataTable dataTable = new DataTable();
            try
            {
                var result = dataTable.Compute(arithmeticExpression, "");
                Console.WriteLine($"Результат виразу: {result}");
            }
            catch (SyntaxErrorException)
            {
                Console.WriteLine("Неправильний формат арифметичного виразу.");
            }
        }

        static string Encrypt(string text, int shift)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    char baseLetter = char.IsUpper(chars[i]) ? 'A' : 'a';
                    chars[i] = (char)((chars[i] - baseLetter + shift) % 26 + baseLetter);
                }
            }
            return new string(chars);
        }

        static string Decrypt(string text, int shift)
        {
            return Encrypt(text, 26 - shift);
        }
    }
}
