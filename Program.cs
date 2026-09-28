using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string path = Path.Combine(desktop, "graph.txt");

        if (!File.Exists(path))
        {
            File.WriteAllLines(path, new string[]
            {
                "A -> B",
                "A -> C",
                "A -> D",
                "B -> C",
                "B -> E",
                "C -> E",
                "D -> E",
                "E -> A"
            });
            Console.WriteLine("Создан пример graph.txt на рабочем столе.");
        }


        Dictionary<string, List<string>> graph = BuildGraph(path);


        Console.WriteLine("\n=== Списки смежности ===");
        PrintGraph(graph);
    }

    static Dictionary<string, List<string>> BuildGraph(string path)
    {
        var graph = new Dictionary<string, List<string>>();

        foreach (string line in File.ReadAllLines(path))
        {

            if (string.IsNullOrWhiteSpace(line)) continue;


            string normalized = line.Replace("→", "->");
            string[] parts = normalized.Split(new[] { "->" }, StringSplitOptions.None);

            if (parts.Length != 2) continue; 

            string from = parts[0].Trim();
            string to = parts[1].Trim();


            if (!graph.ContainsKey(from)) graph[from] = new List<string>();
            if (!graph.ContainsKey(to)) graph[to] = new List<string>();

            graph[from].Add(to);
        }

        return graph;
    }

    static void PrintGraph(Dictionary<string, List<string>> graph)
    {

        var sortedKeys = new List<string>(graph.Keys);
        sortedKeys.Sort();

        foreach (string node in sortedKeys)
        {
            string neighbors = string.Join(", ", graph[node]);
            Console.WriteLine($"({node}, [{neighbors}])");
        }
    }
}