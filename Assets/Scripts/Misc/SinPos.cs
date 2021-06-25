using Unity.Mathematics;
using UnityEngine;
using System;

public class SinPos : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 offsetPos;
    public Vector3 speed;
    public Vector3 strength;

    Vector3 time;

    private void Update()
    {
        time += speed * Time.deltaTime;
        Vector3 pos = offsetPos;
        for (int i = 0; i < 3; i++) pos[i] = offsetPos[i] + (strength[i] * (float)Math.Sin(offset[i] + time[i]));
        transform.position = pos;
    }
}
