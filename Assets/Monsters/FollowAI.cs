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

    // 충돌 판정 플래그
    private void OnCollisionEnter(Collision collision)
    {
        hasHitPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 유저를 바라보고 움직인다
        transform.LookAt(target);
        transform.Translate(Vector3.forward * monsterSpeed * Time.deltaTime);

        // 유저와 접촉 시 데미지 넣기
        if (hasHitPlayer)
        {
            // 데미지 관련 코드
        }
    }
}
