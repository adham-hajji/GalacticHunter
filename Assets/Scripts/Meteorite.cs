using UnityEngine;

public class Meteorite : MonoBehaviour
{
    private static Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
    private NoiseFilter noiseFilter;

    private int resolution = 40;
    private float radius;

    [SerializeField, HideInInspector] private MeshFilter[] meshFilters;
    private MeteoriteFace[] meteoriteFaces;

    private void OnValidate()
    {
        Initialize();
        GenerateMesh();
    }

    private void Initialize()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        meteoriteFaces = new MeteoriteFace[6];

        if (noiseFilter == null)
        {
            noiseFilter = new NoiseFilter();
        }

        radius = Random.Range(30, 50);
        
        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject plane = new GameObject("Plane");
                plane.transform.parent = transform;

                MeshRenderer meshRenderer = plane.AddComponent<MeshRenderer>();
                meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
                meshRenderer.sharedMaterial.color = Color.grey;

                meshFilters[i] = plane.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            meteoriteFaces[i] = new MeteoriteFace(meshFilters[i].sharedMesh, directions[i], radius, resolution, noiseFilter);
        }
    }

    private void GenerateMesh()
    {
        foreach (MeteoriteFace meteoriteFace in meteoriteFaces)
        {
            meteoriteFace.GenerateFace();
        }
    }

}
