using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/**
 * Script to handle timer for the scene, if the timer reaches 0 the end scene is triggered passing a
 * int value via player prefs to represent losing the game.
 */
public class Timer : MonoBehaviour
{
    public static float timer;
    [SerializeField] TextMeshProUGUI timerText;
    private Scene thisScene;
    private float mins;
    private float secs;
    void Start()
    {
        timer = 420;
        thisScene = SceneManager.GetActiveScene();  //Gets the current scene
    }

    
    void Update()
    {
        if(thisScene.buildIndex == 1)  //Only runs timer in the main scene
        {
            timer -= Time.deltaTime;
            updateTimer(timer);
        }
        
    }

    /*
     * Method that updates timer and converst the current time to the closes second
     */
    private void updateTimer(float currentTime)
    {
        mins = Mathf.FloorToInt(currentTime / 60); 
        secs = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00} : {1:00}", mins, secs); //formats the string to 00:00 format for time
        if(mins < 1)
        {
            timerText.color = Color.red;  //sets colour to red when one minute is left
        }
        if(mins<1 && secs < 1)
        {
            EndGame();
        }
    }
    
    public float GetMins()
    {
        return mins;
    }

    public float GetSecs()
    {
        return secs;
    }
    /**
     * Ends game by loading the next scene, sets player prefs didWin value
     * to false to represent player losing.
     */
    private void EndGame()
    {
        PlayerPrefs.SetFloat("didWin", 0);        
        SceneLoader.LoadMyScene(2);
    }
}
