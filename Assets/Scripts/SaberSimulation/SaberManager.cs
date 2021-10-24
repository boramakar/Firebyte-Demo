using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberManager : MonoBehaviour
{
    //[SerializeField] private SaberData[] _sabers;
    public int collisionCheckStepCount = 100;
    public float animationDuration = 2f;
    
    public event Action StartSimulationEvent;
    public event Action CheckCollisionEvent;
    public event Action CollisionEvent;
    
    private static SaberManager _instance = null;
    public static SaberManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void Simulate()
    {
        StartSimulationEvent?.Invoke();
    }

    public void CheckCollision()
    {
        CheckCollisionEvent?.Invoke();
    }
}
