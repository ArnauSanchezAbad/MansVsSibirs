using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float radius = 5f;
    public int enemiesPerWave = 5;

    public void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            float angle = i * (360f / enemiesPerWave);
            Vector3 pos = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad) * radius,
                0,
                Mathf.Sin(angle * Mathf.Deg2Rad) * radius
            );

            Instantiate(enemyPrefab, pos, Quaternion.LookRotation(-pos));
        }

        enemiesPerWave++;
    }
}
