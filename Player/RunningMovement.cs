using UnityEngine;

public class RunningMovement : MonoBehaviour
{
    private float speed = 10f;

    public void Move(Transform playerTransform,Vector2 input,Animator animator)
    {
        Vector3 movement = new Vector3(input.x, input.y, 0) * speed * Time.deltaTime;
    }

    public void Move(Rigidbody2D rigidbody, Vector2 input, Animator animator)
    {
        throw new System.NotImplementedException();
    }
}
