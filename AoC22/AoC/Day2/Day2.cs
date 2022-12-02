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
                sum += CalcOutcomeP1(GetValue(opMoves[i]), GetValue(myMoves[i]));
            else
                sum += CalcOutcomeP2(opMoves[i], myMoves[i]);
        }
        return sum;
    }
    static int CalcOutcomeP1(int op, int me)
    {
        if (me == op)
            return me + 3; // Draw
        if (GetNext(me) == op)
            return me; //Loss
        if (GetPrevious(me) == op)
            return me + 6; //Win
        return -1;

    }

    static int CalcOutcomeP2(string op, string outcome)
    {
        int moveScore = GetValue(op);

        return outcome switch
        {
            "X" => moveScore == 1 ? 3 : (moveScore - 1),
            "Y" => moveScore + 3,
            "Z" => moveScore == 3 ? 1 + 6 : (moveScore + 1) + 6,
            _ => 0,
        };
    }
    private static int GetPrevious(int move)
    {
        return move == 1 ? 3 : move - 1;
    }
    private static int GetNext(int move)
    {
        return move == 3 ? 1 : move + 1;
    }
    private static int GetValue(string move) => move switch
    {
        "A" or "X" => 1,
        "B" or "Y" => 2,
        "C" or "Z" => 3,
    };
}
