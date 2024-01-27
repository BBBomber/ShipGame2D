using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        SoundManager.Instance.Play(Sounds.cannonClick);
    }
}
