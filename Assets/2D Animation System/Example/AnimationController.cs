using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UseCondomsKid.Animator2D;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private SpriteAnimator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            animator.Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.PlayIfNotPlaying("Idle");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.PlayIfNotPlaying("Run");
        }
    }
}
