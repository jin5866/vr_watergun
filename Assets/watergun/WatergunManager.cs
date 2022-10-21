using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.zibra.liquid.Manipulators;

public class WatergunManager : MonoBehaviour
{
    [SerializeField]
    Transform zibraLiquid, zibraLiquidEmitter;
    [SerializeField]
    float liquidPower = 0.15f;
    [SerializeField]
    bool verbose = false;
    [SerializeField]
    bool implementMouseevent = true;

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
    public void FireWater()
    {
        liquidEmitter.VolumePerSimTime = liquidPower;
        if (verbose) Debug.Log("Fire water.");
    }
    public void StopWater()
    {
        liquidEmitter.VolumePerSimTime = 0;
        if (verbose) Debug.Log("Stop firing water.");
    }

    // Update is called once per frame
    void Update()
    {
        // If there's no emitter stop processing.
        if (!liquidEmitter) return;

        // This is test feature.
        // If there's mouse event, please be turn off feature.
        if (implementMouseevent)
        {
            if (Input.GetButtonDown("Fire1")) FireWater();
            if (Input.GetButtonUp("Fire1")) StopWater();
        }
        
    }
}
