using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int coordinates;
    public bool isTaken = false;
    public BuildingType buildingType;
    [SerializeField] List<GameObject> storeys = new List<GameObject>();
    [SerializeField] GameObject ruinsPrefab;
    [SerializeField] float height = .25f;
    [SerializeField] float destroyInterval = .5f;
    WaitForSeconds interval;
    bool isDestroying;
    public bool inCombo;

    private void Awake()
    {
        interval = new WaitForSeconds(destroyInterval);
    }

    private void OnMouseDown()
    {
        if (LogicReference.IsBuilding() || isTaken || !BuildingLogic.instance.IsReady2Build()) { return; }
        Map.SetCurrentTile(this);
        ViewManager.SetTopPerspective();
        SetBuildingType();
        BuildingLogic.instance.SetGrapnelPosition();
        BuildingLogic.instance.SetReadiness(false);
        Queue.Instance.UpdateQueue();
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
    public int GetStoreysAmount() { return storeys.Count; }

    public void FinishBuilding()
    {
        for (int i = 0; i < storeys.Count; i++)
        {
            Rigidbody rigidbody = storeys[i].GetComponent<Rigidbody>();
            if(rigidbody != null) { rigidbody.isKinematic = true; }

            Collider collider = storeys[i].GetComponent<Collider>();
            if(collider != null) { collider.enabled = false; }
        }
        BuildingLogic.instance.SetReadiness(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GenerateRuins();
    }

    void GenerateRuins()
    {
        //sprawdz odleglosc do currentTile ( coordinates ) ?
        //jezeli ok ( odleglosc ) to generuj ruine, zapisz obecna runde
        //dodaj delegate do zmiany rundy oraz nabicia combosa
        //jezeli odleglosc jest za duza to zwroc nic
        //jezeli na obecnej kratce jest ruina zresetuj licznik lub dodaj ilosc rund do clear'a
        //wywolaj akcje OnCollapse
        //zawal currentTile
        //przerwij tryb budowy
        //niszcz budowle

        if (CalculateDistance() <= BuildingLogic.instance.GetMaxRuinsDistance())
        {
            SpawnRuin(this);
            SpawnRuin(Map.currentTile);
            Map.currentTile.DestroyBuilding();
            BuildingLogic.instance.SetReadiness(true);
        }
    }

    void SpawnRuin(Tile _tile)
    {
        _tile.isTaken = true;
        var ruins = Instantiate(ruinsPrefab, _tile.transform);
        ruins.transform.position += Vector3.up * height;
    }

    int CalculateDistance()
    {
        return (int)Vector2.Distance(coordinates, Map.currentTile.coordinates);
    }

    public void DestroyBuilding() 
    {
        if(GetStoreysAmount() <= 0 || isDestroying) { return; }
        StartCoroutine(DestroyAllStoreys());
    }
    
    IEnumerator DestroyAllStoreys()
    {
        isDestroying = true;
        GetLastStorey().GetComponent<Timer>()?.CancelCounting();
        BuildingLogic.instance.AbortBuilding();
        for (int i = 0; i < GetStoreysAmount(); i++)
        {
            yield return interval;
            Destroy(storeys[i]);
        }
        storeys.Clear();
        isDestroying = false;
    }

    void ClearTile()
    {

    }
}