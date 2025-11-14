using TMPro;
using UnityEngine;

public class EndgameManager : MonoBehaviour
{
    public TMP_Text finalScoreText;

    void Start()
    {
        finalScoreText.text = "Gabiotscore: " + GameData.finalScore;
    }
}
