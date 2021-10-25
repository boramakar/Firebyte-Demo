using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scripts needs to be on the same object as the rigidbody.
/// Layer name is not necessary for this demo but usually it proves to be useful in the long run.
/// </summary>
public class SaberCollision : MonoBehaviour
{
    [SerializeField] private string layerName = "Collidable";
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(layerName))
            SaberManager.Instance.OnCollisionEvent(other.GetContact(0));
    }
}