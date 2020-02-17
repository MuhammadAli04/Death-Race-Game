using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;
    public GameObject player;
    public PlayerCracked pc;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            pc.cracked_player_robot();
            //Destroy(this.gameObject);
            player.SetActive(false);
        }
    }
}
