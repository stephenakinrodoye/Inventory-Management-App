using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace InventoryManagement
{
    public class Item
    {
        public string Id { get; set; }
        public string ShortName { get; set; }
        public string LongDesc { get; set; }
        public double Price { get; set; }

        public Item(string id, string shortName, string longDesc, double price)
        {
            Id = id;
            ShortName = shortName;
            LongDesc = longDesc;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Short Name: {ShortName}, Description: {LongDesc}, Price: {Price:C}";
        }
    }

    class Program
    {
        static List<Item> inventory = new List<Item>();

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Insert New Item");
                Console.WriteLine("2. Display an Item");
                Console.WriteLine("3. Display All Item");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        InsertItem();
                        break;
                    case "2":
                        DisplayItem();
                        break;
                    case "3":
                        DisplayAllItems();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }
            }

            Console.WriteLine("Program exited.");
        }

        static void InsertItem()
        {
            do
            {
                Console.Write("\nEnter ID (3-digit number): ");
                string id = Console.ReadLine();

                if (id.Length != 3 || !int.TryParse(id, out _))
                {
                    Console.WriteLine("Invalid ID. Must be a 3-digit numeric string.");
                    continue;
                }

                Console.Write("Enter Short Name: ");
                string shortName = Console.ReadLine();

                Console.Write("Enter Long Description: ");
                string longDesc = Console.ReadLine();

                Console.Write("Enter Price: ");
                string priceInput = Console.ReadLine();

                if (!double.TryParse(priceInput, out double price))
                {
                    Console.WriteLine("Invalid price. Please enter a numeric value.");
                    continue;
                }

                Item newItem = new Item(id, shortName, longDesc, price);
                inventory.Add(newItem);
                Console.WriteLine("Item added successfully!");

                Console.Write("Do you want to add another item? (Y/N): ");
            }
            while (Console.ReadLine().Trim().ToUpper() == "Y");
        }

        static void DisplayItem()
        {
            Console.Write("\nEnter the ID of the item to display: ");
            string searchId = Console.ReadLine();

            Item foundItem = inventory.Find(item => item.Id == searchId);

            if (foundItem != null)
            {
                Console.WriteLine("\nItem Found:");
                Console.WriteLine(foundItem);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        static void DisplayAllItems()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("\nNo items in inventory.");
                return;
            }

            Console.WriteLine("\nID\tShort Name\tLong Description\tPrice");
            foreach (Item item in inventory)
            {
                Console.WriteLine($"{item.Id}\t{item.ShortName}\t\t{item.LongDesc}\t\t{item.Price:C}");
            }
        }
    }
}