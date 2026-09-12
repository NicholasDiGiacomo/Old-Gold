using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    [SerializeField] float baseGravity = 5f;

    Vector2 moveInput;
    Rigidbody2D rB;
    
    BoxCollider2D mainCollider;

    bool isAlive = true;

    const string GROUND_STRING = "Ground";
    const string LADDER_STRING = "Ladder";
    const string ENEMY_STRING = "Enemy";
    const string HAZZARD_STRING = "Hazzard";


    private void Start() 
    {
        rB = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();

        baseGravity = rB.gravityScale;
    }
    
        
    

   
    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        FlipSprite();
        ClimbLadder();
        Die(); 
    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        
    }

     void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        if (!mainCollider.IsTouchingLayers(LayerMask.GetMask(GROUND_STRING)))
        {
            return;
        }
       
            if(value.isPressed)
        {
            rB.linearVelocity += new Vector2 (0f, jumpSpeed);
        }
        
    }

     void ClimbLadder()
    {
         if (!mainCollider.IsTouchingLayers(LayerMask.GetMask(LADDER_STRING)))
        {
            rB.gravityScale = baseGravity;
            return;
            // myAnimator.SetBool("isClimbing", false);
        }
       Vector2 climbVelocity = new Vector2 ( rB.linearVelocity.x, moveInput.y * climbSpeed);
        rB.linearVelocity = climbVelocity;
        rB.gravityScale = 0f;

        bool hasVertacleSpeed = Mathf.Abs(rB.linearVelocity.y) > Mathf.Epsilon;

       
            // myAnimator.SetBool("isClimbing", hasVertacleSpeed);
    }

     void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * moveSpeed , rB.linearVelocity.y);
        rB.linearVelocity = playerVelocity;

        bool hasHorozontalSpeed = Mathf.Abs(rB.linearVelocity.x) > Mathf.Epsilon;

       
            // myAnimator.SetBool("isRunning", hasHorozontalSpeed);
        
        
    }

     void FlipSprite()
    {
        bool hasHorozontalSpeed = Mathf.Abs(rB.linearVelocity.x) > Mathf.Epsilon;

        if(hasHorozontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rB.linearVelocity.x), 1f);
        }
        
    }

    void Die()
    {
        if(mainCollider.IsTouchingLayers(LayerMask.GetMask(ENEMY_STRING, HAZZARD_STRING)))
        {
            isAlive = false;
            // myAnimator.SetTrigger("Dying");
            // rB.linearVelocity = deathKick;
            // FindAnyObjectByType<GameSession>().ProcessPlayerDeath(); 
           
        }
    }
}
