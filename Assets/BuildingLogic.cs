using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLogic : MonoBehaviour
{
    #region Singleton
    public static BuildingLogic instance;
    private void Awake()
    {
        if(instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    #endregion

    [SerializeField] Building building;
    [SerializeField] Transform grapnel;
    [SerializeField] float height = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { SpawnBuildingMid(); }
        else if (Input.GetKeyDown(KeyCode.A)) { SpawnBuildingTop(); }
    }

    public void SetBuilding(Building _building) { building = _building; }

    public void SetGrapnelPosition()
    {
        grapnel.position = Map.currentTile.transform.position + Vector3.up * height;
        grapnel.GetComponent<Grapnel>()?.Init();
        SpawnBuildingBottom();
    }

    void SpawnBuildingBottom()
    {
        var bottom = Instantiate(building.bottom, Map.currentTile.transform);
        bottom.transform.eulerAngles = Vector3.left * 90;
        bottom.transform.localScale = Vector3.one * .4f;
        bottom.transform.localPosition = Vector3.up * .5f;
        Map.currentTile.AddStorey(bottom);
    }

    void SpawnBuildingMid()
    {
        var mid = Instantiate(building.mid, Map.currentTile.transform);

        mid.transform.eulerAngles = Vector3.left * 90;
        mid.transform.localScale = Vector3.one * .4f;
        mid.transform.position = Grapnel.Tip.position;
        
        grapnel.position += Vector3.up * building.midHeight;
        grapnel.GetComponent<Grapnel>().Init();

        Map.currentTile.AddStorey(mid);
    }

    void SpawnBuildingTop()
    {
        var top = Instantiate(building.top, Map.currentTile.transform);

        top.transform.eulerAngles = Vector3.left * 90;
        top.transform.localScale = Vector3.one * .4f;
        top.transform.position = Map.currentTile.GetLastStorey().position + Vector3.up * .5f;

        Map.currentTile.AddStorey(top);

        ViewManager.SetIzoPerspective();
    }

    public void SetGrapnelActive(bool _p) { grapnel.gameObject.SetActive(_p); }
}