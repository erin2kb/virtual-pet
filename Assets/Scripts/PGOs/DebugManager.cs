using UnityEngine;
using NaughtyAttributes;

public class DebugManager : PersistentGameObject
{
    // Class variables
    private static string _tagName;
    private static DebugManager _debugSingleton;
    private SettingsManager _settingsManager;

    // Editor variables
    [Tag, SerializeField]
    private string _editorTag;

    [SerializeField, OnValueChanged("PrintLoggingStatus")]
    private bool _logDebugMessages;

    [SerializeField, OnValueChanged("UpdateAI")]
    private bool _useDefaultAI;

    [SerializeField]
    private RPSHand _defaultConsistentAIHand;

    [SerializeField]
    private RPSHand[] _defaultSequenceAIPattern;

    [SerializeField]
    private int _defaultRandomAISeed;

    [SerializeField]
    private int _defaultEasyChunkLength;

    [SerializeField]
    private SimonInput[] _defaultEasySequence;

    [SerializeField]
    private int _defaultNormalChunkLength;

    [SerializeField]
    private SimonInput[] _defaultNormalSequence;

    [SerializeField]
    private int _defaultHardChunkLength;

    [SerializeField]
    private SimonInput[] _defaultHardSequence;

    // Properties
    protected override PersistentGameObject Singleton
    {
        get { return _debugSingleton; }
        set { _debugSingleton = (DebugManager)value; }
    }

    private static bool LogDebugMessages
    {
        get
        {
            return _debugSingleton._logDebugMessages;
        }
        set
        {
            _debugSingleton._logDebugMessages = value;
            Log("Debug logging enabled.");  // Log() will only print this if it was set to true
        }
    }

    public static bool UseDefaultAI
    {
        get
        {
            return _debugSingleton._useDefaultAI;
        }
        set
        {
            _debugSingleton._useDefaultAI = value;
            if (value)
            {
                Debug.Log("Using default values for AIs.");   // print this regardless of LogDebugMessages value
            }
        }
    }

    public static RPSHand ConsistentAIHand
    {
        get { return _debugSingleton._defaultConsistentAIHand; }
    }

    public static RPSHand[] SequenceAIPattern
    {
        get { return _debugSingleton._defaultSequenceAIPattern; }
    }

    public static int RandomAISeed
    {
        get { return _debugSingleton._defaultRandomAISeed; }
    }

    public static int EasyChunkLength
    {
        get { return _debugSingleton._defaultEasyChunkLength; }
    }

    public static SimonInput[] EasySequence
    {
        get { return _debugSingleton._defaultEasySequence; }
    }

    public static int NormalChunkLength
    {
        get { return _debugSingleton._defaultNormalChunkLength; }
    }

    public static SimonInput[] NormalSequence
    {
        get { return _debugSingleton._defaultNormalSequence; }
    }

    public static int HardChunkLength
    {
        get { return _debugSingleton._defaultHardChunkLength; }
    }

    public static SimonInput[] HardSequence
    {
        get { return _debugSingleton._defaultHardSequence; }
    }

    // Functions
    public static DebugManager Find()
    {
        return FindPersistentObject<DebugManager>(_tagName);
    }

    public static void Log(string message)
    {
        if (LogDebugMessages) Debug.Log(message);
    }

    private void UpdateAI()
    {
        PrintAIStatus();
        OpponentState opponent = OpponentState.Find();
        if (opponent != null)
        {
            opponent.SetAI(_settingsManager.DifficultySetting);
        }
    }

    // Force the properties to print their debug messages, since they do so on assignment (not initialization)
    private void PrintLoggingStatus() { LogDebugMessages = _logDebugMessages; }
    private void PrintAIStatus() { UseDefaultAI = _useDefaultAI; }

    // Unity callbacks
    void Awake()
    {
        Initialize(() =>
        {
            _tagName = _editorTag;
            PrintLoggingStatus();
            PrintAIStatus();
        });
    }

    void Start()
    {
        _settingsManager = SettingsManager.Find();
    }
}
