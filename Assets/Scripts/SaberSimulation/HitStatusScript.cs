using TMPro;
using UnityEngine;

public class HitStatusScript : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        SaberManager.Instance.UpdateCollisionStatusEvent += UpdateStatus;
    }

    private void OnDisable()
    {
        SaberManager.Instance.UpdateCollisionStatusEvent += UpdateStatus;
    }

    void UpdateStatus(string text)
    {
        _textMesh.text = text;
    }
}