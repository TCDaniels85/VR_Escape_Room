using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDart : MonoBehaviour
{
    private float removalTime = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, removalTime); //destroy game object after 1 second to save batch calls
    }
}
