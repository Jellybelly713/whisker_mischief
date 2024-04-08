using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class ChangeFace : MonoBehaviour
{
    public MoveRobot moveRobot;

    public Material happy;
    public Material mad;
    Renderer rend;
    float lerp = Mathf.PingPong(Time.time,0.5f) / 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        // At start, use the first material
        rend.material = happy;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRobot.isMad == false){
            rend.material.Lerp(happy, mad, lerp);
        }
        else if (moveRobot.isMad == true){
            rend.material.Lerp(mad, happy, lerp);
        }
    }

}
