using UnityEngine;

public class MeteoriteGenerator : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;
    public float thrust;

    private void Start()
    {
        GenerateThreeMeteorites();
    }

    private void GenerateThreeMeteorites()
    {
        Vector3 vec = transform.position.normalized;

        for (int i = 0; i < 3; i++)
        {
            float angleA = Random.Range(-Mathf.PI / 3, Mathf.PI / 3) * Mathf.Rad2Deg;
            float angleB = Random.Range(-Mathf.PI / 3, Mathf.PI / 3) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(angleA, angleB, 0);
            float length = Random.Range(.8f, 1f) * maxDistance;
            Vector3 meteoritePosition = length * (rotation * vec).normalized;

            GameObject meteorite = new GameObject("Meteorite");
            meteorite.AddComponent<Meteorite>();
            meteorite.transform.position = meteoritePosition;

            Rigidbody rigidbody = meteorite.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.AddForce(-meteoritePosition.normalized * thrust);
        }
    }
}