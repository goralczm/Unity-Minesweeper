using Unity.VisualScripting;
using UnityEngine;

public static class CameraUtility
{
    public static void SetCameraPosition(GameObject[] cells, int borderOffset)
    {
        Bounds bounds = new Bounds();
        foreach (GameObject cell in cells)
            bounds.Encapsulate(cell.transform.position);

        bounds.Expand(borderOffset);

        Camera cam = Camera.main;
        var vertical = bounds.size.y;
        var horizontal = bounds.size.x * cam.pixelHeight / cam.pixelWidth;

        cam.transform.position = bounds.center + Vector3.back;
        cam.orthographicSize = Mathf.Max(horizontal, vertical) * 0.5f;
    }

    public static void SetCameraScroll()
    {
        Camera cam = Camera.main;
        
        CameraScroll camScroll = cam.GetComponent<CameraScroll>();
        if (camScroll == null)
            camScroll = cam.AddComponent<CameraScroll>();

        camScroll.maxZoom = cam.orthographicSize;
    }
}
