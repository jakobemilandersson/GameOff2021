using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Animator playerAnimator; 
    [SerializeField]
    private bool automatic = true;
    [SerializeField]
    private float attackSpeed = 0.5f;
    private bool gunReady = true;

    public ParticleSystem muzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(automatic)
        {
            if(Input.GetButton("Fire1")&&gunReady)
            {
                Shoot();

                
            }               
        }
        else
        {

        }
    }
    void Shoot()
    {
        gunReady = false;
        Invoke(nameof(ResetGunReady),attackSpeed);
        playerAnimator.SetTrigger("Shoot");
        muzzle.Play();
    }
    
    void ResetGunReady()
    {
        gunReady = true;
    }
}
