using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject monster;
    public GameManager gameManager;
    public bool respawn;
    public float spawnDelay;
    private float currentTime;

    void Start()
    {
        Spawn();
        currentTime = spawnDelay;
        gameManager = FindObjectOfType<GameManager>();
    }

    // 함수 호출 시 필드 내 랜덤한 좌표에 몬스터 생성
    void Spawn()
    {
        GameObject monsterInstance = Instantiate(monster);
        monsterInstance.transform.position = new Vector3(
            Random.Range(-10, 10),
            Random.Range(0, 10),
            Random.Range(-10, 10)
        );

    }
}
