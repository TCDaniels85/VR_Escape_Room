using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

/**
 * Handles duck game logic
 */
public class DuckShootGame : MonoBehaviour
{
    [SerializeField] private Transform[] duckStart;
    [SerializeField] private Transform[] duckEnd;
    [HideInInspector] public static int userScore;
    private int oldScore;
    
    [SerializeField] private GameObject duckPrefab;
    [SerializeField] private GameObject scoreBoard;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private TextMeshProUGUI wellDoneText;
    [SerializeField] public PlayableDirector chestOpen;

    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip gameMusic;
    private bool isPlaying = false;

    private AudioSource audioSrc;
    private Animator animator;


    public bool duckGameStart = true;
    private float timer = 0.0f;

    void Start()
    {
        userScore = 0;
        scoreText.text = "Score: " + userScore;
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    //Updates each frame and checks for a change in score adjused in the duck behaviour script
    private void Update()
    {
        if (duckGameStart)
            runDuckGame();

        checkScoreChange();
        
    }
    /**
     * Starts the duck game by initiating scoreboard and increasing the timer.
     */
    private void runDuckGame()
    {
        scoreBoard.SetActive(true);

        if (!isPlaying)
        {
            audioSrc.PlayOneShot(gameMusic, 0.1f);
            
        }
            
        isPlaying = true;

        if (timer > 2) //create a duck every 2 seconds
        {
            CreateDuck();
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }

    /**
     * Creates and instantiates a duck prefab, uses a random number to set one of the 
     * three start and three end positions.
     */
    private void CreateDuck()
    {
        int indexA = Random.Range(0, 3);
        int indexB = Random.Range(0, 3);
        
        GameObject newDuck = Instantiate(duckPrefab, duckStart[indexA].position, duckStart[indexA].rotation) as GameObject;
        newDuck.name = "newDuck";        
        newDuck.GetComponent<DuckBehaviour>().SetTransform(duckEnd[indexB]);
        
    }

    /*
     * Checks if the score has changed and updates the scoreboard.
     * When final score is reached, endgame is triggered.
     */
    private void checkScoreChange()
    {
        
        if (oldScore != userScore)
        {
            oldScore = userScore;
            scoreText.text = "Score: " + userScore;
        }
        if(userScore == 7)
        {
            
            StartCoroutine(EndGame());
            userScore = 0;
        }
    }

    /**
     * Coroutine to end the game
     */
    IEnumerator EndGame()
    {
        audioSrc.Stop();        
        duckGameStart = false;
        scoreText.enabled = false;
        targetText.enabled = false;
        wellDoneText.enabled = true;
        audioSrc.PlayOneShot(winSound);
        yield return new WaitForSeconds(5);
        //Deactivate scoreboard and start chest opening timeline.
        scoreBoard.SetActive(false);
        chestOpen.Play();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand" || other.gameObject.tag == "LeftHand")
        {
            duckGameStart = true;
            animator.SetTrigger("buttonPress");
        }
    }
}
