using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
    public void PlayAgain(SceneInfo playMenuScene)
    {
        OpponentState.Find().RefreshAI();
        GameScreen.LoadScene(playMenuScene);
    }
}
