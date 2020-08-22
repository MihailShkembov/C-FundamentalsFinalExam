using System;
using System.Linq;
using System.Text;

namespace _0._3_FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypted = Console.ReadLine();
            string[] command = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Decode")
            {
                if (command[0] == "Move")
                {
                    int number = int.Parse(command[1]);
                    var sb = new StringBuilder(encrypted);
                    string temp = encrypted.Substring(0, number);
                    encrypted = encrypted.Replace(temp, "");
                    encrypted += temp;
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    encrypted = encrypted.Insert(index, command[2]);
                }
                else if (command[0] == "ChangeAll")
                {
                    encrypted = encrypted.Replace(command[1], command[2]);

                }
                command = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"The decrypted message is: {encrypted}");
        }
    }
}
