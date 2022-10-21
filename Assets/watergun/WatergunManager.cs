using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.zibra.liquid.Manipulators;

public class WatergunManager : MonoBehaviour
{
    [SerializeField]
    Transform zibraLiquid, zibraLiquidEmitter;
    [SerializeField]
    float liquidPower = (float)0.15;
    [SerializeField]
    bool verbose = false;

    ZibraLiquidEmitter liquidEmitter;

    // Start is called before the first frame update
    void Start()
    {
        // If there's no Transform, It get Transform from getChild.
        if(zibraLiquid == null || zibraLiquidEmitter == null)
        {
            zibraLiquid = transform.GetChild(0);
            zibraLiquidEmitter = zibraLiquid.GetChild(0);


            if (verbose) Debug.Log("Please attach zibraLiquid on Watergun Manager");
        }
        liquidEmitter = zibraLiquidEmitter.GetComponent<ZibraLiquidEmitter>();
        if (!liquidEmitter)
            Debug.LogError("Initialize Failed on WatergunManeger:29");
    }

    // Update is called once per frame
    void Update()
    {
        if (!liquidEmitter) return;

        if(Input.GetButtonDown("Fire1"))
        {
            liquidEmitter.VolumePerSimTime = liquidPower;
            if (verbose) Debug.Log("Fire water.");
        }
        if(Input.GetButtonUp("Fire1"))
        {
            liquidEmitter.VolumePerSimTime = 0;
            if (verbose) Debug.Log("Stop firing water.");
        }
        
    }
}
