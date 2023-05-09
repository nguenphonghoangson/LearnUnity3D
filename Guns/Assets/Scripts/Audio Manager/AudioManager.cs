using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in Sounds)
        {
            s.audioSource=gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume= s.volume;
            s.audioSource.pitch= s.pitch;
            s.audioSource.loop = s.isLooping;
        }
        Play("theme");
    }
    public void Play(string name)
    {
        Sound s=Array.Find(Sounds, (s) => s.name == name);
        s.audioSource.Play();
        
    }
    public bool IsPlaying(string soundName)
    {
        foreach (Sound sound in Sounds)
        {
            if (sound.name == soundName)
            {
                return sound.audioSource.isPlaying;
            }
        }
        return false;
    }
    public void Stop(string soundName)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return;
        }
        s.audioSource.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
