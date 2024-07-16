using UnityEngine;

class BulletMover : MonoBehaviour
{
    [SerializeField] float speed = 10; 

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;   
    }
}
