using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyWhenSceneChanges : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
