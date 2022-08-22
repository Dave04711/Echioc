using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

namespace GameManagerParametersClass
{
    [System.Serializable]
    public sealed class BasicParams
    {
        public int roundIndex = 0;
        public int score = 0;
    }
    [System.Serializable]
    public sealed class BuildingReferences
    {
        public TileV2 highestBuilding;
        public TileV2 lowestBuilding;
    }
    [System.Serializable]
    public sealed class RuinsReferences
    {
        public List<Ruins> ruins = new List<Ruins>();
        [Space]
        public int maxDistanceFromOrigin = 1;
    }
}

public class GameManager : MonoBehaviour
{
    public GameManagerParametersClass.BasicParams basicParams;
    public GameManagerParametersClass.BuildingReferences buildingReferences;
    public GameManagerParametersClass.RuinsReferences ruinsReferences;

    private LogicReferenceV2 logicReference;

    private void Awake()
    {
        logicReference = GetComponent<LogicReferenceV2>();
    }

    public void UpdateRuins()
    {
        int ruinsCount = ruinsReferences.ruins.Count;
        int i = 0;
        while (i < ruinsCount)
        {
            ruinsReferences.ruins[i].DecrementHowManyRoundsLeft();
            i++;
        }
    }
}