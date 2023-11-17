using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sounds[] sounds;

    public string BackgroundSong;

    private void Awake()
    {

        foreach (Sounds sound in sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.clip = sound.clip;

            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.pitch = sound.Pitch;
            sound.AudioSource.loop = sound.Loop;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Play(BackgroundSong);
    }

    public void Play(string SoundName)
    {
        Sounds s = Array.Find(sounds, Sound => Sound.Name == SoundName);

        s.AudioSource.Play();
    }
    
}
