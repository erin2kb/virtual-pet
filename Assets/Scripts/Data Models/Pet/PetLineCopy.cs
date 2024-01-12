// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [CreateAssetMenu(fileName = "Pet", menuName = "Pet/New Pet Line")]
// public class PetLine : ScriptableObject
// {
//     [SerializeField]
//     public Pet eggStage;

//     [SerializeField]
//     public Pet babyStage;

//     [SerializeField]
//     public Pet childStage;

//     [SerializeField]
//     public Pet teenStage;

//     [SerializeField]
//     public Pet adultStage;

//     public Pet getStage(PetStage stage)
//     {
//         switch (stage)
//         {
//             case PetStage.BABY:
//                 return Instantiate(babyStage);
//             case PetStage.CHILD:
//                 return Instantiate(childStage);
//             case PetStage.TEEN:
//                 return Instantiate(teenStage);
//             case PetStage.ADULT:
//                 return Instantiate(adultStage);
//             case PetStage.EGG:
//             default:
//                 return Instantiate(eggStage);
//         }
//     }
// }