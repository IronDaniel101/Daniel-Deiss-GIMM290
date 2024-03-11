using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1 : MonoBehaviour
{

    public Transform player;
    public float rotationSpeed = 5f;
    public float radius = 2f;
    public float heightOffset = 8f; // Adjust the height offset as needed
    public float distanceOffset = 5f; // Adjust the distance offset as needed


    void start()
    {
        
    }


    
    void Update()
    {
        // Ensure the player is assigned in the inspector
        if (player == null)
        {
            Debug.LogError("Player not assigned in the inspector!");
            return;
        }

        // Calculate the position in a circular path around the player
        float angle = Time.time * rotationSpeed;
        Vector3 offset = new Vector3(Mathf.Cos(angle), heightOffset, Mathf.Sin(angle)) * (radius + distanceOffset);
        Vector3 swordPosition = player.position + offset;

        // Update the sword's position
        transform.position = swordPosition;

        // Calculate the look rotation to point away from the player
        Quaternion lookRotation = Quaternion.LookRotation(player.position - swordPosition);

        // Apply the rotation to the sword, considering its initial rotation
        transform.rotation = Quaternion.Euler(90f, lookRotation.eulerAngles.y, 0f);
    }


}
