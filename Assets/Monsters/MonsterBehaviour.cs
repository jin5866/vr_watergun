using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


//ref. from https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html?sort=votes
public class ReadOnlyAttribute : PropertyAttribute
{

}

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position,
                               SerializedProperty property,
                               GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
//end ref.


public class MonsterBehaviour : MonoBehaviour
{
    static float defaultHealth = 10;
    static float defaultSpeed = 3f;


    [SerializeField]
    float health = defaultHealth;
    [SerializeField]
    bool isFollowingPlayer = true;
    [SerializeField]
    float speed = defaultSpeed;
    public MonsterManager manager;
    [SerializeField]
    DamageType damageType;
    float lastAttackTime = -100;
    float duration = 0.5f;


    public void Damage(float value)
    {
        health -= value;
        if (health < 0)
        {
            manager.MonsterDead();

            Destroy(gameObject);
        }
    }
    public void Initialize(int health, float speed)
    {
        SetHealth(health);
        SetSpeed(speed);
    }
    public void SetHealth(int health)
    {
        this.health = health;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void OnTriggerEnter(Collider collision)
    {
        //This is Hard Coding. -Kim
        //Debug.Log("Monster is hitted by Collider.");
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Ball Collider(Clone)" && damageType == DamageType.Water)
        {
            Debug.Log("Water Monster is hitted by Water.");
            Damage(0.5f);
        }
        else if (collision.gameObject.name == "Fire Attack Range" && damageType == DamageType.Fire)
        {
            Debug.Log("Fire Monster is hitted by Fire.");
            Damage(0.2f);
        }
        else if (collision.gameObject.name == "Player")
        {
            Debug.Log("Monster is hitted by Player.");
            collision.GetComponent<PlayerState>().Damage(1,damageType);
            Destroy(gameObject);
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Fire Attack Range" && damageType == DamageType.Fire)
        {
            Debug.Log("Fire Monster is still hitted by Fire.");
            Damage(0.05f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = transform.parent.GetComponent<MonsterManager>();
        if (!manager)
        {
            Debug.Log("Can't find MonsterManager. Destroy it.");
            Destroy(this);
        }
        damageType = (DamageType)Random.Range(0, 2);
        SetMaterial();

    }
    void SetMaterial()
    {
        switch (damageType)
        {
            case DamageType.Water:
                gameObject.GetComponent<Renderer>().material = manager.monsterMaterials[DamageType.Water];
                break;
            case DamageType.Fire:
                gameObject.GetComponent<Renderer>().material = manager.monsterMaterials[DamageType.Fire];
                break;
        }
    }

    void Follow()
    {
        Vector3 player = manager.PlayerPosition;
        Vector3 monster = transform.position;
        Vector3 direction = player - monster;
        direction = Vector3.Normalize(direction) * speed * Time.deltaTime;
        transform.position += direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingPlayer) Follow();

    }
}
