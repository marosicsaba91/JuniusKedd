using UnityEngine;

class Jumper : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float inputMinDistance = 1;
    Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(target, transform.position) < inputMinDistance)
        {
            Vector3 jumpVector = Vector3.zero;
            jumpVector += GetJump(KeyCode.W, KeyCode.UpArrow, Vector3.up);
            jumpVector += GetJump(KeyCode.A, KeyCode.LeftArrow, Vector3.left);
            jumpVector += GetJump(KeyCode.S, KeyCode.DownArrow, Vector3.down);
            jumpVector += GetJump(KeyCode.D, KeyCode.RightArrow, Vector3.right);
            target += jumpVector;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    Vector3 GetJump(KeyCode key1, KeyCode key2, Vector3 dir)
    {
        bool anyKeyPressed = Input.GetKeyDown(key1) || Input.GetKeyDown(key2);
        if (anyKeyPressed)
            return dir;
        else
            return Vector3.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // new Color(0.5f,0,0.5f);
        Gizmos.DrawSphere(target, 0.2f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(target, transform.position);
    }

}
