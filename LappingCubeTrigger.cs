using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LappingCubeTrigger : MonoBehaviour
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
            Lapping.val++;
            print(Lapping.val);
            if (Lapping.val == 39)
            {

                lap++;
                Lapping.val = 0;
                print(Lapping.val);
            }

        }

    }
}
