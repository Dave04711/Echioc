using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LogicReferenceV2 : MonoBehaviour
{
    #region Singleton
    public static LogicReferenceV2 Instance;

    private void Awake()
    {
        if (Instance != null) 
        {
            Debug.LogWarning($"Other {name} was detected on scene. TYPE: {typeof(LogicReferenceV2)}");
            Destroy(gameObject);
        }
        else { Instance = this; }
    }
    #endregion

    public static Action OnChange2IzoView_Callback;
    public static Action OnChange2TopView_Callback;

    public static Action OnBuildStorey_Callback;
    public static Action OnCompleteBuilding_Callback;
    public static Action OnCollapse_Callback;

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