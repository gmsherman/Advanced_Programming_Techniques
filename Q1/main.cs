using System;
using System.Collections.Generic;

class MainContactBook
{
    static void Main(string[] args)
    {
        ContactBook book = new ContactBook(); // Creating a new object of the class ContactBook

        // Initialize minimum 20 contacts on program startup
        book.initialContacts();

        while (true)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("\n===== CONTACT BOOK MAIN MENU =====");
            Console.WriteLine("1: Add Contact");
            Console.WriteLine("2: Show All Contacts");
            Console.WriteLine("3: Show Contact Details");
            Console.WriteLine("4: Update Contact");
            Console.WriteLine("5: Delete Contact");
            Console.WriteLine("0: Exit\n");

            Console.Write("Select an option from the Main Menu: ");
            string? choice = Console.ReadLine();

            //Methods contained in a switch statement
            switch (choice)
            {
                case "1":
                    book.AddContact();
                    break;
                case "2":
                    book.ShowAllContacts();
                    break;
                case "3":
                    book.ShowContactDetails();
                    break;
                case "4":
                    book.UpdateContact();
                    break;
                case "5":
                    book.DeleteContact();
                    break;
                case "0":
                    Console.WriteLine("You have now exited the Contact Book Menu.");
                    return;
                default:
                    Console.WriteLine("You have provided an invalid option. Please try again.");
                    break;
            }
        }
    }
}