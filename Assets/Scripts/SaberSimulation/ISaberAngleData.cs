using System;
using UnityEngine;

public interface ISaberAngleData
{
    public event Action<float> UpdateAngleEvent;
}