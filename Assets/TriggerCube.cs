using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    // Start is called before the first frame update
    public static int lap;
    public GameObject nextcube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nextcube.SetActive(true);
            this.gameObject.SetActive(false);
            LapSytem.val++;
            print(LapSytem.val);
            if (LapSytem.val == 39)
            {
                
                lap++;
                LapSytem.val = 0;
                print(LapSytem.val);
            }
            
        }
        
    }
}
