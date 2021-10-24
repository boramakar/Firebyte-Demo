using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderData : MonoBehaviour, ISaberAngleData
{
    [SerializeField] private Slider _slider;
    
    public event Action<float> UpdateAngleEvent;

    private bool _isClicked;

    private void Start()
    {
        _slider.onValueChanged.AddListener(UpdateData);
        _isClicked = false;
    }

    void UpdateData(float value)
    {
        UpdateAngleEvent?.Invoke(value);
    }

    private void OnMouseDown()
    {
        _isClicked = true;
    }

    private void OnMouseUp()
    {
        Debug.Log("MouseUp");
        if (!_isClicked) return;
        _isClicked = false;
        SaberManager.Instance.CheckCollision();
    }
}