using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lapcubes;
    public static int val;
    public GameObject clear;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void lapcount()
    {
        if (TriggerCube.lap == 2)
        {
            clear.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
