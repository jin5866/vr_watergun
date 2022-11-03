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

    [SerializeField]
    private float maxAcc = 20f;
    [SerializeField]
    private float normalmodeAcc = 9.8f;
    
    
    [SerializeField]
    private float deltaAccPerSecond = 3.0f;
    [SerializeField]
    private float deltaAccPerSecondOnReturnToNormal = 5.0f;


    private Vector3 reveseGravity = Vector3.up * 9.8f;
    [SerializeField]
    private float breakAccToZero = 10f;
    [SerializeField]
    private float powerDownAltitude = 50;
    [SerializeField]
    private float powerDownRate = 2.0f;

    [SerializeField]
    private HUD hud;


    private float accOfBooster = 9.8f;

    private bool _hovering = false;

    void Start()
    {
        player = GetComponent<Valve.VR.InteractionSystem.Player>();
        //leftjoystick = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("LeftJoystick");
        rigidbody = GetComponent<Rigidbody>();
        Debug.Log(GetComponent<Rigidbody>());

        accOfBooster = normalmodeAcc;
        hud.MaxBoost = maxAcc;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updir = player.hmdTransform.up.normalized;
        Vector3 accOnThisUpdate = Vector3.zero;

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
            accOfBooster += deltaAccPerSecond * Time.deltaTime * upaxis;
            accOfBooster = Mathf.Clamp(accOfBooster, 0, maxAcc);
        }
        else { 

            //return to noraml mode
            if(accOfBooster > normalmodeAcc)
            {
                accOfBooster -= deltaAccPerSecondOnReturnToNormal * Time.deltaTime;
            }
            else
            {
                accOfBooster += deltaAccPerSecondOnReturnToNormal * Time.deltaTime;
            }

            //break
            if (_hovering)
            {
                accOnThisUpdate += GetAccVelReturnToZero();
            }
            else
            {
                accOnThisUpdate += GetAccVelReturnToZero(0.2f);
            }
            
        }
        //Debug.Log(acc);
        accOnThisUpdate += updir * accOfBooster;

        if (powerDownAltitude < transform.position.y)
        {
            float powerDown = Mathf.Clamp((transform.position.y - powerDownAltitude) * powerDownRate, 0, 100);
            accOnThisUpdate *= ((100f - powerDown) / 100f);
        }



        rigidbody.AddForce(accOnThisUpdate, ForceMode.Acceleration);

        hud.Boost = accOfBooster;

    }

    private Vector3 GetAccVelReturnToZero(float reveseAccWeight = 1.0f)
    {
        Vector3 vel = rigidbody.velocity;
        Vector3 accToZero = (-1) * breakAccToZero * reveseAccWeight * vel.normalized;
        return accToZero;
    }
    private void velReturnToZero(float reveseAccWeight = 1.0f)
    {
        
        rigidbody.AddForce(GetAccVelReturnToZero(reveseAccWeight), ForceMode.Acceleration);
    }

    public bool Hovering { 
        set
        {
            _hovering = value;
        }
    }

    public void Reset()
    {
        accOfBooster = normalmodeAcc;
        rigidbody.velocity = Vector3.zero;
    }
}
