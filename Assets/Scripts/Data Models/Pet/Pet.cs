using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pet", menuName = "Pet/New Pet")]
public class Pet : ScriptableObject
{
    [SerializeField]
    public string petName;

    [SerializeField]
    public Sprite sprite;
}
