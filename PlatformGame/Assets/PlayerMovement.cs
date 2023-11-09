using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        }

        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
        }

        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
        }

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
        }
    }
}
