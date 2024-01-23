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
    
    // Non-static wrapper to access LoadScene()
    public void LoadNewScene(SceneInfo scene)
    {
        LoadScene(scene);
    }

    void Start()
    {
        // Destroy any PersistentGameObject instances specific to a particular minigame (e.g. player, opponent)
        CleanUp();
    }
}
