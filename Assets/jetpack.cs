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
    private float normalmodeAcc = 9.8f;

    private float acc = 9.8f;
    private float deltaAccPerSecond = 3.0f;
    private float deltaAccPerSecondOnReturnToNormal = 5.0f;


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
        Vector3 updir = player.hmdTransform.up.normalized;

        //Input
        //TODO: move to other class
        Vector2 leftjoystickinput = leftjoystick.GetAxis(SteamVR_Input_Sources.Any);
        Hovering = LeftHovering.GetState(SteamVR_Input_Sources.Any);

        //Debug.Log(leftjoystickinput);
        //Debug.Log(updir);

        float upaxis = leftjoystickinput.y;

        
        if(Mathf.Abs(upaxis) >= 0.05)
        {
            // change acc
            acc += deltaAccPerSecond * Time.deltaTime * upaxis;
            acc = Mathf.Clamp(acc, 0, maxAcc);
        }
        else
        {
            //return to noraml mode
            if(acc > normalmodeAcc)
            {
                acc -= deltaAccPerSecondOnReturnToNormal * Time.deltaTime;
            }
            else
            {
                acc += deltaAccPerSecondOnReturnToNormal * Time.deltaTime;
            }

            velReturnToZero(0.2f);
        }
        Debug.Log(acc);
        if (_hovering)
        {
            velReturnToZero();
        }
        else
        {
            rigidbody.AddForce(updir * acc , ForceMode.Acceleration);
        }
        
    }

    private void velReturnToZero(float reveseAccWeight = 1.0f)
    {
        Vector3 vel = rigidbody.velocity;
        Vector3 accToZero = vel.normalized * breakAccToZero * (-1) * reveseAccWeight;
        rigidbody.AddForce(accToZero, ForceMode.Acceleration);
    }

    public bool Hovering { 
        set
        {
            _hovering = value;
        }
    }
}
