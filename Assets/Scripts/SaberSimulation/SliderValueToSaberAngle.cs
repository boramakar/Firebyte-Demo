using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToSaberAngle : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SaberData data;

    private Transform _prefabTransform;

    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateData);
        _prefabTransform = transform.GetChild(0);
    }

    void UpdateData(float value)
    {
        var rotation = Vector3.Lerp(data.sliderMinRotation, data.sliderMaxRotation, value);
        _prefabTransform.localRotation = Quaternion.Euler(rotation);
    }
}