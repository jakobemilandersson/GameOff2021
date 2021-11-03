using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Animator playerAnimator; 
    [SerializeField]
    private bool automatic = true;

    //Stats of the weapon
    [SerializeField]
    private float attackSpeed = 0.5f;
    [SerializeField]
    private float maxShootRange = 300f;
    [SerializeField]
    private float damage = 100f;   
    public int maxAmmo = 30;
    
    private int currentAmmo = 25;
    public LayerMask playerLayer;

    private bool gunReady = true;

    //Prefabs and effects
    public ParticleSystem muzzle;
    public GameObject barrel;
    public GameObject bulletImpactPrefab;
    public GameObject plasmaBulletPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        //Kollar om automatisk, om ja använder vi Getbutton, annars använder vi GetbuttonDown
        //Vi kallar shoot().
        if(automatic)
        {
            if(Input.GetButton("Fire1")&&gunReady&&currentAmmo>0)
            {
                Shoot();                
            }               
        }
        else
        {
            if(Input.GetButtonDown("Fire1")&&gunReady&&currentAmmo>0)
            {
                Shoot();                
            }   
        }
        
        //Reload, om R klickas, blir vapnet oanvändbart tills animationen är klar.
        if(Input.GetButtonDown("Reload"))
        {
            gunReady = false;
            playerAnimator.SetTrigger("Reload");
        }
    }
    void Shoot() //Kallas från detta script när spelaren skjuter.      
    {
        gunReady = false;// gör vapnet oskjutbart
        Invoke(nameof(ResetGunReady),attackSpeed);//Kallar en reset av gunReady efter viss antal tid attackspeed
        currentAmmo -=1;
        
        
        playerAnimator.SetTrigger("Shoot");//Aktiverar animationen
        muzzle.Play();//Aktiverar muzzle flash som är ett child på vapnet
        
        
        Ray shootRay = new Ray(Camera.main.transform.position,Camera.main.transform.forward);//Skapar en ray från mitten av kameran
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, maxShootRange, ~(playerLayer)))//Vi kollar om vi träfar nåt på maxShootRange, vi ignorerar spelaren
        {
            if(hit.collider.tag == "Enemy")//Om vi träffar en collider med en fiende tag
            {
                Enemy enemyScript = hit.collider.GetComponent<Enemy>();//Fiender har ett Enemy component där vi sedan tar bort liv från dom.
                enemyScript.TakeDamage(damage);//Tar skadan av fienden
            }
            
            
            Instantiate(bulletImpactPrefab,hit.point,Quaternion.LookRotation(transform.position - hit.point));//Vi skapar en bulletimpact effect vid punkten vi träffar
            
            //Skapar en kula som effekt om vi är tillräckligt långt bort (bara som cool effekt)
            Vector3 distanceToHitPoint =  (hit.point-transform.position); //räknar ut hur långt bort träffen är
            if(distanceToHitPoint.magnitude>5)//Om den är tillräckligt långt bort spawnar vi en kula
            {
                GameObject bullet = Instantiate(plasmaBulletPrefab,barrel.transform.position,Quaternion.LookRotation(barrel.transform.position - hit.point));
                Bullet bulletScript = bullet.GetComponent<Bullet>();//Kulan som spawnas har en komponent bullet
                bulletScript.TargetBullet(hit.point);//Bullet komponenten får kulan att åka mot positionen vi anger.
            }

        }
    }
    
    void ResetGunReady()
    {
        gunReady = true;
    }
    public void FinishedReloadAnimation()
    {
        ResetGunReady();
        currentAmmo = maxAmmo;
    }
}
