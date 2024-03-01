using UnityEngine;
using System.Collections.Generic;

public class ActivePet : PersistentGameObject, GrowthValueUpdater
{
    // Class variables
    private static string _tagName;
    private static ActivePet _activePetSingleton;
    private GrowthValues _growthValues;  

    // Editor variables
    [NaughtyAttributes.Tag, SerializeField]
    private string _editorTag;

    [SerializeField]
    public PetLine petLine;

    [SerializeField]
    public PetStage petStage;

    [SerializeField] private int initialCareValue = 0;
    [SerializeField] private int initialFoodValue = 0;
    [SerializeField] private int initialGroomingValue = 0;
    [SerializeField] private int initialExerciseValue = 0;
    [SerializeField] private int initialKnowledgeValue = 0;

    // Properties
    protected override PersistentGameObject Singleton
    {
        get { return _activePetSingleton; }
        set { _activePetSingleton = (ActivePet)value; }
    }

    public PetSpecies Species {
        get { return petLine.stages[petStage]; }
    }

    // Interface functions
    public void AddGrowthValues(GrowthCategory category, int value) {
        DebugManager.Log($"Adding {value} to {category}");////////////
    }

    // Regular functions
    public static ActivePet Find()
    {
        return FindPersistentObject<ActivePet>(_tagName);
    }

    public int GetGrowthValue(GrowthCategory category) {
        return _growthValues.GetGrowthValue(category);
    }

    // Unity callbacks
    void Awake()
    {
        Initialize(() => { _tagName = _editorTag; });
        _growthValues = new GrowthValues();
        _growthValues.SetGrowthValue(GrowthCategory.CARE, initialCareValue);
        _growthValues.SetGrowthValue(GrowthCategory.FOOD, initialFoodValue);
        _growthValues.SetGrowthValue(GrowthCategory.GROOMING, initialGroomingValue);
        _growthValues.SetGrowthValue(GrowthCategory.EXERCISE, initialExerciseValue);
        _growthValues.SetGrowthValue(GrowthCategory.KNOWLEDGE, initialKnowledgeValue);
    }
}
