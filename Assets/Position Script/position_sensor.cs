using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class position_sensor : MonoBehaviour
{
    
    
    
    public int positionnumber;
    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
    
    }
    

    public virtual void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(new Vector3(this.transform.position.x, this.transform.position.y + 0.15f, this.transform.position.z), new Vector3(0.3f, 0.3f, 0.3f));
    }

}