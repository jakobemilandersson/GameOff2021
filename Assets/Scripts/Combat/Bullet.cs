using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Bullet används endast som effekt, vi spawnar den när vi skjuter. Den kommer åka dit vi träffar och sen förstöras.
public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 50f;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, bulletSpeed*Time.deltaTime);
        if(Vector3.Magnitude((transform.position-targetPosition))<1)
        {
            Destroy(gameObject);
        }
    }
    public void TargetBullet(Vector3 target)
    {
        targetPosition = target;
    }
}
