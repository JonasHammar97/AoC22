
using System.Text.RegularExpressions;

var _input = File.ReadAllText("Input.txt");
var _testInput1 = File.ReadAllText("TestInput1.txt");
var _testInput2 = File.ReadAllText("TestInput2.txt");

//Part 1
Console.WriteLine("Part 1");
Console.WriteLine("TestInput1:" + FindSumOfGamesUnderOrEqualToThreshold(_testInput1));
Console.WriteLine("Input:" + FindSumOfGamesUnderOrEqualToThreshold(_input));

Console.WriteLine("\nPart 2");
Console.WriteLine("TestInput2:" + FindSumOfPowersOfSets(_testInput2));
Console.WriteLine("Input:" + FindSumOfPowersOfSets(_input));


int FindSumOfGamesUnderOrEqualToThreshold(string input) => (
        from line in input.Split("\n")
        let Game = ParseGame(line)
        where Game.Red <= 12 && Game.Green <= 13 && Game.Blue <= 14
        select Game.GameId
        ).Sum();

int FindSumOfPowersOfSets(string input) => (
        from line in input.Split("\n")
        let Game = ParseGame(line)
        select Game.Red * Game.Green * Game.Blue
        ).Sum();

(int GameId, int Red, int Green, int Blue) ParseGame(string line)
{
    var gameId = ParseValues(line, @"Game (\d+)").First();
    var maxRed = ParseValues(line, @"(\d+) red").Max();
    var maxGreen = ParseValues(line, @"(\d+) green").Max();
    var maxBlue = ParseValues(line, @"(\d+) blue").Max();
    return (gameId, maxRed, maxGreen, maxBlue);
}

IEnumerable<int> ParseValues(string st, string rx) =>
    from m in Regex.Matches(st, rx)
    select int.Parse(m.Groups[1].Value);