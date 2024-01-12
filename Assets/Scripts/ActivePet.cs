using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivePet : MonoBehaviour
{
    [SerializeField]
    public PetLine petLine;

    [SerializeField]
    public PetStage petStage;

    [SerializeField]
    public TextMeshProUGUI nameText;

    void Update() {
        nameText.SetText(petLine.stages[petStage].petName);
    }
}
