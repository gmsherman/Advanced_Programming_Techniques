//Phone Contact Book with its Methods

using System;
using System.Collections.Generic; //Utilizing generic collections to implement the data structure List

class ContactBook
{
    private List<Contact> contacts;

    public ContactBook() //Constructor method, same as class name
    {
        contacts = new List<Contact>();
    }
    //Manually initializing the minimum twenty (20) contacts
    public void initialContacts()
    {
        var initialContacts = new List<(string FirstName, string LastName, string Company, string Mobile, string Email, string address, DateTime Birthdate)>
        {
            ("Prince M.", "Myers", "Forestry Development Authority", "880987675", "pmyers@fda.gov.lr", " Parker Paint", new DateTime(1998, 10, 11)),
            ("Johnny", "Kortee", "Ministry of Finance & Development Planning", "886564543", "jkortee@mfdp.gov.lr", "Johnson Street", new DateTime(1969, 5, 23)),
            ("Thomas", "Momo", "Buchanan Renewable Energy", "888123456", "tmomo@buchananrenewables.com", "Buchanan Street", new DateTime(1992, 8, 15)),
            ("James", "Junius", "Public Procurement Concessions Commission", "555121212", "jjunius@ppcc.gov.lr", "Careysburg", new DateTime(1990, 02, 10)),
            ("Sam K.", "Flomo", "Central Agricultural Research Institute", "881232345", "sfomo@cari.org", "Bong County", new DateTime(2003, 11, 11)),
            ("Rebecca S.", "Brewer", "NOCAL", "885209876", "rbrewer@nocal.com", "Buchanan Street", new DateTime(1992, 8, 15)),
            ("Lutrisah", "Mulbah", "Environmental Protection Agency", "880909098", "lmulbah@epa.com", "Center Street", new DateTime(1999, 03, 15)),
            ("Alyxa F.", "Sherman", "Saint Teresa Convent", "770460354", "asherman.convent.com", "Caldwell, Coffee Farm", new DateTime(2011, 05, 11)),
            ("Don K.", "Lamah", "Dublin Business School", "777675654", "dlamah@dbs.ie", "Mills Street", new DateTime(2002, 10, 05)),
            ("Frederick", "Kamara", "National College of Ireland", "555123457", "fkamara@nci.ie", "Dublin 1", new DateTime(1996, 03, 10)),
            ("Kutu", "Vanyanbah", "Lonestar Cell Inc.", "887202020", "kvanyanbah@lonestar.com", "19th Street, Sinkor", new DateTime(1983, 01, 10)),
            ("Blessing", "Samah", "Stella Maris Polytechnic", "088656543", "bsamah@smp.edu.lr", "S.K.D Boulevard", new DateTime(1999, 04, 11)),
            ("Samuel", "Ogunlusi", "Dublin Business School", "089786751", "sogunlusi@dbs.ie", "Dublin 24", new DateTime(2001, 03, 05)),
            ("Sanu", "Matthew", "Maynooth University", "999990897", "smatthew@maynooth.ie", "Maynooth City", new DateTime(1990, 10, 12)),
            ("Eddie R.", "Moulton", "Unique Technology Solutions", "888123456", "emoulton@uniquesolutions.com", "Johnsonville", new DateTime(2005, 07, 07)),
            ("Eunice", "Sonyah", "United Methodist University", "770901876", "esonyah@umu.edu.lr", "Bassa Community", new DateTime(1989, 01, 02)),
            ("Monica", "Sow", "University of Liberia", "889345342", "msow@ul.edu.lr", "Thinker Village", new DateTime(1983, 04, 01)),
            ("Jack", "Seboe", "Stargate Technology", "555678654", "jseboe@stargate.com", "Iron Gate", new DateTime(1967, 08, 10)),
            ("Mabintu", "Mansaray", "Litte Dream Big", "885890897", "mmansaray@littledreambig.com", "Duport Road", new DateTime(1989, 03, 03)),
            ("Jerome", "Teah", "Central Bank of Liberia", "777876543", "jteah@cbl.gov.lr", "Tower Holl", new DateTime(1979, 07, 01))
        };

        foreach (var (firstName, lastName, company, mobile, email, address, birthdate) in initialContacts)
        {
            try
            {
                contacts.Add(new Contact(firstName, lastName, company, mobile, email, address, birthdate));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding an initial contact {firstName} {lastName}: {ex.Message}");
            }
        }

        Console.WriteLine($"\n{initialContacts.Count} minimum contacts have been preloaded to the phone contact book. To see their details, select 2.");
    }

    // Public Methods describing the behavior of the object ContactBook
    
     //Method to add a contact to the phone contact book
    public void AddContact()
    {
        Console.Write("Enter your First Name: ");
        string? firstName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(firstName))
        {
        Console.WriteLine("First Name cannot be empty. Please enter a First Name.");
        return;
        }

        Console.Write("Enter your Last Name: ");
        string? lastName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(lastName))
        {
        Console.WriteLine("Last Name cannot be empty.Please enter a Last Name.");
        return;
        }

        Console.Write("Enter the name of your Company: ");
        string? company = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(company))
         {
        Console.WriteLine("Company cannot be blank. Please enter a company.");
        return;
         }

        string? mobileNumber;
        while (true)
        {
            Console.Write("Enter Mobile Number (9-digit positive number): ");
            mobileNumber = Console.ReadLine();
            if (IsValidMobileNumber(mobileNumber)) 
            break;
            Console.WriteLine("Mobile number is invalid. The mobile number must be a non-zero 9-digit number.");
        }

        Console.Write("Enter your Email: ");
        string? email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email))
        {
        Console.WriteLine("Email cannot be blank. Please enter an email address.");
        return;
        }

        Console.Write("Enter your Address: ");
        string? address = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(address))
        {
        Console.WriteLine("Address cannot be blank.Please enter a valid address.");
        return;
        }

        Console.Write("Enter your Birthdate (dd/MM/yyyy): ");
        DateTime birthdate;

        while (!DateTime.TryParse(Console.ReadLine(), out birthdate))
        {
            Console.WriteLine("Invalid date format. Please try again using a valid date format.");
        }

        contacts.Add(new Contact(firstName, lastName, company, mobileNumber!, email, address, birthdate));
        Console.WriteLine("\nContact has been added successfully to the Contact Book!");
    }
      //Method to show all contacts in the phone contact book
    public void ShowAllContacts()
    {
        Console.WriteLine("\n===== Displaying details of All Contacts only by Names, Companies, Phone Numbers, and Email Addresses. =====");
        foreach (var contact in contacts)
        {
        Console.WriteLine($" - {contact.FirstName} {contact.LastName} | {contact.Company} | {contact.MobileNumber} | {contact.Email} ");
        }
    }
     //Method to show the details of a contact
    public void ShowContactDetails()
    {
        Console.Write("Enter the mobile number of a contact to show their details: ");
        string? mobileNumber = Console.ReadLine();

        Contact? contact = contacts.FirstOrDefault(contact => contact.MobileNumber == mobileNumber);
        if (contact != null)
        {
        Console.WriteLine($"First Name: {contact.FirstName}");
        Console.WriteLine($"Last Name: {contact.LastName}");
        Console.WriteLine($"Company: {contact.Company}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Address: {contact.Address}");
        Console.WriteLine($"Birthdate: {contact.Birthdate.ToString()}");
        }
        else
        {
        Console.WriteLine("Contact information not found.......");
        }
    }
     //Method to update a contact
    public void UpdateContact()
    {
        Console.Write("Enter the Mobile Number of the contact to update: ");
        string? mobileNumber = Console.ReadLine();
        
        Contact? contact = contacts.FirstOrDefault(contact => contact.MobileNumber == mobileNumber);
        if (contact != null)
        {
        Console.Write("Enter new First Name for update (leave blank to keep existing First Name.): ");
        string? firstName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(firstName)) 
        contact.FirstName = firstName; 

        Console.Write("Enter new Last Name for update (leave blank to keep existing Last Name.): ");
        string? lastName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastName)) 
        contact.LastName = lastName;

        Console.Write("Enter new Company for update (leave blank to keep existing Company.): ");
        string? company = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(company)) 
        contact.Company = company;

        Console.Write("Enter new Email for update (leave blank to keep existing Email.): ");
         string? email = Console.ReadLine();
         if (!string.IsNullOrWhiteSpace(email)) 
         contact.Email = email;

        Console.Write("Enter new Address for update (leave blank to keep existing Address.): ");
        string? address = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(address)) 
        contact.Address = address;

        Console.Write("Enter new Birthdate for update (dd/MM/yyyy) (leave blank to keep existing BirthDate.):");
        string? birthdateInput = Console.ReadLine();
        if (DateTime.TryParse(birthdateInput, out DateTime birthdate)) 
        contact.Birthdate = birthdate;

        Console.WriteLine("Contact has been updated successfully!");
        }
        else
        {
        Console.WriteLine("Contact information not found.");
        }
    }
      //Method to delete a contact from the phone contact book
    public void DeleteContact()
{
        Console.Write("Enter the Mobile Number of the contact to delete: ");
        string? mobileNumber = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(mobileNumber))
    {
        Console.WriteLine(" Mobile Number cannot be empty. Please provide a valid mobile number to continue.");
        return;
    }
    Contact? contactToRemove = null;
    
    //  Using a loop to search for a contact
    foreach (var contact in contacts)
    {
        if (contact.MobileNumber == mobileNumber)
        {
            contactToRemove = contact;
            break; 
        }
    }

    if (contactToRemove != null)
    {
        contacts.Remove(contactToRemove);
        Console.WriteLine("Contact has been deleted successfully from the Contact Book!");
    }
    else
    {
        Console.WriteLine("Contact information not found.");
    }
}
      //Method to check if the mobile number is null or empty
    private bool IsValidMobileNumber(string? mobileNumber)
    {
        if (string.IsNullOrWhiteSpace(mobileNumber))
         {
        return false; // Checks if Mobile Number is null or empty and returns false
         }
        return mobileNumber.Length == 9 && long.TryParse(mobileNumber, out long _);
    }
}