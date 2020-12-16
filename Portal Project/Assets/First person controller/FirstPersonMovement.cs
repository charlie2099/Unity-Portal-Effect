using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;


    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }
}
