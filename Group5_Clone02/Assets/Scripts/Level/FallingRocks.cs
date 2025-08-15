using System.Collections;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    [SerializeField] private GameObject[] rockPrefabs;
    [SerializeField] private float rockFallSpeed = 5f;
    [Header("Spawn Area")]
    [SerializeField] private float minX;  // left boundary
    [SerializeField] private float maxX;   // right boundary
    [SerializeField] private float spawnY;   // height at which rocks will start spawning

    [Header("Rain Settings")]
    [SerializeField] private float spawnRate = 0.1f; // how fast to spawn rocks (lower = more rain)
    [SerializeField] private float secsToDestroy = 5f;

    private void Start()
    {
        StartCoroutine(RainRoutine());
    }

    private IEnumerator RainRoutine()
    {
        while (true)
        {
            SpawnRock();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnRock()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), spawnY, 0f);

        GameObject prefab = rockPrefabs[Random.Range(0, rockPrefabs.Length)];
        GameObject rock = Instantiate(prefab, spawnPos, Quaternion.identity);
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * rockFallSpeed;
        Destroy(rock, secsToDestroy);
    }
}
