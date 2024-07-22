using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 10f;

    [HideInInspector] public float maxZoom;

    public float minZoom;
    
    private InputManager _inputManager;
    private Camera _camera;
    
    void Awake()
    {
        _inputManager = InputManager.Instance;
        _camera = Camera.main;
        maxZoom = 10f;
    }

    void Update()
    {
        float newCameraSize = _camera.orthographicSize - _inputManager.ScrollWheel * _sensitivity;
        newCameraSize = Mathf.Clamp(newCameraSize, minZoom, maxZoom);
        _camera.orthographicSize = newCameraSize;
    }
}
