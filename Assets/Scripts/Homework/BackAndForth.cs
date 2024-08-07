using UnityEngine;

class BackAndForth : MonoBehaviour
{
    [SerializeField] Transform pointA, pointB;
    [SerializeField] float speed = 10;
    [SerializeField, Range(0, 1)] float startPointRate = 0.1f;

    Transform target;

    void OnValidate()
    {
        if (pointA == null || pointB == null)
            return;

        Vector3 a = pointA.position;
        Vector3 b = pointB.position;

        // transform.position = b * startPointRate + a * (1 - startPointRate);
        transform.position = Vector3.Lerp(a, b, startPointRate);
    }

    void Start()
    {
        transform.position = pointA.position;
        target = pointB;
    }

    void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
            target = target == pointA ? pointB : pointA;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pointA.position, 0.2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(pointB.position, 0.2f);
        Gizmos.color = Color.Lerp(Color.red, Color.blue, startPointRate);
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}
