using System;

public class StudentWork
{
    public string Name { get; set; }
    public string Topic { get; set; }
    public DateTime Date { get; set; }

    public StudentWork(string name, string topic, DateTime date)
    {
        Name = name;
        Topic = topic;
        Date = date;
    }

    public static StudentWork FromString(string text)
    {
        string[] parts = text.Split(',');

        if (parts.Length < 3)
            throw new FormatException("Нужно три значения: имя, тема, дата");

        string name = Clean(parts[0]);
        string topic = Clean(parts[1]);
        string dateStr = Clean(parts[2]);

        DateTime date = DateTime.ParseExact(dateStr, "yyyy.MM.dd", null);

        return new StudentWork(name, topic, date);
    }

    private static string Clean(string s)
    {
        return s.Trim().Trim('"', '«', '»', ' ').Trim();
    }

    public override string ToString()
    {
        return $"Имя студента: {Name}\n" +
               $"Название темы: {Topic}\n" +
               $"Дата выдачи: {Date:yyyy.MM.dd}";
    }
}

public class App
{
    public void Run()
    {
        while (true)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InputData();
                    break;
                case "2":
                    Console.WriteLine("Программа завершена.");
                    return; 
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\n===== МЕНЮ =====");
        Console.WriteLine("1 - Ввести данные");
        Console.WriteLine("2 - Выход");
        Console.Write("Ваш выбор: ");
    }

    private void InputData()
    {
        Console.Write("\nВведите данные (например: «John», «ооп», 2024.12.12): ");
        string text = Console.ReadLine();

        try
        {
            StudentWork work = StudentWork.FromString(text);
            Console.WriteLine("\n--- Результат ---");
            Console.WriteLine(work);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        App app = new App();
        app.Run();
    }
}
