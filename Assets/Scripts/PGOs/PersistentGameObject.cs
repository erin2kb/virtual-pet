using UnityEngine;
using System;

public abstract class PersistentGameObject : MonoBehaviour
{
    // Properties
    protected abstract PersistentGameObject Singleton
    {
        get; set;
    }

    // Functions
    protected static Type FindPersistentObject<Type>(string tagName) where Type : PersistentGameObject
    {
        if (tagName != null)
        {
            return GameObject.FindWithTag(tagName)?.GetComponent<Type>();
        }
        return null;
    }

    protected void Initialize(Action callback)
    {
        if (initializationPerformed())
        {
            callback();
        }
    }

    /*
    Each scene has its own copies of any Persistent Game Objects it needs, to allow entering Play mode from any 
    scene (for debugging purposes). This means any time those scenes are loaded, they'll attempt to create new
    instances of these objects. However, we don't want to overwrite it if we already have one, hence this function.
    Returns true if a new instance was created, and false if one already existed.
    */
    private bool initializationPerformed()
    {
        if (Singleton != null)
        {
            Destroy(gameObject);
            return false;
        }
        else
        {
            Singleton = this;
            DebugManager.Log($"Creating Persistent Game Object: {gameObject.name}");
            DontDestroyOnLoad(gameObject);
            return true;
        }
    }
}
