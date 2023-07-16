using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles duck movement
 */
public class DuckBehaviour : MonoBehaviour
{
    private Transform endPosition;
    public float speed = 2.0f;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDuck();
    }

    /**
     * Move the duck game object accross the screen from one position to another.
     */
    void MoveDuck()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition.position, speed * Time.deltaTime);
        
        if (transform.position == endPosition.position)
        {
            
            Destroy(gameObject);
        }
    }

    /**
     * Sets the end position target
     */
    public void SetTransform(Transform position)
    {
        endPosition = position;
    }

    /**
     * Removes duck from view, incerases score, and plays audio when a dart comes into contact with a duck.
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dart")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            render.enabled = false;
            audioSrc.Play();
            DuckShootGame.userScore += 1;
            
            Destroy(gameObject, 0.5f);
            Destroy(other);
            
        }
    }
}
