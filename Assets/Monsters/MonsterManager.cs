using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType { Water = 0, Fire = 1 };

//May be Singletone? -Kim
public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] monsters;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Spawn spawn;
    [SerializeField]
    int health;
    [SerializeField]
    float speed;


    public Dictionary<DamageType, Material> monsterMaterials = new Dictionary<DamageType, Material>();
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
        // Copilot is God.
        if (monsters.Length == 0) Debug.LogError("Please attach Monster Prefab.");
        if (!player) Debug.LogError("Please attach Player.");
    }

    Vector3 RandomVector()
    {
        return new Vector3(Random.value, Random.value, Random.value);
    }
    // Spawn a monster with monster number.
    public void Spawnf(int monsterNumber)
    {
        // Error Check. Copilot is God.
        if(monsterNumber >= monsters.Length)
        {
            Debug.LogError("Monster Number is out of range.");
            return;
        }
        float distance = Random.Range(0, spawn.SpawnDistance);
        GameObject gameObject = Instantiate(monsters[monsterNumber], spawn.SpawnCenter[Random.Range(0, 2)].position, Quaternion.identity, transform);
        gameObject.GetComponent<MonsterBehaviour>().Initialize(health, speed);
        gameObject.SetActive(true);
        lastSpawnTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - lastSpawnTime > spawn.SpawnDuration) Spawnf(Random.Range(0, monsters.Length));

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