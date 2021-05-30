using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WorldBoundaries : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Vector3.zero);
        Vector3 unitVector = transform.position.normalized;

        if (distance < minDistance)
        {
            transform.position = unitVector * minDistance;
        }
        else if (maxDistance < distance)
        {
            transform.position = unitVector * maxDistance;
        }
    }
}
