using UnityEngine;

public class RepeatSequenceBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SimonGame game = animator.gameObject.GetComponent<SimonGame>();
        game.EnterRepeatMode();
    }
}
