using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody2D;
    [SerializeField] float minSpeed = 2;
    [SerializeField] float maxSpeed = 3;
    [SerializeField] float maxAngularSpeed = 360;
    [SerializeField] float maxDamage = 25;
    [SerializeField] float maxDamageSpeed = 10;

    void OnValidate()
    {
        if (rigidbody2D == null)
            rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        rigidbody2D.velocity = Random.insideUnitCircle.normalized * speed;
        rigidbody2D.angularVelocity = Random.Range(-maxAngularSpeed, maxAngularSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        // if (go.TryGetComponent(out Damageable d)) { }

        Damageable d = go.GetComponent<Damageable>();
        if (d != null)
        {
            float t = collision.relativeVelocity.magnitude / maxDamageSpeed;
            float damage = Mathf.Lerp(0,maxDamage, t);
            d.DoDamage(damage);
        }
    }

}
