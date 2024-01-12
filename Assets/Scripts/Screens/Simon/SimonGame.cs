using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class SimonGame : GameScreen
{
    // Class variables
    private string _readyText = "Ready...";
    private string _memorizeText = "Memorize:";
    private string _repeatText = "Repeat!";
    private SimonOpponentAI _opponent;
    private SimonInput[] _currentChunk;
    private int _currentIndex;

    // Editor variables
    [SerializeField]
    private TMPro.TextMeshProUGUI _instructionText;

    [SerializeField]
    private TMPro.TextMeshProUGUI _feedbackText;

    [SerializeField]
    private Button _upArrow;

    [SerializeField]
    private Button _downArrow;

    [SerializeField]
    private Button _rightArrow;

    [SerializeField]
    private Button _leftArrow;

    [SerializeField]
    private Animator _simonAnimator;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _flashUpTrigger;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _flashDownTrigger;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _flashRightTrigger;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _flashLeftTrigger;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _chunkFlashingCompleteTrigger;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _nextChunkTrigger;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _loseTrigger;

    [AnimatorParam("_simonAnimator"), SerializeField]
    private string _winTrigger;

    // Functions
    public void EnterMemorizeMode()
    {
        _feedbackText.gameObject.SetActive(false);
        _instructionText.text = _memorizeText;
        _currentChunk = _opponent.Play();
        _currentIndex = 0;
    }

    public void EnterRepeatMode()
    {
        _instructionText.text = _repeatText;
        ToggleButtons(true);
        _currentIndex = 0;
    }

    public void EnterReadyMode()
    {
        _instructionText.text = _readyText;
    }

    public void PrepareForNextChunk()
    {
        _feedbackText.gameObject.SetActive(true);
        ToggleButtons(false);
    }

    public void LightUpSequence()
    {
        if (_currentIndex >= _currentChunk.Length)
        {
            _simonAnimator.SetTrigger(_chunkFlashingCompleteTrigger);
        }
        else
        {
            SimonInput next = _currentChunk[_currentIndex];
            switch (next)
            {
                case SimonInput.Up:
                    _simonAnimator.SetTrigger(_flashUpTrigger);
                    break;
                case SimonInput.Down:
                    _simonAnimator.SetTrigger(_flashDownTrigger);
                    break;
                case SimonInput.Right:
                    _simonAnimator.SetTrigger(_flashRightTrigger);
                    break;
                case SimonInput.Left:
                    _simonAnimator.SetTrigger(_flashLeftTrigger);
                    break;
            }
            _currentIndex++;
        }
    }

    private void ToggleButtons(bool isEnabled)
    {
        _upArrow.interactable = isEnabled;
        _downArrow.interactable = isEnabled;
        _leftArrow.interactable = isEnabled;
        _rightArrow.interactable = isEnabled;
    }

    public void PressUp()
    {
        PressButton(SimonInput.Up);
    }

    public void PressDown()
    {
        PressButton(SimonInput.Down);
    }

    public void PressLeft()
    {
        PressButton(SimonInput.Left);
    }

    public void PressRight()
    {
        PressButton(SimonInput.Right);
    }

    private void PressButton(SimonInput button)
    {
        DebugManager.Log($"User pressed {button}");
        if (button != _currentChunk[_currentIndex])
        {
            DebugManager.Log($"Incorrect user input, was expecting {_currentChunk[_currentIndex]}");
            _simonAnimator.SetTrigger(_loseTrigger);
        }
        else
        {
            _currentIndex++;
            DetermineNextState();
        }
    }

    private void DetermineNextState()
    {
        if (_currentIndex >= _currentChunk.Length)
        {
            // user successfully entered chunk
            if (_opponent.IsFinished)
            {
                _simonAnimator.SetTrigger(_winTrigger);
            }
            else
            {
                _simonAnimator.SetTrigger(_nextChunkTrigger);
            }
        }
    }

    // Unity callbacks
    void Start()
    {
        ToggleButtons(false);
        _opponent = SimonOpponentState.Find().OpponentAI;
    }
}
