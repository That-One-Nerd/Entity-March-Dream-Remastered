using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Button : MonoBehaviour
{
    public bool IsClicked => IsHovered && ConstantManager.Click();
    public bool IsClickedOnce => IsHovered && ConstantManager.ClickDown();
    public bool IsHovered => Input.mousePosition.x > col.bounds.min.x && Input.mousePosition.x < col.bounds.max.x && Input.mousePosition.y > col.bounds.min.y && Input.mousePosition.y < col.bounds.max.y;
    public ButtonMode GetMode
    {
        get
        {
            ButtonMode ret = ButtonMode.None;
            if (IsHovered)
            {
                ret = ButtonMode.Hovered;
                if (ConstantManager.ClickDown()) ret = ButtonMode.ClickedOnce;
                else if (ConstantManager.Click()) ret = ButtonMode.Clicked;
            }

            return ret;
        }
    }

    public Button Internal { get; private set; }

    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        Internal = this;
    }

    public void Run()
    {
        switch (GetMode)
        {
            case ButtonMode.Clicked:
                OnClick();
                break;

            case ButtonMode.ClickedOnce:
                OnClickOnce();
                break;

            case ButtonMode.Hovered:
                OnHover();
                break;

            default:
                OnRegular();
                break;
        }
    }

    public abstract void OnClick();
    public abstract void OnClickOnce();
    public abstract void OnHover();
    public abstract void OnRegular();

    public enum ButtonMode
    {
        None,
        Hovered,
        Clicked,
        ClickedOnce,
    }
}