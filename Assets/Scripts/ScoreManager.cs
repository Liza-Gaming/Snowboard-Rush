using UnityEngine;
using UnityEngine.UI;

/**
 * Displays score in the scene
 * I learned from here: https://www.youtube.com/watch?v=YUcvy9PHeXs&t=210s&ab_channel=CocoCode
 * Did the same thing in the last assignment.
 */

/// Manages the game's scoring system.
public class ScoreManager : MonoBehaviour
{
    /// Singleton instance of the ScoreManager.
    public static ScoreManager instance;

    /// Text UI element for displaying the player's current score.
    public Text scoreText;

    /// Current score of the player.
    public int score = 0;


    /// Ensures that only one instance of ScoreManager exists.
    private void Awake()
    {
        instance = this;
    }

    /// Initializes the score and high score on game start.
    void Start()
    {
        UpdateScoreText();
    }

    /// Adds a point to the player's score and updates the display.
    public void AddPoint()
    {
        score++;
        UpdateScoreText();

    }

    /// Updates the score text UI element.
    private void UpdateScoreText()
    {
        scoreText.text = $"{score} POINTS";
    }


}