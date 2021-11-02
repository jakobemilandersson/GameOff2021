using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Animation script (mest för test just nu men kan absolut användas)
    //Scriptet tar _speed från FirstpersonController och activerar "gå" animationen när spelaren rör sig.
    public Animator animator;
    public StarterAssets.FirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Kollar om spelare rör sig, om ja, aktivera "gå" animation.
        if(controller._speed > 0.1)
            animator.SetBool("_isWalking", true);
        else
            animator.SetBool("_isWalking", false);
    }
}
