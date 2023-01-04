using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    bool isPlaying = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BGM Theme");
    }
    public void Play(string name)
    {
      Sound s = Array.Find(sounds, sound => sound.name == name);
      if(s == null)
      {
            Debug.LogWarning("Sound: " + name + " not found");
        return;
      }
      s.source.Play();
      isPlaying = true;
    }

    public void Stop(string stopName)
    {
        Sound stop = Array.Find(sounds, sound => sound.name == stopName);
        if (stop == null)
        {
            Debug.LogWarning("Sound: " + stopName + " not found");
            return;
        }
            stop.source.Stop();

    }

    public void Pause(string pauseName)
    {
        Sound pause = Array.Find(sounds, sound => sound.name == pauseName);
        if (pauseName == null)
        {
            Debug.LogWarning("Sound: " + pauseName + " not found");
            return;
        }
            pause.source.loop = false;
            //pause.source.Pause();
    }

    public void UnPause(string unpauseName)
    {
        Sound Unpause = Array.Find(sounds, sound => sound.name == unpauseName);
        if (unpauseName == null)
        {
            Debug.LogWarning("Sound: " + unpauseName + " not found");
            return;
        }
            Unpause.source.loop = true;
            //Unpause.source.UnPause();
    }
}
