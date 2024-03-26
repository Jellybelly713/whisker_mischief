using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI endScreenScoreText;

    void Start()
    {
        if (ScoreManager.instance != null)
        {
            endScreenScoreText.text = " " + ScoreManager.instance.score;
        }
        else
        {
            endScreenScoreText.text = "N/A";
        }
    }
}
