using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class TileFactory
{
    private static Dictionary<string, Type> _tilesByName;
    private static bool IsInitialized => _tilesByName != null;
    
    private static void InitializeFactory()
    {
        if (IsInitialized) return;

        var tilesTypes = Assembly.GetAssembly(typeof(Tile)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Tile)));

        _tilesByName = new Dictionary<string, Type>();

        foreach (var type in tilesTypes)
        {
            var tempTile = Activator.CreateInstance(type) as Tile;
            _tilesByName.Add(tempTile.Name, type);
        }
    }

    public static Tile GetTile(string tileName)
    {
        if (!_tilesByName.ContainsKey(tileName))
            return null;

        Type type = _tilesByName[tileName];
        var tile = Activator.CreateInstance(type) as Tile;
        return tile;
    }

    internal static IEnumerable<string> GetTileNames()
    {
        return _tilesByName.Keys;
    }
}