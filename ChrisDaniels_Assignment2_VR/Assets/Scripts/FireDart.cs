using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Handle firing a dart from the dart gun
 */
public class FireDart : MonoBehaviour
{
    [SerializeField] private Rigidbody dartPrefab;
    [SerializeField] private GameObject projectileStart;
    [SerializeField] private GameObject handModel;
    private Animator fireGun;
    private bool canPress;
    private AudioSource audioSrc;
    [SerializeField] InputAction buttonPress;

    private float launchPower = 10.0f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        fireGun = GetComponent<Animator>();
    }


    private void Update()
    {
        //Checks dart gun is in hand and button is pressed
        if (buttonPress.WasPressedThisFrame() && canPress)
        {
            
            Fire();
            fireGun.SetTrigger("Fire");
        }
    }


    /**
     * Checks the dartgun is in the user's hand
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand" || other.gameObject.tag == "LeftHand")
        {

            canPress = true;
            handModel.SetActive(true);
        }
    }

    /**
     * Stops the user from firing when the dart gun is dropped
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RightHand" || other.gameObject.tag == "LeftHand")
        {
            canPress = false;
            handModel.SetActive(false);
        }
    }

    /**
     * Fires dart from gun
     */
    public void Fire()
    {
        Rigidbody newDart = Instantiate(dartPrefab, projectileStart.transform.position, projectileStart.transform.rotation) as Rigidbody; //Instantiate dart prefab at correct rotation and position       
        newDart.name = "dart";
        newDart.velocity = transform.forward * launchPower;
        audioSrc.Play();
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
}
