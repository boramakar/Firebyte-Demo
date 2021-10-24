using System;
using System.Collections;
using UnityEngine;

public class SwingAnimation : MonoBehaviour, ISimulationAnimation
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

    public void PlayAnimation(float duration)
    {
        StartCoroutine(Swing(duration));
    }

    IEnumerator Swing(float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            var progress = Mathf.Clamp01(elapsedTime / duration);
            var xRotation = Mathf.Lerp(xMinAngle, xMaxAngle, xCurve.Evaluate(progress));
            var yRotation = Mathf.Lerp(yMinAngle, yMaxAngle, yCurve.Evaluate(progress));
            var zRotation = Mathf.Lerp(zMinAngle, zMaxAngle, zCurve.Evaluate(progress));
            Debug.Log(string.Format("x: {0} y: {1} z: {2}", xRotation.ToString(), yRotation.ToString(), zRotation.ToString()));
            transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
            Debug.Break();
            yield return null;
        }
    }
}