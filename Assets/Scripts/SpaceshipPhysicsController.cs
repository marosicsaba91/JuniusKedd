using UnityEngine;

public class SpaceshipPhysicsController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 2;
    [SerializeField] float acceleration = 2;
    [SerializeField] float angularSpeed = 180;

    [SerializeField] new Rigidbody2D rigidbody;

    void OnValidate()
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Input
        float inputX = Input.GetAxisRaw("Horizontal");

        // Mozg�s
        // NEM KELL: Menedzseli a rigidbody

        // Forg�s
        rigidbody.rotation += -inputX * angularSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // Input
        float inputY = Input.GetAxisRaw("Vertical");

        // Gyorsul�s
        Vector2 direction = transform.up * Mathf.Max(inputY, 0);
        rigidbody.velocity += direction * acceleration * Time.fixedDeltaTime;
        rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);

        // K�zegellen�ll�s
        // NEM KELL: Menedzseli a rigidbody
    }

}
