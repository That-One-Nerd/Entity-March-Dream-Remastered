using UnityEngine;

public class TimedTransition : MonoBehaviour
{
    public bool skipOnClick;
    public float transitonDelay;
    [Header("Transition Data")]
    public int scene;
    public float speed;
    public float delay;
    public float afterDelay = 0;
    public float afterSpeed = -1;

    float time;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= transitonDelay || (skipOnClick && ConstantManager.ClickDown()))
        {
            Transition.Instance.FadeTransition(scene, speed, delay, afterDelay, afterSpeed);
            Destroy(this);
        }
    }
}
