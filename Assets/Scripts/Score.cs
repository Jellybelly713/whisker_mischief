
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PosItem")
        {
            
            ScoreManager.instance.score = score += 1;
            scoreText.text = "Score: " + ScoreManager.instance.score;
            Debug.Log("Points: " + ScoreManager.instance.score + "\n");
            GameObject.Destroy(other.gameObject);


        }
        if (other.tag == "NegItem")
        {
            ScoreManager.instance.score = ScoreManager.instance.score -= 1;
            scoreText.text = "Score: " + ScoreManager.instance.score;
            Debug.Log("Points: " + ScoreManager.instance.score + "\n");
            Destroy(other.gameObject);
;
        }

        if(other.gameObject.tag == "angryZone")
        {
            ScoreManager.instance.score = ScoreManager.instance.score -= 1;
            CollisionNegPnt();
            scoreText.text = "Score: " + ScoreManager.instance.score;
;
        }
    }

    public void CollisionNegPnt()
    {
        score = score - 1;
        scoreText.text = "Score: " + ScoreManager.instance.score;
    }


}
