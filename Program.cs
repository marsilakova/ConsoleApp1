using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store product names
        List<string> products = new List<string>();

        // Display the updated header for Level 2 matching the sample
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("PRODUCT LIST MANAGER - LEVEL 2");
        Console.WriteLine("-----------------------------------\n");
        Console.WriteLine("Enter product names.");
        Console.WriteLine("Type 'exit' to finish.\n");

        while (true)
        {
            // Prompt user for input
            Console.Write("Product: ");
            string input = Console.ReadLine();

            if (input == null) continue;

            // Trim unnecessary spaces and convert to lowercase for comparison
            string cleanedInput = input.Trim().ToLower();

            // Accept exit, EXIT, eXiT, and versions with spaces
            if (cleanedInput == "exit")
            {
                break;
            }

            // Prevent adding empty or whitespace-only names
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Product name cannot be empty. Please try again.");
                continue;
            }

            // Add the trimmed product name to the list
            products.Add(input.Trim());
        }

        // Sort the product list alphabetically
        products.Sort();

        // Exact text from the sample screenshot
        Console.WriteLine("\nSorted product list:\n");

        foreach (string product in products)
        {
            // Print each sorted product with indentation and a dash
            Console.WriteLine($"- {product}");
        }

        // Final line from the sample screenshot
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}