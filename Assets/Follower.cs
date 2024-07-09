using UnityEngine;

class Follower : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 self = transform.position;
        Vector3 other = target.position;

        transform.position = Vector3.MoveTowards(self, other, speed * Time.deltaTime);

        if (other != self)
        {
            Vector3 direction = other - self;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}