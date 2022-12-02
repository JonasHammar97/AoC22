namespace AoC;

public class Day2
{
    string _input = File.ReadAllText(@"..\..\..\Day2\Input.txt");
    public Day2()
    {
        Console.WriteLine("Day2");
        List<string> myMoves = new();
        List<string> opMoves = new();
        foreach (var match in _input.Split('\n'))
        {
            opMoves.Add(match.Split(' ')[0]);
            myMoves.Add(match.Split(' ')[1].Replace("\r",""));
        }
        //Part 1
        Console.WriteLine("P1: Total score if the semi-correct guide is followed: " + scoreAccordingToStartegy(opMoves, myMoves, true));
        //Part 2
        Console.WriteLine("P2: Total score if the orrect guide is followed: " + scoreAccordingToStartegy(opMoves, myMoves, false));
    }
    public int scoreAccordingToStartegy(List<string> opMoves, List<string> myMoves, bool p1)
    {
        int sum = 0;
        for (int i = 0; i < opMoves.Count; i++) 
        {
            if (p1)
                sum += calcOutcomeP1(opMoves[i], myMoves[i]);
            else
                sum += calcOutcomeP2(opMoves[i], myMoves[i]);
        }
        return sum;
    }
    int calcOutcomeP1(string op, string my)
    {
        if (my == "X")
        {
            if (op == "C")
                return 7;
            if (op == "A")
                return 4;
            return 1;
        }
        if (my == "Y")
        {
            if (op == "A")
                return 8;

            if (op == "B")
                return 5;

            return 2;
        }
        if (my == "Z")
        {
            if (op == "B")
                return 9;
            if (op == "C")
                return 6;
            return 3;
        }
        return -1;
    }

    int calcOutcomeP2(string op, string outcome)
    {
        int moveScore = 0;
        if(op =="A")
            moveScore = 1;
        if (op == "B")
            moveScore = 2;
        if (op == "C")
            moveScore = 3;

        switch (outcome)
        {
            case "X":
                return moveScore == 1 ? 3 : (moveScore - 1);
            case "Y":
                return moveScore + 3;
            case "Z":
                return moveScore == 3 ? 1 + 6 : (moveScore + 1) + 6;

        }
        return 0;
    }
}
