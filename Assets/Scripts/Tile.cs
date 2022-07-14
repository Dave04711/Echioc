using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int coordinates;
    public bool isTaken = false;

    private void OnMouseDown()
    {
        Map.SetCurrentTile(this);
        ViewManager.SetTopPerspective();
    }
}