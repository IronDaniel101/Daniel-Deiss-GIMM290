using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player1win : MonoBehaviour
{
    private TextMeshProUGUI winText;
    private bool hasActivated = false;

    // Start is called before the first frame update
    void Start()
    {
       

        // Get the TextMeshPro component from the same GameObject
        winText = GetComponent<TextMeshProUGUI>();

        // Ensure the TextMeshPro component is initially invisible
        if (winText != null)
        {
            winText.enabled = false;
        }


        PlayerOneScore.OnPlayerOneScored += HandlePlayerOneScore;
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional update logic here if needed
    }

    // Method to handle the event when Player One scores
    void HandlePlayerOneScore()
    {
        // Check if the win condition is met and hasn't been activated yet
        if (PlayerOneScore.Score == 4 && !hasActivated)
        {
            // Your logic when Player One wins (e.g., show a win message)
            Debug.Log("Player One Wins!");

            // Set the flag to indicate that the win condition has been activated
            hasActivated = true;

            if (winText != null)
            {
                winText.enabled = true;
            }
        }
    }

    // Unsubscribe from the event when this script is disabled
    private void OnDisable()
    {
        PlayerOneScore.OnPlayerOneScored -= HandlePlayerOneScore;
    }
}
