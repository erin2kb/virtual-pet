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
