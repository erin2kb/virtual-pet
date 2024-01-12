using UnityEngine;

public class VictoryBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private SceneInfo _victoryScene;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameScreen.LoadScene(_victoryScene);
    }
}
