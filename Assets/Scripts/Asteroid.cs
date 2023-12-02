using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerDeathHandler playerDeathHandler))
        {
            playerDeathHandler.ProcessCrash();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
