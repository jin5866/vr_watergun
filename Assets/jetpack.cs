using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class jetpack : MonoBehaviour
{
    // Start is called before the first frame update

    private Valve.VR.InteractionSystem.Player player;
    //[SerializeField]
    private Rigidbody rigidbody;

    //[StreamVR_DefaultAction("LeftJoystick", "default")]
    public SteamVR_Action_Vector2 leftjoystick = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("LeftJoystick");

    private Vector3 accel = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        player = GetComponent<Valve.VR.InteractionSystem.Player>();
        //leftjoystick = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("LeftJoystick");
        rigidbody = GetComponent<Rigidbody>();
        Debug.Log(GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updir = player.hmdTransform.up;

        Vector2 leftjoystickinput = leftjoystick.GetAxis(SteamVR_Input_Sources.Any);

        //Debug.Log(leftjoystickinput);
        //Debug.Log(updir);

        float upaxis = leftjoystickinput.y;

        rigidbody.AddForce(updir * upaxis * 20);
        
        

        //player.transform.position += updir * upaxis * 10f;

        //if(SteamVR_Input._de)
        
    }
}
