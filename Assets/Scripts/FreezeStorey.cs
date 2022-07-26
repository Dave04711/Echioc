using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeStorey : MonoBehaviour
{
    Timer timer;
    [SerializeField] float time2Freeze = 5;
    [SerializeField] Bar bar;

    private void Awake()
    {
        timer = GetComponent<Timer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        timer.finishCallback += FinishCallback;
        timer.StartCounting(time2Freeze);
    }

    void FinishCallback()
    {
        Map.currentTile.FinishBuilding();
        LogicReference.OnCompleteBuilding_Callback();

        timer.finishCallback -= FinishCallback;
    }

    private void Update()
    {
        float time = timer.GetCompletionPercent();
        bar.SetFill(time);
    }
}