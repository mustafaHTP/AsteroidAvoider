using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    /*
     * To achieve parallax effect, sprite needs to 
     * jump by size of width * 2 
     * **/
    private float _jumpAmount;

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _jumpAmount = 2f * spriteRenderer.bounds.size.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position += new Vector3(-_jumpAmount, 0f);
    }

    void Update()
    {
        float deltaMoveX = _moveSpeed * Time.deltaTime;
        transform.position += new Vector3(deltaMoveX, 0f);
    }
}
