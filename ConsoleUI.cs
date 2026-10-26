using System;

namespace lab2
{
    public class ConsoleUI
    {
        public void Show(string text) => Console.WriteLine(text);
        public string Ask(string prompt) { Console.Write(prompt); return Console.ReadLine(); }
        public void ShowWork(Work work) => Console.WriteLine(work.Describe());
    }
}

