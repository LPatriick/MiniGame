using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [Header("Chunk Settings")]
    public GameObject[] chunkPrefabs;
    public float chunkWidth = 20f;
    public int chunksAhead = 3;
    public float despawnDistance = 40f;
    public GameObject startChunkPrefab;

    [Header("References")]
    public Transform player;

    private float nextSpawn = 0f;
    private List<GameObject> activeChunks = new List<GameObject>();

    void Start()
    {
        GameObject startChunk = Instantiate(startChunkPrefab, new Vector3(nextSpawn, 0, 0), Quaternion.identity);
        activeChunks.Add(startChunk);
        nextSpawn += chunkWidth;
        for (int i = 0; i < chunksAhead; i++)
        {
            SpawnNextChunk();
        }
    }

    void Update()
    {
        if (player.position.x + chunkWidth * chunksAhead > nextSpawn)
        {
            SpawnNextChunk();
        }
        CleanOldChunks();
    }

    void SpawnNextChunk()
    {
        int randomIndex = Random.Range(0, chunkPrefabs.Length);
        GameObject newChunk = Instantiate(chunkPrefabs[randomIndex], new Vector3(nextSpawn, 0, 0), Quaternion.identity);
        activeChunks.Add(newChunk);
        nextSpawn += chunkWidth;
    }

    void CleanOldChunks()
    {
        for (int i = activeChunks.Count - 1; i >= 0; i--)
        {
            if (activeChunks[i] == null) continue;
            if (player.position.x - activeChunks[i].transform.position.x > despawnDistance)
            {
                Destroy(activeChunks[i]);
                activeChunks.RemoveAt(i);
            }
        }
    }
}