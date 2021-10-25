using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberClashParticlesHandler : MonoBehaviour
{
    private void OnEnable()
    {
        SaberManager.Instance.CollisionEvent += ShowParticles;
    }

    private void OnDisable()
    {
        SaberManager.Instance.CollisionEvent -= ShowParticles;
    }

    /// <summary>
    /// Move particles to the position of contact.
    /// Can be modified to change the angle of the particles if needed.
    /// </summary>
    /// <param name="contact"></param>
    void ShowParticles(ContactPoint contact)
    {
        transform.position = contact.point;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ParticleSystem>().Play();
        }
    }
}
