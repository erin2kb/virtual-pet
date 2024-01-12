// RPS AI that always chooses the same hand
public class RPSConsistentAI : RPSOpponentAI
{
    private RPSHand _handOfChoice;

    // Constructor
    public RPSConsistentAI(RPSHand h)
    {
        _handOfChoice = h;
    }

    // Functions
    protected override RPSHand GetHand()
    {
        return _handOfChoice;
    }

    public override string ToString()
    {
        return $"Consistent AI with chosen hand of {_handOfChoice}";
    }
}