using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Robot_GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] playcomponents;
    public AudioSource btn, soundgame;

    public AudioClip btnsnd;
    public static int playcount, flagTimer;
    int my_Scene;
    public Text TimerBar, coin1;
    public float Timer;
    private int minutes;
    private int seconds;
    public static int CallClear, CallFail;
    public GameObject failed;
    public AudioSource tracksound;
    void Start()
    {
        Time.timeScale = 1;
        my_Scene = SceneManager.GetActiveScene().buildIndex;
        flagTimer = 0;
        CallClear = 1;
        CallFail = 1;
        //playercar = GameObject.FindGameObjectWithTag("Player");
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("Coinsscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //playercar = GameObject.FindGameObjectWithTag("Player");
        coin1.text = PlayerPrefs.GetInt("Score").ToString();
        btn.volume = PlayerPrefs.GetFloat("soundval");
        soundgame.volume = PlayerPrefs.GetFloat("soundval");
        for (int i = 0; i < playcomponents.Length; i++)
        {
            if (i == playcount)
            {
                playcomponents[i].SetActive(true);
            }
            else
            {
                playcomponents[i].SetActive(false);
            }
        }
        if (flagTimer.Equals(1))
        {
            Timer -= Time.deltaTime;
            minutes = (int)Timer / 60;
            seconds = (int)Timer % 60;
            TimerBar.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (Timer <= 0)
            {
                Invoke("FailCall", 2.0f);
                Timer = 0;
            }
        }
    }
    public void playonclick(int value)
    {
        btn.PlayOneShot(btnsnd, 1f);
        playcount = value;
        if (value.Equals(2))//pause
        {
            flagTimer = 0;
            playcount = 2;
            Time.timeScale = 0;
        }
        else if (value.Equals(3))//resume
        {

            flagTimer = 1;
            playcount = 1;
            tracksound.GetComponent<AudioSource>().enabled = true;
            Time.timeScale = 1;
        }
        else if (value.Equals(7))
        {//Restart
         //failed.SetActive(false);
            SceneManager.LoadScene(my_Scene, LoadSceneMode.Single);

        }
        else if (value.Equals(5))
        {//Menu
            SceneManager.LoadSceneAsync("Menu");
            //Menu_Script.menucount = 1;
            Time.timeScale = 1;
        }
        else if (value.Equals(6))
        {//Next

            SceneManager.LoadSceneAsync("Menu");
            //Menu_Script.menucount = 2;
            //SceneManager.LoadScene(my_Scene + 1);
        }
        else
        {
        }
    }
    public void FailCall()
    {
        playcount = 4;
        if (CallFail.Equals(1))
        {
            CallFail = 0;
        }
        Time.timeScale = 0;
    }
    public void ClearCall()
    {
        playcount = 3;
        if (CallClear.Equals(1))
        {
            PlayerPrefs.SetInt("Lock" + SceneManager.GetActiveScene().buildIndex, 1);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
            CallClear = 0;
        }
        Time.timeScale = 0;
    }
}
