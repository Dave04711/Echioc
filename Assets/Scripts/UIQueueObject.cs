using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQueueObject : MonoBehaviour
{
    [SerializeField] Vector3 posOffset;
    [SerializeField] Vector3Int rotOffset;
    [SerializeField] Vector3 newScale;

    Vector3 targetPos;
    bool canMove = false;

    Vector3 velocity;
    public int index;

    [SerializeField] float moveDuration = .1f;
    [SerializeField] float scaleStep = .75f;
    [Space]
    public GameObject buildingPrefab;

    private void Start()
    {
        transform.position += posOffset;
        transform.eulerAngles = rotOffset;
        StartCoroutine(ScaleInit());
    }

    private void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, targetPos) > .01f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, moveDuration);
            }
            else
            {
                transform.position = targetPos;
                canMove = false;
            }
        }
        
    }

    public void SetPosition(Vector3 _newPos)
    {
        transform.position = _newPos;
    }

    public void Translate(Vector3 _newPos, bool _hide = false)
    {
        if (_hide) 
        { 
            StartCoroutine(SmoothScale());
            return;
        }
        targetPos = _newPos;
        targetPos += posOffset;
        canMove = true;
    }

    IEnumerator ScaleInit()
    {
        transform.localScale = Vector3.zero;
        while(transform.localScale.x < newScale.x) //I assume it's proportional
        {
            yield return null;
            transform.localScale += Vector3.one * Time.deltaTime * scaleStep;
        }
        transform.localScale = newScale;
    }

    IEnumerator SmoothScale()
    {
        transform.position += Vector3.forward;//delete when pivot will be better
        while (transform.localScale.x > 0) //I assume it's proportional
        {
            yield return null;
            transform.localScale -= Vector3.one * Time.deltaTime * scaleStep;
        }
        transform.localScale = Vector3.zero;
    }
}