using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickyStuffs : MonoBehaviour
{
    public string link;

    Collider2D col;
    Color start;
    Text txt;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        txt = GetComponent<Text>();

        start = txt.color;
    }

    private void Update()
    {
        txt.color = start;
        if (col.OverlapPoint(Input.mousePosition))
        {
            txt.color += Color.white * 0.15f;
            if (Input.GetMouseButtonDown(0)) Application.OpenURL(link);
        }
    }
}