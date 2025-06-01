using UnityEngine;

public class WalkingMovement : IMovementStrategy
{
    private float speed = 5f;
    public void Move(Rigidbody2D rigidbody, Vector2 input)
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    
        if (input.magnitude > 0)
        {
            Vector3 movement = new Vector3(input.x, input.y, 0) * speed;
            rigidbody.linearVelocity = movement;
        }
        else
            rigidbody.linearVelocity = Vector2.zero;
    }

    public void OnMovementEnd(Rigidbody2D rigidbody)
    {
        throw new System.NotImplementedException();
    }
}
