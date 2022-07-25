using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LogicReference : MonoBehaviour
{
    public static Action OnChange2IzoView_Callback;
    public static Action OnChange2TopView_Callback;

    public static Action OnBuildStorey_Callback;
    public static Action OnCompleteBuilding_Callback;
    public static Action OnCollapse_Callback;

    public static bool IsBuilding() { return ViewManager.IsBuildingInProgress; }

    private void Start()
    {
        OnChange2IzoView_Callback += OnIzoView;
        OnChange2TopView_Callback += OnTopView;
        OnBuildStorey_Callback += OnStorey;
        OnCompleteBuilding_Callback += OnBuild;
        OnCollapse_Callback += OnCollapse;
    }

    protected virtual void OnIzoView() { }
    protected virtual void OnTopView() { }
    protected virtual void OnStorey() { }
    protected virtual void OnBuild() { }
    protected virtual void OnCollapse() { }
}