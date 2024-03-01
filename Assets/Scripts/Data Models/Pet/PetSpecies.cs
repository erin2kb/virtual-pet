using UnityEngine;

[CreateAssetMenu(fileName = "Pet", menuName = "Pet/New Pet")]
public class PetSpecies : ScriptableObject
{
    [SerializeField]
    public string speciesName;

    [SerializeField]
    public Sprite sprite;

    [SerializeField]
    int careRequirement;

    [SerializeField]
    int foodRequirement;

    [SerializeField]
    int groomingRequirement;

    [SerializeField]
    int exerciseRequirement;

    [SerializeField]
    int knowledgeRequirement;

    public GrowthValues evolutionRequirements;

    void OnEnable()
    {
        evolutionRequirements = new GrowthValues();
        evolutionRequirements.SetGrowthValue(GrowthCategory.CARE, careRequirement);
        evolutionRequirements.SetGrowthValue(GrowthCategory.FOOD, foodRequirement);
        evolutionRequirements.SetGrowthValue(GrowthCategory.GROOMING, groomingRequirement);
        evolutionRequirements.SetGrowthValue(GrowthCategory.EXERCISE, exerciseRequirement);
        evolutionRequirements.SetGrowthValue(GrowthCategory.KNOWLEDGE, knowledgeRequirement);
    }
}
