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
        bottom.transform.position += Vector3.up * .25f;
    }

    public void SetGrapnelActive(bool _p) { grapnel.gameObject.SetActive(_p); }
}