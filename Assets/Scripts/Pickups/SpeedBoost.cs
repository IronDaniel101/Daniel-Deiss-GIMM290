using System.Collections;
using System.Collections.Generic;



using UnityEngine;

public interface ISpeedBoostable
{
    void ApplySpeedBoost(float boostAmount);
}

public class SpeedBoost : MonoBehaviour
{
    public float speedBoostAmount = 2f; // Adjust the speed boost factor as needed
    public float spinSpeed = 50f;

    public void ApplySpeedBoost(GameObject player)
    {
        // Assuming your player has a movement script controlling speed
        ISpeedBoostable speedBoostable = player.GetComponent<ISpeedBoostable>();

        if (speedBoostable != null)
        {
            // Apply speed boost
            speedBoostable.ApplySpeedBoost(speedBoostAmount);
            Destroy(gameObject); // Remove the pickup after it's collected
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplySpeedBoost(other.gameObject);
            Destroy(gameObject); // Remove the pickup after it's collected
        }
    }
    private void Update()
    {
        // Rotate the SpeedBoost object slightly over time
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
