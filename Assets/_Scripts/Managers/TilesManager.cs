using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : Singleton<TilesManager>
{
    public GameObject[] cells;
    public Tile[] tiles;
    public Plate[] plates;
    public Bomb[] bombs;
}
