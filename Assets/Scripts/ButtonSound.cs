using System.Collections;
using System.Collections.Generic;
//using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class ButtonSound : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip outAudioClip;
    private int frequency;
    public System.Random randomized = new System.Random();
    public int freq_click=300;
    public int freq_hover = 200;
    public float timer = 0f;
    private Button button { get { return GetComponent<Button>(); } }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // outAudioClip = CreateToneAudioClip(freq);

        // PlayOutAudio();

        audioSource.playOnAwake = false;
        button.onClick.AddListener(() => click_sound());
    }

    /*
    void Update()
    {

        //outAudioClip = CreateToneAudioClip(freq);
        //frequency = -frequency + 10;
        // PlayOutAudio();
        if (timer % 0.5f == 0)
            
        timer = timer + 0.5f;
    }
    */
    public void hover_sound()
    {
        outAudioClip = CreateToneAudioClip(freq_hover);
        audioSource.PlayOneShot(outAudioClip);
    }
    public void click_sound()
    {
        outAudioClip = CreateToneAudioClip(freq_click);
        PlayOutAudio();
    }

    // Public APIs
    public void PlayOutAudio()
    {
        audioSource.PlayOneShot(outAudioClip);
    }


    public void StopAudio()
    {
        audioSource.Stop();
    }


    // Private
    private AudioClip CreateToneAudioClip(int frequency)
    {
        int sampleDurationSecs = 1;
        int sampleRate = 44100;
        // int sampleLength = sampleRate * sampleDurationSecs;
        int sampleLength = 15000;
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


#if UNITY_EDITOR
    // [Button("Save Wav file")]
    private void SaveWavFile()
    {
        string path = EditorUtility.SaveFilePanel("Where do you want the wav file to go?", "", "", "wav");
        var audioClip = CreateToneAudioClip(1500);
        //SaveWavUtil.Save(path, audioClip);
    }
#endif
}