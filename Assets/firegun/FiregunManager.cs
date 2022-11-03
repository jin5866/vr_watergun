using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiregunManager : MonoBehaviour
{
    [SerializeField]
    GameObject flameThrower;
    [SerializeField]
    GameObject attackRange;
    [SerializeField]
    bool mouseEvent = true;
    ParticleSystem particleSystem1;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem1 = flameThrower.GetComponent<ParticleSystem>();
        StopFire();
    }
    public void Fire()
    {
        FireFire();
    }
    public void FireFire()
    {
        particleSystem1.Play();
        attackRange.SetActive(true);
    }
    public void StopFire()
    {
        particleSystem1.Stop();
        attackRange.SetActive(false);
    }
    void Update()
    {
        if (!mouseEvent) return;

        //if (Input.GetKeyDown(KeyCode.Mouse0)) FireFire();
        //if (Input.GetKeyUp(KeyCode.Mouse0)) StopFire();


    }
}
