using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [HideInInspector] public float maxZoom;

    public float minZoom;
    
    private InputManager _inputManager;
    private Camera _camera;
    
    void Start()
    {
        _inputManager = InputManager.Instance;
        _camera = Camera.main;
    }

    void Update()
    {
        float newCameraSize = _camera.orthographicSize - _inputManager.ScrollWheel * 10f;
        newCameraSize = Mathf.Clamp(newCameraSize, minZoom, maxZoom);
        _camera.orthographicSize = newCameraSize;
    }
}
