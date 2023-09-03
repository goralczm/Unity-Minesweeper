using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public float ScrollWheel => Input.GetAxis("Mouse ScrollWheel");
    public Vector2 MouseWorldPos => Camera.main.ScreenToWorldPoint(Input.mousePosition);
}
