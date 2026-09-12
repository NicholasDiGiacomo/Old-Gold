using UnityEngine;

public class Lava : MonoBehaviour
{
    public float upspeed;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] CountDown cd;
    float counter;

    //[SerializeField] GameObject player;

    private void Start()
    {
        upspeed = 0;
    }

    private void Update()
    {
        counter = cd.Counter;

        if (counter > 30) { return; }
        if (counter > 20 && counter < 30) { upspeed = 1f; }
        else if (counter > 10 && counter < 20) {  upspeed = 2f; }
        else if (counter > 5 && counter < 10) { upspeed = 4f; }
        else { upspeed = 6f; }

        rb.linearVelocity = new Vector2 (0, upspeed);
    }
}
