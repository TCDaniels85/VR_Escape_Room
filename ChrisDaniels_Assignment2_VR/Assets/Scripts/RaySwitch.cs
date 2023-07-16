using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/**
 * Class to handle turning rays on and off with button press
 */
public class RaySwitch : MonoBehaviour
{
    [SerializeField] private XRDirectInteractor directInt;
    [SerializeField] private GameObject controller;
    private XRRayInteractor rayInt;
    public bool isActivated;

    [SerializeField] private InputAction secondaryPress; //Enables button binding from inspector



    // Start is called before the first frame update
    void Start()
    {
        secondaryPress.performed += _ => EnableRay(); //Lambda that calls designated method following button press
        rayInt = GetComponent<XRRayInteractor>();
        rayInt.enabled = isActivated;

    }
    

    /**
     * Toggles the ray interactor 
     */
    public void EnableRay()
    {
        if (rayInt.enabled == true)
        {
            rayInt.enabled = false;
            directInt.enabled = true;
            UnhideController();
        }
        else if (rayInt.enabled == false)
        {
            
            rayInt.enabled = true;
            directInt.enabled = false;
            HideController();
        }
    }
    //Disables rays
    public void DisableRay()
    {
        
        rayInt.enabled = false;
    }

    public void HideController()
    {
        controller.SetActive(false);
        
    }

    public void UnhideController()
    {
        controller.SetActive(true);
    }

    //Methods below handle input actions
    private void OnEnable()
    {
        secondaryPress.Enable();
    }

    private void OnDisable()
    {
        secondaryPress.Disable();
    }
}
