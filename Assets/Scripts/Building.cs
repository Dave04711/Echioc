using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject top;
    public GameObject mid;
    public GameObject bottom;
    [Space]
    public BuildingType buildingType;

    public float midHeight = .5f;
}
public enum BuildingType { A, B, C, D, E, F, None }