using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] float damage = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable d = collision.GetComponent<Damageable>();

        if (d != null)
            d.DoDamage(damage);
    }
}