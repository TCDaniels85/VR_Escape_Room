using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportation : MonoBehaviour
{
    [SerializeField] InputAction buttonPress;
    [SerializeField] GameObject canvas;
    private TeleportationAnchor teleportAbility;
    private bool canTeleport;


    private void Start()
    {
        teleportAbility = GetComponent<TeleportationAnchor>();
    }
    private void Update()
    {
        
        if (buttonPress.WasPressedThisFrame() )  //check for button press
        {
            ToggleTeleport();   
        }
    }
    //Methods related to the InputAction
    private void OnEnable()
    {
        buttonPress.Enable();
    }

    private void OnDisable()
    {
        buttonPress.Disable();
    }


    /*
     * Toggles the teleport pads, checks a bool value representing activation state
     * then activate/deactivates teleport ability and canvas accoringly
     */
    private void ToggleTeleport()
    {
        canTeleport = !canTeleport;
        if(canTeleport)
        {
            teleportAbility.enabled = true;
            canvas.SetActive(true);
        } else
        {
            teleportAbility.enabled = false;
            canvas.SetActive(false);
        }
    }
}
