namespace AoC;

public class Day1
{
    readonly string _input = File.ReadAllText(@"..\..\..\Day1\Input.txt");
    public Day1()
    {
        Console.WriteLine("Day1");
        //Part 1
        Console.WriteLine("P1: The elf that carry most is carrying: " + CalculateMaxCalories(_input, 1));
        //Part 2
        Console.WriteLine("P2: The top 3 elfs that carry the most is carrying: " + CalculateMaxCalories(_input, 3));
    }
     static int CalculateMaxCalories(string input, int amountElfs)
    {
        var elfs = input.Split(new string[] { "\r\n\r\n" },
                       StringSplitOptions.RemoveEmptyEntries);
        var calPerElf = new List<int>();

        foreach (var elf in elfs)
        {
            var food = elf.Split("\n");
            var temp = 0;
            foreach (var cal in food)
                temp += int.Parse(cal);

            calPerElf.Add(temp);
        }
        return calPerElf.OrderByDescending(x => x).Take(amountElfs).Sum();

    }
}
