using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Tile currentTile;
    public static List<Tile> tiles;

    public static void SetCurrentTile(Tile _tile) { currentTile = _tile; }
    public static void SetCurrentTiles(List<Tile> _tiles) { tiles = _tiles; }
}