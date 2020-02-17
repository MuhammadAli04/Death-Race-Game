using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class lap_script : MonoBehaviour
{
    public player_pos_gui PlayerCar;
    private Computer_Car_Script[] ComputerCars;
    //public GUIText lapDisplay;
    public int numberOfLaps;
    private int initialFontSize;
    public int finishedFontSize;
    public int positionfinished; //1=1st, 2=2nd, etc...
    public bool hasfinished;
    public bool useCs;
    public GameObject CsObject;
    private bool hasSentCsInfo;
    public virtual void Start()
    {
        GameObject storageobject = GameObject.Find("Storage");
        storage storagescript = (storage) storageobject.GetComponent(typeof(storage));
        this.ComputerCars = storagescript.allcomputercars;
        //this.initialFontSize = this.lapDisplay.fontSize;
    }

    /*
DO STUFF WHEN FINISHED:

Use the script in the EndOfRaceScripts folder to do something at the end of the race
There is a c# and javascript version. (if you use the c# version look in the Inspector of the LapSystem object and tick the toggle, make sure you drag the object which the script is applied to into the revelent field)

If you wish to write your own here is some advice:

You can type code here (outside the comment area)
Refer to positionfinished if needed, 1=1st, 2=2nd, etc...

if you put your own variables here, they will not appear in the inspector
instead, you could call a function from another script or look into the editor
extension for this script if you are more experianced

for example if you put a script called 'dostuff' on this LapSystem object, use
the following to call the function 'interestingfunction' on the script:

var script = gameObject.GetComponent(dostuff);
script.interestingfunction();

But it is advised that you look at the scripts in the EndOfRaceScripts folder, if you did not understand the above (apologies ... it is not very clear)
*/    public virtual void Update()
    {
        int lapsbeen = this.PlayerCar.currentlap;
        if (lapsbeen > this.numberOfLaps)
        {
            if (this.hasfinished == false)
            {
                this.positionfinished = this.positionfinished + 1;
            }
            //this.lapDisplay.text = "Finished";
            //this.lapDisplay.fontSize = this.finishedFontSize;
            this.hasfinished = true;
        }
        else
        {
            //this.lapDisplay.fontSize = this.initialFontSize;
            //this.lapDisplay.text = (("" + lapsbeen) + "/") + this.numberOfLaps;
        }
        if (this.hasfinished == false)
        {
            foreach (Computer_Car_Script car in this.ComputerCars)
            {
                if (car.hasbeenaddedtofinishingposition == false)
                {
                    if (car.currentlap > this.numberOfLaps)
                    {
                        car.hasbeenaddedtofinishingposition = true;
                        this.positionfinished = this.positionfinished + 1;
                    }
                }
            }
        }
        else
        {
            if (this.useCs == true)
            {
                if (this.hasSentCsInfo == false)
                {
                    if (this.CsObject != null)
                    {
                        this.CsObject.BroadcastMessage("RaceFinished", this.positionfinished);
                    }
                    this.hasSentCsInfo = true;
                }
            }
        }
    }

    public lap_script()
    {
        this.numberOfLaps = 3;
        this.finishedFontSize = 10;
        this.positionfinished = 1;
    }

}