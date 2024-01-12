using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pet", menuName = "Pet/New Pet Line")]
public class PetLine : ScriptableObject
{
    [SerializeField]
    public Pet eggStage;

    [SerializeField]
    public Pet babyStage;

    [SerializeField]
    public Pet childStage;

    [SerializeField]
    public Pet teenStage;

    [SerializeField]
    public Pet adultStage;

    public Dictionary<PetStage, Pet> stages;

    void OnEnable()
    {
        stages = new Dictionary<PetStage, Pet>() {
            {PetStage.EGG, eggStage},
            {PetStage.BABY, babyStage},
            {PetStage.CHILD, childStage},
            {PetStage.TEEN, teenStage},
            {PetStage.ADULT, adultStage}
        };
    }
}
