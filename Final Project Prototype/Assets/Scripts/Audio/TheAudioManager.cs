using UnityEngine.Audio;
using System;
using UnityEngine;

public class TheAudioManager : MonoBehaviour
{
    public Sound[] ListOfSounds;

    void Awake()
    {

        foreach (Sound s in ListOfSounds)
        {
            s.soundSource = gameObject.AddComponent<AudioSource>();
            s.soundSource.clip = s.clip;
            s.soundSource.volume = s.volume;
            s.soundSource.pitch = s.pitch;
            s.soundSource.loop = s.loop;
        }
    }

    void Start()
    {
        PlayAudio("Ambience");
    }

    public void PlayAudio(string name)
    {
        Sound s = Array.Find(ListOfSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning(name + "could not be found!");
            return;
        }

        s.soundSource.Play();    
    }

    public void StopAudio(string name)
    {
        Sound s = Array.Find(ListOfSounds, sound => sound.name == name);

        s.soundSource.Stop();
    }

    public void SoundButton()
    {
        PlayAudio("Click");
    }
    
}
