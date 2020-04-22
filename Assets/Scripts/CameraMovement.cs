using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public GameObject topBoarder;
    public GameObject botBoarder;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(target.transform.position.x, 0, -5f);
        topBoarder.transform.position = new Vector3(target.transform.position.x, this.gameObject.transform.position.y+4, target.gameObject.transform.position.z);
        botBoarder.transform.position = new Vector3(target.transform.position.x, this.gameObject.transform.position.y-4, target.gameObject.transform.position.z);
    }
}
