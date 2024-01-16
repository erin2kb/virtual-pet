using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivePet : MonoBehaviour
{
    private GrowthValues currentValues = new GrowthValues();

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

    [SerializeField]
    public TextMeshProUGUI careText;

    [SerializeField]
    public TextMeshProUGUI foodText;

    [SerializeField]
    public TextMeshProUGUI groomingText;

    [SerializeField]
    public TextMeshProUGUI exerciseText;

    void Update() {
        Pet currentPet = petLine.stages[petStage];
        nameText.SetText(currentPet.petName);

        if (petStage == PetStage.EGG) {
            levelText.SetText("");
        } else {
            levelText.SetText(petStage.ToString());
        }

        petImage.sprite = currentPet.sprite;

        careText.SetText($"{currentValues.GetGrowthValue(GrowthCategory.CARE)} / {currentPet.evolutionRequirements.GetGrowthValue(GrowthCategory.CARE)}");
    }
}
