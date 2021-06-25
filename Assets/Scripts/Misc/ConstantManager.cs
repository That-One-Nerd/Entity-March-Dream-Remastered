using UnityEngine;

public class ConstantManager : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(gameObject);

    public static bool Click() => Input.GetMouseButton(0) || Input.GetButton("Submit");
    public static bool ClickDown() => Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit");
}