using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Recores trophy placement and opens door to endgame area.
 */
public class OpenEndDoor : MonoBehaviour
{
    private int trophies; //Records Trophies
    private bool placementAFilled;
    private bool placementBFilled;
    private bool placementCFilled;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    public bool moveDoors;
    private float speed = 2.0f;
    private AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveDoors)
        {
            leftDoor.transform.Translate(Vector3.right * speed * Time.deltaTime);
            rightDoor.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    /**
     * Records trophy placement on trophy stand, if all placements return true
     * openDoor method is called.
     */
    public void RecordTrophy(int index)
    {
        
        if (index == 1)
            placementAFilled = true;
        if (index == 2)
            placementBFilled = true;
        if (index == 3)
            placementCFilled = true;
        if(placementAFilled && placementBFilled && placementCFilled)
        {
            StartCoroutine(OpenDoors());
            
        }
    }
    /**
     * sets trophy placement bool to false if trophy is removed.
     */
    public void RemoveTrophy(int index)
    {
        if (index == 1)
            placementAFilled = false;
        if (index == 2)
            placementBFilled = false;
        if (index == 3)
            placementBFilled = false;
    }
    /**
     * Opens door by setting a bool value to true (allows doors to move in update method)
     */
    IEnumerator OpenDoors()
    {
        moveDoors = true;
        audioSrc.Play();  //door audio
        yield return new WaitForSeconds(2);
        moveDoors = false;
    }
}
