using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class script : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PosItem")
        {
            score = score + 1;
            scoreText.text = "Score: " + score;
            Debug.Log("Points: " + score + "\n");

        }
        if (other.gameObject.tag == "NegItem")
        {
            score = score - 1;
            scoreText.text = "Score: " + score;
            Debug.Log("Points: " + score + "\n");
        }
    }
}
