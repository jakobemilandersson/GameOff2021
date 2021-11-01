using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public StarterAssets.FirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller._speed > 0.1)
            animator.SetBool("_isWalking", true);
        else
            animator.SetBool("_isWalking", false);
    }
}
