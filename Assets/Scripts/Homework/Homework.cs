using UnityEngine;

public class Homework : MonoBehaviour
{
    // Input
    [SerializeField] float number1;
    [SerializeField] float number2;
    [SerializeField] float min, max;
    [SerializeField] int integer;

    // Output
    [SerializeField] float clamped;
    [SerializeField] float smallest;
    [SerializeField] float largest;
    [SerializeField] bool isPrime;

    void OnValidate()
    {
        clamped = Clamp(number1, min, max);
        smallest = Min(number1, number2);
        largest = Max(number1, number2);

        float round1 = Round(number1);
        float roundAny = Round(number1, number2);

        isPrime = IsPrime(integer);
    }


    float Clamp(float value, float min, float max) 
    {
        if (value < min)
            return min;

        if (value > max)
            return max;
        
        return value;
    }

    float Min(float a, float b) => a < b ? a : b;

    float Max(float a, float b) => a > b ? a : b;

    float Round(float number) 
    {
        float remainder = number % 1;

        float full = number - remainder;

        //if (remainder > 0.5f)
        //    return full + 1;
        //else
        //    return full;

        return remainder > 0.5f ? full + 1 : full;
    }

    float Round(float number, float roundTo)
    {
        float remainder = number % roundTo;
        float full = number - remainder;

        float half = roundTo / 2;

        return remainder > half ? full + roundTo : full;
    }

    bool IsPrime(int number) 
    {
        number = Mathf.Abs(number);

        if (number <= 1)
            return false;

        for (int i = 2; i < number / 2; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    Vector3 MoveTowards(Vector3 current, Vector3 target, float maxStep)
    {
        Vector3 direction = target - current;
        float distance = direction.magnitude;
        direction /= distance;  // Normalizálás

        if (distance <= maxStep)
            return target;

        return current + direction * maxStep;
    }
}
