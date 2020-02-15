using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float health=50f;
    public EnemyCracked ec;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health<=0f)
        {
            ec.cracked_enemy_robot();
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
