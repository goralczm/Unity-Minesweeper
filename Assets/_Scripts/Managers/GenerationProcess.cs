using UnityEngine;

public class GenerationProcess : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private int _gridWidth, _gridHeight;
    [SerializeField] private float _cellGap;
    [SerializeField] private int _minesCount;

    private void Start()
    {
        GameObject[] cells = GridGenearator.GenerateGrid(transform, _cellPrefab, _gridWidth, _gridHeight, _cellGap);
        CameraUtility.SetCameraPosition(cells, 2);
        CameraUtility.SetCameraScroll();
        CellAssignment.AssignTiles(cells, _minesCount);
        CellAssignment.AssignAdjecentTiles(_gridWidth);
        CellAssignment.CalculateNearbyBombs();
        PlateNaming.NamePlates();
    }
}
