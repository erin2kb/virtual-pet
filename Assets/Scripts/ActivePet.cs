using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivePet : MonoBehaviour
{
    private GrowthValues currentValues = new GrowthValues();

    private Pet currentPet;

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

    [SerializeField]
    private Color requirementsMetColor = new Color(0.18f, 0.64f, 0.11f);

    void OnEnable() {
        currentPet = petLine.stages[petStage];
        nameText.SetText(currentPet.petName);

        if (petStage == PetStage.EGG) {
            levelText.SetText("");
        } else {
            levelText.SetText(petStage.ToString());
        }

        petImage.sprite = currentPet.sprite;

        UpdateRequirementsText(careText, GrowthCategory.CARE);
        UpdateRequirementsText(foodText, GrowthCategory.FOOD);
        UpdateRequirementsText(groomingText, GrowthCategory.GROOMING);
        UpdateRequirementsText(exerciseText, GrowthCategory.EXERCISE);
    }

    private void UpdateRequirementsText(TextMeshProUGUI text, GrowthCategory category) {
        int currentValue = currentValues.GetGrowthValue(category);
        int requiredValue = currentPet.evolutionRequirements.GetGrowthValue(category);

        text.SetText($"{currentValue} / {requiredValue}");

        if (currentValue >= requiredValue) {
            text.color = requirementsMetColor;
        }
    }
}
