using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButtons : Button
{
    public int buildIndex;
    public Vector3 sizes = new Vector3(1, 1.2f, 0.9f);
    public float switchSpeed = 11.5f;

    float size;

    private void Update()
    {
        Internal.Run();

        transform.localScale += (Vector3.one * size - transform.localScale) * (Time.deltaTime * switchSpeed);
    }

    public override void OnClick() => size = sizes.z;
    public override void OnClickOnce() => Transition.Instance.FadeTransition(buildIndex, 1);
    public override void OnHover() => size = sizes.y;
    public override void OnRegular() => size = sizes.x;
}