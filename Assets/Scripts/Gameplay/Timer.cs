using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static float gameTime;

    public string format;

    bool run;
    float currentTime;
    Text txt;

    private void Start() => txt = GetComponent<Text>();

    private void Update()
    {
        if (!run || FindObjectOfType<PlayerController>().currentMode != PlayerController.Mode.Alive)
        {
            run = true;
            return;
        }

        gameTime += Time.deltaTime;
        currentTime += Time.deltaTime;

        txt.text = gameTime.ToString(format) + " | " + currentTime.ToString(format);
    }
}