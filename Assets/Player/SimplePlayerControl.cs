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

    bool lastleft = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!WatergunManager) Debug.LogError("Please attach WatergunManager.");
        if(!firegunManager) Debug.LogError("Please attach FiregunManager.");

        //Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) ;

        
        //GameObject watergun = Instantiate(watergunPrefab, RightPosition.transform);
        //GameObject firegun = Instantiate(firegunPrefab, leftPosition.transform);
        //WatergunManager = watergun.GetComponent<WatergunManager>();
        //firegunManager = firegun.GetComponent<FiregunManager>();

        //righthand.AttachObject(watergun, righthand.GetGrabStarting(), attachmentFlags);
        //lefthand.AttachObject(firegun, lefthand.GetGrabStarting(), attachmentFlags);

        //righthand.currentAttachedTeleportManager.teleportAllowed = true;
        //lefthand.currentAttachedTeleportManager.teleportAllowed = true;

        lefthand.SetVisibility(false);
        righthand.SetVisibility(false);
        //firegunManager.Fire();
        //WatergunManager.Fire();
    }

    // Update is called once per frame
    void Update()
    {
        //firegunManager.Fire();
        //WatergunManager.Fire();

        bool leftfireinput = leftfire.GetState(SteamVR_Input_Sources.Any);
        bool rightfireinput = rightfire.GetState(SteamVR_Input_Sources.Any);

        //Debug.Log(leftfireinput);

        if(!lastleft && leftfireinput)
        {
            firegunManager.Fire();

        }
        else if(lastleft && !leftfireinput)
        {
            firegunManager.StopFire();
        }

        lastleft = leftfireinput;

        if (rightfireinput)
        {
            WatergunManager.Fire();
        }
        else
        {
            WatergunManager.StopFire();
        }

    }
}
