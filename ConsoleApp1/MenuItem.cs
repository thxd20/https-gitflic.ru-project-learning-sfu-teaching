using System;

namespace lab3
{
    public class MenuItem
    {
        public string Title { get; }
        private readonly Action _action;


        public MenuItem(string title, Action action)
        {
            Title = title;
            _action = action;
        }

        public void Run()
        {
            _action?.Invoke();
        }
    }
}

