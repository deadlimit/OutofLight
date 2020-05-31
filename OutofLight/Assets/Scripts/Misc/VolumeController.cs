using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    public FloatVariable volumeVar;
    //public AudioSource[] audioSources = new AudioSource[10];
    public Slider volumeControl;

    private void Awake()
    {
        volumeControl.maxValue = 1f;
        volumeControl.value = volumeVar.GetValue();
        //audioSources = (AudioSource[])GameObject.FindObjectsOfType(typeof(AudioSource));
    }

    private void Update()
    {
        VolumeCheck();
        AudioListener.volume = volumeControl.value;
    }

   // private void SetVolume()
    //{
      //  for (int i = 0; i < audioSources.Length-1; i++)
        //{
          //  if (!audioSources.Equals(null))
            //{
              //  audioSources[i].volume = volumeVar.GetValue();
            //}
        //}

    //}

    private void VolumeCheck()
    {
        if (volumeControl.value < volumeVar.GetValue())
        {
          volumeVar.ChangeValue(-0.1f);
        }
       if (volumeControl.value > volumeVar.GetValue())
        {
            volumeVar.ChangeValue(+0.1f);
        }
    }
}
