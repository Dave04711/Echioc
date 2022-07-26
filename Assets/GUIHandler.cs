using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text roundIncicator;

    private void Start()
    {
        LogicReference.OnCompleteBuilding_Callback += UpdateUIOnBuild;
    }

    void UpdateUIOnBuild()
    {
        UpdateRoundIndicator();
    }

    void UpdateRoundIndicator()
    {
        roundIncicator.text = $"R: {BuildingLogic.instance.GetCurrentRound()}";
    }
}