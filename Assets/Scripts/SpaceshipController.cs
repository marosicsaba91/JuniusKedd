using UnityEngine;

class SpaceshipController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 2;
    [SerializeField] float acceleration = 2;
    [SerializeField] float angularSpeed = 180;
    [SerializeField] float drag = 0.5f;

    Vector3 velocity;

    void Update()
    {
        // Input
        float inputX = Input.GetAxisRaw("Horizontal");

        // Mozgás
        transform.position += velocity * Time.deltaTime;

        // Forgás
        transform.Rotate(0, 0, -inputX * angularSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Input
        float inputY = Input.GetAxisRaw("Vertical");

        // Gyorsulás
        Vector3 direction = transform.up * Mathf.Max(inputY, 0);
        velocity += direction * acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Közegellenállás
        velocity -= velocity * drag * Time.fixedDeltaTime;
    }
}
