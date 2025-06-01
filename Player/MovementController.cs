using UnityEngine;

public class MovementController : MonoBehaviour
{
    public IMovementStrategy currentMovementStrategy;
    private IMovementStrategy previousMovementStrategy;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        currentMovementStrategy = new WalkingMovement();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void SetMovementStrategy(IMovementStrategy newMovementStrategy)
    {
        if(newMovementStrategy.GetType() != currentMovementStrategy.GetType())
        {
            previousMovementStrategy = currentMovementStrategy;
            currentMovementStrategy = newMovementStrategy;
        }
    }
    public void RestorePreviousMovementStrategy()
    {
        currentMovementStrategy.OnMovementEnd(_rigidbody);
        currentMovementStrategy = previousMovementStrategy;
    }
    public void ChangeMovementStrategy()
    {

    }
}
