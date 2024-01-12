using UnityEngine;
using NaughtyAttributes;

// A container to allow setting values in Inspector (because Unity can't handle Scenes as function parameters)
[CreateAssetMenu(fileName = "SceneInfo", menuName = "Minigame Collection/Game Scene Info")]
public class SceneInfo : ScriptableObject
{
    [Scene, SerializeField]
    public string Name;
}