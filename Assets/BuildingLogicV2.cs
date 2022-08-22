using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLogicV2 : MonoBehaviour
{
    [SerializeField] private Transform grapnel;
    [SerializeField] private float defaultTipSpeed = 1.25f;
    [SerializeField] private float tipSpeedGain = .1f;
    [Space]
    [SerializeField] private float gridHeight = 1;

    private bool isReady2Build;
}