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
            ReplaceArea(field, x, y);  
            Console.WriteLine("\n>>> Попадание! Решётки в зоне заменены на *");
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

 
    static void ReplaceArea(string[] field, int x, int y)
    {

        for (int dy = -1; dy <= 1; dy++)
        {

            for (int dx = -1; dx <= 1; dx++)
            {
                int nx = x + dx;  
                int ny = y + dy;  

           
                if (ny < 0 || ny >= field.Length) continue;
                if (nx < 0 || nx >= field[ny].Length) continue;

               
                if (field[ny][nx] == '#')
                {
                    char[] row = field[ny].ToCharArray();
                    row[nx] = '*';
                    field[ny] = new string(row);
                }
            }
        }
    }

    static void PrintField(string[] field)
    {
        for (int i = 0; i < field.Length; i++)
        {
            Console.WriteLine(field[i]);
        }
    }
}
