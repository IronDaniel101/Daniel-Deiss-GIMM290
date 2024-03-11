using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerTwoScore : MonoBehaviour
{
    public static Action OnPlayerTwoScored; // Event to notify Player2win script
    public TextMeshProUGUI scoreText;
    private static int score = 0; // Make the score static

    public static int Score // Property to access the score
    {
        get { return score; }
    }


    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro Text not assigned in the inspector!");
        }
    }

    void Update()
    {
        



    }

    public void IncreaseScore()
    {
        // Increase the score
        score += 1;

        // Update the TextMeshPro element
         if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }


         //check to see if score is 4.
         if (score == 4)
        {
            // Stop the game by setting the time scale to 0
            Time.timeScale = 0f;
            Debug.Log("Game Over!");

            // Trigger the event to notify Player1win script
            OnPlayerTwoScored?.Invoke();
        }
    }
}

