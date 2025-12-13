// Main program for File Extensions


public class fileExtensions
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n\n===== WELCOME TO THE INFORMATION SYSTEM PLATFORM FOR FILE EXTENSIONS =====\n");
        
        Console.WriteLine("===== To get more details of a file extension, enter an extension:(.wav,.doc,.mtm, etc.) or 'Quit', to exit the platform =====");


        while (true)
        {
            try
            {
                Console.Write("\nInput a file extension for more information: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Kindly input a valid file extension. Null values are not allowed.");
                continue;
                }

                if (input.Equals("quit", StringComparison.OrdinalIgnoreCase)) // Case insensitive (Quit & quit works)
                {
                    Console.WriteLine("===== The program has exited.Thanks for making use of our File Extensions Information System.=====");
                break;
                }

                if (!input.StartsWith("."))
                {
                    input = "." + input;
                }

                if (FileExtensionInfo.fileExtensions.TryGetValue(input, out string? description))
                {
                    Console.WriteLine($"{input}: {description}");
                }
                else
                {
                    Console.WriteLine($"We're sorry, information for '{input}' is not available. Please try another");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }
    }
}
