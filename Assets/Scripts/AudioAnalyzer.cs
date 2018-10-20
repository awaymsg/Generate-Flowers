using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyzer : MonoBehaviour {

    public AudioSource source;
    public float[] sample = new float[512];
    public float[] freqband = new float[8];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (source != null)
            GetSpectrum();
        if (source != null)
            MakeFreqBands();
	}

    void GetSpectrum ()
    {
        source.GetSpectrumData(sample, 0, FFTWindow.Blackman);
    }

    void MakeFreqBands ()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int samplecount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                samplecount += 2;
            }
            for (int j = 0; j < samplecount; j++)
            {
                average += sample[count] * (count + 1);
                count++;
            }
            average /= count;
            freqband[i] = average;
        }
    }
}
