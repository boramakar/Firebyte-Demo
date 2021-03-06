using System;
using UnityEngine;

public class SimpleCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        SaberManager.Instance.UpdateCollisionStatus(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");
        SaberManager.Instance.UpdateCollisionStatus(false);
    }
}