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
        if (LogicReference.IsBuilding() || isTaken) { return; }
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

    public void FinishBuilding()
    {
        for (int i = 0; i < storeys.Count; i++)
        {
            Rigidbody rigidbody = storeys[i].GetComponent<Rigidbody>();
            if(rigidbody != null) { rigidbody.isKinematic = true; }

            Collider collider = storeys[i].GetComponent<Collider>();
            if(collider != null) { collider.enabled = false; }
        }
    }
}