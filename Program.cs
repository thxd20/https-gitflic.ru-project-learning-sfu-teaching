using System;
using System.Collections.Generic;
using System.IO;

namespace lab2
{
    class Program
    {
        static readonly List<Work> works = new List<Work>();
        static readonly ConsoleUI ui = new ConsoleUI();

        static void Main()
        {
            var menu = new Menu(ui);

            
            menu.Add("Добавить лабораторную", AddLab);
            menu.Add("Добавить курсовую", AddCourse);
            menu.Add("Добавить дипломную", AddDiploma);
            menu.Add("Добавить контрольную", AddTest);
            menu.Add("Загрузить из файла", LoadFromFile);
            menu.Add("Загрузить из строки", LoadFromString);
            menu.Add("Показать всё", ShowAll);

            menu.Add("Выход", () => Environment.Exit(0));

            menu.Run();
        }

        static void AddLab() { var (s, t, d) = AskCommon(); works.Add(new LabWork(s, t, d)); ui.Show("Добавлено"); }
        static void AddCourse() { var (s, t, d) = AskCommon(); works.Add(new CourseWork(s, t, d, ui.Ask("Руководитель: "))); ui.Show("Добавлено"); }
        static void AddDiploma() { var (s, t, d) = AskCommon(); works.Add(new DiplomaWork(s, t, d, ui.Ask("Руководитель: "), int.Parse(ui.Ask("Оценка: ")))); ui.Show("Добавлено"); }
        static void AddTest() { var (s, t, d) = AskCommon(); works.Add(new TestWork(s, t, d, ui.Ask("Преподаватель: "), int.Parse(ui.Ask("Вопросов: ")))); ui.Show("Добавлено"); }

        static (string, string, DateTime) AskCommon()
        {
            string s = ui.Ask("Студент: ");
            string t = ui.Ask("Тема: ");
            DateTime d = DateTime.ParseExact(ui.Ask("Дата (гггг.мм.дд): ").Trim(), "yyyy.MM.dd", null);
            return (s, t, d);
        }

        static void LoadFromFile()
        {
            string path = ui.Ask("Путь к файлу: ");
            if (!File.Exists(path)) { ui.Show("Нет файла"); return; }
            foreach (string line in File.ReadAllLines(path)) TryAdd(line);
        }

        static void LoadFromString()
        {
            ui.Show("Введите строки (пустая — конец):");
            string line;
            while (!string.IsNullOrWhiteSpace(line = ui.Ask(""))) TryAdd(line);
        }

        static void TryAdd(string line)
        {
            try { works.Add(WorkParser.Parse(line)); }
            catch (Exception ex) { ui.Show($"Ошибка: {ex.Message}"); }
        }

        static void ShowAll()
        {
            ui.Show($"\n=== Всего работ: {works.Count} ===");
            foreach (Work w in works) ui.ShowWork(w);
        }
    }
}

