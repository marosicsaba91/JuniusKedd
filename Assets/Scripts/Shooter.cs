using UnityEngine;

class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrototype;

    void Update()
    {
        bool isFire = Input.GetKeyDown(KeyCode.Space);

        if (isFire)
        {
            GameObject newBullet = Instantiate(bulletPrototype);
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = transform.rotation;
        }
    }
}
