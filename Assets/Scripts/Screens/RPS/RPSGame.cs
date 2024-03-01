using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RPSGame : GameScreen
{
    // Class variables
    private RPSHand _playerHand;
    private RPSHand _opponentHand;
    private RPSOutcome _gameOutcome;

    // Editor variables
    [SerializeField]
    private Sprite _rockHandSprite;

    [SerializeField]
    private Sprite _paperHandSprite;

    [SerializeField]
    private Sprite _scissorsHandSprite;

    [SerializeField]
    private Image _playerHandImage;

    [SerializeField]
    private Image _opponentHandImage;

    [SerializeField]
    private TMPro.TextMeshProUGUI _playerHandText;

    [SerializeField]
    private TMPro.TextMeshProUGUI _opponentHandText;

    [SerializeField]
    private Image _resultsImage;

    [SerializeField]
    private TMPro.TextMeshProUGUI _resultsText;

    [SerializeField]
    private Sprite _victorySprite;

    [SerializeField]
    private Sprite _defeatSprite;

    [SerializeField]
    private Sprite _drawSprite;

    // Functions
    private void PlayRound()
    {
        GetMoves();
        DetermineResults();
        DisplayResults();
    }

    private void GetMoves()
    {
        RPSPlayerState player = RPSPlayerState.Find();
        RPSOpponentState opponent = RPSOpponentState.Find();
        _playerHand = player.CurrentHand;
        _opponentHand = opponent.OpponentAI.Play();
    }

    private void DetermineResults()
    {
        if ((_playerHand == RPSHand.Rock && _opponentHand == RPSHand.Scissors)
        || (_playerHand == RPSHand.Paper && _opponentHand == RPSHand.Rock)
        || (_playerHand == RPSHand.Scissors && _opponentHand == RPSHand.Paper))
        {
            _gameOutcome = RPSOutcome.ConstructVictory(true);
        }
        else if ((_opponentHand == RPSHand.Rock && _playerHand == RPSHand.Scissors)
        || (_opponentHand == RPSHand.Paper && _playerHand == RPSHand.Rock)
        || (_opponentHand == RPSHand.Scissors && _playerHand == RPSHand.Paper))
        {
            _gameOutcome = RPSOutcome.ConstructVictory(false);
        }
        else
        {
            _gameOutcome = RPSOutcome.ConstructDraw();
        }
    }

    private void DisplayResults()
    {
        DebugManager.Log($"Displaying results for game where player chose {_playerHand} and opponent chose {_opponentHand}");

        // Display moves chosen by player and opponent
        switch (_playerHand)
        {
            case RPSHand.Rock:
                _playerHandImage.sprite = _rockHandSprite;
                break;
            case RPSHand.Paper:
                _playerHandImage.sprite = _paperHandSprite;
                break;
            case RPSHand.Scissors:
                _playerHandImage.sprite = _scissorsHandSprite;
                break;
        }
        _playerHandText.text = _playerHand.ToString();

        switch (_opponentHand)
        {
            case RPSHand.Rock:
                _opponentHandImage.sprite = _rockHandSprite;
                break;
            case RPSHand.Paper:
                _opponentHandImage.sprite = _paperHandSprite;
                break;
            case RPSHand.Scissors:
                _opponentHandImage.sprite = _scissorsHandSprite;
                break;
        }
        _opponentHandText.text = _opponentHand.ToString();

        // Display outcome of the game
        if (_gameOutcome.IsDraw)
        {
            _resultsImage.sprite = _drawSprite;
            _resultsText.text = "Draw";
        }
        else if (_gameOutcome.PlayerWins)
        {
            _resultsImage.sprite = _victorySprite;
            _resultsText.text = "You Won!";
        }
        else
        {
            _resultsImage.sprite = _defeatSprite;
            _resultsText.text = "You Lost...";
        }
    }

    // TODO: structure this better, like maybe have a parent Game class that implements this and each child merely needs to define their category and point mappings?
    private void awardGrowthValues() {
        ///////ExecuteEvents.Execute<GrowthValueUpdater>()
    }

    // Unity callbacks
    void Start()
    {
        PlayRound();
    }
}
