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

    void ShowParticles()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ParticleSystem>().Play();
        }
    }
}
