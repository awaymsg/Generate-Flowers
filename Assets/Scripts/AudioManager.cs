using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] Sounds;

	// Use this for initialization
	void Awake () {
        foreach (Sound s in Sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    private void Start()
    {
        Play("song1");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s != null)
        {
            s.source.Play();
            GetComponent<AudioAnalyzer>().source = s.source;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
