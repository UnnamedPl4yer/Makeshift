using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audiosrc;
    private AudioClip activeClip;
    public static float volume;

    //Player Sounds
    private AudioClip FoxDig = Resources.Load("Sounds/FoxDig") as AudioClip;
    private AudioClip FoxStep = Resources.Load("Sounds/FoxStep") as AudioClip;
    private AudioClip BirdFlap = Resources.Load("Sounds/BirdFlap") as AudioClip;
    private AudioClip BirdChirp = Resources.Load("Sounds/BirdChirp") as AudioClip;

    //Ambient Music
    private AudioClip Region1Music = Resources.Load("Sounds/Region1Music") as AudioClip;
    private AudioClip Region2Music = Resources.Load("Sounds/Region2Music") as AudioClip;
    private AudioClip Region3Music = Resources.Load("Sounds/Region3Music") as AudioClip;
    private AudioClip Region4Music = Resources.Load("Sounds/Region4Music") as AudioClip;
    private AudioClip Region5Music = Resources.Load("Sounds/Region5Music") as AudioClip;

    //Ambient Sounds


    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        audiosrc.clip = activeClip;
    }

    // Update is called once per frame
    void Update()
    {
        volume = MainMenu.volume;
    }

    void ChangeClip(string ClipToPlay)
    {
        string location = string.Concat("Sounds/", ClipToPlay);
        //activeClip = Resources.Load(location);
        audiosrc.clip = activeClip;
    }

    void PlaySound(AudioClip SoundToPlay)
    {
        //audiosrc.Play("")
    }
}
