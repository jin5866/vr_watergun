using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAnswers_IgnoreChildsCollision : MonoBehaviour
{

    private Collider[] childrenColliders;

    void Start()
    {
        // adding all colliders to an array, but our collider will be added to !
        childrenColliders = GetComponentsInChildren<Collider>();


        foreach (Collider col in childrenColliders)
        {
            
            // checking if it is our collider, then skip it, 
            if (col != GetComponent<Collider>())
            {
                Debug.Log(col);
                // if it is not our collider then ignore collision between our collider and childs collider
                Physics.IgnoreCollision(col, GetComponent<Collider>());
            }
        }
    }
}
