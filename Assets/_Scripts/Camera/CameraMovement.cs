using UnityEngine;
using Utilities.Utilities.Shapes;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Rectangle _rectangleBorder;

    private Vector2 _startDragPos;

    private InputManager _inputManager;

    private void Start()
    {
        _inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startDragPos = _inputManager.MouseWorldPos;
            return;
        }

        if (!Input.GetMouseButton(0))
            return;

        Vector2 offset = _inputManager.MouseWorldPos - (Vector2)transform.position;
        Vector2 dir = _startDragPos - offset;
        dir = _rectangleBorder.ClampPositionInside(dir);
        Vector3 newPos = new Vector3(dir.x, dir.y, -10);

        transform.position = newPos;
    }
}
