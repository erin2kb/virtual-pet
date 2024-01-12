// RPS AI that always uses the same sequence of hands
public class RPSSequenceAI : RPSOpponentAI
{
    private RPSHand[] _handSequence;
    private int _currentIndex = 0;

    // Constructor
    public RPSSequenceAI(RPSHand[] seq)
    {
        _handSequence = seq;
    }

    // Functions
    protected override RPSHand GetHand()
    {
        RPSHand handToPlay = _handSequence[_currentIndex];
        // reset the current index if we've reached the end of the sequence, else increment it
        _currentIndex = (_currentIndex >= _handSequence.Length - 1) ? 0 : _currentIndex + 1;
        return handToPlay;
    }

    private string GetSequenceString()
    {
        string sequence = "";
        for (int i = 0; i < _handSequence.Length; i++)
        {
            sequence += $"{_handSequence[i]} ";
        }
        return sequence;
    }

    public override string ToString()
    {
        return $"Sequence AI with chosen sequence of {GetSequenceString()}";
    }
}