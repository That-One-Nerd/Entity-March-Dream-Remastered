using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool CanJump { get => Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1) && hit.collider.CompareTag("Jumpable"); }

    public static bool canMove;

    internal bool heightenJump;
    internal bool slowDecel;
    internal Rigidbody rb;

    internal Mode currentMode;

    private void Start()
    {
        canMove = true;
        currentMode = Mode.Alive;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        switch (currentMode)
        {
            case Mode.Dead: Die();
                break;

            case Mode.Finished: Finish();
                break;
        }

        if (!canMove) return;

        // this must be at the start of all velocity related code
        Vector2 vel = rb.velocity;

        float vertical = Input.GetAxisRaw("Vertical");
        if (CanJump && vertical > 0)
        {
            if (heightenJump) vel.y = vertical * 20;
            else vel.y = vertical * 16;
        }

        if (vel.y < 0.1f) vel.y -= 24f * Time.deltaTime;

        // this must be at the end of all velocity related code
        rb.velocity = vel;
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        // this must be at the start of all velocity related code
        Vector2 vel = rb.velocity;

        if (slowDecel) vel.x += Input.GetAxis("Horizontal") * 5f;
        else vel.x += Input.GetAxis("Horizontal") * 2f;
        vel.x *= 0.75f;

        // this must be at the end of all velocity related code
        rb.velocity = vel;
    }

    float deathTimer;

    public void Die()
    {
        if (currentMode == Mode.Finished) return;

        canMove = false;
        currentMode = Mode.Dead;

        CinemachineVirtualCamera cam = FindObjectOfType<CinemachineVirtualCamera>();
        if (cam != null) cam.Follow = null;

        deathTimer += Time.deltaTime;

        if (deathTimer >= 2) Transition.Instance.ReloadFadeTransition(2);
    }

    public void Finish()
    {
        if (currentMode == Mode.Dead) return;

        canMove = false;
        currentMode = Mode.Finished;

        CinemachineVirtualCamera cam = FindObjectOfType<CinemachineVirtualCamera>();
        if (cam != null) cam.Follow = null;

        if (SceneManager.sceneCountInBuildSettings >= SceneManager.GetActiveScene().buildIndex + 1) Transition.Instance.FadeTransition(1, 2);
        else Transition.Instance.NextSceneTransition(2);
    }

    public enum Mode
    {
        Alive,
        Dead,
        Finished,
    }
}