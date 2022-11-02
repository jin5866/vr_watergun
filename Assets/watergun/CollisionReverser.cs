using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReverser : MonoBehaviour
{
    // Start is called before the first frame update

    public void HelloReverse()
    { 
        Debug.Log("Hello!! Reversing!!");
    }
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello!! OnCollisionEnter Reversing!!");
        Debug.Log(transform.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
