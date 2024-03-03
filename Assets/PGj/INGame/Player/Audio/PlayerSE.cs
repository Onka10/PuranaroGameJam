using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : Singleton<PlayerSE>
{
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public List<AudioClip> SE = new List<AudioClip>(6);

    public void Fire()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[0]);
    }

    public void Damage()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[1]);
    }

    public void Eat()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[2]);
    }
}
