
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
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
            ScoreManager.instance.score = score += 1;
            scoreText.text = "Score: " + ScoreManager.instance.score;
            Debug.Log("Points: " + ScoreManager.instance.score + "\n");
            AudioClip clip = other.gameObject.GetComponent<AudioSource>().clip;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);

        }
        if (other.gameObject.tag == "NegItem")
        {
            ScoreManager.instance.score = ScoreManager.instance.score -= 1;
            scoreText.text = "Score: " + ScoreManager.instance.score;
            Debug.Log("Points: " + ScoreManager.instance.score + "\n");
            AudioClip clip = other.gameObject.GetComponent<AudioSource>().clip;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        }

        if(other.gameObject.tag == "angryZone")
        {
            ScoreManager.instance.score = ScoreManager.instance.score -= 1;
            CollisionNegPnt();
            scoreText.text = "Score: " + ScoreManager.instance.score;
        }
    }

    public void CollisionNegPnt()
    {
        score = score - 1;
        scoreText.text = "Score: " + ScoreManager.instance.score;
    }


}
