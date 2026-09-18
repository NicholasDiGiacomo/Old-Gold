using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float upSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Countdown countdown;
    [SerializeField] private EndingManager endingManager;

    private bool playerKilled;

    private void Start()
    {
        upSpeed = 0f;
    }

    private void FixedUpdate()
    {
        if (playerKilled)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float counter = countdown.Counter;

        if (counter > 30f)
        {
            upSpeed = 0f;
        }
        else if (counter > 20f)
        {
            upSpeed = 1f;
        }
        else if (counter > 10f)
        {
            upSpeed = 2f;
        }
        else if (counter > 5f)
        {
            upSpeed = 4f;
        }
        else
        {
            upSpeed = 6f;
        }

        rb.linearVelocity = new Vector2(0f, upSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerKilled)
            return;

        if (!other.CompareTag("Player"))
            return;

        playerKilled = true;

        rb.linearVelocity = Vector2.zero;

        endingManager.PlayerDied();
    }
}
