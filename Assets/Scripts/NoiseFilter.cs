using UnityEngine;

public class NoiseFilter
{
    private Noise noise = new Noise();

    private float strength = 1;
    private float baseRoughness = 1;
    private float roughness = Random.Range(2f, 5f);
    private float persistence = .2f;
    private int nbLayers = 5;
    private Vector3 center = Random.insideUnitSphere * Random.value;

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = baseRoughness;
        float amplitude = 1;

        for (int i = 0; i < nbLayers; i++)
        {
            float v = noise.Evaluate(point * frequency + center);
            noiseValue += (v + 1) * .5f * amplitude;
            frequency *= roughness;
            amplitude *= persistence;
        }

        return noiseValue * strength;
    }
}