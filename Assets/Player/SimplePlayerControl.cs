using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimplePlayerControl : MonoBehaviour
{
    [SerializeField]
    SteamVR_Action_Boolean leftfire;
    [SerializeField]
    SteamVR_Action_Boolean rightfire;


    [SerializeField]
    GameObject watergunPrefab;
    [SerializeField]
    GameObject firegunPrefab;
    [SerializeField]
    Hand lefthand;
    [SerializeField]
    Hand righthand;

    [SerializeField]
    GameObject leftPosition;
    [SerializeField]
    GameObject RightPosition;

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

        Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) ;

        
        GameObject watergun = Instantiate(watergunPrefab, RightPosition.transform);
        GameObject firegun = Instantiate(firegunPrefab, leftPosition.transform);
        WatergunManager = watergun.GetComponent<WatergunManager>();
        firegunManager = firegun.GetComponent<FiregunManager>();

        righthand.AttachObject(watergun, righthand.GetGrabStarting(), attachmentFlags);
        lefthand.AttachObject(firegun, lefthand.GetGrabStarting(), attachmentFlags);

        lefthand.SetVisibility(false);
        righthand.SetVisibility(false);
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
            else
            {
                firegunManager.StopFire();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                WatergunManager.Fire();
            }
            else
            {
                WatergunManager.StopFire();
            }
        }
        if (rightfire.GetState(SteamVR_Input_Sources.Any))
        {
            firegunManager.Fire();
        }
        else
        {
            firegunManager.StopFire();
        }
        if (rightfire.GetState(SteamVR_Input_Sources.Any))
        {
            WatergunManager.Fire();
        }
        else
        {
            WatergunManager.StopFire();
        }

    }
}
