using UnityEngine;

// A container to allow setting values in Inspector (because Unity can't handle enums as function parameters)
[CreateAssetMenu(fileName = "Difficulty", menuName = "Minigame Data/Difficulty Setting")]
public class DifficultyContainer : ScriptableObject
{
    public Difficulty Setting;
}