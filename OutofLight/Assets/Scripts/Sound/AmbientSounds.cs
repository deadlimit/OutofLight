using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour {

    
    
    
    public List<AudioClip> soundClips = new List<AudioClip>();

    private AudioSource audio;

    private float audioClipLength;
    private float startTime;
    private float randomWaitTime;
    
    private void Awake() {
        startTime = 0;
        randomWaitTime = Random.Range(5, 10);
        audio = GetComponent<AudioSource>();
    }

    private void Update() {

        startTime += Time.deltaTime;

        if (!audio.isPlaying && startTime > randomWaitTime) {
            startTime = 0;
            randomWaitTime = Random.Range(5, 10) + audioClipLength;
            audio.PlayOneShot(GetAudioClip());
        }
        
    }

    private AudioClip GetAudioClip() {
        int randomIndex = Random.Range(0, soundClips.Count);
        var clip = soundClips[randomIndex];
        audioClipLength = clip.length;
        return clip;
    }
    
    

}
