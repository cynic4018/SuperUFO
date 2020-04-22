using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePipeTrigger : MonoBehaviour
{

    public GamePlayManager gm;

    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GamePlayManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        gm.ReassignPipePos();
        gm.passingCheck ++;
    }
}
