namespace AoC;

public class Day2
{
    readonly string _input = File.ReadAllText(@"..\..\..\Day2\Input.txt");
    public Day2()
    {
        Console.WriteLine("Day2");
        List<string> myMoves = new();
        List<string> opMoves = new();
        foreach (var match in _input.Split('\n'))
        {
            opMoves.Add(match.Split(' ')[0]);
            myMoves.Add(match.Split(' ')[1].Replace("\r", ""));
        }
        //Part 1
        Console.WriteLine("P1: Total score if the semi-correct guide is followed: " + ScoreAccordingToStartegy(opMoves, myMoves, true));
        //Part 2
        Console.WriteLine("P2: Total score if the orrect guide is followed: " + ScoreAccordingToStartegy(opMoves, myMoves, false));
    }
    static int ScoreAccordingToStartegy(List<string> opMoves, List<string> myMoves, bool p1)
    {
        int sum = 0;
        for (int i = 0; i < opMoves.Count; i++)
        {
            if (p1)
                sum += CalcOutcomeP1(opMoves[i], myMoves[i]);
            else
                sum += CalcOutcomeP2(opMoves[i], myMoves[i]);
        }
        return sum;
    }
    static int CalcOutcomeP1(string op, string my)
    {
        switch (my)
        {
            case "X":
                if (op == "C")
                    return 7;
                if (op == "A")
                    return 4;
                return 1;

            case "Y":
                if (op == "A")
                    return 8;
                if (op == "B")
                    return 5;
                return 2;

            case "Z":
                if (op == "B")
                    return 9;
                if (op == "C")
                    return 6;
                return 3;
            default:
                return -1;
        }
    }

    static int CalcOutcomeP2(string op, string outcome)
    {
        int moveScore = 0;
        if (op == "A")
            moveScore = 1;
        if (op == "B")
            moveScore = 2;
        if (op == "C")
            moveScore = 3;

        return outcome switch
        {
            "X" => moveScore == 1 ? 3 : (moveScore - 1),
            "Y" => moveScore + 3,
            "Z" => moveScore == 3 ? 1 + 6 : (moveScore + 1) + 6,
            _ => 0,
        };
    }
}
