using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Basic script to rotate a trophy when placed on podium
 */
public class TrophySpin : MonoBehaviour
{
    private float speed = 100.0f;
    private bool willRotate = false;
    
    // Update is called once per frame
    void Update()
    {
        if (willRotate)
        {

            gameObject.transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }

    public void RotateTrophy()
    {
        willRotate = true;
    }
}
