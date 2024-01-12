using UnityEngine;
using NaughtyAttributes;

public class SettingsManager : PersistentGameObject
{
    // Class variables
    private static string _tagName;
    private static SettingsManager _settingsSingleton;

    // Editor variables
    [Tag, SerializeField]
    private string _editorTag;

    [SerializeField]
    private Difficulty _difficultySetting;

    [SerializeField]
    private int _easySimonChunkLength;

    [SerializeField]
    private int _easyNumberOfChunks;

    [SerializeField]
    private int _normalSimonChunkLength;

    [SerializeField]
    private int _normalNumberOfChunks;

    [SerializeField]
    private int _hardSimonChunkLength;

    [SerializeField]
    private int _hardNumberOfChunks;

    // Properties
    protected override PersistentGameObject Singleton
    {
        get { return _settingsSingleton; }
        set { _settingsSingleton = (SettingsManager)value; }
    }

    public Difficulty DifficultySetting
    {
        get
        {
            return _difficultySetting;
        }
        set
        {
            // don't log a message that the value changed unless it's actually become something different
            if (_difficultySetting != value)
            {
                _difficultySetting = value;
                DebugManager.Log("Difficulty changed to " + value);
            }
        }
    }

    public static int EasyChunkLength
    {
        get { return _settingsSingleton._easySimonChunkLength; }
    }

    public static int EasyNumberOfChunks
    {
        get { return _settingsSingleton._easyNumberOfChunks; }
    }

    public static int NormalChunkLength
    {
        get { return _settingsSingleton._normalSimonChunkLength; }
    }

    public static int NormalNumberOfChunks
    {
        get { return _settingsSingleton._normalNumberOfChunks; }
    }

    public static int HardChunkLength
    {
        get { return _settingsSingleton._hardSimonChunkLength; }
    }

    public static int HardNumberOfChunks
    {
        get { return _settingsSingleton._hardNumberOfChunks; }
    }

    // Functions
    public static SettingsManager Find()
    {
        return FindPersistentObject<SettingsManager>(_tagName);
    }

    // Unity callbacks
    void Awake()
    {
        Initialize(() => { _tagName = _editorTag; });
    }
}
