using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pet", menuName = "Pet/New Pet Line")]
public class PetLine : ScriptableObject
{
    [SerializeField]
    public PetSpecies eggStage;

    [SerializeField]
    public PetSpecies babyStage;

    [SerializeField]
    public PetSpecies childStage;

    [SerializeField]
    public PetSpecies teenStage;

    [SerializeField]
    public PetSpecies adultStage;

    public Dictionary<PetStage, PetSpecies> stages;

    void OnEnable()
    {
        stages = new Dictionary<PetStage, PetSpecies>() {
            {PetStage.EGG, eggStage},
            {PetStage.BABY, babyStage},
            {PetStage.CHILD, childStage},
            {PetStage.TEEN, teenStage},
            {PetStage.ADULT, adultStage}
        };
    }
}
