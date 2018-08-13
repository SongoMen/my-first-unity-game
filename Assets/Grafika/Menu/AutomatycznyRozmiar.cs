using UnityEngine;
using System.Collections;

public class AutomatycznyRozmiar : MonoBehaviour
{

    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        rt.sizeDelta = new Vector2(Screen.width*2.5f, Screen.height*2.5f);
    }
}
