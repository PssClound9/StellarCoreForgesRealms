using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [System.Serializable]
    public class Resource
    {
        public string name;
        public GameObject prefab;
        public int spawnCount;
        public float spawnRadius;
    }
    
    public Resource[] resources;
    public Transform spawnArea;
    
    void Start()
    {
        SpawnResources();
    }
    
    void SpawnResources()
    {
        foreach (Resource resource in resources)
        {
            for (int i = 0; i < resource.spawnCount; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition(resource.spawnRadius);
                Instantiate(resource.prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
    
    Vector3 GetRandomSpawnPosition(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection.y = 0; // 保持在同一高度
        return spawnArea.position + randomDirection;
    }
}