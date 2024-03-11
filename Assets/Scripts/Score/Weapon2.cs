using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    
    public int pointsToAward = 1;  // Adjust the points as needed

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        // Check if the collided object is the player
        if (other.CompareTag("Player"))
        {
            // Assuming the player has a script with a method to handle points
            PlayerTwoScore playerScore = other.GetComponent<PlayerTwoScore>();

            if (playerScore != null)
            {
                // Call a method in the PlayerOneScore script to add points
                playerScore.IncreaseScore();

                Debug.Log("Score Increased!");
                // You can add additional effects or logic here if needed
            }
        }
    }
}
