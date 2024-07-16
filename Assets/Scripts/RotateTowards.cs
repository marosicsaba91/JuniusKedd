using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    [SerializeField] Transform other;
    [SerializeField] float angularSpeed;

    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, other.rotation, angularSpeed * Time.deltaTime);
    }
}
