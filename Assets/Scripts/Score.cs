
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
        if (other.tag == "PosItem")
        {
            score = score + 1;
            scoreText.text = "Score: " + score;
            Debug.Log("Points: " + score + "\n");
            GameObject.Destroy(other.gameObject);
            AudioClip clip = other.gameObject.GetComponent<AudioSource>().clip;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);

        }
        if (other.tag == "NegItem")
        {
            score = score - 1;
            scoreText.text = "Score: " + score;
            Debug.Log("Points: " + score + "\n");
            Destroy(other.gameObject);
            AudioClip clip = other.gameObject.GetComponent<AudioSource>().clip;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        }


    }

    public void CollisionNegPnt()
    {
        score = score - 1;
        scoreText.text = "Score: " + score;
    }


}
