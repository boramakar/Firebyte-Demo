using UnityEngine;


/// <summary>
/// The purpose of this SO is to collect all the parameters directly related to a Saber in one location.
/// It is possible to move some other existing parameters indirectly related to the saber to here such as animation details.
/// In its current form, this is a sample solution that can be extended or discarded depending on the needs of the Game Designers.
/// </summary>
[CreateAssetMenu(menuName = "SO/SaberData", fileName = "NewSaberData")]
public class SaberData : ScriptableObject
{
    //Instantiate disabled right now, so this is also not needed
    //public GameObject saberPrefab;
    
    /// <summary>
    /// Local rotation of the saber when slider value is at its minimum
    /// </summary>
    public Vector3 sliderMinRotation;
    
    /// <summary>
    /// Local rotation of the saber when slider value is at its maximum
    /// </summary>
    public Vector3 sliderMaxRotation;
    
    /*Possibly useful for swapping materials without using variants
    But most likely less performance efficient
    Removed since it's not needed for the time being*/
    //public Material[] materials;
}
