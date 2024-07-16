using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");

        Vector3 direction = new(xDir, 0, yDir);  
        direction.Normalize();


        Vector3 velocity = direction * speed;
        transform.position += velocity * Time.deltaTime;
    }

    float GetDirection(KeyCode positive, KeyCode negative)
    {
        bool dPos = Input.GetKey(positive);
        bool dNeg = Input.GetKey(negative);

        float dir = 0;
        if (dPos)
            dir += 1;
        if (dNeg)
            dir -= 1;

        return dir;
    }
}
