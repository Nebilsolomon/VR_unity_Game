using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{


    [SerializeField] Slider VolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            load();
        }
        else {
            load();
        }
    }

    // Update is called once per frame
    
    public void changeVolumemusic()
    {
        AudioListener.volume = VolumeSlider.value;
        save();
    }


    private void load() {

     VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

    }


    private void save() {

PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);

    }
}
