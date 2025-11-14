using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;

    public TMP_Text livesText;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateUI();
    }

    public void LoseLife(int dmg)
    {
        lives -= dmg;
        UpdateUI();

        if (lives <= 0)
            GameOver();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        livesText.text = "Vides: " + lives;
        scoreText.text = "Punts: " + score;
    }

    void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}