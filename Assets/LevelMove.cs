using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject text;

    private GameObject player;
    void Start()
    {
        player = FindObjectOfType<PlayerState>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        text.transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("Trigger Enter");
        }
        
    }
}
