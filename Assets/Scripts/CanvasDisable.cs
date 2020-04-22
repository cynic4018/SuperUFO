using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisable : MonoBehaviour
{
    public Canvas canvas;
    public SuperUFO su;

    void Awake() {
        su = FindObjectOfType<SuperUFO>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            canvas.GetComponent<Canvas>().enabled = false;
            su.rb.isKinematic = false;
        }
    }
}
