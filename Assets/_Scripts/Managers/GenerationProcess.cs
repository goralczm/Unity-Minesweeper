using UnityEngine;

public class GenerationProcess : MonoBehaviour
{
    [SerializeField] private Plate _platePrefab;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private float _gap;

    public void MakeBoard(int width, int height, int minesCount)
    {
        Vector2[] cells = GridGenearator.GenerateGrid(width, height, _gap);
        CameraUtility.SetCameraPosition(cells, 2);
        CameraUtility.SetCameraScroll();
        CellAssignment.AssignTiles(cells, minesCount, transform, _platePrefab, _bombPrefab);
        CellAssignment.AssignAdjecentTiles(width);
        CellAssignment.CalculateNearbyBombs();
        PlateNaming.NamePlates();
    }
}
