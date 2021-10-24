using UnityEngine;

[CreateAssetMenu(menuName = "SO/SaberData", fileName = "NewSaberData")]
public class SaberData : ScriptableObject
{
    //Instantiate disabled right now, so this is also not needed
    //public GameObject saberPrefab;
    public Vector3 sliderMinRotation;
    public Vector3 sliderMaxRotation;
    
    /*Possibly useful for swapping materials without using variants
    But most likely less performance efficient
    Removed since it's not needed for the time being*/
    //public Material[] materials;
}
