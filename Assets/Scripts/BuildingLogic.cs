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
    [SerializeField] float defTipSpeed = 1.25f;
    [SerializeField] float tipSpeedGain = .1f;
    [Header("Ruins")]
    [SerializeField] int maxDistanceFromOrigin = 1;
    [SerializeField] int rounds2ClearRuins = 5;
    [SerializeField] int round = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) { SpawnBuildingMid(); }
        else if (Input.GetMouseButtonDown(1)) { SpawnBuildingTop(); }
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
        bottom.transform.localPosition = Vector3.up * .25f;
        Map.currentTile.AddStorey(bottom);
        Map.currentTile.isTaken = true;
        grapnel.GetComponent<Grapnel>().SetSpeed(defTipSpeed);
    }

    void SpawnBuildingMid()
    {
        if (LogicReference.IsBuilding())
        {
            var mid = Instantiate(building.mid, Map.currentTile.transform);

            mid.transform.eulerAngles = Vector3.left * 90;
            mid.transform.localScale = Vector3.one * .4f;
            mid.transform.position = Grapnel.Tip.position;

            grapnel.position += Vector3.up * building.midHeight;
            Grapnel _grapnel = grapnel.GetComponent<Grapnel>();
            _grapnel.Init();
            _grapnel.SetSpeed(defTipSpeed + (defTipSpeed * tipSpeedGain * Map.currentTile.GetStoreysAmount()));

            Map.currentTile.AddStorey(mid);

            LogicReference.OnBuildStorey_Callback(); 
        }
    }

    void SpawnBuildingTop()
    {
        if (LogicReference.IsBuilding())
        {
            var top = Instantiate(building.top, Map.currentTile.transform);

            top.transform.eulerAngles = Vector3.left * 90;
            top.transform.localScale = Vector3.one * .4f;
            top.transform.position = Map.currentTile.GetLastStorey().position + Vector3.up * .5f;

            Map.currentTile.AddStorey(top);

            ViewManager.SetIzoPerspective();

            LogicReference.OnCompleteBuilding_Callback(); 
        }
    }

    public void SetGrapnelActive(bool _p) { grapnel.gameObject.SetActive(_p); }
    public int GetMaxRuinsDistance() { return maxDistanceFromOrigin; }
    public int GetMaxRuinsRounds() { return rounds2ClearRuins; }
}