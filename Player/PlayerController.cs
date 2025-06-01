using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public static Vector3 playerLastTransform;
    [HideInInspector] public Animator animator;
    private Rigidbody2D rigidbody2d;
    
    private IInputProvider inputProvider;

    private float lastDirection = 1f;

    private Vector2 input;

    [HideInInspector] public AnimationController animationController;
    [HideInInspector] public MovementController movementController;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        animationController = GetComponent<AnimationController>();
        movementController = GetComponent<MovementController>();

        inputProvider = new KeyboardInput();
    }
    private void Update()
    {
        input = inputProvider.GetInput();

        if (input.x > 0)
            lastDirection = 1f;
        else if(input.x < 0)
            lastDirection = -1f;

        if(input.magnitude > 0)
            transform.localScale = new Vector3(lastDirection, 1f, 1f);


    }
    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        movementController.currentMovementStrategy.Move(rigidbody2d, input);
        animationController.currentAnimation.PlayAnimation(animator, input);
    }

}
