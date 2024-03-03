using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSE : Singleton<SystemSE>
{
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public List<AudioClip> SE = new List<AudioClip>(6);

    public void Count()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[0]);
    }

    public void Go()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[1]);
    }

    public void End()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[2]);
    }
}
