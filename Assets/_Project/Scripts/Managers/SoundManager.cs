using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip[] _sounds;

    private AudioSource _audioSource;

    public bool SoundState => SavingSystem.Instance.Data.SoundState;

    protected override void Awake()
    {
        base.Awake();

        _audioSource = GetComponent<AudioSource>();
    }

    public bool SwitchSound()
    {
        SavingSystem.Instance.Data.SoundState = !SoundState;
        SavingSystem.Instance.Save();

        return SoundState;
    }

    public void PlaySound(Sound sound)
    {
        if(SoundState)
            _audioSource.PlayOneShot(_sounds[(int)sound]);
    }
}

public enum Sound
{
    Button,
    TakeDamage
}