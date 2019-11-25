using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



[RequireComponent(typeof(Button))]

public class ButtonSound : MonoBehaviour
{

    
    private AudioSource audioSource;
    private AudioClip outAudioClip;
    private int freq=100;
    private Button button { get { return GetComponent<Button>(); } }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        outAudioClip = CreateToneAudioClip(freq);
        button.onClick.AddListener(() => PlayOutAudio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOutAudio()
    {
        audioSource.PlayOneShot(outAudioClip);
    }


    private AudioClip CreateToneAudioClip(int frequency)
    {
        int sampleDurationSecs = 2;
        int sampleRate = 44100;
        int sampleLength = sampleRate * sampleDurationSecs;
        float maxValue = 1f / 4f;

        var audioClip = AudioClip.Create("tone", sampleLength, 1, sampleRate, false);

        float[] samples = new float[sampleLength];
        for (var i = 0; i < sampleLength; i++)
        {
            float s = Mathf.Sin(2.0f * Mathf.PI * frequency * ((float)i / (float)sampleRate));
            float v = s * maxValue;
            samples[i] = v;
        }

        audioClip.SetData(samples, 0);
        return audioClip;
    }

}
