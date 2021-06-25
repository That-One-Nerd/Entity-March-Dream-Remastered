using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public static bool active;

    RawImage img;

    private void Start()
    {
        active = false;
        img = GetComponent<RawImage>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) active = !active;

        img.color = Color.black * Convert.ToSingle(active) * 0.75f;
        for (int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.SetActive(active);
    }
}