using System.Linq;
using System.Text.RegularExpressions;

namespace AoC;

public class Day5
{
    readonly string _input = File.ReadAllText(@"..\..\..\Day5\Input.txt");
    public List<Stack<char>> Stacks = new();
    public Day5()
    {

        Console.WriteLine("Day5");

        //Part 1
        initStack();
        Console.WriteLine($"P1: {P1(_input)} " +
            $"{Stacks[0].Pop()}{Stacks[1].Pop()}{Stacks[2].Pop()}" +
            $"{Stacks[3].Pop()}{Stacks[4].Pop()}{Stacks[5].Pop()}" +
            $"{Stacks[6].Pop()}{Stacks[7].Pop()}{Stacks[8].Pop()}");
        //Part 2
        initStack();
        Console.WriteLine($"P2: {P2(_input)} " +
            $"{Stacks[0].Pop()}{Stacks[1].Pop()}{Stacks[2].Pop()}" +
            $"{Stacks[3].Pop()}{Stacks[4].Pop()}{Stacks[5].Pop()}" +
            $"{Stacks[6].Pop()}{Stacks[7].Pop()}{Stacks[8].Pop()}");
    }

    public string P1(string input)
    {
        var temp = input.Split(new string[] { "\r\n\r\n" },
                       StringSplitOptions.RemoveEmptyEntries);

        var moveOrders = temp[1].Split('\n');


        foreach (var moveOrder in moveOrders)
        {
            Match match = Regex.Match(moveOrder, @"move (\d{1,2}) from (\d{1,2}) to (\d{1,2})");
            if (match.Success)
            {
                int nrOfCrates = int.Parse(match.Groups[1].Value);
                int source = int.Parse(match.Groups[2].Value) - 1;
                int destination = int.Parse(match.Groups[3].Value) - 1;

                for(int i = 0; i < nrOfCrates; i++)
                {
                    Stacks[destination].Push(Stacks[source].Pop());
                }
            }
        }

        return String.Empty;
    }


    public string P2(string input)
    {
        var temp = input.Split(new string[] { "\r\n\r\n" },
                       StringSplitOptions.RemoveEmptyEntries);

        var moveOrders = temp[1].Split('\n');


        foreach (var moveOrder in moveOrders)
        {
            Match match = Regex.Match(moveOrder, @"move (\d{1,2}) from (\d{1,2}) to (\d{1,2})");
            if (match.Success)
            {
                int nrOfCrates = int.Parse(match.Groups[1].Value);
                int source = int.Parse(match.Groups[2].Value) - 1;
                int destination = int.Parse(match.Groups[3].Value) - 1;

                if(nrOfCrates == 1)
                    Stacks[destination].Push(Stacks[source].Pop());
                else
                {
                    Stack<char> tempStack = new();
                    for(int i = 0; i < nrOfCrates; i++)
                        tempStack.Push(Stacks[source].Pop());
                    for(int i = 0; i < nrOfCrates; i++)
                        Stacks[destination].Push(tempStack.Pop());
                }
            }
        }

        return String.Empty;
    }

    private void initStack()
    {
        Stacks.AddRange(new Stack<char>[] {
            new Stack<char>(), new Stack<char>(), new Stack<char>(), // 1 2 3
            new Stack<char>(), new Stack<char>(), new Stack<char>(), // 4 5 6
            new Stack<char>(), new Stack<char>(), new Stack<char>()  // 7 8 9
        });

        Stacks[0].Push('Z'); Stacks[0].Push('T'); Stacks[0].Push('F'); Stacks[0].Push('R');
        Stacks[0].Push('W'); Stacks[0].Push('J'); Stacks[0].Push('G');

        Stacks[1].Push('G'); Stacks[1].Push('W'); Stacks[1].Push('M');

        Stacks[2].Push('J'); Stacks[2].Push('N'); Stacks[2].Push('H'); Stacks[2].Push('G');

        Stacks[3].Push('J'); Stacks[3].Push('R'); Stacks[3].Push('C'); Stacks[3].Push('N');
        Stacks[3].Push('W');

        Stacks[4].Push('W'); Stacks[4].Push('F'); Stacks[4].Push('S'); Stacks[4].Push('B');
        Stacks[4].Push('G'); Stacks[4].Push('Q'); Stacks[4].Push('V'); Stacks[4].Push('M');

        Stacks[5].Push('S'); Stacks[5].Push('R'); Stacks[5].Push('T'); Stacks[5].Push('D');
        Stacks[5].Push('V'); Stacks[5].Push('W'); Stacks[5].Push('C');

        Stacks[6].Push('H'); Stacks[6].Push('B'); Stacks[6].Push('N'); Stacks[6].Push('C');
        Stacks[6].Push('D'); Stacks[6].Push('Z'); Stacks[6].Push('G'); Stacks[6].Push('V');

        Stacks[7].Push('S'); Stacks[7].Push('J'); Stacks[7].Push('N'); Stacks[7].Push('M');
        Stacks[7].Push('G'); Stacks[7].Push('C');

        Stacks[8].Push('G'); Stacks[8].Push('P'); Stacks[8].Push('N'); Stacks[8].Push('W');
        Stacks[8].Push('C'); Stacks[8].Push('J'); Stacks[8].Push('D'); Stacks[8].Push('L');
    }
}
