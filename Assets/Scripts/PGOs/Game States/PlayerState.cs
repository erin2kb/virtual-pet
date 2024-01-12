using UnityEngine;
using NaughtyAttributes;

public abstract class PlayerState : PersistentGameObject
{
    // Class variables
    protected static string _tagName;

    // Editor variables
    [Tag, SerializeField]
    private string _editorTag;

    // Functions
    public static PlayerState Find()
    {
        if (_tagName != null)
        {
            return FindPersistentObject<PlayerState>(_tagName);
        }
        return null;
    }

    protected void InitializeTag()
    {
        _tagName = _editorTag;
    }

    public void CleanUp()
    {
        DebugManager.Log("Cleaning up old Player game object");
        Destroy(gameObject);
    }
}