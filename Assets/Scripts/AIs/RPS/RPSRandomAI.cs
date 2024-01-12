using System;

// RPS AI that always chooses a hand at random
public class RPSRandomAI : RPSOpponentAI
{
    private System.Random _random;
    private string _seedType;

    // Constructors
    public RPSRandomAI()
    {
        _random = new System.Random();
        _seedType = "seeded by the current timestamp";
    }
    public RPSRandomAI(int seed)
    {
        _random = new System.Random(seed);
        _seedType = $"with seed of {seed}";
    }

    // Functions
    protected override RPSHand GetHand()
    {
        RPSHand hand = (RPSHand)Enum.ToObject(typeof(RPSHand), _random.Next(3));
        return hand;
    }

    public override string ToString()
    {
        return $"Random AI {_seedType}";
    }
}