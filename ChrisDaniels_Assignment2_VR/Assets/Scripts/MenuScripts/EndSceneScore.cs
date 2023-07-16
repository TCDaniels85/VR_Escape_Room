using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * Sets the text on the final score display.
 */
public class EndSceneScore : MonoBehaviour
{
    private float mins;
    private float secs;

    [SerializeField] TextMeshProUGUI timerScore;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI failedText;
    // Start is called before the first frame update
    void Start()
    {
       if(PlayerPrefs.GetInt("didWin") == 1)  //represents bool for player completing scenario
        {
            mins = PlayerPrefs.GetFloat("mins");
            secs = PlayerPrefs.GetFloat("sec");
            timerScore.enabled = true;
            titleText.enabled = true;
            scoreText.enabled = true;
            timerScore.text = string.Format("{0:00} : {1:00}", (6 - mins), (60 - secs)); //Calculates time user took to complete
        } 
        if(PlayerPrefs.GetInt("didWin") ==0) // represents false bool value
        {
            failedText.enabled = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
