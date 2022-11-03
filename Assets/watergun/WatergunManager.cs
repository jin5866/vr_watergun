using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.zibra.liquid.Manipulators;

public class WatergunManager : MonoBehaviour
{
    [SerializeField]
    GameObject BallColider;
    [SerializeField]
    Transform BallParent;
    [SerializeField]
    int BallPerSecond = 5;
    [SerializeField]
    bool verbose = false;
    [SerializeField]
    bool implementMouseevent = true;
    public float ballSpeed = 30;
    public Vector3 OriginVelocityNormal = Vector3.up;
    bool ifFireing = false;
    float lastBallCreationTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    Vector3 Location()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;
        Vector3 a = new(Random.Range(-x, x) / 2, Random.Range(-y, y) / 2, Random.Range(-z, z) / 2);
        a = transform.rotation * a;
        return a;
    }
    void CreateBall()
    {
        GameObject gameObject = !BallParent ? Instantiate(BallColider) : Instantiate(BallColider, BallParent);
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        gameObject.SetActive(true);
        if (!gameObject || !rigidbody)
        {
            Debug.LogError("GameObject and Collider not be found.");
            return;
        }
        gameObject.transform.position = transform.position + Location();
        rigidbody.velocity = this.gameObject.transform.rotation * OriginVelocityNormal * ballSpeed;
        lastBallCreationTime = Time.realtimeSinceStartup;
    }
    public void Fire()
    {
        FireWater();
    }
    public void StopFire()
    {
        StopWater();
    }
    public void FireWater()
    {
        ifFireing = true;
        CreateBall();
        if (verbose) Debug.Log("Fire water.");
    }
    public void StopWater()
    {
        ifFireing = false;
        if (verbose) Debug.Log("Stop firing water.");
    }

    // Update is called once per frame
    void Update()
    {
        if (ifFireing && Time.realtimeSinceStartup - lastBallCreationTime > 1 / BallPerSecond)
        {
            CreateBall();
        }
        // This is test feature.
        // If there's mouse event, please be turn off feature.
        if (implementMouseevent)
        {
            if (Input.GetButtonDown("Fire1")) FireWater();
            if (Input.GetButtonUp("Fire1")) StopWater();
        }

    }
}
