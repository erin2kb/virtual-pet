using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetDisplay : MonoBehaviour
{
    // Class variables
    private ActivePet currentPet;

    // Editor variables
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


    // Ordinary functions
    private void UpdateRequirementsText(TextMeshProUGUI text, GrowthCategory category) {
        int currentValue = currentPet.GetGrowthValue(category);
        int requiredValue = currentPet.Species.evolutionRequirements.GetGrowthValue(category);

        text.SetText($"{currentValue} / {requiredValue}");

        if (currentValue >= requiredValue) {
            text.color = requirementsMetColor;
        }
    }

    // Unity callbacks
    void OnEnable() {
        currentPet = ActivePet.Find();
        nameText.SetText(currentPet.Species.speciesName);

        if (currentPet.petStage == PetStage.EGG) {
            levelText.SetText("");
        } else {
            levelText.SetText(currentPet.petStage.ToString());
        }

        petImage.sprite = currentPet.Species.sprite;

        UpdateRequirementsText(careText, GrowthCategory.CARE);
        UpdateRequirementsText(foodText, GrowthCategory.FOOD);
        UpdateRequirementsText(groomingText, GrowthCategory.GROOMING);
        UpdateRequirementsText(exerciseText, GrowthCategory.EXERCISE);
    }
}
