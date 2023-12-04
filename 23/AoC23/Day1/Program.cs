using System.Linq;
using System.Text.RegularExpressions;

var _input = File.ReadAllText("Input.txt");
var _testInput1 = File.ReadAllText("TestInput1.txt");
var _testInput2 = File.ReadAllText("TestInput2.txt");

//Part 1
Console.WriteLine("Part 1");
Console.WriteLine("TestInput1:" + FindSum(_testInput1, @"\d"));
Console.WriteLine("Input:" + FindSum(_input, @"\d"));

Console.WriteLine("\nPart 2");
Console.WriteLine("TestInput2:" + FindSum(_testInput2,@"\d|one|two|three|four|five|six|seven|eight|nine"));
Console.WriteLine("Input:" + FindSum(_input, @"\d|one|two|three|four|five|six|seven|eight|nine"));


int FindSum(string input, string condition) => (
        from line in input.Split("\n")
        let first = Regex.Match(line, condition)
        let last = Regex.Match(line, condition, RegexOptions.RightToLeft)
        select ConvertStringToInt(first.Value) * 10 + ConvertStringToInt(last.Value)
    ).Sum();

int ConvertStringToInt(string str) => str switch
{
    "one" => 1,
    "two" => 2,
    "three" => 3,
    "four" => 4,
    "five" => 5,
    "six" => 6,
    "seven" => 7,
    "eight" => 8,
    "nine" => 9,
    var d => int.Parse(d)
};

