using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform path;
    private List<Transform> nodes;
    public float maxsteerangle = 40f;
    public int currentnode=0;
    public WheelCollider FL;
    public WheelCollider FR;
    void Start()
    {
        Transform[] pathtransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathtransforms.Length; i++)
        {
            if (pathtransforms[i] != path.transform)
            {
                nodes.Add(pathtransforms[i]);
            }
        }
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        ApplySteer();
    }
    private void ApplySteer()
    {
        
        Vector3 relativevector = transform.InverseTransformDirection(nodes[currentnode].position);
        //relativevector /= relativevector.magnitude;
        float newsteer = (relativevector.x / relativevector.magnitude) * maxsteerangle;
        FL.steerAngle = newsteer;
        FR .steerAngle = newsteer;
    }
}
