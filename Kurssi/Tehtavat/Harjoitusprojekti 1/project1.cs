namespace Harjoitusprojekti1
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()   //Selkeyden vuoksi, lisään rivivälejä ja ylimääräisiä Console.WriteLine() -komentoja, jotta tulostus on helpommin luettavaa.
        {
            Console.WriteLine("");
            Console.WriteLine("Tehdään uusi varasto.");
            Dictionary<string, int> stock = new Dictionary<string, int>();
            Console.WriteLine("Varasto luotu.");
            Console.WriteLine("");

            stock.Add("Milk", 10);
            stock.Add("Bread", 5);
            stock.Add("Apple", 20);

            Console.WriteLine("");

            PrintStock(stock);

            Console.WriteLine("");

            AddOrIncrease(stock, "Milk", 3);
            AddOrIncrease(stock, "Banana", 7);

            Console.WriteLine("");

            TrySell(stock, "Apple", 5);
            TrySell(stock, "Apple", 500);
            TrySell(stock, "Cheese", 1);

            Console.WriteLine("");

            RemoveProduct(stock, "Bread");
            RemoveProduct(stock, "Bread");

            Console.WriteLine("");

            Console.WriteLine();
            PrintStock(stock);

            Console.WriteLine("");

            // Ryhmittely
            Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();
            AddToCategory(categories, "Dairy", "Milk");
            AddToCategory(categories, "Fruit", "Apple");
            AddToCategory(categories, "Fruit", "Banana");

            Console.WriteLine();
            PrintCategories(categories);
        }

        static void PrintStock(Dictionary<string, int> stock)
        {
            foreach (var pair in stock)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }

        static void AddOrIncrease(Dictionary<string, int> stock, string name, int amount)
        {
            // TODO: ContainsKey + Add / kasvatus :DONE
            // Kerrotaan mitä lisätään ja paljonko. Jos tuotetta ei ole, niin kerrotaan siitäkin. 
            // Tämänhän voi muuttaa käyttäjän syötteeksi tulevaisuudessa, jos on tarvis...
            Console.WriteLine($"Adding following product to stock: {name} with amount: {amount}");
            if (stock.ContainsKey(name))
            {
                stock[name] += amount;
            }
            else
            {
                Console.WriteLine($"Product {name} does not exist in stock, adding it with amount: {amount}");
                stock.Add(name, amount);
            }
        }

        static void TrySell(Dictionary<string, int> stock, string name, int amount)
        {
            // TODO: TryGetValue + säännöt :DONE
            // Tarkistaa onko tuotetta varastossa ja onko sitä tarpeeksi. 
            Console.WriteLine($"Trying to sell {amount} of {name}");
            if (stock.TryGetValue(name, out int saldo)) // tuo tuotteen määrä väliaikaiseen muuttujaan, jota verrataan myytävään määrään.
            {
                if (saldo >= amount) //saldoa on riittävästi.
                {
                    Console.WriteLine($"Stock has enough {name}, selling {amount}");
                    stock[name] -= amount;
                }
                else if (saldo < amount) //saldoa on liia vähä.
                {
                    Console.WriteLine($"Not enough {name} in stock.");
                    return;
                }
            }
            else    // Ei ole tuotetta.
            {
                Console.WriteLine($"{name} not found in stock.");
                return;
            }
        }

        static void RemoveProduct(Dictionary<string, int> stock, string name)
        {
            // TODO: Remove + tulostus
            Console.WriteLine($"Trying to remove {name} from stock.");
            if (stock.ContainsKey(name))
            {
                stock.Remove(name);
                Console.WriteLine($"{name} removed from stock.");
            }
            else if (!stock.ContainsKey(name))
            {
                Console.WriteLine($"{name} not found in stock.");
            }

        }

        static void AddToCategory(Dictionary<string, List<string>> categories, string category, string product)
        {
            // TODO: ContainsKey/TryGetValue + lista
        }

        static void PrintCategories(Dictionary<string, List<string>> categories)
        {
            foreach (var pair in categories)
            {
                Console.WriteLine(pair.Key + ":");
                foreach (var product in pair.Value)
                {
                    Console.WriteLine(" - " + product);
                }
            }
        }
    }
}