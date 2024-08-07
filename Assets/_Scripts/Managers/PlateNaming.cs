using UnityEngine;
using TMPro;

public static class PlateNaming
{
    public static void NamePlates()
    {
        foreach (Plate plate in TilesManager.Instance.plates)
        {
            if (plate.nearbyBombs == 0)
                continue;

            plate.SetPlateText(Colors.GetColoredText(Colors.GetColorByNumber(plate.nearbyBombs), plate.nearbyBombs.ToString()));
        }
    }
}