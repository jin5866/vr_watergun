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

    // �Լ� ȣ�� �� �ʵ� �� ������ ��ǥ�� ���� ����
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
