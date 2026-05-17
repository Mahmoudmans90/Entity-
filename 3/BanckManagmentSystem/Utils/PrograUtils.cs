using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanckManagmentSystem.Utils
{
    public static class PrograUtils
    {
        public static void PrintMenu()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("National Bank Management System");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Add a new customer");
            Console.WriteLine("2. Open a new account for a customer");
            Console.WriteLine("3. Update an existing account for a customer");
            Console.WriteLine("4. Delete an account for a customer");
            Console.WriteLine("5. View customer with account details");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================================");
        }
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }
        public static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result) && result >= 0)
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
        public static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
            int input = ReadPositiveInt(prompt);
            if (input >= min && input <= max)
            {
                return input;
                
            }
           Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");

        }
    }
        public static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();
                if (DateTime.TryParse(input ,  out DateTime date))
                {
                    return date;
                } 
                Console.WriteLine("Invalid date format. Please enter a valid date (e.g., MM/DD/YYYY).");
            }
        }
}
}