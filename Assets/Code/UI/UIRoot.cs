using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void Start() => 
        SetWorldCamera();

    private void SetWorldCamera() => 
        _canvas.worldCamera = Camera.main;
}
