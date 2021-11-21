using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public static Animator animator;

    public static bool WasOpenned = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("WasOpenned", WasOpenned); 
    }
}
