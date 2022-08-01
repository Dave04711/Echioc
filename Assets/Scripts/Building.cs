using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject top;
    public GameObject mid;
    public GameObject bottom;
    [Space]
    public BuildingType buildingType;
    public int value = 100;

    public float midHeight = .5f;
    [Header("Default references")]
    [SerializeField] GameObject barRef;
    [SerializeField] PhysicMaterial phyMatRef;

    private void Reset()
    {
        if (transform.Find("top")) { top = transform.Find("top").gameObject; }
        else { Debug.LogWarning($"Wrong storey name at <color=yellow>Top</color>, there is a need to arrange them manually in {name}"); }
        if (transform.Find("mid")) { mid = transform.Find("mid").gameObject; }
        else { Debug.LogWarning($"Wrong storey name at <color=yellow>Mid</color>, there is a need to arrange them manually in {name}"); }
        if (transform.Find("bot")) { bottom = transform.Find("bot").gameObject; }
        else { Debug.LogWarning($"Wrong storey name at <color=yellow>Bottom</color>, there is a need to arrange them manually in {name}"); }

        // TOP

        var bar = Instantiate(barRef, top.transform);
        top.AddComponent<Rigidbody>();
        var col = top.AddComponent<BoxCollider>();
        col.material = phyMatRef;
        var freeze = top.AddComponent<FreezeStorey>();
        freeze.SetBar(bar.GetComponentInChildren<Bar>());
        top.AddComponent<Timer>();

        // MID

        mid.AddComponent<Rigidbody>();
        var col2 = mid.AddComponent<BoxCollider>();
        col2.material = phyMatRef;

        // BOT

        var col3 = bottom.AddComponent<BoxCollider>();
        col3.material = phyMatRef;
    }
}
public enum BuildingType { A, B, C, D, E, F, None }