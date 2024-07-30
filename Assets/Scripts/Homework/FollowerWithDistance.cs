using UnityEngine;

class FollowerWithDistance : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] float minDistance;

    [SerializeField] Color gizmoColor1 = Color.white;
    [SerializeField] Color gizmoColor2 = Color.black;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetRealTarget(), speed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor1;
        Gizmos.DrawWireSphere(target.position, minDistance);
        Gizmos.DrawLine(target.position, transform.position);

        Gizmos.color = gizmoColor2;
        Gizmos.DrawSphere(GetRealTarget(), 0.2f);
    }

    Vector3 GetRealTarget()
    {
        Vector3 self = transform.position;
        Vector3 other = target.position;
        Vector3 direction = (other - self).normalized;
        Vector3 realTargetPoint = other - (direction * minDistance);
        return realTargetPoint;
    }
}