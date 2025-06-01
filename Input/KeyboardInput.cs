using UnityEngine;

public class KeyboardInput : IInputProvider
{
    public Vector2 GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        return new Vector2(x, y).normalized;
    }
}
