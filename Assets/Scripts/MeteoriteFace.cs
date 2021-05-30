using UnityEngine;

public class MeteoriteFace
{
    private Mesh mesh;
    private Vector3 localUp;
    private float radius;
    private int resolution;
    private NoiseFilter noiseFilter;

    public MeteoriteFace(Mesh mesh, Vector3 localUp, float radius, int resolution, NoiseFilter noiseFilter)
    {
        this.mesh = mesh;
        this.localUp = localUp;
        this.radius = radius;
        this.resolution = resolution;
        this.noiseFilter = noiseFilter;
    }

    public void GenerateFace()
    {
        Vector3 localForward = new Vector3(localUp.y, localUp.z, localUp.x);
        Vector3 localRight = Vector3.Cross(localUp, localForward);

        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];

        int tIndex = 0;

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                int i = x + y * resolution;

                Vector2 pc = new Vector2(x, y) / (resolution - 1);
                Vector3 cubePoint = localUp + (pc.x - .5f) * 2 * localForward + (pc.y - .5f) * 2 * localRight;
                Vector3 spherePoint = cubePoint.normalized;
                float elevation = ((noiseFilter.Evaluate(spherePoint) + 1) * .5f + 1);

                vertices[i] = spherePoint * radius * elevation;

                if (x != resolution - 1 && y != resolution - 1)
                {
                    triangles[tIndex] = i;
                    triangles[tIndex + 1] = i + resolution + 1;
                    triangles[tIndex + 2] = i + resolution;

                    triangles[tIndex + 3] = i;
                    triangles[tIndex + 4] = i + 1;
                    triangles[tIndex + 5] = i + resolution + 1;

                    tIndex += 6;
                }
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}