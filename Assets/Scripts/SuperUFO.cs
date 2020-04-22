using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperUFO : MonoBehaviour
{
    public Rigidbody rb;
    public float JumpPower = 3f;
    public float fowardSpeed = 2f;
    public GamePlayManager gm;
    public float maxSpeed = 3f;
    public bool preventInput = false;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GamePlayManager>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver == false){
            if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                if(preventInput == true){
                    preventInput = false;
                }
                else if(preventInput == false){
                    rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                    gm.soundManager.JumpSoundActive();
                }
            }  
        }
        
    }

    void FixedUpdate()
    {
        if(gm.gameOver == false && preventInput == false){
            rb.AddForce(Vector3.right * fowardSpeed);
            if(rb.velocity.magnitude > maxSpeed){
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
        
    }

    // void MyUpdate(){
    //     rb.AddForce(Vector3.right * fowardSpeed);
    //     //rb.velocity = Vector3.right * fowardSpeed;
    // }

    void OnCollisionEnter(Collision collision)
    {
        preventInput = true;
        print("Colide something, GAME OVER");
        gm.GameOver();
        rb.isKinematic = true;
    }
}
