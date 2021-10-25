using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberManager : MonoBehaviour
{
    //[SerializeField] private SaberData[] _sabers;
    public float animationDuration = 2f;
    public bool resetAfterSimulation = true;
    public float resetDelay = 2f;
    public string hitText = "hit";
    public string missText = "miss";

    public event Action StartSimulationEvent;
    public event Action<ContactPoint> CollisionEvent;
    public event Action<string> UpdateCollisionStatusEvent;

    private static SaberManager _instance = null;

    public static SaberManager Instance
    {
        get { return _instance; }
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

    public void UpdateCollisionStatus(bool hit)
    {
        UpdateCollisionStatusEvent?.Invoke(hit ? hitText : missText);
    }

    public void OnCollisionEvent(ContactPoint contact)
    {
        Debug.Log("CollisionEvent");
        CollisionEvent?.Invoke(contact);
    }
}