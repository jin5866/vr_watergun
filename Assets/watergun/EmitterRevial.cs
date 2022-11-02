using com.zibra.liquid.Manipulators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterRevial : MonoBehaviour
{
    public float playerAngle,emitterAngle;
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform line;
    ZibraLiquidEmitter emitter;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<ZibraLiquidEmitter>();
        Debug.Log(emitter);
    }

    // Update is called once per frame
    void Update()
    {
        playerAngle = Vector3.Angle(Vector3.forward, player.rotation * Vector3.forward);
        emitterAngle = Vector3.Angle(Vector3.forward, emitter.InitialVelocity);
        Vector3 normal = Vector3.Normalize(emitter.InitialVelocity);
        //line.rotation = 
        //angle = Vector3.Angle(player.transform.position, emitter.InitialVelocity);
        
    }
}
