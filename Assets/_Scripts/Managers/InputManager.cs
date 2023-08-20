using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public float ScrollWheel { get; private set; }
    public Vector2 MouseWorldPos { get; private set; }

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        MouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
