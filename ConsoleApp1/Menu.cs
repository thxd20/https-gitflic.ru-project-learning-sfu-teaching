using Lab3;
using System;
using System.Collections.Generic;

namespace lab3
{
    public class Menu
    {
        private readonly List<MenuItem> _items = new List<MenuItem>();
        private readonly ConsoleUI _ui;

        public Menu(ConsoleUI ui)
        {
            _ui = ui;
        }

        public void Add(string title, Action action)
        {
            _items.Add(new MenuItem(title, action));
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();

                for (int i = 0; i < _items.Count; i++)
                {
                    _ui.Show($"{i + 1} - {_items[i].Title}");
                }

                string input = _ui.Ask("\nВаш выбор: ");

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= _items.Count)
                {

                    _items[choice - 1].Run();

                    if (choice != _items.Count)
                    {
                        _ui.Show("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    _ui.Show($"Неверный выбор! Введите число от 1 до {_items.Count}");
                    Console.ReadKey();
                }
            }
        }
    }
}
