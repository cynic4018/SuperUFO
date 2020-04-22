using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFORing : MonoBehaviour
{
    public float ringSpeed = 2f;
    public SuperUFO su;
    // Start is called before the first frame update
    void Awake()
    {
        su = FindObjectOfType<SuperUFO>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotate the x-axis of UFO's ring.
        if(su.preventInput == false){
            this.transform.Rotate(0+ringSpeed, 180, 180);
        }   
    }
}
