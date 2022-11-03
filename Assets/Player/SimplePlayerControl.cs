using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerControl : MonoBehaviour
{
    [SerializeField]
    WatergunManager WatergunManager;
    [SerializeField]
    FiregunManager firegunManager;
    [SerializeField]
    bool mouseEvent = true;
    // Start is called before the first frame update
    void Start()
    {
        if(!WatergunManager) Debug.LogError("Please attach WatergunManager.");
        if(!firegunManager) Debug.LogError("Please attach FiregunManager.");
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseEvent)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                firegunManager.Fire();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                WatergunManager.Fire();
            }
        }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                firegunManager.StopFire();
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                WatergunManager.StopFire();
            }
            {
        }
    }
}
