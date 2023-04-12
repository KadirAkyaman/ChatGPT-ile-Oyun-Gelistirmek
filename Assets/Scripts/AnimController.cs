using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Static_b", true);
                animator.SetFloat("Speed_f", 0.60f);
            }
            else
            {
                animator.SetBool("Static_b", true);
                animator.SetFloat("Speed_f", 0.30f);
            }
        }
        else
        {
            animator.SetFloat("Speed_f", 0.0f);
            animator.SetBool("Static_b", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump_trig");
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetInteger("WeaponType_int", 6);
        }
        else
        {
            animator.SetInteger("WeaponType_int", 0);
        }

    }
}
