public class HomeScreen : GameScreen
{
    // Functions
    private void CleanUp()
    {
        OpponentState opponent = OpponentState.Find();
        PlayerState player = PlayerState.Find();
        if (opponent != null) opponent.CleanUp();
        if (player != null) player.CleanUp();
    }

    // Unity callbacks
    void Start()
    {
        // Destroy any PersistentGameObject instances specific to a particular minigame (e.g. player, opponent)
        CleanUp();
    }
}
