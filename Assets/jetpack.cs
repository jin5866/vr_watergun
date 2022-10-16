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
    private SteamVR_Action_Vector2 leftjoystick = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("LeftJoystick");
    private SteamVR_Action_Boolean LeftHovering = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Hovering");

    private float maxAcc = 20f;


    private Vector3 reveseGravity = Vector3.up * 9.8f;
    [SerializeField]
    private float breakAccToZero = 10f;

    private bool _hovering = false;

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

        //Input
        //TODO: move to other class
        Vector2 leftjoystickinput = leftjoystick.GetAxis(SteamVR_Input_Sources.Any);
        Hovering = LeftHovering.GetState(SteamVR_Input_Sources.Any);

        //Debug.Log(leftjoystickinput);
        //Debug.Log(updir);

        float upaxis = leftjoystickinput.y;

        

        if (_hovering)
        {
            Vector3 vel = rigidbody.velocity;

            Vector3 accToZero = vel.normalized  * breakAccToZero * (-1);
            //Debug.Log(vel);

            rigidbody.AddForce(reveseGravity + accToZero,ForceMode.Acceleration);
        }
        else
        {
            rigidbody.AddForce(updir * upaxis * maxAcc , ForceMode.Acceleration);
        }
        
    }

    public bool Hovering { 
        set
        {
            _hovering = value;
        }
    }
}
