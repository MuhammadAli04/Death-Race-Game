using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EndOfDemoRace : MonoBehaviour
{
    //You can use this script to customize what happens at the end of your race
    //This is in UnityScript (or javascript), for a C# version look for GeneralEndOfRaceCS.cs (it should be in the same folder)
    public lap_script lapScript; //remeber to drag your LapSystem object here
    public float delayUntilGUIFadesIn;
    private bool delayover;
    private bool hasFinished;
    private bool hasFadedGUIIn;
    private int positionFinished;
    //GUI to fade in:
    public TextureScript background;
    public TextureScript first;
    public TextureScript second;
    public TextureScript third;
    public TextureScript fourth;
   // public PlayAgainButton playAgainButton;
    public virtual void Update()
    {
        this.hasFinished = this.lapScript.hasfinished;
        this.positionFinished = this.lapScript.positionfinished;
        if (this.delayover == true)
        {
            if (this.hasFadedGUIIn == false)
            {
                //fade GUI in
                this.background.FadeIn();
                //this.playAgainButton.FadeIn();
                if (this.positionFinished == 2)
                {
                    //came 1st
                    this.first.FadeIn();
                }
                if (this.positionFinished == 3)
                {
                    //came 2nd
                    this.second.FadeIn();
                }
                if (this.positionFinished == 4)
                {
                    //came 3rd
                    this.third.FadeIn();
                }
                if (this.positionFinished == 5)
                {
                    //came 4th
                    this.fourth.FadeIn();
                }
                // ... etc
                this.hasFadedGUIIn = true;
            }
        }
        if (this.hasFinished == true)
        {
            this.StartCoroutine(this.DelayUntilFadeIn());
        }
    }

    public virtual IEnumerator DelayUntilFadeIn()
    {
        yield return new WaitForSeconds(this.delayUntilGUIFadesIn);
        this.delayover = true;
    }

    public virtual void ButtonPressed()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}