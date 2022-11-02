using com.zibra.liquid.Manipulators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebraLocationManager : MonoBehaviour
{
    [SerializeField]
    Transform zebra;
    [SerializeField]
    Transform zebraEmitter;
    ZibraLiquidEmitter emitter;
    [SerializeField]
    Transform player;

    Vector3 OriginVelocity;
    Vector3 OriginDistance;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        if (!zebra)
        {
            Debug.LogError("Please Attach \":Zebra Liquid.\"");
            Destroy(this);
            return;
        }
        if (!zebraEmitter)
        {
            Debug.LogError("Please Attach \":Zebra Liquid Emitter.\"");
            Destroy(this);
            return;
        }
        if (!player)
        {
            Debug.LogError("Please Attach Player transform.");
            Destroy(this);
            return;
        }

        emitter = zebraEmitter.GetComponent<ZibraLiquidEmitter>();
        OriginVelocity = emitter.InitialVelocity;


        distance = Vector3.Distance(player.transform.position, transform.position);
        OriginDistance = zebra.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        zebra.transform.position = player.transform.position + player.transform.rotation * OriginDistance;
        Quaternion e = player.transform.rotation;
        //e = Quaternion.Euler(e.eulerAngles / 2);
        emitter.InitialVelocity = e * OriginVelocity;
    }
}
