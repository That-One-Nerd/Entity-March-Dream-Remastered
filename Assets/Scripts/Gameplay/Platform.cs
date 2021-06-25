using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType type;

    PlayerController p;

    private void Start() => p = FindObjectOfType<PlayerController>();

    private void Update()
    {
        switch (type)
        {
            case PlatformType.Boost:
                p.heightenJump = PlayerCollides(1.1f);
                // if (PlayerCollides(0.75f) && p.rb.velocity.y < -0.5f) p.rb.velocity = new Vector2(p.rb.velocity.x, p.rb.velocity.y * -0.5f);
                break;

            case PlatformType.Death:
                if (PlayerCollides(1.1f)) p.Die();
                break;

            case PlatformType.Finish:
                if (PlayerCollides(1.1f)) p.Finish();
                break;

            case PlatformType.Speed:
                p.slowDecel = PlayerCollides(1.1f);
                break;

            case PlatformType.Standing:
                tag = "Untagged";
                break;
        }
    }

    public bool PlayerCollides(float distance) => Physics.Raycast(p.transform.position, Vector3.down, out RaycastHit hit, distance) && hit.transform.TryGetComponent(out Platform plat) && plat.type == type;

    public enum PlatformType
    {
        Basic,
        Boost,
        Death,
        Finish,
        Hidden,
        Speed,
        Standing,
    }
}