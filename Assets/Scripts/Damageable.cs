using UnityEngine;

class Damageable : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;

    float health;

    void Start()
    {
        health = maxHealth;
    }

    public void ResetHealth() 
    {
        health = maxHealth;
    }

    public void DoDamage(float damage) 
    {
        health -= damage;
        // Debug.Log($"Health:  {health}");
        if (health <= 0)
            Destroy(gameObject);
    }
}
