using System;
using UnityEngine;

public class PauseMenuButtons : Button
{
    public Mode mode;
    public Vector3 sizes = new Vector3(1, 1.2f, 0.9f);
    public float switchSpeed = 11.5f;

    float size;

    private void Update()
    {
        Internal.Run();

        transform.localScale += (Vector3.one * size - transform.localScale) * (Time.deltaTime * switchSpeed);
    }

    public override void OnClick() => size = sizes.z;
    public override void OnClickOnce()
    {
        switch (mode)
        {
            case Mode.Resume:
                PauseMenuController.active = false;
                return;

            case Mode.Restart:
                Transition.Instance.ReloadFadeTransition(2);
                return;

            case Mode.Quit:
                Transition.Instance.FadeTransition(1, 2);
                return;
        }
    }
    public override void OnHover() => size = sizes.y;
    public override void OnRegular() => size = sizes.x;

    public enum Mode
    {
        Resume,
        Restart,
        Quit,
    }
}