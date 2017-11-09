using UnityEngine;

namespace BidOn
{
    public class AudioPlayStateMachines : StateMachineBehaviour
    {
        //A sound clip that will be played when the animation starts
        public AudioClip PlayOnStart;

        /// <summary>
        /// A possible demo option for playing this audio clip at the start of this animation
        /// </summary>
        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            if (PlayOnStart)
                AudioSource.PlayClipAtPoint(PlayOnStart, animator.transform.position);
        }

    }
}