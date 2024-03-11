using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal1 : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "soccer"
        if (other.CompareTag("Soccer"))
        {
            // Stop the game by setting the time scale to 0
            Time.timeScale = 0f;
            Debug.Log("Game Over!");

            // Find the Player1win script in the scene
            Player1win player1win = FindObjectOfType<Player1win>();

            // Check if Player1win script is found
            if (player1win != null)
            {
                // Enable the winText in Player1win script
                player1win.EnableWinText();
            }
            else
            {
                Debug.LogWarning("Player1win script not found in the scene.");
            }

            // You can add any additional logic here, such as displaying a game over screen
        }
    }
}
