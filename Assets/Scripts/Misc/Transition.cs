using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public static readonly bool enableFade = true;

    public static bool Transitioning;
    public static float speed;
    public static Transition Instance;

    RawImage img;

    private void Awake()
    {
        img = GetComponent<RawImage>();
        img.color = Color.clear;
        Instance = this;
    }

    private void Update()
    {
        if (enableFade)
        {
            Color c = img.color;

            if (!Transitioning) c.a -= Time.deltaTime * speed;
            c.a = Mathf.Clamp01(c.a);

            img.color = c;
        }
        else img.color = Color.clear;
    }

    public void NextSceneTransition(float speed, float delay = 0, float afterDelay = 0, float afterSpeed = -1) => FadeTransition(SceneManager.GetActiveScene().buildIndex + 1, speed, delay, afterDelay, afterSpeed);
    public void ReloadFadeTransition(float speed, float delay = 0, float afterDelay = 0, float afterSpeed = -1) => FadeTransition(SceneManager.GetActiveScene().buildIndex, speed, delay, afterDelay, afterSpeed);

    public void FadeTransition(int scene, float speed, float delay = 0, float afterDelay = 0, float afterSpeed = -1) { if (!Transitioning) StartCoroutine(IFadeTransition(scene, speed, delay, afterDelay, afterSpeed)); }
    private IEnumerator IFadeTransition(int scene, float speed, float delay, float afterDelay, float afterSpeed)
    {
        Transitioning = true;

        Transition.speed = speed;

        for (float f = 0; f < delay; f += Time.deltaTime) yield return null;

        if (enableFade)
        {
            while (img.color.a < 1)
            {
                img.color += Color.black * Time.deltaTime * speed;
                yield return null;
            }
            img.color = Color.black;
        }

        for (float f = 0; f < afterDelay; f += Time.deltaTime) yield return null;

        if (afterSpeed != -1) Transition.speed = afterSpeed;

        SceneManager.LoadScene(scene);
        Transitioning = false;

        yield break;
    }

    public void QuitTransition(float speed, float delay = 0, float afterDelay = 0) { if (!Transitioning) StartCoroutine(IQuitTransition(speed, delay, afterDelay)); }
    private IEnumerator IQuitTransition(float speed, float delay, float afterDelay)
    {
        Transitioning = true;

        Transition.speed = speed;

        for (float f = 0; f < delay; f += Time.deltaTime) yield return null;

        if (enableFade)
        {
            while (img.color.a < 1)
            {
                img.color += Color.black * Time.deltaTime * speed;
                yield return null;
            }
            img.color = Color.black;
        }

        for (float f = 0; f < afterDelay; f += Time.deltaTime) yield return null;

        Application.Quit();

        yield break;
    }
}