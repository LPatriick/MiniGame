using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [Header("Chunk Settings")]
    public GameObject[] chunkPrefabs;
    public float chunkWidth = 20f;
    public int chunksAhead = 3;
    public float despawnDistance = 40f;

    [Header("Referances")]
    public Transform player;

    private float nextSpawn = 0f;
    private List<GameObject> activeChunks = new List<GameObject>();

    void Start()
    {
        if(player.position.x + chunkWidth * chunksAhead > nextSpawn)
        {
            SpawnNextChunk();
        }

        CleanOldChunks();
    }

    void SpawnNextChunk
    {
        internal randomIndex = Random.Range(0, chunkPrefabs.Length);
        GameObject newChunk = Instantiate(chunkPrefabs[randomIndex],new Vector3(nextSpawnX, 0, 0), Quaternion.identity);

        activeChunks.Add(newChunk);
        nextSpawnX += chunkWidth;
    }

    void CleanOldChunks()
    {
        for (int i = activeChunks.Count - 1; i >= 0; i--)
        {
            if (activeChunks[i] == null) continue;

            if(player.position.x - activeChunks[i].transform.position.x > despawnDistance)
            {
                Destroy(activeChunks[i]);
                activeChunks.RemoveAt(i);
            }
        }
    }
}
