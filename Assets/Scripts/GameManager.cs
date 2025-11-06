using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public EnemySpawner spawner;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;

    private int score = 0;
    private int wave = 1;
    private int enemiesRemaining = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        StartNextWave();
    }

    public void StartNextWave()
    {
        waveText.text = "Wave " + wave;
        enemiesRemaining = spawner.enemiesPerWave;
        spawner.SpawnWave();
    }

    public void OnEnemyDefeated()
    {
        score++;
        enemiesRemaining--;
        scoreText.text = "Score: " + score;

        if (enemiesRemaining <= 0)
        {
            wave++;
            spawner.enemiesPerWave++;
            Invoke(nameof(StartNextWave), 2f); // pequeña pausa entre oleadas
        }
    }
}
