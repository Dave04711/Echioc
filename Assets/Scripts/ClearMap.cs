using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMap : MonoBehaviour
{
    private void Start()
    {
        LogicReference.OnCompleteBuilding_Callback += Test;
    }

    void Test()
    {
        Debug.Log(Map.currentTile.coordinates + " " + CheckingNeighbors.Check(Map.currentTile).Count);
        CheckingNeighbors.ResetComboCheck();
    }
}