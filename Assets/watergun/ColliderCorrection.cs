using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCorrection : MonoBehaviour
{

    [SerializeField]
    float correctionValue = 0.5f;

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (!rigidbody)
        {
            Debug.Log("Failed initializing correction component.");
            Destroy(this);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += rigidbody.velocity * correctionValue;
    }
}
