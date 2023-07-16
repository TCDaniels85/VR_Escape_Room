using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles sound played when item contacts another surface.
 */
public class BounceSound : MonoBehaviour
{
    private AudioSource audioSrc;
    private bool isEffectPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

    }

    /**
     * Plays sound effect and prevents the sound being started again whilst it is playing
     */
    IEnumerator PlayEffect()
    {
        audioSrc.Play();
        isEffectPlaying = true; //boolean used to prevent sound being played again
        yield return new WaitForSeconds(audioSrc.clip.length);
        isEffectPlaying = false;
    }



    /**
     * Used to play colission noise for the ball hitting a surface.
     * @param object that is being collided with
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "RightHand" || collision.gameObject.tag != "LeftHand") //Prevents ball bounce sound when picking ball up
            StartCoroutine(PlayEffect());
    }
}
