using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacole")]
    public GameObject[] singleSpikePrefab;
    public GameObject[] tripleSpikePrefab;

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
                TrySpawnObstacle(child);
            }
        }
    }

    void TrySpawnObstacle(Transform spawnPoint)
    {
        int roll = Random.Range(0, 100);
        if (roll > spawnChance) return;

        bool isSingle = Random.Range(0, 2) == 0;
        GameObject[] group = isSingle ? singleSpikePrefab : tripleSpikePrefab;

        if(group.Length == 0)
        {
            group = isSingle ? tripleSpikePrefab : singleSpikePrefab;
        }

        if(group.Length == 0) return;

        GameObject prefab = group[Random.Range(0, group.Length)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}