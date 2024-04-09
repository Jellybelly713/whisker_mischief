using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour

{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        if (remainingTime > 0.0f)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime < 10.0f)
        {
            timerText.color = Color.red;
        }
        if (remainingTime < 0.0f) 
        {
            remainingTime = 0.0f;

            
        }

        if (remainingTime <= 0.0f)
        {
            remainingTime = 0.0f;

            // Check the score
            int score = ScoreManager.instance.score;
            if (score <= 9)
            {
                SceneManager.LoadScene("BadEndScreen");

            }
            if (score >= 20)
            {
                SceneManager.LoadScene("SuperWinScreen");
            }
            else
            {
                SceneManager.LoadScene("GoodEndScreen");
            }
        }

        int MIN = Mathf.FloorToInt(remainingTime / 60);
        int SEC = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", MIN, SEC);
    }
}
