using UnityEngine;

// A container to allow setting values in Inspector (because Unity can't handle enums as function parameters)
[CreateAssetMenu(fileName = "RPS Hand", menuName = "Minigame Data/Hand (Rock Paper Scissors)")]
public class RPSHandContainer : ScriptableObject
{
    public RPSHand Hand;
}