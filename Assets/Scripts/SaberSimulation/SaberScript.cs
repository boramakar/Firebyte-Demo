using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SaberScript : MonoBehaviour
{
    [SerializeField] private SaberData saberDetails;
    
    private ISimulationAnimation _animation;
    private ISaberAngleData _saberAngleData;

    private Vector3 _minRotation;
    private Vector3 _maxRotation;
    private Transform _prefabTransform;

    private void Awake()
    {
        _animation = GetComponent<ISimulationAnimation>();
        _saberAngleData = GetComponent<ISaberAngleData>();
        Assert.IsNotNull(_animation, "Animation not found!");
        Assert.IsNotNull(_saberAngleData, "AngleData not found!");
    }

    private void OnEnable()
    {
        SaberManager.Instance.StartSimulationEvent += StartSimulation;
        _saberAngleData.UpdateAngleEvent += UpdateAngleEvent;
    }

    private void OnDisable()
    {
        SaberManager.Instance.StartSimulationEvent -= StartSimulation;
        _saberAngleData.UpdateAngleEvent += UpdateAngleEvent;
    }

    private void Start()
    {
        _minRotation = saberDetails.sliderMinRotation;
        _maxRotation = saberDetails.sliderMaxRotation;
        _prefabTransform = transform.GetChild(0);
        //Can instantiate prefabs at runtime
        //Disabled because not needed right now
        //Instantiate(saberDetails.saberPrefab, transform);
        
        Assert.IsNotNull(SaberManager.Instance, "Manager not found!");
    }

    private void StartSimulation()
    {
        Debug.Log("PlayingAnimation");
        _animation.PlayAnimation(SaberManager.Instance.animationDuration);
    }

    private void UpdateAngleEvent(float value)
    {
        var rotation = Vector3.Lerp(_minRotation, _maxRotation, value);
        _prefabTransform.localRotation = Quaternion.Euler(rotation);
    }
}