using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    public GameObject maxChaosImg;


    // Start is called before the first frame update
    void Start()
    {
        maxChaosImg.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (score >= 20)
        {
            maxChaosImg.SetActive(true);
        }
        else
        {
            maxChaosImg.SetActive(false);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}