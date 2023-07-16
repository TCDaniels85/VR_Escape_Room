using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles triggers within the game
 */
public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject objectToTrigger;  //set an object reference, this can by used within the script
    public bool moveMainDoor;
    public bool moveInitialDoor;
    private float speed = 3.0f;
    private Animator animator;
    private AudioSource audioSrc;
    private bool audioPlaying;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveMainDoor)
        {
            MoveMainDoor();
        }
        if(moveInitialDoor)
        {
            MoveInitialDoor();
        }
    }

    /**
     * Checks tags interacting with collider and the object to trigger and creates actions appropriately.
     */
    private void OnTriggerEnter(Collider other)
    {
        //Moves main door
        if(gameObject.tag == "DoorTrigger" && objectToTrigger.tag == "MainDoor")
        {
            
            if (other.tag == "Player")
            {
                
                moveMainDoor = true;
                
            } 
            
        }
        //Animate button and open first door
        if (gameObject.tag == "ButtonTrigger" && objectToTrigger.tag == "FirstDoor")
        {

            if (other.tag == "RightHand" || other.tag == "LeftHand")
            {

                moveInitialDoor = true;
                animator.SetTrigger("buttonPress");
                
            }           

        }
        //ends the game
        if (gameObject.tag == "EndGameTrigger" && other.tag == "Player")
        {
            Timer timer = objectToTrigger.GetComponent<Timer>();
            PlayerPrefs.SetFloat("mins", timer.GetMins());
            PlayerPrefs.SetFloat("sec", timer.GetSecs());
            PlayerPrefs.SetInt("didWin", 1); //Represents true bool value indicating a win
            SceneLoader.LoadMyScene(2);  //Ends game and returns user to menu

        } 
        //Displays hints
        if(gameObject.tag == "Hint" && other.tag == "Player")
        {
            if(objectToTrigger != null)
            {
                objectToTrigger.SetActive(true);
                Destroy(objectToTrigger, 4);
            }
            
        }
    }
    /**
     * Moves the main door object into position at a certain speed, stops wher reaches position
     */
    private void MoveMainDoor()
    {
        if (objectToTrigger.transform.position.y > 1.0f)
        {
            objectToTrigger.transform.Translate(Vector3.down * speed * Time.deltaTime);
            if(!audioPlaying)
            {
                audioSrc.Play();
                audioPlaying = true;
            }
                 
        } else
        {
            moveMainDoor = false;
            audioPlaying = false;
        }        
    }

    /**
     * Moves the initial door object into position at a certain speed, stops wher reaches position
     */
    private void MoveInitialDoor()
    {
        if (objectToTrigger.transform.position.y < 4.44f)
        {
            objectToTrigger.transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (!audioPlaying)
            {
                audioSrc.Play();
                audioPlaying = true;
            };
        }
        else
        {
            moveInitialDoor = false;
            audioPlaying = false;
        }
    }
}
