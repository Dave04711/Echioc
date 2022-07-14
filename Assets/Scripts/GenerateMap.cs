using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] Vector2Int mapSize;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] float tileWidth = 1;
    [SerializeField] List<Tile> tiles = new List<Tile>();
    [Space]
    [SerializeField] bool showGizmos = true;

    private void Start()
    {
        Generate();
        showGizmos = false;
    }

    void Generate()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                var tile = Instantiate(tilePrefab, transform).GetComponent<Tile>();
                tile.transform.position = new Vector3(x * tileWidth, transform.position.y, y * tileWidth);
                tile.coordinates.x = x;
                tile.coordinates.y = y;
                //tile.name = $"Tile ({x} ; {y})";
                tiles.Add(tile);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = new Color(255, 255, 255, .5f);
            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    Gizmos.DrawCube(new Vector3(x * tileWidth, transform.position.y, y * tileWidth), new Vector3(1, .5f, 1));
                }
            } 
        }
    }
}