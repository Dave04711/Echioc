using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Tile currentTile;

    public static void SetCurrentTile(Tile _tile) { currentTile = _tile; }
}