using System;
namespace CSharp12
{
    public static class StringExtensions
    {
        //1
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            str = str.Replace(" ", "").ToLower();
            int len = str.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (str[i] != str[len - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        //2
        public static string Shufr(this string str, int key)
        {
            char[] buffer = str.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + key);
                buffer[i] = letter;
            }
            return new string(buffer);
        }

        //3
        public static Dictionary<T, int> CountDuplicates<T>(this T[] array)
        {
            var counts = new Dictionary<T, int>();

            foreach (var item in array)
            {
                if (counts.ContainsKey(item))
                {
                    counts[item]++;
                }
                else
                {
                    counts[item] = 1;
                }
            }

            return counts;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Enter a fraza: ");
            string input = Console.ReadLine();
            if (input.IsPalindrome())
            {
                Console.WriteLine("Fraza is a palindrome.");
            }
            else
            {
                Console.WriteLine("Fraza is not a palindrome.");
            }

            //2
            Console.WriteLine("Enter a fraza to encrypt: ");
            string inputToEncrypt = Console.ReadLine();
            Console.WriteLine("Enter a number: ");

            if (int.TryParse(Console.ReadLine(), out int key))
            {
                string shufr = inputToEncrypt.Shufr(key);
                Console.WriteLine($"Encrypted fraza: {shufr}");
            }
            else
            {
                Console.WriteLine("Incorrect key.");
            }

            //3
            int[] array = { 1, 2, 2, 3, 3, 3, 4, 4, 4};
            var duplicates = array.CountDuplicates();

            Console.WriteLine("Element - Count");
            foreach (var kvp in duplicates)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}

