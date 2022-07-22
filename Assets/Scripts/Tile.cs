using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int coordinates;
    public bool isTaken = false;
    public BuildingType buildingType;
    [SerializeField] List<GameObject> storeys = new List<GameObject>();

    private void OnMouseDown()
    {
        Map.SetCurrentTile(this);
        ViewManager.SetTopPerspective();
        SetBuildingType();
        BuildingLogic.instance.SetGrapnelPosition();
    }

    void SetBuildingType()
    {
        var building = Queue.Instance.PeekQueue();
        buildingType = building.buildingType;
        BuildingLogic.instance.SetBuilding(building);
    }

    public void AddStorey(GameObject _storey)
    {
        storeys.Add(_storey);
    }

    public Transform GetLastStorey() { return storeys[storeys.Count - 1].transform; }
}