using UnityEngine;

public class Sleep : IMovementStrategy
{
    public void Move(Rigidbody2D rigidbody, Vector2 input)
    {
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void OnMovementEnd(Rigidbody2D rigidbody)
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}
