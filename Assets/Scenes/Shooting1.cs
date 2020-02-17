using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting1 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem fire1,fire2;
    public GameObject ImpactEffect,aim,gun;
   
    public Camera fps;

    void Awake()
    {
        fire1.Stop();
        fire2.Stop();
        
    }
    void Start()
    {
        fire1.Stop();
        fire2.Stop();
       
    }
    // Update is called once per frame
    void Update()
    {
        gun.transform.LookAt(aim.transform);

    }
    
    public void particleOn()
    {
        fire1.Play();
        fire2.Play();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.transform.name);

            Enemy1 traget = hit.transform.GetComponent<Enemy1>();
            if (traget != null)
            {
                traget.TakeDamage(damage);
            }
            GameObject EffectDestory = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(EffectDestory, 1.5f);
        }
       
    }
    public void particleOff()
    {
        fire1.Stop();
        fire2.Stop();
        

    }
}
