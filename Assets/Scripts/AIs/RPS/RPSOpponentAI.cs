public abstract class RPSOpponentAI : AIOpponent
{
    protected abstract RPSHand GetHand();
    public RPSHand Play()
    {
        RPSHand hand = GetHand();
        DebugManager.Log($"Opponent chooses {hand}");
        return hand;
    }
}