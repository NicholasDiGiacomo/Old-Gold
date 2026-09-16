using UnityEngine;

public class Lava : MonoBehaviour
{
    public float Upspeed;
    [SerializeField] Rigidbody2D Rb;

    [SerializeField] Countdown Cd;
    float Counter;

    //[SerializeField] GameObject player;

    private void Start()
    {
        Upspeed = 0;
    }

    private void Update()
    {
        Counter = Cd.Counter;

        if (Counter > 30) { return; }
        if (Counter > 20 && Counter < 30) { Upspeed = 1f; }
        else if (Counter > 10 && Counter < 20) {  Upspeed = 2f; }
        else if (Counter > 5 && Counter < 10) { Upspeed = 4f; }
        else { Upspeed = 6f; }

        Rb.linearVelocity = new Vector2 (0, Upspeed);
    }
}
