using UnityEngine;
using Utilities.Utilities.Shapes;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Rectangle _rectangleBorder;

    private InputManager _inputManager;
    private Vector2 _startDragPos;
    private float _startDragTime;

    private const float DRAG_TIME_TRESHOLD = .12f;

    private void Start()
    {
        _inputManager = InputManager.Instance;
    }

    private void Update()
    {
        bool hasClickedMouseThisFrame = Input.GetMouseButtonDown(0);

        if (hasClickedMouseThisFrame)
        {
            OnDragStart();
            return;
        }

        bool isHoldingMouse = Input.GetMouseButton(0);
        bool isHoldingLongEnough = Time.time - _startDragTime >= DRAG_TIME_TRESHOLD;

        if (isHoldingMouse && isHoldingLongEnough)
            OnDrag();
    }

    private void OnDragStart()
    {
        _startDragPos = _inputManager.MouseWorldPos;
        _startDragTime = Time.time;
    }

    private void OnDrag()
    {
        Vector2 offset = _inputManager.MouseWorldPos - (Vector2)transform.position;
        Vector2 dir = _startDragPos - offset;
        dir = _rectangleBorder.ClampPositionInside(dir);
        Vector3 newPos = new Vector3(dir.x, dir.y, -10);

        transform.position = newPos;
    }
}
