using System;
using System.IO;

class Program
{
    static void Main()
    {

        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string path = Path.Combine(desktop, "field.txt");

        Console.WriteLine($"Ищу файл: {path}");


        if (!File.Exists(path))
        {
            File.WriteAllLines(path, new string[]
            {
                "#.#.#",
                ".##..",
                "#...#",
                "..#.#",
                "#..#."
            });
            Console.WriteLine("Файл не найден. Создан новый field.txt на рабочем столе.");
        }


        string[] field = File.ReadAllLines(path);

        Console.WriteLine("\n=== Исходное поле ===");
        PrintField(field);

        Console.Write("\nВведите X (столбец): ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("X должен быть числом!");
            return;
        }

        Console.Write("Введите Y (строка): ");
        if (!int.TryParse(Console.ReadLine(), out int y))
        {
            Console.WriteLine("Y должен быть числом!");
            return;
        }

        
        if (y < 0 || y >= field.Length || x < 0 || x >= field[y].Length)
        {
            Console.WriteLine("Координаты за пределами поля!");
            return;
        }

        char cell = field[y][x];

        if (cell == '#')
        {
            char[] row = field[y].ToCharArray();
            row[x] = '*';
            field[y] = new string(row);
            Console.WriteLine("\n>>> Попадание! Решётка заменена на *");
        }
        else if (cell == '.')
        {
            Console.WriteLine("\n>>> Здесь точка. Ничего не меняем.");
        }
        else
        {
            Console.WriteLine($"\n>>> Неизвестный символ: {cell}");
        }

        Console.WriteLine("\n=== Поле после ===");
        PrintField(field);

        File.WriteAllLines(path, field);
        Console.WriteLine($"\nИзменения сохранены в {path}");
    }

    static void PrintField(string[] field)
    {
        for (int i = 0; i < field.Length; i++)
        {
            Console.WriteLine(field[i]);
        }
    }
}
