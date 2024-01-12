using UnityEngine;
using NaughtyAttributes;

public abstract class OpponentState : PersistentGameObject
{
    // Class variables
    protected static string _tagName;

    // Editor variables
    [Tag, SerializeField]
    private string _editorTag;

    // Functions
    public abstract void SetAI(Difficulty difficulty);

    public static OpponentState Find()
    {
        return FindPersistentObject<OpponentState>(_tagName);
    }

    protected void InitializeTag()
    {
        _tagName = _editorTag;
    }

    public void RefreshAI()
    {
        Difficulty difficulty = SettingsManager.Find().DifficultySetting;
        SetAI(difficulty);
    }

    public void CleanUp()
    {
        DebugManager.Log("Cleaning up old Opponent game object");
        Destroy(gameObject);
    }
}