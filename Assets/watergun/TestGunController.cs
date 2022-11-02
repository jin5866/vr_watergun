using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGunController : MonoBehaviour
{
    public float sensitivity = 700.0f;

    float rotationX = 0;
    float rotationY = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");
        //Debug.Log(mouseMoveValueX + " x, " + mouseMoveValueY + "y");

        rotationX += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationY += mouseMoveValueY * sensitivity * Time.deltaTime;

        rotationY = Mathf.Clamp(rotationY, -50.0f, 60.0f);

        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
    }
}
