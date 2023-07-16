using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;


/**
 * Handles logic for basketball minigame
 */
public class BasketBallGame : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoard;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private TextMeshProUGUI wellDoneText;
    [SerializeField] public PlayableDirector chestOpen;
    private AudioSource audioSrc;

    private int userScore;
    

    void Start()
    {
        scoreText.text = "Score: " + userScore;
        audioSrc = GetComponent<AudioSource>();
    }

    /**
     * Activates on entering trigger, updates score when ball passes though net
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BasketBall")
        {
            if(scoreBoard.activeSelf == false) //set the score board active if inactive
            {
                scoreBoard.SetActive(true);
            }
            UpdateScore();
        }
    }

    /**
     * Updates score by 1
     * Starts end game coroutine when score reaches three.
     */
    private void UpdateScore()
    {
        userScore += 1;
        scoreText.text = "Score: " + userScore;  //set menu text
        if (userScore == 3)
        {

            StartCoroutine(EndGame());
            userScore = 0;
        }
    }

    /**
     * Coroutine plays audio and disables scoreboard after displaying win text.
     * After the wait time, the chestOpen timeline is set to play.
     */
    IEnumerator EndGame()
    {
        audioSrc.Play();
        
        scoreText.enabled = false;
        targetText.enabled = false;
        wellDoneText.enabled = true;
       
        yield return new WaitForSeconds(5);
        scoreBoard.SetActive(false);
        chestOpen.Play();


    }
}
