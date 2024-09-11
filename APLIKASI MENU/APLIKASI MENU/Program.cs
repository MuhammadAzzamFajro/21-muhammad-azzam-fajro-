using System;

class Program
{
    static void Main()
    {
        // Menu
        string[,] makanan = {
            {"Nasi Goreng", "12000"},
            {"Nasi Uduk", "9000"},
            {"Nasi Kucing", "8000"},
            {"Mie Rebus", "7000"},
            {"Mie Goreng", "9000"},
            {"Mie Ayam", "13000"}
        };

        string[,] minuman = {
            {"Teh Botol", "5000"},
            {"Teh Pucuk", "4000"},
            {"Susu Jahe", "6000"},
            {"Kopi Jahe", "5000"},
            {"Kopi Susu", "5000"},
            {"Tea Jus", "0"} // Free item
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("============== MENU PESANAN ==============");
            Console.WriteLine("1. Makanan");
            for (int i = 0; i < makanan.GetLength(0); i++)
            {
                Console.WriteLine($"{(char)('a' + i)}. {makanan[i, 0]} - Rp. {makanan[i, 1]}");
            }

            Console.WriteLine("\n2. Minuman");
            for (int i = 0; i < minuman.GetLength(0); i++)
            {
                Console.WriteLine($"{(char)('a' + i)}. {minuman[i, 0]} - Rp. {minuman[i, 1]}");
            }

            Console.WriteLine("\n==========================================");
            Console.Write("Pesanan contoh 1a: ");
            string input = Console.ReadLine();
            if (input.Length < 2)
            {
                Console.WriteLine("Input tidak valid! Pastikan formatnya benar.");
                continue;
            }

            // Parsing menu input
            int menuType;
            char menuCode = input[1];
            if (!int.TryParse(input[0].ToString(), out menuType) || (menuType != 1 && menuType != 2) || !char.IsLetter(menuCode))
            {
                Console.WriteLine("Input tidak valid! Pastikan formatnya benar.");
                continue;
            }

            int menuIndex = menuCode - 'a';

            string itemName;
            int price;

            if (menuType == 1 && menuIndex < makanan.GetLength(0))
            {
                itemName = makanan[menuIndex, 0];
                price = int.Parse(makanan[menuIndex, 1]);
            }
            else if (menuType == 2 && menuIndex < minuman.GetLength(0))
            {
                itemName = minuman[menuIndex, 0];
                price = int.Parse(minuman[menuIndex, 1]);
            }
            else
            {
                Console.WriteLine("Menu tidak valid!");
                continue;
            }

            int quantity;
            Console.Write($"Berapa Banyak yang dipesan untuk {itemName}: ");
            if (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.WriteLine("Jumlah tidak valid! Harus lebih dari 0.");
                continue;
            }

            int total = price * quantity;

            Console.WriteLine($"\nAnda memesan {quantity} {itemName}, Total Harga: Rp. {total}");
            Console.WriteLine("Terima Kasih!");

            // End program or continue
            Console.Write("\nPesan lagi? (y/n): ");
            string repeat = Console.ReadLine();
            if (repeat?.ToLower() != "y")
                break;
        }
    }
}