using Unity.VisualScripting;
using UnityEngine;
using Utilities.Utilities.Shapes;

public static class CameraUtility
{
    public static void SetCameraPosition(Vector2[] cells, int borderOffset)
    {
        Bounds bounds = GetCameraBounds(cells, borderOffset);

        Camera cam = Camera.main;
        float vertical = bounds.size.y;
        float horizontal = bounds.size.x * cam.pixelHeight / cam.pixelWidth;

        cam.transform.position = bounds.center + Vector3.back;
        cam.orthographicSize = Mathf.Max(horizontal, vertical) * 0.5f;
    }

    private static Bounds GetCameraBounds(Vector2[] cells, int borderOffset)
    {
        Bounds bounds = new Bounds();
        foreach (Vector2 cell in cells)
            bounds.Encapsulate(cell);

        bounds.Expand(borderOffset);

        return bounds;
    }

    public static void SetCameraBorder(Rectangle rectangleBorder, Vector2[] cells)
    {
        float width = cells[cells.Length - 1].x - cells[0].x;
        float height = cells[cells.Length - 1].y - cells[0].y;

        rectangleBorder.transform.position = Camera.main.transform.position;
        rectangleBorder.SetWidth(width);
        rectangleBorder.SetHeight(height);
    }

    public static void SetCameraScroll()
    {
        Camera cam = Camera.main;
        
        CameraScroll camScroll = cam.GetComponent<CameraScroll>();
        if (camScroll == null)
            camScroll = cam.AddComponent<CameraScroll>();

        if (camScroll.minZoom > cam.orthographicSize)
            camScroll.minZoom = cam.orthographicSize;

        camScroll.maxZoom = cam.orthographicSize;
    }
}
