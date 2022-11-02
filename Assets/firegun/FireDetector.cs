using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Fire Attack Range")
        {
            Debug.Log("Fire is detected.");
        }
        
    }
}
