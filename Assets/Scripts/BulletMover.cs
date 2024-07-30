using UnityEngine;

class BulletMover : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float duration = 3;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
