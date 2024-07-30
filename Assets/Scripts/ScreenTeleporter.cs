using UnityEngine;

public class ScreenTeleporter : MonoBehaviour
{
    new Collider2D collider2D;
    new Camera camera;

    void Start()
    {
        // camera = FindAnyObjectByType<Camera>();
        camera = Camera.main; // Fõ kamerát
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        Rect cameraRect = GetCameraRect();
        Rect selfRect = GetSelfRect();

        // TODO: Teleport
    }

    Rect GetSelfRect()
    {
        Bounds bounds = collider2D.bounds;
        return new Rect(bounds.min, bounds.size);
    }

    Rect GetCameraRect()
    {
        Vector2 center = camera.transform.position;

        float y = camera.orthographicSize * 2;
        float x = camera.aspect * y;

        Vector2 size = new (x,y);
        Vector2 position = center - size / 2;
        return new(position, size);
    }

    void OnDrawGizmos()
    {
        if(camera == null)
            return;

        if(collider2D == null)
            return;

        Rect cameraRect = GetCameraRect();
        Rect selfRect = GetSelfRect();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(cameraRect.center, cameraRect.size);
        Gizmos.DrawWireCube(selfRect.center, selfRect.size);
    }
}
