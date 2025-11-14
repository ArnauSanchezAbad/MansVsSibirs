using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;

    public TMP_Text scoreText;

    [Header("UI de Vidas")]
    public Image livesImage;
    public Sprite life3Sprite;
    public Sprite life2Sprite;
    public Sprite life1Sprite;

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
        scoreText.text = "Gabiotscore: " + score;
        UpdateLifeSprite();
    }

    void UpdateLifeSprite()
    {
        if (livesImage == null) return;

        switch (lives)
        {
            case 3:
                livesImage.sprite = life3Sprite;
                break;
            case 2:
                livesImage.sprite = life2Sprite;
                break;
            case 1:
                livesImage.sprite = life1Sprite;
                break;
        }
    }

    void GameOver()
    {
        GameData.finalScore = score;
        SceneManager.LoadScene("FiDePartida");
    }
}