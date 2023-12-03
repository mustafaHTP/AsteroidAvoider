using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSFXController : MonoBehaviour
{
    [SerializeField] private AudioSource _jetEngineSFX;
    [SerializeField] private float _minVolume = 0.3f;
    [SerializeField] private float _maxVolume = 0.7f;
    [SerializeField] private float _volumeChangeSpeed;

    private float _deltaVolume = 0f;

    private void Awake()
    {
        _jetEngineSFX.volume = _minVolume;
    }

    private void OnEnable()
    {
        if (!_jetEngineSFX.isPlaying)
        {
            _jetEngineSFX.Play();
        }
    }

    private void Update()
    {
        UpdateJetEngineSFXVolume();
    }

    private void UpdateJetEngineSFXVolume()
    {
        _jetEngineSFX.volume = Mathf.Lerp(_minVolume, _maxVolume, _deltaVolume);

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            _deltaVolume += _volumeChangeSpeed * Time.deltaTime;
            _deltaVolume = Mathf.Clamp01(_deltaVolume);
        }
        else
        {
            _deltaVolume -= _volumeChangeSpeed * Time.deltaTime;
            _deltaVolume = Mathf.Clamp01(_deltaVolume);
        }
    }

    public void PlayJetEngineSFX()
    {
        if (!_jetEngineSFX.isPlaying)
            _jetEngineSFX.Play();
    }
}
