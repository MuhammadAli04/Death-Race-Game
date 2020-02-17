using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCracked : MonoBehaviour
{
    public GameObject crackedcar, bombs, CrackedEnemy;
    public float power = 30.0f;
    public float radius = 5.0f;
    public float upforce = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void cracked_enemy_robot()
    {
        CrackedEnemy= Instantiate(crackedcar, transform.position, transform.rotation);
        gameObject.SetActive(false);
        Detonatesss();
    }
    public void Detonatesss()
    {
        Vector3 expolsionposition = bombs.transform.position;
        Collider[] colliders = Physics.OverlapSphere(expolsionposition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody r1 = hit.GetComponent<Rigidbody>();
            if (r1 != null)
            {
                r1.AddExplosionForce(power, expolsionposition, radius, upforce, ForceMode.Impulse);
            }

        }

        Destroy(CrackedEnemy, 4f);
        //gameObject.SetActive(true);
        //Invoke("off", 3f);
    }
    public void off()
    {
        print(0);
        crackedcar.SetActive(false);
    }
}
