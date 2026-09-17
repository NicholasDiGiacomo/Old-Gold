using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float overWeightMoveSpeed = 0.5f;
    [SerializeField] int overWeightLimit = 5;
    [Header("Jump functions")]
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGrounded; 
    [SerializeField] bool wasGrounded; 
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius = 0.2f;
    [SerializeField]  LayerMask whatIsGround;
    [SerializeField] private PlayerWeight playerWeight;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;

    
   
    private int normalMaxJumps = 2;
    private int jumpCount;
    [SerializeField] float climbSpeed = 5f;

    [SerializeField] float baseGravity = 5f;
    

    
    [SerializeField] Rigidbody2D rb;

    
    
    
    MaineController controller; 

    Vector2 moveInput;
    Vector2 targetVelosity;
    Vector2 velosityRef;
    [SerializeField] float smoothTime = 0.2f; 

    

    bool isAlive = true;
    private Vector3 originalScale;
    

    const string GROUND_STRING = "Ground";
    const string LADDER_STRING = "Ladder";
    const string ENEMY_STRING = "Enemy";
    const string HAZZARD_STRING = "Hazzard";
    const string LAVA_WALL = "Lava";

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
        originalScale = transform.localScale;
    }

    void Update()
    {
        //pause menu
        //checks if game is already paused or not
        bool Paused = SceneManager.GetSceneByName("PauseMenu").isLoaded;
        if (Input.GetKeyDown(KeyCode.Escape) && !Paused)
        {
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
        }

            moveInput = controller.Player.Move.ReadValue<Vector2>();

// checks to see if player is touching the ground there is a gameobject at base of player 
// also checks if what player standing on is in the groumd layer
         isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

         if(!wasGrounded && isGrounded)
        {
            jumpCount = 0; 
           audioSource.PlayOneShot(landSound);
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
    targetVelosity = new Vector2(
        moveInput.x * GetMoveSpeed(), 
        rb.linearVelocityY
    );

    rb.linearVelocity = Vector2.SmoothDamp(
        rb.linearVelocity, 
        targetVelosity, 
        ref velosityRef, 
        smoothTime
    );
}
   private int GetMaxJumps()
    {
        if (playerWeight.WeightModifier >= overWeightLimit)
        {
            return 1;
        }

        return normalMaxJumps;
    }
    private float GetMoveSpeed()
    {
        if (playerWeight.WeightModifier >= overWeightLimit)
        {
            return overWeightMoveSpeed;
        }

        return moveSpeed;
    }

    

    void OnJump(InputAction.CallbackContext context)
{
    if (!isAlive)
    {
        return;
    }

    if (jumpCount < GetMaxJumps())
    {
        Jump();
    }
}

    private void Jump()
{
    isGrounded = false;
    
    jumpCount++;

    rb.linearVelocityY = 0;
    rb.linearVelocityY = jumpForce;
    audioSource.PlayOneShot(jumpSound);
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
            transform.localScale = new Vector3(Mathf.Sign(rb.linearVelocity.x) * Mathf.Abs(originalScale.x)
            ,originalScale.y, originalScale.z);
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
