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
    [SerializeField]
    private float maxShootRange = 300f;
    [SerializeField]
    private float damage = 100f;   
    public LayerMask playerLayer;
    public LayerMask enviromentLayer;
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
        Ray shootRay = new Ray(Camera.main.transform.position,Camera.main.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, maxShootRange, ~(playerLayer)))
        {
            if(hit.collider.tag == "Enemy")
            {
                Enemy enemyScript = hit.collider.GetComponent<Enemy>();
                enemyScript.TakeDamage(damage);
            }

        }
    }
    
    void ResetGunReady()
    {
        gunReady = true;
    }
}
