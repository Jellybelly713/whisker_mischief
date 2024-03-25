using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    
    public void GraphicsQualityLow()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void GraphicsQualityMed()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void GraphicsQualityHigh()
    {
        QualitySettings.SetQualityLevel(2);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
