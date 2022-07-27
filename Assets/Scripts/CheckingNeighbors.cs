using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckingNeighbors : MonoBehaviour
{
    public static Func<Tile, List<Tile>> Check;

    private void Awake()
    {
        Check += CheckNeighbors;
    }
    public virtual List<Tile> CheckNeighbors(Tile _tile)
    {
        List<Tile> tmp = new List<Tile>();

        Tile leftNeighbor = GetSpecificTile(_tile.coordinates + Vector2Int.left);
        Tile rightNeighbor = GetSpecificTile(_tile.coordinates + Vector2Int.right);
        Tile upNeighbor = GetSpecificTile(_tile.coordinates + Vector2Int.up);
        Tile downNeighbor = GetSpecificTile(_tile.coordinates + Vector2Int.down);

        if (!tmp.Contains(leftNeighbor) && CheckTile(leftNeighbor))
        {
            leftNeighbor.inCombo = true;
            tmp.Add(leftNeighbor);
            Concat(ref tmp, Check(leftNeighbor));
        }
        if (!tmp.Contains(rightNeighbor) && CheckTile(rightNeighbor))
        {
            rightNeighbor.inCombo = true;
            tmp.Add(rightNeighbor);
            Concat(ref tmp, Check(rightNeighbor));
        }
        if (!tmp.Contains(upNeighbor) && CheckTile(upNeighbor))
        {
            upNeighbor.inCombo = true;
            tmp.Add(upNeighbor);
            Concat(ref tmp, Check(upNeighbor));
        }
        if (!tmp.Contains(downNeighbor) && CheckTile(downNeighbor))
        {
            downNeighbor.inCombo = true;
            tmp.Add(downNeighbor);
            Concat(ref tmp, Check(downNeighbor));
        }

        return tmp;
    }

    void Concat(ref List<Tile> A, List<Tile> B)
    {
        foreach (var item in B)
        {
            A.Add(item);
        }
    }

    bool CheckTile(Tile _tile)
    {
        if (_tile == null) { return false; }
        bool tmpA = _tile.buildingType == Map.currentTile.buildingType;
        bool tmpB = _tile.isTaken;
        bool tmpC = !_tile.inCombo;
        return tmpA && tmpB & tmpC;
    }

    Tile GetSpecificTile(Vector2Int _coordinates) 
    {
        for (int i = 0; i < Map.tiles.Count; i++)
        {
            if (Map.tiles[i].coordinates == _coordinates) { return Map.tiles[i]; }
        }
        return null;
    }

    public static void ResetComboCheck()
    {
        foreach (var tile in Map.tiles)
        {
            tile.inCombo = false;
        }
    }
}