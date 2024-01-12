using UnityEngine;

public class RPSPlayerState : PlayerState
{
    // Class variables
    private static RPSPlayerState _playerSingleton;

    // Editor variables
    [SerializeField]
    private RPSHand _currentHand;

    // Properties
    protected override PersistentGameObject Singleton
    {
        get { return _playerSingleton; }
        set { _playerSingleton = (RPSPlayerState)value; }
    }

    public RPSHand CurrentHand
    {
        get
        {
            return _currentHand;
        }
        set
        {
            // don't log a message that the value changed unless it's actually become something different
            if (_currentHand != value)
            {
                _currentHand = value;
                DebugManager.Log("Move changed to " + value);
            }
        }
    }

    // Functions
    public static new RPSPlayerState Find()
    {
        return FindPersistentObject<RPSPlayerState>(_tagName);
    }

    // Unity callbacks
    void Awake()
    {
        Initialize(() => { InitializeTag(); });
    }
}
