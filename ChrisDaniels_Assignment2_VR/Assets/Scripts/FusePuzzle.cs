using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/**
 * Handles logic for the powercell puzzle (changed from fuses)
 */
public class FusePuzzle : MonoBehaviour
{
    private static int score;
    private string fuseName = "";
    [SerializeField] public PlayableDirector chestOpen;
    private AudioSource audioSrc;
    void Start()
    {
        score = 0;
        audioSrc = GetComponent<AudioSource>();
    }

    
    /**
     * Sets a string value to the name of the object placed in the powercell socket.
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.tag != "RightHand" && other.tag != "LeftHand") //prevent these tags being used
            fuseName = other.tag;
    }

    /**
     * Checs the fuse is the correct colour by comparing fuseName set in onTrigger function and socket name.
     * Plays audio on correct placement
     */
    public void CheckFuseAdd()
    {
        
            if (fuseName == "RedFuse" && gameObject.name == "RedFuseBox")
            {
                score++;
                audioSrc.Play();

            }
            if (fuseName == "BlueFuse" && gameObject.name == "BlueFuseBox")
            {
                score++;
                audioSrc.Play();
            }
            if (fuseName == "GreenFuse" && gameObject.name == "GreenFuseBox")
            {
                score++;
                audioSrc.Play();
            }
            if (fuseName == "PurpleFuse" && gameObject.name == "PurpleFuseBox")
            {
                score++;
                audioSrc.Play();
            }
        
        if(score == 4) //Ends th minigame when the score reaches 4 indicating each cell is correctly placed.
        {
            EndPuzzle();            
        }
        

    }

    /**
     * Removes score when correct fuse is removed.
     */
    public void CheckFuseRemove()
    {
        if(score < 4)
        {
            if (fuseName == "RedFuse" && gameObject.name == "RedFuseBox")
            {
                score--;
                fuseName = "";

            }
            if (fuseName == "BlueFuse" && gameObject.name == "BlueFuseBox")
            {
                score--;
                fuseName = "";
            }
            if (fuseName == "GreenFuse" && gameObject.name == "GreenFuseBox")
            {
                score--;
                fuseName = "";
            }
            if (fuseName == "PurpleFuse" && gameObject.name == "PurpleFuseBox")
            {
                score--;
                fuseName = "";
            }
        }
        


    }
    /**
     * Ends the puzzle by starting the animation to lower chest from the ceiling.
     */
    private void EndPuzzle()
    {
        chestOpen.Play();
    }

}
