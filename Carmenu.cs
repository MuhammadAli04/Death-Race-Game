using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Carmenu : MonoBehaviour
{
    //  public Slider slidsound, slidermusic;

    // Use this for initialization
    public GameObject NextLevelButton, soundon, soundoff, selection,unlockall;
    //public InputField playername;
    public GameObject[] menucomponents;
    public static int menucount;
    //public AudioSource btn;
    //public AudioClip btnsnd;
    public Button[] lockbutton;
    int LeveltoLoad;


    public GameObject[] player, lock_btn_img;
    public GameObject left_Btn, right_Btn, not_enough_cash, lock_img, price;
    public int scoreint;
    public static int value_count;
    public static int ControlsSelections;
    public Button nextBtn;
    public Text ScoreCoins;

    void Start()
    {
        //lockimage.SetActive (false);
        //PlayerPrefs.DeleteAll();
        LeveltoLoad = 0;
        NextLevelButton.SetActive(false);
        //slidermusic.value = 0.5f;
        //slidsound.value = 0.5f;
        //Time.timeScale = 1;
        value_count = 0;
        //menucount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ScoreCoins.text = PlayerPrefs.GetInt("Score").ToString();
        //PlayerPrefs.SetInt ("TruckValue", value_count);
        for (int i = 0; i < player.Length; i++)
        {
            if (i == value_count)
            {
                player[i].SetActive(true);
            }
            else
            {
                //player [i].SetActive (false);
            }
        }
        //PlayerPrefs.SetFloat("soundval", slidsound.value);
        //menusound.volume = slidermusic.value;
        for (int i = 0; i < menucomponents.Length; i++)
        {
            if (i == menucount)
            {
                menucomponents[i].SetActive(true);
            }
            else
            {
                menucomponents[i].SetActive(false);
            }
        }
        for (int j = 0; j < lockbutton.Length; j++)
        {
            if (PlayerPrefs.GetInt("Lock" + (j + 1)).Equals(1))
            {
                lockbutton[j].interactable = true;
            }
        }
        //if (value_count == 0)
        //{
        //    left_Btn.SetActive(false);
        //}
        //else
        //{
        //    left_Btn.SetActive(true);
        //}
        //if (value_count == 2)
        //{
        //    right_Btn.SetActive(false);
        //}
        //else
        //{
        //    right_Btn.SetActive(true);
        //}
        
        if (PlayerPrefs.GetInt("unlock_player" + value_count) == 1)
        {
            lock_img.SetActive(false);
            price.SetActive(false);
            nextBtn.GetComponent<Button>().interactable = true;
        }
        else
        {
            if (value_count == 0)
            {
                lock_img.SetActive(false);
                price.SetActive(false);
                nextBtn.GetComponent<Button>().interactable = true;
            }
            else
            {
                lock_img.SetActive(true);
                price.SetActive(true);
                nextBtn.GetComponent<Button>().interactable = false;

            }
        }
    }
    public void menuonclick(int value)
    {
        //btn.volume = slidermusic.value;
        //btn.playoneshot(btnsnd, 1f);
        menucount = value;

        if (menucount == 1)
        {
            selection.SetActive(true);
            unlockall.SetActive(false);
        }
       
    }
    public void loadscene()
    {
        //btn.PlayOneShot(btnsnd, 1f);
        menucount = 3;
        //load.fillAmount
        //menusound.SetActive(false);
        Invoke("loading_level", 1.8f);
    }
    void loading_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LeveltoLoad);
    }
    public void onclick_levelbtn(int level_value)
    {
        //GameMusic.PlayOneShot (ButtonSound, 1f);
        LeveltoLoad = level_value;
        NextLevelButton.SetActive(true);
    }
    public void OnSound()
    {
        soundoff.SetActive(true);
        soundon.SetActive(false);
        //menusound.SetActive(false);

    }
    public void OffSound()
    {
        soundoff.SetActive(false);
        soundon.SetActive(true);
        //menusound.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Right_Button()
    {
        value_count++;
        //btn_selection.PlayOneShot(btnsnd, 1f);
    }
    public void Left_Button()
    {
        //music.PlayOneShot (sound, 1.0f);
        value_count--;
        //btn_selection.PlayOneShot(btnsnd, 1f);
    }
    public void loadlevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
    public void level()
    {

    }
    public void onclick_buy()
    {
        //btn_selection.PlayOneShot(btnsnd, 1f);
        //music.PlayOneShot (sound, 1.0f);
        if (PlayerPrefs.GetInt("Score") >= (300))
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - (400));
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("unlock_player" + value_count, 1);
        }
        else
        {
            not_enough_cash.SetActive(true);
            Invoke("not_E_cash", 2f);
        }
    }
    public void not_E_cash()
    {
        not_enough_cash.SetActive(false);
    }
    public void unlockplayer()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("unlock_player" + (i + 1), 1);

        }
        unlockall.SetActive(false);
    }
    public void Select_Robot()
    {
        menucount = 2;
        PlayerPrefs.SetInt("Robot_Select", value_count);
    }
    //public void RemoveAdd()
    //{
    //    add.SetActive(true);
    //}
    public void unlock()
    {
        unlockall.SetActive(true);
    }
   
}
