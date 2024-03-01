using System.Diagnostics;

public class HomeScreen : GameScreen
{
    // Non-static wrapper to access LoadScene()
    public void LoadNewScene(SceneInfo scene)
    {
        LoadScene(scene);
    }

    // Ordinary functions
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
