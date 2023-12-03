using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketFlameController : MonoBehaviour
{
    [Header("Rocket Flame VFX Config")]
    [Space(1)]
    [SerializeField] private float _minShapeAngle = 0f;
    [SerializeField] private float _maxShapeAngle = 1.8f;
    [SerializeField] private float _minStartLifeTime = 0.76f;
    [SerializeField] private float _maxStartLifeTime = 1.78f;
    [SerializeField] private float _effectChangeSpeed = 1f;

    float deltaEffectChange = 0f;
    private ParticleSystem _rocketFlameVFX;

    private void Awake()
    {
        _rocketFlameVFX = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Touchscreen.current.press.isPressed)
        {
            deltaEffectChange += _effectChangeSpeed * Time.deltaTime;
        }
        else
        {
            deltaEffectChange -= _effectChangeSpeed * Time.deltaTime;
        }

        deltaEffectChange = Mathf.Clamp01(deltaEffectChange);


        //Change angle
        ParticleSystem.ShapeModule shapeModule = _rocketFlameVFX.shape;
        shapeModule.angle = Mathf.Lerp(_maxShapeAngle, _minShapeAngle, deltaEffectChange);

        //Change startlife time
        ParticleSystem.MainModule mainModule = _rocketFlameVFX.main;
        mainModule.startLifetime = Mathf.Lerp(_minStartLifeTime, _maxStartLifeTime, deltaEffectChange);
    }

}
