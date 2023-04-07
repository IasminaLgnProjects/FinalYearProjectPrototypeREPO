using UnityEngine.Audio;
using System;
using UnityEngine;

public class TheAudioManager : MonoBehaviour
{
    public Sound[] ListOfSounds;

    //public static TheAudioManager instance;

    void Awake()
    {
        /*if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);*/

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

        //if (name == "Ambience")
            //s.volume = 0.1f;

        s.soundSource.Play();


            
    }

    public void StopAudio(string name)
    {
        Sound s = Array.Find(ListOfSounds, sound => sound.name == name);
        
        /*if (s == null)
        {
            Debug.LogWarning(name + "could not be found!");
            return;
        }*/
        s.soundSource.Stop();
    }

    public void SoundButton()
    {
        PlayAudio("Click");
    }
    
}
