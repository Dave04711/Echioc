using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField][Range(0, 1f)] float percent;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetFill(float _p)
    {
        image.fillAmount = _p;
    }
}