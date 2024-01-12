using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public static string PreviousScene;

    [SerializeField]
    private SceneInfo _settingsScene;

    public void OpenSettingsMenu()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_settingsScene.Name);
    }
}
