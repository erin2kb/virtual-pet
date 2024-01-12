using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour
{
    public static void LoadScene(SceneInfo scene)
    {
        SceneManager.LoadScene(scene.Name);
    }
}
