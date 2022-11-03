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

//TBD enum MonsterType { Water, Fire }

public class MonsterBehaviour : MonoBehaviour
{
    static int defaultHealth = 10;
    static float defaultSpeed = 3f;


    [ReadOnly,SerializeField]
    int health = defaultHealth;
    [SerializeField]
    bool isFollowingPlayer = true;
    [SerializeField]
    float speed = defaultSpeed;
    public MonsterManager manager;
    //TBD MonsterType type;


    public void Damage(int value)
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
    private void OnCollisionEnter(Collision collision)
    {
        //collision type? TBD.
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
