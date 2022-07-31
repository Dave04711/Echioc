using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnTopView : MonoBehaviour
{
    [SerializeField] GameObject @object;
    private void LateUpdate()
    {
        @object.SetActive(!ViewManager.IsBuildingInProgress);
    }
}