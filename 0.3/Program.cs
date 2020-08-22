using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0._3_FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] fakeCommand = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string composer = fakeCommand[1];
                string key = fakeCommand[2];
                var list = new List<string>();
                list.Add(composer);
                list.Add(key);
                dictionary.Add(fakeCommand[0], list);
            }
            string[] command = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Stop")
            {
                if (command[0] == "Add")
                {
                    if (!dictionary.ContainsKey(command[1]))
                    {
                        var list = new List<string>();
                        list.Add(command[2]);
                        list.Add(command[3]);
                        dictionary.Add(command[1], list);
                        Console.WriteLine($"{command[1]} by {command[2]} in {command[3]} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{command[1]} is already in the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (dictionary.ContainsKey(command[1]))
                    {
                        dictionary.Remove(command[1]);
                        Console.WriteLine($"Successfully removed {command[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                    }
                }
                else if (command[0] == "ChangeKey")
                {
                    if (dictionary.ContainsKey(command[1]))
                    {
                        dictionary[command[1]][1] = command[2];
                        Console.WriteLine($"Changed the key of {command[1]} to {command[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                    }
                }
                command = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }
            var sorted = dictionary.OrderBy(x => x.Key).ThenBy(x => x.Value[0]);
            foreach (var item in sorted)
            {
                string piece = item.Key;
                string composer = item.Value[0];
                string key = item.Value[1];
                Console.WriteLine($"{piece} -> Composer: {composer}, Key: {key}");
            }
        }
    }
}
