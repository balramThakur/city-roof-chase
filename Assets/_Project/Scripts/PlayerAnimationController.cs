using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class PlayerAnimationController : MonoBehaviour
{
    private AnimationClip[] myClips;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            myClips = animator.runtimeAnimatorController.animationClips;
        }

    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int i = 0; i < myClips.Length; i++)
            {
                Debug.Log($"{i} => {myClips[i].name}");
            }
            animator.SetBool("running",true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("running", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("jump");
        }
        
    }
}

