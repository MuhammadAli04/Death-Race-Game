using UnityEngine;
using System.Collections;

public class StartCarsMovingDelay : MonoBehaviour {


public RCC_AICarController carOne;
public RCC_AICarController carTwo;
public RCC_AICarController carThree;
//public RCC_CarControllerV3 playerCar;
    public GameObject playercars;
public float delay;
//public AudioSource tracksound;
//public GameObject wrong;
	// Use this for initialization
    void Awake()
    {
        playercars = GameObject.FindGameObjectWithTag("Player");
    }
	void Start () {
		StartCoroutine("Delay");
       
        //playercars.GetComponent<RCC_CarControllerV3>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        playercars = GameObject.FindGameObjectWithTag("Player");
    }
	
	IEnumerator Delay() {
		yield return new WaitForSeconds(delay);
		carOne.enabled = true;
		carTwo.enabled = true;
		//carThree.enabled = true;
		//playerCar.enabled = true;
        playercars.GetComponent<Death_Race_CarControllerV3>().enabled = true;
        //PlayOf2.playcount = 1;
       // PlayOf2.flagTimer = 1;
       // Play.playcount=1;
		//Play.flagTimer=1;
		//tracksound.GetComponent<AudioSource>().enabled=true;
		//wrong.SetActive(true);
	}
}
