using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DisplayInfoText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject informationText;
    private TextMeshProUGUI infoText;

    void Start()
    {
        infoText = informationText.GetComponent<TextMeshProUGUI>();
    }


    /**
     * Sets information text when button hovered over by ray
     * 
     */
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.name == "StartButton")
        {
            infoText.text = "Begin the escape game.";
        }
        if (this.name == "InstructionsButton")
        {
            infoText.text = "View the controls.";
        }
        if (this.name == "OptionsButton")
        {
            infoText.text = "Adjust settings for the game.";
        }
        if (this.name == "QuitButton")
        {
            infoText.text = "Exit the game.";
        }
        



    }

    /**
     * Resets text to nothing
     */
    public void OnPointerExit(PointerEventData eventData)
    {
        infoText.text = "";
    }
}
