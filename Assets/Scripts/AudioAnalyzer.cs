using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyzer : MonoBehaviour {

    public AudioSource source;
    public float[] sample = new float[512];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (source != null)
            GetSpectrum();
	}

    void GetSpectrum ()
    {
        source.GetSpectrumData(sample, 0, FFTWindow.Blackman);
    }
}
