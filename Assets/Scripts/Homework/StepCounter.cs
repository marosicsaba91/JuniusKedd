
using UnityEngine;

public class StepCounter : MonoBehaviour
{
    [SerializeField] Vector2 a, b;
    [SerializeField] int jumpCount;
    [SerializeField] Vector2 jump;

    void OnValidate()
    {
        Vector2 distanceVector = b - a;
        float distance = distanceVector.magnitude;
        jumpCount = Mathf.CeilToInt(distance);
        jump = distanceVector / jumpCount;
    }
}
