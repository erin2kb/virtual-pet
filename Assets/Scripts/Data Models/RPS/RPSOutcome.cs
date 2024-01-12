public struct RPSOutcome
{
    public bool PlayerWins;
    public bool IsDraw;

    // Factory-style "constructor" for game that ends with a winner
    public static RPSOutcome ConstructVictory(bool victory)
    {
        RPSOutcome victoryOutcome = new RPSOutcome();
        victoryOutcome.PlayerWins = victory;
        victoryOutcome.IsDraw = false;
        return victoryOutcome;
    }

    // Factory-style "constructor" for game that ends in a draw
    public static RPSOutcome ConstructDraw()
    {
        RPSOutcome drawOutcome = new RPSOutcome();
        drawOutcome.PlayerWins = false;
        drawOutcome.IsDraw = true;
        return drawOutcome;
    }
}