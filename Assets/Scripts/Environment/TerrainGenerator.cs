using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 100;
    public int length = 100;
    public float height = 20;
    public float roughness = 0.5f;
    
    private Terrain terrain;
    
    void Start()
    {
        terrain = GetComponent<Terrain>();
        if (terrain == null)
        {
            terrain = gameObject.AddComponent<Terrain>();
        }
        
        GenerateTerrain();
    }
    
    void GenerateTerrain()
    {
        TerrainData terrainData = new TerrainData();
        terrainData.size = new Vector3(width, height, length);
        
        float[,] heights = new float[width, length];
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                float xCoord = (float)x / width;
                float zCoord = (float)z / length;
                heights[x, z] = Mathf.PerlinNoise(xCoord * roughness, zCoord * roughness) * 0.5f;
            }
        }
        
        terrainData.SetHeights(0, 0, heights);
        terrain.terrainData = terrainData;
    }
}