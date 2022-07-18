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
    [SerializeField] Transform rotateReference;
    [SerializeField] float angle = 45;
    [SerializeField] float rotateTime = .5f;
    [SerializeField] GameObject rotateButton;
    [SerializeField]bool rotate = false;

    public static Action SetIzoPerspective;
    public static Action SetTopPerspective;

    private void Start()
    {
        SetIzoPerspective = SetIzoView;
        SetTopPerspective = SetTopView;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) { SetIzoPerspective(); }
        if (rotate)
        {
            rotatePoint.rotation = Quaternion.Slerp(rotatePoint.rotation, rotateReference.rotation, rotateTime * Time.deltaTime);
            rotate = rotatePoint.rotation != rotateReference.rotation;
        }
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

    public void RotateIzoView()
    {
        rotateReference.Rotate(Vector3.up * angle);
        rotate = true;
    }
}