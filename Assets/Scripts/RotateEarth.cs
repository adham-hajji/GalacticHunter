using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    [SerializeField] private int duration;

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(360 / duration * Time.deltaTime, Vector2.up);
    }
}
