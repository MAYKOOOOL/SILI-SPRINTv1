using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public Transform player;
    public TMP_Text distanceText;
    public TMP_Text highScoreText;

    public float distanceMultiplier = 1f;

    private float startX;
    private float distanceRun;
    private float highScore;

    void Start()
    {
        if (player != null)
            startX = player.position.x;

        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        UpdateHighScoreUI();
    }

    void Update()
    {
        if (player == null) return;

        distanceRun = (player.position.x - startX) * distanceMultiplier;
        distanceRun = Mathf.Max(0, distanceRun);

        if (distanceText != null)
            distanceText.text = "Distance: " + Mathf.FloorToInt(distanceRun) + "m";

        if (distanceRun > highScore)
        {
            highScore = distanceRun;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreUI();
        }
    }

    void UpdateHighScoreUI()
    {
        if (highScoreText != null)
            highScoreText.text = "Best: " + Mathf.FloorToInt(highScore) + "m";
    }

    public float GetDistance() => distanceRun;
    public float GetHighScore() => highScore;
}
