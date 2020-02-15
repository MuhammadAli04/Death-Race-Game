using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrong_controller : MonoBehaviour {
	public Transform player,current_pos;
	public Transform[] position_point;
	public float dotProduct;
	public int number_,highest_number, highestupdate_number;
	public GameObject wrongway,wrongway1;
   // public RCC_UIController up;

//	public position_sensor wp;
//	public RCC_AICarController AI_controller;
//	public GameObject wrongway,start,end,back_cube,clear_cube;
	public int checkpoint_value,checkpoint_value2,checkpoint_value3,checkpoint_value4,number;
		//public int lap_value = 10;
	// Use this for initialization
	void Start () {
		//	wp = FindObjectOfType<position_sensor>();
		//	AI_controller = FindObjectOfType<RCC_AICarController> ();
			number = 0;
           // up = FindObjectOfType<RCC_UIController>();
	}
	
	// Update is called once per frame
	void Update () {
			player = GameObject.FindGameObjectWithTag ("Player").transform;
			number_= player.GetComponent<player_pos_gui>().positionn;
        //highest_number = FindObjectOfType<RCC_UIController>().updatepos;
        //highestupdate_number = up.GetComponent<RCC_UIController>().updatepos;

             if (number_>highest_number)
			 {
                highest_number =number_;
            
             }
        //else
        //{
        //     highest_number = up.GetComponent<RCC_UIController>().updatepos;
        //}
            if (number_<highest_number)
			{ 
                wrongway1.SetActive(true);
                //wrongsound.SetActive(true);
            
            }
			else
			{
				wrongway1.SetActive(false);
               // wrongsound.SetActive(false);
        }
			for (int i = 0; i < position_point.Length; i++) 
      		{
				if(i.Equals(number_))
				current_pos=	position_point[i];
			}
			dotProduct = Vector3.Dot(current_pos.transform.forward, player.transform.forward);
			if(dotProduct<-0.5f)
		{
			wrongway.SetActive(true);
            wrongway1.SetActive(false);
           // wrongsound.SetActive(true);
        }
		else
		{
			wrongway.SetActive(false);
           // wrongsound.SetActive(false);
        }
		
	//		if (AI_controller.totalWaypointPassed == 0) {
	//			start.SetActive (true);
	//			end.SetActive (false);
	//			back_cube.SetActive (true);
	//			clear_cube.SetActive (false);
	//		}
			/* if (AI_controller.totalWaypointPassed == checkpoint_value || wp.check==checkpoint_value2 ) {

				back_cube.SetActive (false);
			}
			if (AI_controller.totalWaypointPassed == checkpoint_value4 || wp.check==checkpoint_value3) {
				start.SetActive (false);
				end.SetActive (true);
				clear_cube.SetActive (true);
			}
			if (wp.check == lap_value) {
				if (number == 0) {
					FindObjectOfType<RCC_AICarController> ().lap++;
					number = 1;
				}
			}*/
	}
}

