using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SoundSwitcher : MonoBehaviour
{
    [SerializeField] private Color _enabled;
    [SerializeField] private Color _disabled;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.color = SoundManager.Instance.SoundState ? _enabled : _disabled;
    }

    public void SwitchSound()
    {
        _image.color = SoundManager.Instance.SwitchSound() ? _enabled : _disabled;
    }
}
