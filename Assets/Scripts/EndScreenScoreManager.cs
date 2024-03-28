using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI endScreenScoreText;

    void Start()
    {
        if (ScoreManager.instance.score != 0)
        {
            endScreenScoreText.text = " " + ScoreManager.instance.score;
        }
        else
        {
            endScreenScoreText.text = "N/A"; // if score = 0
        }
    }
}
