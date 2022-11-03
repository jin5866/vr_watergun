using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//May be Singletone? -Kim
public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    GameObject monster;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Spawn spawn;
    [SerializeField]
    int health;
    [SerializeField]
    float speed;
    public Vector3 PlayerPosition { get => player.transform.position; }

    float lastSpawnTime = -100;


    public void MonsterDead()
    {
        Debug.Log("A Monster dead.");
        //TBD
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!monster) Debug.LogError("Please attach Monster Prefab.");
        if (!player) Debug.LogError("Please attach Player.");
    }

    Vector3 RandomVector()
    {
        return new Vector3(Random.value, Random.value, Random.value);
    }
    void Spawnf()
    {
        float distance = Random.Range(0, spawn.SpawnDistance);
        Vector3 direction = Quaternion.Euler(RandomVector() * 90) * Vector3.Normalize(RandomVector());
        Vector3 position = spawn.SpawnCenter[0].position;       //TBD
        Quaternion rotationObject = Quaternion.Euler(RandomVector() * 90);
        Quaternion rotationPosition = Quaternion.Euler(RandomVector() * 90);
        GameObject gameObject = Instantiate(monster, rotationPosition * (position + distance * direction), rotationObject, transform);
        gameObject.GetComponent<MonsterBehaviour>().Initialize(health, speed);
        gameObject.SetActive(true);
        lastSpawnTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        //Event???
        if (Time.realtimeSinceStartup - lastSpawnTime > spawn.SpawnDuration) Spawnf();

    }
}

[System.Serializable]
public class Spawn
{
    [SerializeField]
    List<Transform> spawnCenter;
    [SerializeField]
    float spawnDistance;
    [SerializeField]
    float spawnDuration = 2f;

    public List<Transform> SpawnCenter { get => spawnCenter; }
    public float SpawnDistance { get => spawnDistance; }
    public float SpawnDuration { get => spawnDuration; }
}