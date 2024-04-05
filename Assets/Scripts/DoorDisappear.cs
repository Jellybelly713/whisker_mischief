using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDisappear : MonoBehaviour
{

    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if ((Door.GetComponent<Renderer>().enabled) == true)
            {
                Door.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                Door.GetComponent<Renderer>().enabled = true;
            }
        }
            
    }
}
