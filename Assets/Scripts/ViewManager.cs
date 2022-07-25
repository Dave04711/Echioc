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

    public static bool IsBuildingInProgress;

    public static GameObject cameraIzo;

    private void Start()
    {
        SetIzoPerspective = SetIzoView;
        SetTopPerspective = SetTopView;

        cameraIzo = camIzo;
    }

    private void Update()
    {
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
        BuildingLogic.instance.SetGrapnelActive(false);
        StartCoroutine(SetBuildingRefBool(false));
        LogicReference.OnChange2IzoView_Callback();
    }

    void SetTopView()
    {
        SetNewPos();
        camIzo.SetActive(false);
        camTop.SetActive(true);
        rotateButton.SetActive(false);
        BuildingLogic.instance.SetGrapnelActive(true);
        StartCoroutine(SetBuildingRefBool(true));
        LogicReference.OnChange2TopView_Callback();
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

    IEnumerator SetBuildingRefBool(bool _p)
    {
        yield return null; // has to wait 1 frame
        IsBuildingInProgress = _p;
    }
}