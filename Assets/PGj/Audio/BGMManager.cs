using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    AudioSource _audioSource;
    public List<AudioClip> BGM = new List<AudioClip>(6);

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void InGame()
    {
        _audioSource.volume = 1f;
        _audioSource.clip = BGM[1];
        _audioSource.Play();
    }

    public void Stopped()
    {
        _audioSource.Stop();
    }

}
