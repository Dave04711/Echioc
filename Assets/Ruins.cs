using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruins : MonoBehaviour
{
    [SerializeField] private int duration = 5;
    [Space]
    [SerializeField] private TMPro.TMP_Text howManyRoundsLeftTxt;

    private int howManyRoundsLeft;

    private void OnEnable()
    {
        howManyRoundsLeft = duration;
    }

    public void DecrementHowManyRoundsLeft()
    {
        howManyRoundsLeft--;
    }
}