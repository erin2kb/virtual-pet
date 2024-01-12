using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : GameScreen
{
    // Class variables
    private SettingsManager _settingsManager;

    /* Since we don't allow our toggle group to be off, it will automatically choose a difficulty button to enable when the scene is loaded,
    thus invoking its OnValueChanged function (SetDifficulty(), in this case) and overriding the value in PlayerState. To circumvent this,
    we'll use this flag to ensure SetDifficulty() won't do anything until we're ready for actual player input */
    private bool _difficultyButtonsEnabled;

    // Editor variables
    [SerializeField]
    private Toggle _easyButton;

    [SerializeField]
    private Toggle _normalButton;

    [SerializeField]
    private Toggle _hardButton;

    // Functions
    public void SetDifficulty(DifficultyContainer chosenDifficulty)
    {
        if (_difficultyButtonsEnabled)
        {
            _settingsManager.DifficultySetting = chosenDifficulty.Setting;
            UpdateAI();
        }
    }

    public void CloseSettingsMenu()
    {
        string scene = SettingsButton.PreviousScene;
        DebugManager.Log($"Returning to previous scene: {scene}");
        SceneManager.LoadScene(scene);
    }

    private void UpdateAI()
    {
        OpponentState opponent = OpponentState.Find();
        if (opponent != null)
        {
            opponent.SetAI(_settingsManager.DifficultySetting);
        }
    }

    // Unity callbacks
    void OnEnable()
    {
        _settingsManager = SettingsManager.Find();

        // set initial toggle to match the player's current difficulty setting
        switch (_settingsManager.DifficultySetting)
        {
            case Difficulty.Easy:
                _easyButton.isOn = true;
                break;
            case Difficulty.Normal:
                _normalButton.isOn = true;
                break;
            case Difficulty.Hard:
                _hardButton.isOn = true;
                break;
        }
    }

    void Start()
    {
        _difficultyButtonsEnabled = true;
    }
}
