using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip[] _sounds;
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioMixer _masterMixer;

    public bool VolumeState => SavingSystem.Instance.Data.VolumeState;

    protected override void Awake()
    {
        MakeGlobal();
    }

    private void Start()
    {
        _masterMixer.SetFloat("Volume", VolumeState ? 0f : -80f);
        
        _musicSource.Play();
    }

    public bool SwitchVolume()
    {
        SavingSystem.Instance.Data.VolumeState = !VolumeState;
        SavingSystem.Instance.Save();

        _masterMixer.SetFloat("Volume", VolumeState ? 0f : -80f); 

        return VolumeState;
    }

    public void PlaySound(Sound sound)
    {
        if(VolumeState)
            _soundSource.PlayOneShot(_sounds[(int)sound]);
    }
}

public enum Sound
{
    Button,
    TakeDamage,
    Heal
}