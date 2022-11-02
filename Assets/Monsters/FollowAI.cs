using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public Transform target;
    public Transform myTransform;
    public int monsterSpeed;
    private bool hasHitPlayer;

    // Start is called before the first frame update
    void Start()
    {
        hasHitPlayer = false;
    }

    // �浹 ���� �÷���
    private void OnCollisionEnter(Collision collision)
    {
        hasHitPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ������ �ٶ󺸰� �����δ�
        transform.LookAt(target);
        transform.Translate(Vector3.forward * monsterSpeed * Time.deltaTime);

        // ������ ���� �� ������ �ֱ�
        if (hasHitPlayer)
        {
            // ������ ���� �ڵ�
        }
    }
}
