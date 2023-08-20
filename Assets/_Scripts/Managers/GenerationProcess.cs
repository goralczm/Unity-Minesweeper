using UnityEngine;

public class GenerationProcess : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private float _gap;

    public void MakeBoard(int width, int height, int minesCount)
    {
        GameObject[] cells = GridGenearator.GenerateGrid(transform, _cellPrefab, width, height, _gap);
        CameraUtility.SetCameraPosition(cells, 2);
        CameraUtility.SetCameraScroll();
        CellAssignment.AssignTiles(cells, minesCount);
        CellAssignment.AssignAdjecentTiles(width);
        CellAssignment.CalculateNearbyBombs();
        PlateNaming.NamePlates();
    }
}
