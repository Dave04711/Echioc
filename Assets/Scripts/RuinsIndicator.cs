using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RuinsIndicator : MonoBehaviour
{
    [SerializeField] int defaultValue = 5;
    public int roundIndex;
    [SerializeField] TMP_Text txt;
    public Tile tile;
    bool canAdd = true;

    private void Start()
    {
        roundIndex = defaultValue;
        canAdd = true;
        txt.text = roundIndex.ToString();
        LogicReference.OnCompleteBuilding_Callback += DecrementValue;
        LogicReference.OnBuildStorey_Callback += ResetCanAdd;
    }

    void ResetCanAdd() { canAdd = true; }

    void DecrementValue()
    {
        roundIndex--;
        txt.text = roundIndex.ToString();
        if (roundIndex == 0) { ClearTile(); }
    }

    public void ClearTile()
    {
        LogicReference.OnCompleteBuilding_Callback -= DecrementValue;
        tile.buildingType = BuildingType.None;
        tile.isTaken = false;
        tile.ruins = null;
        Destroy(gameObject);
    }

    public void AccumulateValues()
    {
        if (canAdd)
        {
            tile.buildingType = BuildingType.F;
            roundIndex += defaultValue;
            txt.text = roundIndex.ToString();
            canAdd = false; 
        }
    }
}