namespace AoC;

public class Class1
{
    string _input = File.ReadAllText(@"C:\Users\jonhr\Documents\AoC22\AoC22\AoC\Day1\Input.txt");
    
    public Class1()
    {
        //Part 1
        Console.WriteLine("P1: The elf that carry most is carrying: " + calculateMaxCalories(_input, 1));

        //Part 2
        Console.WriteLine("P2: The top 3 elfs that carry the most is carrying: " + calculateMaxCalories(_input, 3));

    }
    public int calculateMaxCalories(string input, int amountElfs)
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
