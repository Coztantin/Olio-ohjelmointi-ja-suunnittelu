using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>();

        stock.Add("Milk", 10);
        stock.Add("Bread", 5);
        stock.Add("Apple", 20);

        PrintStock(stock);

        AddOrIncrease(stock, "Milk", 3);
        AddOrIncrease(stock, "Banana", 7);

        TrySell(stock, "Apple", 5);
        TrySell(stock, "Apple", 500);
        TrySell(stock, "Cheese", 1);

        RemoveProduct(stock, "Bread");
        RemoveProduct(stock, "Bread");

        Console.WriteLine();
        PrintStock(stock);

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
        // TODO: ContainsKey + Add / kasvatus
    }

    static void TrySell(Dictionary<string, int> stock, string name, int amount)
    {
        // TODO: TryGetValue + säännöt
    }

    static void RemoveProduct(Dictionary<string, int> stock, string name)
    {
        // TODO: Remove + tulostus
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
