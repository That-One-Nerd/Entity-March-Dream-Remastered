using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public float deathFloor;

    PlayerController p;

    private void Start() => p = FindObjectOfType<PlayerController>();

    private void Update() { if (p.transform.position.y <= deathFloor) p.Die(); }
}