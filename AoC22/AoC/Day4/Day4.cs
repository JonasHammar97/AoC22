using System.Reflection.Emit;

namespace AoC;

public class Day4
{
    readonly string _input = File.ReadAllText(@"..\..\..\Day4\Input.txt");
    public Day4()
    {
        Console.WriteLine("Day4");

        //Part 1
        Console.WriteLine($"P1: {P1(_input)} assignment pairs is fully contained in others");
        //Part 2
        Console.WriteLine($"P2: {P2(_input)} assignment pairs have overlapping ranges");
    }

    static int P1(string input)
    {
        int sum = 0;
        var pairs = input.Split('\n');
        foreach (var pair in pairs)
            sum += GetFullOverlap(pair);


        return sum;
    }
    static int P2(string input)
    {
        int sum = 0;
        var pairs = input.Split('\n');
        foreach (var pair in pairs)
            sum += GetPartialOverlap(pair);


        return sum;
    }

    private static int GetFullOverlap(string pair)
    {
        Worker wOne = new Worker(pair.Split(',')[0]);
        Worker wTwo = new Worker(pair.Split(',')[1]);

        if ((wOne.min <= wTwo.min && wOne.max >= wTwo.max) || (wTwo.min <= wOne.min && wTwo.max >= wOne.max))
            return 1;


        return 0;
    }

    private static int GetPartialOverlap(string pair)
    {

        Worker wOne = new Worker(pair.Split(',')[0]);
        Worker wTwo = new Worker(pair.Split(',')[1]);

        if (TestRange(wOne.min, wTwo.min, wTwo.max) || TestRange(wOne.max, wTwo.min, wTwo.max))
            return 1;

        if (TestRange(wTwo.min, wOne.min, wOne.max) || TestRange(wTwo.max, wOne.min, wOne.max))
            return 1;
        

        return 0;
    }
    static bool TestRange(int numberToCheck, int bottom, int top)
    {
        return (numberToCheck >= bottom && numberToCheck <= top);
    }

    class Worker
    {
        public Worker(string _range)
        {
            range = _range;
            min = int.Parse(range.Split('-')[0]);
            max = int.Parse(range.Split('-')[1]);
        }
        public string range { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}
