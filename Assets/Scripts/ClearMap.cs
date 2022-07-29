using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMap : MonoBehaviour
{
    [SerializeField] int minAmount2Combo = 3;
    private void Start()
    {
        LogicReference.OnCompleteBuilding_Callback += Look4Combo;
    }

    //void Test()
    //{
    //    Debug.Log(Map.currentTile.coordinates + " " + CheckingNeighbors.Check(Map.currentTile).Count);
    //    CheckingNeighbors.ResetComboCheck();
    //}

    void Look4Combo()
    {
        List<Tile> combo = CheckingNeighbors.Check(Map.currentTile);
        CheckingNeighbors.ResetComboCheck();
        if(combo.Count >= minAmount2Combo)
        {
            int totalStoreys = 0;
            foreach (var tile in combo)
            {
                totalStoreys += tile.GetStoreysAmount() - 2;// Bottom, Top
                tile.ClearTile();
            }
            CalculateValue(totalStoreys);
        }
    }

    void CalculateValue(int _totalStoreys)
    {
        int score = BuildingLogic.instance.GetBuildingValue() * _totalStoreys;
        BuildingLogic.instance.AddScore(score);
    }
}