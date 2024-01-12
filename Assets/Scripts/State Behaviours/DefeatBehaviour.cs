using UnityEngine;

public class DefeatBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private SceneInfo _defeatScene;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameScreen.LoadScene(_defeatScene);
    }
}
