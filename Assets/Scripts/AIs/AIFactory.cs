using UnityEngine;

public abstract class AIFactory
{
    protected abstract AIOpponent CreateEasyAI();
    protected abstract AIOpponent CreateNormalAI();
    protected abstract AIOpponent CreateHardAI();

    public OpponentType CreateAI<OpponentType>(Difficulty difficulty) where OpponentType : AIOpponent
    {
        return (OpponentType)MakeGenericAI(difficulty);
    }

    private AIOpponent MakeGenericAI(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                return CreateEasyAI();
            case Difficulty.Normal:
                return CreateNormalAI();
            case Difficulty.Hard:
                return CreateHardAI();
            default:
                Debug.Log("ERROR: Unknown difficulty provided to AI Factory. Returning null!");
                return null;
        }
    }
}
