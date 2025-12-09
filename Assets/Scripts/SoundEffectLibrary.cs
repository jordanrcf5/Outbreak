using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectgroup[] soundEffectgroups;
    //string = name
    private Dictionary<string, List<AudioClip>> soundDictonary;

    private void Awake()
    {
        InitializeDictonary();
    }

    private void InitializeDictonary()
    {
        soundDictonary = new Dictionary<string, List<AudioClip>>();
        foreach(SoundEffectgroup soundEffectgroup in soundEffectgroups)
        {
            soundDictonary[soundEffectgroup.name] = soundEffectgroup.audioClips;
        }
    }

    public AudioClip GetRandomClip(string name)
    {
        if(soundDictonary.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundDictonary[name];
            if(audioClips.Count > 0)
            {
                return audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
            }
        }
        return null;
    }
}

[System.Serializable]

public struct SoundEffectgroup
{
    public string name;
    public List<AudioClip> audioClips;
}
