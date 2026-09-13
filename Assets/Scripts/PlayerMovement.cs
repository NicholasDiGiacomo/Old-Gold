using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
[Header("Jump functions")]
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGrounded; 
    [SerializeField] bool wasGrounded; 
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius = 0.2f;
    [SerializeField]  LayerMask whatIsGround;

    [SerializeField] int maxJumpCount = 2; 
    int jumpCount; 
    [SerializeField] float climbSpeed = 5f;

    [SerializeField] float baseGravity = 5f;
    

    
    [SerializeField] Rigidbody2D rb;
    
    
    MaineController controller; 

    Vector2 moveInput;
    Vector2 targetVelosity;
    Vector2 velosityRef;
    [SerializeField] float smoothTime = 0.2f; 

    // bool facingRight = true; 
   

    bool isAlive = true;
    

    const string GROUND_STRING = "Ground";
    const string LADDER_STRING = "Ladder";
    const string ENEMY_STRING = "Enemy";
    const string HAZZARD_STRING = "Hazzard";

    void Awake()
    {
        controller = new MaineController();
        controller.Player.Jump.performed += OnJump;
    }
    void OnEnable()
    {
        controller.Enable();
        
    }

    void OnDisable()
    {
        controller.Disable();
         controller.Player.Jump.performed -= OnJump;
    }



    private void Start() 
    {
        // rb = GetComponent<Rigidbody2D>();
        // mainCollider = GetComponent<BoxCollider2D>();
        // extraJumps = extraJumpsValue;

        // baseGravity = rb.gravityScale;
    }
    
        
    

   
    void Update()
    {

            moveInput = controller.Player.Move.ReadValue<Vector2>();


         isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

         if(!wasGrounded && isGrounded)
        {
            jumpCount = 0; 
        }

        wasGrounded = isGrounded;

        
         if (!isAlive)
         {
             return;
         }
        //  Run();
         FlipSprite();
        ClimbLadder();
        Die(); 
    }
    void FixedUpdate()
    {
        targetVelosity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocityY);
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelosity, ref velosityRef, smoothTime);
    }

    

     void OnJump(InputAction.CallbackContext context)
    {
         if (!isAlive)
         {
            return;
         }

        if (jumpCount < maxJumpCount)
         {
            isGrounded = false;
            jumpCount++;
            rb.linearVelocityY = 0; 
            rb.linearVelocityY = jumpForce;
        }
       
           
        
    }

     void ClimbLadder()
    {
    //      if (!mainCollider.IsTouchingLayers(LayerMask.GetMask(LADDER_STRING)))
    //     {
    //         rb.gravityScale = baseGravity;
    //         return;
    //         // myAnimator.SetBool("isClimbing", false);
    //     }
    //    Vector2 climbVelocity = new Vector2 ( rb.linearVelocity.x, moveInput.y * climbSpeed);
    //     rb.linearVelocity = climbVelocity;
    //     rb.gravityScale = 0f;

    //     bool hasVertacleSpeed = Mathf.Abs(rb.linearVelocity.y) > Mathf.Epsilon;

       
            // myAnimator.SetBool("isClimbing", hasVertacleSpeed);
    }

    //  void Run()
    // {
    //     Vector2 playerVelocity = new Vector2 (moveInput.x * moveSpeed , rb.linearVelocity.y);
    //     rb.linearVelocity = playerVelocity;

    //     bool hasHorozontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;

       
    //         // myAnimator.SetBool("isRunning", hasHorozontalSpeed);
        
        
    // }

     void FlipSprite()
    {
        bool hasHorozontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;

        if(hasHorozontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
        
    }

    

    void Die()
    {
        // if(mainCollider.IsTouchingLayers(LayerMask.GetMask(ENEMY_STRING, HAZZARD_STRING)))
        // {
        //     isAlive = false;
        //     // myAnimator.SetTrigger("Dying");
        //     // rB.linearVelocity = deathKick;
        //     // FindAnyObjectByType<GameSession>().ProcessPlayerDeath(); 
           
        // }
    }
}
