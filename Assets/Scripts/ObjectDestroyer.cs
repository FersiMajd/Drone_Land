using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float DestroyDelay;

    void Start()
    {
        Destroy(gameObject, DestroyDelay);
    }
}
