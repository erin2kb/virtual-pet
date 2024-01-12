using System;

public class RPSOpponentState : OpponentState
{
    // Class variables
    private static RPSOpponentState _opponentSingleton;
    private StandardAIFactory _standardFactory;
    private DebugAIFactory _debugFactory;
    private RPSOpponentAI _opponentAI;

    // Properties
    protected override PersistentGameObject Singleton
    {
        get { return _opponentSingleton; }
        set { _opponentSingleton = (RPSOpponentState)value; }
    }

    public RPSOpponentAI OpponentAI
    {
        get
        {
            return _opponentAI;
        }
        set
        {
            _opponentAI = value;
            DebugManager.Log($"RPS Opponent set to {_opponentAI}");
        }
    }

    // Functions
    public static new RPSOpponentState Find()
    {
        return FindPersistentObject<RPSOpponentState>(_tagName);
    }

    public override void SetAI(Difficulty difficulty)
    {
        if (DebugManager.UseDefaultAI)
        {
            OpponentAI = _debugFactory.CreateAI<RPSOpponentAI>(difficulty);
        }
        else
        {
            OpponentAI = _standardFactory.CreateAI<RPSOpponentAI>(difficulty);
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
        // Class variables
        private System.Random _random;

        // Constructor
        public StandardAIFactory()
        {
            _random = new System.Random();
        }

        // Functions
        protected override AIOpponent CreateEasyAI()
        {
            RPSHand hand = RandomRPSHand();
            return new RPSConsistentAI(hand);
        }

        protected override AIOpponent CreateNormalAI()
        {
            RPSHand[] sequence = RandomRPSSequence();
            return new RPSSequenceAI(sequence);
        }

        protected override AIOpponent CreateHardAI()
        {
            return new RPSRandomAI();
        }

        private RPSHand RandomRPSHand()
        {
            return (RPSHand)Enum.ToObject(typeof(RPSHand), _random.Next(3));
        }

        private RPSHand[] RandomRPSSequence()
        {
            int sequenceLength = _random.Next(3) + 3;   // we want length between 3 and 5
            RPSHand[] sequence = new RPSHand[sequenceLength];
            for (int i = 0; i < sequenceLength; i++)
            {
                sequence[i] = RandomRPSHand();
            }
            return sequence;
        }
    }

    private class DebugAIFactory : AIFactory
    {
        // Functions
        protected override AIOpponent CreateEasyAI()
        {
            return new RPSConsistentAI(DebugManager.ConsistentAIHand);
        }

        protected override AIOpponent CreateNormalAI()
        {
            return new RPSSequenceAI(DebugManager.SequenceAIPattern);
        }

        protected override AIOpponent CreateHardAI()
        {
            return new RPSRandomAI(DebugManager.RandomAISeed);
        }
    }
}