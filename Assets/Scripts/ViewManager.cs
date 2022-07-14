using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ViewManager : MonoBehaviour
{
    [SerializeField] GameObject camIzo;
    [SerializeField] GameObject camTop;
    [Space]
    [SerializeField] Transform rotatePoint;
    [SerializeField] float angle = 45;
    [SerializeField] GameObject rotateButton;

    public static Action SetIzoPerspective;
    public static Action SetTopPerspective;

    private void Start()
    {
        SetIzoPerspective = SetIzoView;
        SetTopPerspective = SetTopView;
    }

    void SetIzoView()
    {
        camIzo.SetActive(true);
        camTop.SetActive(false);
        rotateButton.SetActive(true);
    }

    void SetTopView()
    {
        SetNewPos();
        camIzo.SetActive(false);
        camTop.SetActive(true);
        rotateButton.SetActive(false);
    }

    void SetNewPos()
    {
        Transform cTop = camTop.transform;
        Transform curTile = Map.currentTile.transform;
        cTop.position = new Vector3(curTile.position.x, cTop.position.y, curTile.position.z);
    }

    public void RotateIzoView() { rotatePoint.Rotate(Vector3.up * angle); }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) { SetIzoPerspective(); }
    }
}