using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform other;
    public float damage = 0.5f;
    public float dist;
    public float range = 100f;
    public ParticleSystem fire1;
    public GameObject ImpactEffect;
    // Start is called before the first frame update
    void Awake()
    {
        fire1.Stop();
        

    }
    void Start()
    {
        fire1.Stop();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (other)
        {

            dist = Vector3.Distance(other.position, transform.position);
            print("Distance to other: " + dist);
        }
        if (dist < 100f)
        {
            fire1.Play();
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
            {
                
                Debug.Log(hit.transform.name);
               PlayerHealth P_health= hit.transform.GetComponent<PlayerHealth>();
                if(P_health!=null)
                {
                    P_health.TakeDamage(damage);
                }
                
                GameObject EffectDestory = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(EffectDestory, 1f);
            }
        }
        else
        {
            fire1.Stop();
        }
    }
    

    void Example()
    {
        
    }
}
