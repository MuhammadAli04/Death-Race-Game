using UnityEngine;
using System.Collections;

[System.Serializable]
public  class Computer_Car_Script : MonoBehaviour
{
    public bool hasbeenaddedtofinishingposition;
    //gui
    public bool textureEnabled;
    //public GameObject objecttochangetexture;
    //public Material[] positionTextures;
    public bool ElementsExpand;
    public int ElementsSize;
    //race position stuff
    public int raceposition;
    public GameObject playercar;
    public Computer_Car_Script[] othercomputercars;
    public bool othercomputercars_ElementsExpand;
    public int othercomputercars_ElementsSize;
    //detector stuff
    public int positionn;
    public float positionpercenage;
    public int lastposition;
    public GameObject[] positionobjectarray;
    public GameObject closest;
    public position_sensor script;
    public int currentlap;
    public int numbergoneback;
    public int numberofpositions;
    void Awake()
    {
        playercar = GameObject.FindGameObjectWithTag("Player");
    }
    public virtual void Start()
    {
        playercar = GameObject.FindGameObjectWithTag("Player");
        GameObject[] bob = (GameObject[]) GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject tom in bob)
        {
            if (tom.gameObject.name == "PositionSensor")
            {
                GameObject[] santa = new GameObject[0];
                santa = this.positionobjectarray;
                this.positionobjectarray = new GameObject[santa.Length + 1];
                int rudolf = 0;
                foreach (GameObject obj in santa)
                {
                    this.positionobjectarray[rudolf] = santa[rudolf];
                    rudolf = rudolf + 1;
                }
                this.positionobjectarray[this.positionobjectarray.Length - 1] = tom.gameObject;
            }
        }
    }

    public virtual void Update()
    {
        playercar = GameObject.FindGameObjectWithTag("Player");
        float distancepercentage = 0.0f;
        //raceposition stuff
        this.raceposition = 0;
        if (this.othercomputercars.Length > 0)
        {
            foreach (Computer_Car_Script scripts in this.othercomputercars)
            {
                if ((scripts.currentlap - scripts.numbergoneback) > (this.currentlap - this.numbergoneback))
                {
                    this.raceposition = this.raceposition + 1;
                }
                else
                {
                    if ((scripts.currentlap - scripts.numbergoneback) == (this.currentlap - this.numbergoneback))
                    {
                        if (scripts.positionn > this.positionn)
                        {
                            this.raceposition = this.raceposition + 1;
                        }
                        else
                        {
                            if (scripts.positionn == this.positionn)
                            {
                                if (scripts.positionpercenage > this.positionpercenage)
                                {
                                    this.raceposition = this.raceposition + 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        player_pos_gui playerscript = (player_pos_gui) this.playercar.gameObject.GetComponent(typeof(player_pos_gui));
        if ((playerscript.currentlap - playerscript.numbergoneback) > (this.currentlap - this.numbergoneback))
        {
            this.raceposition = this.raceposition + 1;
        }
        else
        {
            if ((playerscript.currentlap - playerscript.numbergoneback) == (this.currentlap - this.numbergoneback))
            {
                if (playerscript.positionn > this.positionn)
                {
                    this.raceposition = this.raceposition + 1;
                }
                else
                {
                    if (playerscript.positionn == this.positionn)
                    {
                        if (playerscript.positionpercenage > this.positionpercenage)
                        {
                            this.raceposition = this.raceposition + 1;
                        }
                    }
                }
            }
        }
        //texture stuff
        if (this.textureEnabled == false)
        {
            //this.objecttochangetexture.gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            //this.objecttochangetexture.gameObject.GetComponent<Renderer>().enabled = true;
            //this.objecttochangetexture.gameObject.GetComponent<Renderer>().material = this.positionTextures[this.raceposition];
        }
        if (this.closest == null)
        {
        }
        else
        {
            this.lastposition = this.positionn;
            this.script = (position_sensor) this.closest.gameObject.GetComponent("position_sensor");
            this.positionn = this.script.positionnumber;
            if ((this.lastposition == this.numberofpositions) && (this.positionn == 0))
            {
                if (this.numbergoneback > 0)
                {
                    this.numbergoneback = this.numbergoneback - 1;
                }
                else
                {
                    this.currentlap = this.currentlap + 1;
                }
            }
            if ((this.lastposition == 0) && (this.positionn == this.numberofpositions))
            {
                this.numbergoneback = this.numbergoneback + 1;
            }
        }
        float nearestDistanceSqr = Mathf.Infinity;
        foreach (GameObject obj in this.positionobjectarray)
        {
            Vector3 objectPos = obj.transform.position;
            float distanceSqr = (objectPos - this.transform.position).sqrMagnitude;
            if (distanceSqr < nearestDistanceSqr)
            {
                this.closest = obj.gameObject;
                nearestDistanceSqr = distanceSqr;
            }
        }
        position_sensor closestscript = (position_sensor) this.closest.gameObject.GetComponent(typeof(position_sensor));
        int closestpositionnumber = closestscript.positionnumber;
        int infrontnumber = 0;
        int behindnumber = 0;
        if (closestpositionnumber == this.numberofpositions)
        {
            infrontnumber = 0;
            behindnumber = closestscript.positionnumber - 1;
        }
        else
        {
            if (closestpositionnumber == 0)
            {
                infrontnumber = 1;
                behindnumber = this.numberofpositions;
            }
            else
            {
                infrontnumber = closestscript.positionnumber + 1;
                behindnumber = closestscript.positionnumber - 1;
            }
        }
        //find closest between infront objects
        GameObject closestinfrontobject = null;
        float neearestDistanceSqr = Mathf.Infinity;
        foreach (GameObject obbj in this.positionobjectarray)
        {
            int posnumberinobbj = ((position_sensor) obbj.gameObject.GetComponent(typeof(position_sensor))).positionnumber;
            if (posnumberinobbj == infrontnumber)
            {
                Vector3 obbjectPos = obbj.transform.position;
                float diistanceSqr = (obbjectPos - this.transform.position).sqrMagnitude;
                if (diistanceSqr < neearestDistanceSqr)
                {
                    closestinfrontobject = obbj.gameObject;
                    neearestDistanceSqr = diistanceSqr;
                }
            }
        }
        //find closest between behind objects
        GameObject closestbehindobject = null;
        float neeearestDistanceSqr = Mathf.Infinity;
        foreach (GameObject obbbj in this.positionobjectarray)
        {
            int posnumberinobbbj = ((position_sensor) obbbj.gameObject.GetComponent(typeof(position_sensor))).positionnumber;
            if (posnumberinobbbj == behindnumber)
            {
                Vector3 obbbjectPos = obbbj.transform.position;
                float diiistanceSqr = (obbbjectPos - this.transform.position).sqrMagnitude;
                if (diiistanceSqr < neeearestDistanceSqr)
                {
                    closestbehindobject = obbbj.gameObject;
                    neeearestDistanceSqr = diiistanceSqr;
                }
            }
        }
        float distancebetweenposandinfront = Vector3.Distance(closestinfrontobject.transform.position, closestbehindobject.transform.position);
        float distancebetweenposandbehind = Vector3.Distance(closestbehindobject.transform.position, this.gameObject.transform.position);
        distancepercentage = distancebetweenposandbehind / distancebetweenposandinfront;
        this.positionpercenage = distancepercentage * 100;
    }

    public Computer_Car_Script()
    {
        this.textureEnabled = true;
       // this.positionTextures = new Material[this.ElementsSize];
        this.ElementsExpand = true;
        this.ElementsSize = 1;
        this.othercomputercars = new Computer_Car_Script[this.othercomputercars_ElementsSize];
        this.othercomputercars_ElementsExpand = true;
        this.othercomputercars_ElementsSize = 1;
        this.currentlap = 1;
    }

}