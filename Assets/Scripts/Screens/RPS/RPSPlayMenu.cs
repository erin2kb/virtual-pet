using UnityEngine;
using UnityEngine.UI;

public class RPSPlayMenu : GameScreen
{
    // Class variables
    private RPSPlayerState _player;

    /* Since we don't allow our toggle group to be off, it will automatically choose a move button to enable when the scene is loaded,
    thus invoking its OnValueChanged function (SetMove(), in this case) and overriding the value in PlayerState. To circumvent this,
    we'll use this flag to ensure SetMove() won't do anything until we're ready for actual player input */
    private bool _moveButtonsEnabled;

    // Editor variables
    [SerializeField]
    private Toggle _rockButton;

    [SerializeField]
    private Toggle _paperButton;

    [SerializeField]
    private Toggle _scissorsButton;

    // Functions
    public void SetMove(RPSHandContainer chosenHand)
    {
        if (_moveButtonsEnabled) _player.CurrentHand = chosenHand.Hand;
    }

    // Unity callbacks
    void Start()
    {
        _player = RPSPlayerState.Find();

        // set initial toggle to match the player's current hand choice
        switch (_player.CurrentHand)
        {
            case RPSHand.Rock:
                _rockButton.isOn = true;
                break;
            case RPSHand.Paper:
                _paperButton.isOn = true;
                break;
            case RPSHand.Scissors:
                _scissorsButton.isOn = true;
                break;
        }

        _moveButtonsEnabled = true;
    }
}
