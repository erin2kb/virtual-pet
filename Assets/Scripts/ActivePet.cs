using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivePet : MonoBehaviour
{
    [SerializeField]
    public PetLine petLine;

    [SerializeField]
    public PetStage petStage;

    [SerializeField]
    public TextMeshProUGUI nameText;

    [SerializeField]
    public TextMeshProUGUI levelText;

    [SerializeField]
    public Image petImage;

    void Update() {
        Pet currentPet = petLine.stages[petStage];
        nameText.SetText(currentPet.petName);

        if (petStage != PetStage.EGG) {
            levelText.SetText(petStage.ToString());
        }

        petImage.sprite = currentPet.sprite; 
    }
}
