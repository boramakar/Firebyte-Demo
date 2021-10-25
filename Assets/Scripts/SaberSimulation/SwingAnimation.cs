using System;
using System.Collections;
using UnityEngine;

public class SwingAnimation : MonoBehaviour
{
    [SerializeField] private float xMinAngle = 0;
    [SerializeField] private float xMaxAngle = 0;
    [SerializeField] private AnimationCurve xCurve;
    [SerializeField] private float yMinAngle = 0;
    [SerializeField] private float yMaxAngle = 90;
    [SerializeField] private AnimationCurve yCurve;
    [SerializeField] private float zMinAngle = 0;
    [SerializeField] private float zMaxAngle = 0;
    [SerializeField] private AnimationCurve zCurve;
    
    private bool _isPlaying;

    private void OnEnable()
    {
        SaberManager.Instance.StartSimulationEvent += PlayAnimation;
        SaberManager.Instance.CollisionEvent += StopAnimation;
    }

    private void OnDisable()
    {
        SaberManager.Instance.StartSimulationEvent += PlayAnimation;
        SaberManager.Instance.CollisionEvent -= StopAnimation;
    }

    public void PlayAnimation()
    {
        _isPlaying = true;
        StartCoroutine(Swing(SaberManager.Instance.animationDuration));
    }

    private void StopAnimation(ContactPoint contact)
    {
        _isPlaying = false;
    }

    IEnumerator Swing(float duration)
    {
        float elapsedTime = 0;
        while (_isPlaying && elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            var progress = Mathf.Clamp01(elapsedTime / duration);
            var xRotation = Mathf.Lerp(xMinAngle, xMaxAngle, xCurve.Evaluate(progress));
            var yRotation = Mathf.Lerp(yMinAngle, yMaxAngle, yCurve.Evaluate(progress));
            var zRotation = Mathf.Lerp(zMinAngle, zMaxAngle, zCurve.Evaluate(progress));
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
            yield return null;
        }

        if (!SaberManager.Instance.resetAfterSimulation) yield break;
        {
            yield return new WaitForSeconds(SaberManager.Instance.resetDelay);
            var xRotation = Mathf.Lerp(xMinAngle, xMaxAngle, xCurve.Evaluate(0));
            var yRotation = Mathf.Lerp(yMinAngle, yMaxAngle, yCurve.Evaluate(0));
            var zRotation = Mathf.Lerp(zMinAngle, zMaxAngle, zCurve.Evaluate(0));
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        }
    }
}