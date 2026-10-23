using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // En enkel lista för att spara alla godkända produkter

        List<string> produktLista = new List<string>();

        // Skriver ut rubriken exakt enligt instruktionerna

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("PRODUCT LIST MANAGER - LEVEL 3");
        Console.WriteLine("-----------------------------------\n");
        Console.WriteLine("Enter product names.");
        Console.WriteLine("Type 'exit' to finish.\n");

        while (true)
        {
            Console.Write("Product: ");
            string inmatning = Console.ReadLine();

            if (inmatning == null) continue;

            // Ta bort mellanslag i början och slutet
            string rensadText = inmatning.Trim();

            // Kolla om användaren vill avsluta programmet
            if (rensadText.ToLower() == "exit")
            {
                break;
            }

            // Validering 1: Kontrollera om inmatningen är tom

            if (string.IsNullOrWhiteSpace(rensadText))
            {
                Console.WriteLine("ERROR: Input cannot be empty.");
                Console.WriteLine();
                continue;
            }

            // Kör vår egen funktion för att kolla formatet

            if (!KollaProduktFormat(rensadText))
            {
                Console.WriteLine();
                continue;
            }

            // Om allt är okej, lägg till produkten i listan

            produktLista.Add(rensadText);
        }

        // Sortera listan i bokstavsordning innan utskrift

        produktLista.Sort();

        Console.WriteLine("\nSorted valid products:\n");
        foreach (string produkt in produktLista)
        {
            Console.WriteLine($"- {produkt}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    // Funktion som kontrollerar alla regler steg för steg

    static bool KollaProduktFormat(string namn)
    {
        // Validering 2: Måste innehålla ett bindestreck
        if (!namn.Contains("-"))
        {
            Console.WriteLine("ERROR: The right side must contain numbers only.");
            return false;
        }

        // Dela upp texten i två delar vid bindestrecket
        string[] delar = namn.Split('-');

        // Säkerhetskoll om användaren skrev mer än ett bindestreck
        if (delar.Length != 2)
        {
            Console.WriteLine("ERROR: The right side must contain numbers only.");
            return false;
        }

        string vansterDel = delar[0].Trim();
        string hogerDel = delar[1].Trim();

        // Validering 3: Kolla vänster sida (får bara vara bokstäver)
        if (vansterDel.Length == 0)
        {
            Console.WriteLine("ERROR: The left side must contain letters only.");
            return false;
        }

        foreach (char bokstav in vansterDel)
        {
            if (!char.IsLetter(bokstav))
            {
                Console.WriteLine("ERROR: The left side must contain letters only.");
                return false;
            }
        }

        // Validering 4: Kolla höger sida (får bara vara siffror)

        if (hogerDel.Length == 0)
        {
            Console.WriteLine("ERROR: The right side must contain numbers only.");
            return false;
        }

        foreach (char siffra in hogerDel)
        {
            if (!char.IsDigit(siffra))
            {
                Console.WriteLine("ERROR: The right side must contain numbers only.");
                return false;
            }
        }

        // Validering 5: Gör om till heltal och kolla intervallet 200-500

        if (int.TryParse(hogerDel, out int nummer))
        {
            if (nummer < 200 || nummer > 500)
            {
                Console.WriteLine("ERROR: The numeric part must be between 200 and 500.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("ERROR: The right side must contain numbers only.");
            return false;
        }

        return true; // Alla kontroller godkända!
        //Uppdaterat idag
    }
}
