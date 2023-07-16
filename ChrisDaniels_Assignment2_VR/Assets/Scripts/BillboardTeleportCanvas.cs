using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardTeleportCanvas : MonoBehaviour
{
    [SerializeField] GameObject playerPos;
    

    // Update ensures the canvas is looking at the player.
    void Update()
    {
        Vector3 dir = playerPos.transform.position - transform.position;
        dir.y = 0;      //removes rotation on this axis
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
