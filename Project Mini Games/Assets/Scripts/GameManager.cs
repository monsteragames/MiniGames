using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public TextMeshProUGUI scoreText; // Reference to a TextMeshPro Text element to display the score
    private int score = 0; // Player's score

    public int totalCollectibles = 0; // Total number of collectibles in the scene

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Count the total number of collectibles in the scene
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;

        UpdateScoreUI();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
        Debug.Log("Score Increased! Current Score: " + score);
    }

    public void CollectItem()
    {
        totalCollectibles--;

        if (totalCollectibles <= 0)
        {
            PlayerWins();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void PlayerWins()
    {
        // Implement winning logic here (e.g., display a win message, load a new scene, etc.)
        Debug.Log("Congratulations! You Win!");
    }
}



