using BanckManagmentSystem.Utils;
using System;
namespace BanckManagmentSystem
{
    
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            PrograUtils.PrintMenu();
            int choice = PrograUtils.ReadIntInRange("Enter a number (or 'exit' to quit):", 0, 5);
           
            if (choice == 0)
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                return;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Adding a new customer...");
                    DatabaseActions.AddCustomer();
                    PrograUtils.Pause();
                    break;
                case 2:
                    Console.WriteLine("Opening a new account for a customer...");
                      DatabaseActions.openAccountForCustomer();
                    PrograUtils.Pause();
                    break;
                case 3:
                    Console.WriteLine("Updating an existing account for a customer...");
                     DatabaseActions.UpdateAccount();
                    PrograUtils.Pause();
                    break;
                case 4:
                    Console.WriteLine("Deleting an account for a customer...");
                    DatabaseActions.DeleteAccount();
                    PrograUtils.Pause();
                    break;
                case 5:
                    Console.WriteLine("Viewing customer with account details...");
                    DatabaseActions.ViewCustomerWithAccountDetails();
                    PrograUtils.Pause();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    PrograUtils.Pause();
                    break;
            }
        }

      
    }
}
}