using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButton : Button
{
    public Mode buttonMode;
    public Vector3 sizes;
    public float switchSpeed;

    float size;

    private void Update()
    {
        Internal.Run();

        transform.localScale += (Vector3.one * size - transform.localScale) * (Time.deltaTime * switchSpeed);
    }

    public override void OnClick() => size = sizes.z;
    public override void OnClickOnce()
    {
        switch (buttonMode)
        {
            case Mode.Back:
                Transition.Instance.FadeTransition(1, 1); // needs to go to the title screen
                return;

            case Mode.Play:
                Transition.Instance.FadeTransition(3, 1); // needs to go to the tutorial level
                return;

            case Mode.LevelSelect:
                Transition.Instance.FadeTransition(2, 1); // needs to go to the level select menu
                return;

            case Mode.Quit:
                Transition.Instance.QuitTransition(1, 0, 0);
                return;
        }
    }
    public override void OnHover() => size = sizes.y;
    public override void OnRegular() => size = sizes.x;

    public enum Mode
    {
        Play,
        LevelSelect,
        Options,
        Quit,
        Back,
    }
}
