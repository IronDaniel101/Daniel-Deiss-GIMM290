using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{

    
    public float spinSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Rotate the SpeedBoost object slightly over time
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
    
}
