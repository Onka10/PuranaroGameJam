using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySE : Singleton<EnemySE>
{
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public List<AudioClip> SE = new List<AudioClip>(6);

    public void Damage()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[0]);
    }
}
