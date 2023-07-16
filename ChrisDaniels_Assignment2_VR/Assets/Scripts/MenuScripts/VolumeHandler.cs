using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Handle volume throughout the applications using the playerPrefs class
 */
public class VolumeHandler : MonoBehaviour
{
    public Slider volSlider;
    private void Start()
    {
        LoadVolumeValue();
    }
    public void VolumeSave()
    {
        float volume = volSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volume); //Sets a float value named GameVolume that can be called upon later from any scene
        LoadVolumeValue();
    }
    /**
     * Loads current GameVolume float and applies it to the AudioListener volume
     */
    void LoadVolumeValue()
    {
        float volume = PlayerPrefs.GetFloat("GameVolume");
        if(volSlider != null)  //only runs if the volume can be set in a menu
        {
            volSlider.value = volume;
            Debug.Log(volume);
            
        }
        AudioListener.volume = volume;
    }
}
