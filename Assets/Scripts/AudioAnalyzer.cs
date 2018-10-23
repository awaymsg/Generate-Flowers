using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyzer : MonoBehaviour {

    public AudioSource source;
    public float[] sample = new float[512];
    public float[] freqband = new float[8];
    public float[] bandbuffer = new float[8];
    float[] bufferdecrease = new float[8];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (source != null)
        {
            GetSpectrum();
            MakeFreqBands();
            GetBuffer();
        }
	}

    void GetSpectrum ()
    {
        source.GetSpectrumData(sample, 0, FFTWindow.Blackman);
    }

    void GetBuffer ()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqband[i] > bandbuffer[i])
            {
                bandbuffer[i] = freqband[i];
                bufferdecrease[i] = 0.005f;
            }
            if (freqband[i] < bandbuffer[i])
            {
                bandbuffer[i] -= bufferdecrease[i];
                bufferdecrease[i] *= 1.2f;
            }
        }
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
