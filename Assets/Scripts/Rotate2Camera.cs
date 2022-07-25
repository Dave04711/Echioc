using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2Camera : MonoBehaviour
{
    Transform target;

    void Start()
    {
        target = ViewManager.cameraIzo.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(target.position);
    }
}