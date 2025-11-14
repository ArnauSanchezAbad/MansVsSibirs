using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 3f;
    public float initialDelay = 2f;
    // This is the starting spawn interval; it will be decreased over time
    public float spawnInterval = 5f;
    // Minimum allowed spawn interval
    public float minSpawnInterval = 0.3f;
    // How much to decrease the interval after each wave (base value)
    public float spawnIntervalDecrease = 0.1f;
    public int waveCount = 1;

    Transform player;
    float currentSpawnInterval;

    void Start()
    {
        player = Camera.main.transform;
        currentSpawnInterval = spawnInterval;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        // initial delay before the first wave
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            SpawnWave();

            // Decrease the interval but clamp to minSpawnInterval.
            // Scale down the decrease as more waves pass so the interval reduction slows over time.
            float scale = 1f / Mathf.Max(1f, Mathf.Log(waveCount + 2f));
            float decrease = spawnIntervalDecrease * scale;
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - decrease);

            // Wait for the (possibly decreased) interval until next wave
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }

    void SpawnWave()
    {
        // Slower enemy growth: use square root of the wave count so difficulty scales gently
        int enemiesToSpawn = 1 + Mathf.FloorToInt(Mathf.Sqrt(waveCount));

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 pos = player.position + (Random.insideUnitSphere * spawnRadius);
            pos.y = player.position.y;
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }

        waveCount++;
    }
}
