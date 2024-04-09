
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoreText;
    public AudioSource plop;
    public AudioSource buzz;
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
            AudioClip clip = other.gameObject.GetComponent<AudioSource>().clip;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
            plop.Play();

        }
        if (other.tag == "NegItem")
        {
            ScoreManager.instance.score = ScoreManager.instance.score -= 1;
            scoreText.text = "Score: " + ScoreManager.instance.score;
            Debug.Log("Points: " + ScoreManager.instance.score + "\n");
            Destroy(other.gameObject);
            AudioClip clip = other.gameObject.GetComponent<AudioSource>().clip;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        }

        if(other.gameObject.tag == "angryZone")
        {
            ScoreManager.instance.score = ScoreManager.instance.score -= 1;
            CollisionNegPnt();
            scoreText.text = "Score: " + ScoreManager.instance.score;
            buzz.Play();
        }
    }

    public void CollisionNegPnt()
    {
        score = score - 1;
        scoreText.text = "Score: " + ScoreManager.instance.score;
    }


}
