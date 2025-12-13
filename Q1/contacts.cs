// Program for Class Contact with properties
public class Contact
{
    //Public Access Modifiers using the accessors get and set
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime Birthdate { get; set; }
  
    // Passing values by utilizing a parameterized constructor, C# Concepts
    public Contact(string firstName, string lastName, string company, string mobileNumber, 
                   string email, string address, DateTime birthdate)
    {
        FirstName = firstName;
        LastName = lastName;
        Company = company;
        MobileNumber = mobileNumber;
        Email = email;
        Address = address;
        Birthdate = birthdate;
    }
}