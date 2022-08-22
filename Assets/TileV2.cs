using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileV2 : MonoBehaviour
{
    private bool isTaken = false;

    private const int buildingLayerIndex = 7;
    private const BuildingType ruinsBuildingTypeRef = BuildingType.F;
    private const BuildingType defaultBuildingTypeRef = BuildingType.None;

    public BuildingType buildingType;

    [SerializeField] private GameObject ruins;
    [SerializeField] List<GameObject> storeys = new List<GameObject>();

    public bool IsTileTaken() { return isTaken; }
    public void SetTileAvailability(bool _availability) { isTaken = _availability; }

    private void ToggleRuins(bool _visibility) { ruins.SetActive(_visibility); }

    public void SetBuildingType(BuildingType _buildingType) { buildingType = _buildingType; }

    public void Clear()
    {
        SetTileAvailability(false);
        ToggleRuins(false);
        SetBuildingType(defaultBuildingTypeRef);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != buildingLayerIndex) { return; }
        SetTileAvailability(true);
        ToggleRuins(true);
        SetBuildingType(ruinsBuildingTypeRef);
    }
}