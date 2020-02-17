using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCracked : MonoBehaviour
{
    public GameObject crackedcar, bombs, CrackedPlayer;
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
    public void cracked_player_robot()
    {
        CrackedPlayer = Instantiate(crackedcar, transform.position, transform.rotation);
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

        Destroy(CrackedPlayer, 4f);
        //gameObject.SetActive(true);
        //Invoke("off", 3f);
    }
    public void off()
    {
        print(0);
        crackedcar.SetActive(false);
    }
}
