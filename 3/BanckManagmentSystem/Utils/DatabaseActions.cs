using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanckManagmentSystem.Data;
using BanckManagmentSystem.Enums;
using Microsoft.EntityFrameworkCore;

namespace BanckManagmentSystem.Utils
{
    public class DatabaseActions
    {
        public static void AddCustomer()
        {
            using var context = new BankDbContext();
            Console.Clear();
            Console.WriteLine("Add a New Customer");
            Console.WriteLine("==================");
            string fullName = PrograUtils.ReadNonEmptyString("Enter full name: ");
            string email = PrograUtils.ReadNonEmptyString("Enter email: ");
            string nationalId = PrograUtils.ReadNonEmptyString("Enter national ID: ");
            DateTime dateOfBirth = PrograUtils.ReadDate("Enter date of birth (yyyy-MM-dd): ");
            string phoneNumber = PrograUtils.ReadNonEmptyString("Enter phone number: ");
            string address = PrograUtils.ReadNonEmptyString("Enter address: ");
            Console.WriteLine();
            Console.WriteLine("Select customer type:");
            Console.WriteLine("1. Individual");
            Console.WriteLine("2. Business");
            int customerTypeChoice = PrograUtils.ReadIntInRange("Enter a number (1 or 2): ", 1, 2);
            var customerType = customerTypeChoice == 1 ? Enums.CustomerType.individual : Enums.CustomerType.business;
            bool nationalIdExists = context.Customers.Any(c => c.NationalId == nationalId);
            if (nationalIdExists)
            {
                Console.WriteLine("A customer with this national ID already exists. Please try again.");
                return;
            } 
            bool emailExists = context.Customers.Any(c => c.Email == email);
            if (emailExists)
            {
                Console.WriteLine("A customer with this email already exists. Please try again.");
                return;
            }
            var newCustomer = new Models.Customer
            {
                FullName = fullName,
                Email = email,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                Address = address,
                CustomerType = customerType
            };
            context.Customers.Add(newCustomer);
            context.SaveChanges();
            Console.WriteLine();
            Console.WriteLine($"Customer added successfully. Customer ID: {newCustomer.Id}");
        }
    public static void openAccountForCustomer()
        {
            using var context = new BankDbContext();
            Console.Clear();
            Console.WriteLine("Open a New Account for a Customer");
            Console.WriteLine("===============================");
            string accountNumber = PrograUtils.ReadNonEmptyString("Enter account number: ");
            Console.WriteLine();
            Console.WriteLine("Select account type:");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Current");
            Console.WriteLine("3. Business");
            int accountTypeChoice = PrograUtils.ReadIntInRange("enter a number (1, 2, or 3): " , 1 , 3);
            AccountType accountType = (AccountType)(accountTypeChoice - 1);
            int branchId = PrograUtils.ReadPositiveInt("Enter branch ID: ");
            int customerId = PrograUtils.ReadPositiveInt("Enter customer ID: ");

            int ouwnerShipRoleChoice = PrograUtils.ReadIntInRange("Select ownership role (1 for Primary, 2 for Secondary): ", 1, 2);
            OwnerShipRole ownerShipRole = (OwnerShipRole)(ouwnerShipRoleChoice - 1);
            var branch = context.Branches.FirstOrDefault(b=> b.Id == branchId);
            if (branch is null)
            {
                Console.WriteLine("Branch not found. Please try again.");
                return;
            }
            var customer  = context.Customers.FirstOrDefault(c=>c.Id == customerId);
            if (customer is null)
            {
                    Console.WriteLine("Customer not found. Please try again.");
                    return;
            }

            var accountExists = context.Accounts.Any(a=>a.AccountNumber == accountNumber);
            if (accountExists)
            {
                Console.WriteLine("An account with this account number already exists. Please try again.");
                return;
            }
            var account = new Models.Account
            {
                AccountNumber = accountNumber,
                AccountType = accountType,
                Balance = 0,
                AccountStatus = AccountStatus.Active,
                OwnerShipRole = ownerShipRole,
                CreatedDate = DateTime.Now,
                BranchId = branchId,
            };
            context.Accounts.Add(account);
            context.SaveChanges();
            var customerAccount = new Models.CustomerAccount
            {
                CustomerId = customerId,
                AccountId = account.Id,
                OwnerShipRole = ownerShipRole
            };
            context.CustomerAccounts.Add(customerAccount);
            context.SaveChanges();
            Console.WriteLine();
            Console.WriteLine($"Account opened successfully. Account ID: {account.Id}");
        }
   
    public static void UpdateAccount()
        {
            var countext = new BankDbContext();
            Console.Clear();
            Console.WriteLine("Update an Existing Account for a Customer");
            Console.WriteLine("==========================================");
            int accountId = PrograUtils.ReadPositiveInt("Enter account ID to update: ");
            int customerId = PrograUtils.ReadPositiveInt("Enter Customer ID to update: ");
            var customerAccount = countext.CustomerAccounts.Include(ca => ca.Account).Include(ca=>ca.Customer).FirstOrDefault(ca => ca.CustomerId == customerId && ca.AccountId == accountId);
            if (customerAccount is null)
            {
                Console.WriteLine("Account not found for the given customer. Please try again.");
                return;
            }
            var account = customerAccount.Account;
            Console.WriteLine();
            var AccountStatuse = account.AccountStatus;
            Console.WriteLine($"Current account status: {AccountStatuse}");
            Console.WriteLine("Select new account status:");
            Console.WriteLine("1. Active");
            Console.WriteLine("2. Inactive");
            int  accountStatusChosie = PrograUtils.ReadIntInRange("Enter a number (1 or 2): ", 1, 2); 
            account.AccountStatus = (AccountStatus)(accountStatusChosie -1) ;
            countext.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Account status updated successfully.");
        }
    public static void DeleteAccount()
        {
            var context = new BankDbContext();
            Console.Clear();
            Console.WriteLine("Delete an Account for a Customer");
            Console.WriteLine("==================================");
            string accountNumber = PrograUtils.ReadNonEmptyString("Enter account number to delete: ");
            int customerId = PrograUtils.ReadPositiveInt("Enter Customer ID to delete: ");
            var customerAccount = context.CustomerAccounts.Include(ca=>ca.Account).Include(ca=>ca.Customer).FirstOrDefault(ca=>ca.Account.AccountNumber == accountNumber && ca.Customer.Id == customerId);
            if (customerAccount is null)
            {
                Console.WriteLine("Account not found. Please try again.");
                return;
            }
            context.CustomerAccounts.Remove(customerAccount);
            context.Accounts.Remove(customerAccount.Account);
            context.SaveChanges();
            Console.WriteLine("Account deleted successfully.");
        }
    public static void ViewCustomerWithAccountDetails()
        {
            using var context = new BankDbContext();
            Console.Clear();
            Console.WriteLine("View Customer with Account Details");
            Console.WriteLine("===================================");
            var customers = context.Customers.Include(c=>c.CustomerAccounts).ThenInclude(ca=>ca.Account).ThenInclude(a=>a.Branch).ToList();
            if (!customers.Any())
            {
                Console.WriteLine("No customers found.");
                return;
            }
            foreach (var customer in customers)
            {
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine($"Customer ID: {customer.Id}");
                Console.WriteLine($"Full Name: {customer.FullName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"National ID: {customer.NationalId}");
                Console.WriteLine($"Date of Birth: {customer.DateOfBirth:yyyy-MM-dd}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                Console.WriteLine($"Address: {customer.Address}");
                Console.WriteLine($"Customer Type: {customer.CustomerType}");
                Console.WriteLine("Accounts:");
                if (!customer.CustomerAccounts.Any())
                {
                    Console.WriteLine("No accounts found for this customer.");
                }
                else
                {
                foreach (var account in customer.CustomerAccounts.Select(ca => ca.Account))
                    {
                        Console.WriteLine($"  Account ID: {account.Id}");
                        Console.WriteLine($"  Account Number: {account.AccountNumber}");
                        Console.WriteLine($"  Balance: {account.Balance:C}");
                        Console.WriteLine($"  Account Type: {account.AccountType}");
                        Console.WriteLine($"  Account Status: {account.AccountStatus}");
                        Console.WriteLine($"  Ownership Role: {account.OwnerShipRole}");
                        Console.WriteLine($"  Created Date: {account.CreatedDate:yyyy-MM-dd}");
                        if (account.Branch != null)
                        {
                            Console.WriteLine($"  Branch Name: {account.Branch.Name}");
                            Console.WriteLine($"  Branch Location: {account.Branch.Address}");
                        }
                        else
                        {
                            Console.WriteLine("  Branch information not available.");
                        }
                        Console.WriteLine();
                    }
                }
                    
                }
            }
            
            }
        } 
