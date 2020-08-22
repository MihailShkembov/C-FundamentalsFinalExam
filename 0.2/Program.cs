using System;
using System.Text.RegularExpressions;

namespace _0._2FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([|#])(?<food>[A-Za-z\s]+)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<cal>[0-9]+)\1";
            var matches = Regex.Matches(input, pattern);
            int totalCal = 0;
            foreach (Match match in matches)
            {
                totalCal += int.Parse(match.Groups["cal"].Value);
            }
            int daysOfSurvive = totalCal / 2000;
            Console.WriteLine($"You have food to last you for: {daysOfSurvive} days!");
            foreach (Match match in matches)
            {
                string food = match.Groups["food"].Value;
                int curCalories = int.Parse(match.Groups["cal"].Value);
                string date = match.Groups["date"].Value;
                Console.WriteLine($"Item: {food}, Best before: {date}, Nutrition: {curCalories}");

            }
        }
    }
}
