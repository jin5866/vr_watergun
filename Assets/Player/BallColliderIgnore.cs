using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColliderIgnore : MonoBehaviour
{
    Collider collider;

    void Start(){
        collider = GetComponent<Collider>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Contains("Ball Collider"))
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
    }
}