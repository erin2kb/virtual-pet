public class SimonOpponentState : OpponentState
{
    // Class variables
    private static SimonOpponentState _opponentSingleton;
    private StandardAIFactory _standardFactory;
    private DebugAIFactory _debugFactory;
    private SimonOpponentAI _opponentAI;

    // Properties
    protected override PersistentGameObject Singleton
    {
        get { return _opponentSingleton; }
        set { _opponentSingleton = (SimonOpponentState)value; }
    }

    public SimonOpponentAI OpponentAI
    {
        get
        {
            return _opponentAI;
        }
        set
        {
            _opponentAI = value;
            DebugManager.Log($"Simon Opponent set to use {_opponentAI}");
        }
    }

    // Functions
    public static new SimonOpponentState Find()
    {
        return FindPersistentObject<SimonOpponentState>(_tagName);
    }

    public override void SetAI(Difficulty difficulty)
    {
        if (DebugManager.UseDefaultAI)
        {
            OpponentAI = _debugFactory.CreateAI<SimonOpponentAI>(difficulty);
        }
        else
        {
            OpponentAI = _standardFactory.CreateAI<SimonOpponentAI>(difficulty);
        }
    }

    // Unity callbacks
    void Awake()
    {
        Initialize(() =>
        {
            InitializeTag();
            _standardFactory = new StandardAIFactory();
            _debugFactory = new DebugAIFactory();
        });
    }

    void Start()
    {
        RefreshAI();
    }

    // Nested classes
    private class StandardAIFactory : AIFactory
    {
        protected override AIOpponent CreateEasyAI()
        {
            return new SimonOpponentAI(SettingsManager.EasyChunkLength, SettingsManager.EasyNumberOfChunks);
        }

        protected override AIOpponent CreateNormalAI()
        {
            return new SimonOpponentAI(SettingsManager.NormalChunkLength, SettingsManager.NormalNumberOfChunks);
        }

        protected override AIOpponent CreateHardAI()
        {
            return new SimonOpponentAI(SettingsManager.HardChunkLength, SettingsManager.HardNumberOfChunks);
        }
    }

    private class DebugAIFactory : AIFactory
    {
        protected override AIOpponent CreateEasyAI()
        {
            return new SimonOpponentAI(DebugManager.EasyChunkLength, DebugManager.EasySequence);
        }

        protected override AIOpponent CreateNormalAI()
        {
            return new SimonOpponentAI(DebugManager.NormalChunkLength, DebugManager.NormalSequence);
        }

        protected override AIOpponent CreateHardAI()
        {
            return new SimonOpponentAI(DebugManager.HardChunkLength, DebugManager.HardSequence);
        }
    }
}