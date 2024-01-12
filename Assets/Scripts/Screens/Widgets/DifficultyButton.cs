using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField]
    private SettingsMenu _menu;

    [SerializeField]
    private DifficultyContainer _difficulty;

    // Dynamic UnityEvent boolean on the Toggle component
    public void ToggledOn(bool isOn)
    {
        if (isOn) _menu.SetDifficulty(_difficulty);
    }
}
