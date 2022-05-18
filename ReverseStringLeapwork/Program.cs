using System;
using System.Threading;

namespace ReverseStringLeapwork
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = "";
            while (inputText != "quit")
            {
                PrintToScreen("Enter a text to be reversed: ");
                inputText = Console.ReadLine();
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    ReverseAndPrint(inputText);
                }));
                thread.Start();
            }

        }

        internal static void PrintToScreen(string textToPrint)
        {
            foreach (var charItem in textToPrint)
            {
                Console.Write(charItem);
            }
            Console.WriteLine();
        }
        internal static string ReverseText(string textToReverse)
        {
            string reverseResult = textToReverse[textToReverse.Length - 1].ToString();
            int index = 1;
            while (reverseResult.Length < textToReverse.Length)
            {
                index = index + 1;
                reverseResult = reverseResult + textToReverse[textToReverse.Length - index];
            }
            return reverseResult;
        }
        internal static void ReverseAndPrint(string text)
        {
            string reversedText = ReverseText(text);
            PrintToScreen(reversedText);
        }
    }
}
