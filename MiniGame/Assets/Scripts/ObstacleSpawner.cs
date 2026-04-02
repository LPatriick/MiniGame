using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacole")]
    public GameObject singleSpikePrefab;   
    public GameObject tripleSpikePrefab;   

    [Header("Sanse de aparitie (0-100)")]
    [Range(0, 100)]
    public int spawnChance = 60;           

    void Start()
    {
        PopulateSpawnPoints();
    }

    void PopulateSpawnPoints()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.CompareTag("SpawnPoint_Spike"))
            {
                TrySpawnObstacle(child, true);
            }
        }
    }

    void TrySpawnObstacle(Transform spawnPoint)
    {
        int roll = Random.Range(0, 100);

        if (roll > spawnChance) return;

        bool isSingle = Random.Range(0, 2) == 0;
        GameObject prefab = isSingle ? singleSpikePrefab : tripleSpikePrefab;
        Instantiate(prefab, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}