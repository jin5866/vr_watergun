using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private HUD hud;
    [SerializeField]
    private float MaxHealth;
    [SerializeField]
    private GameState gameState = GameState.InGame;


    private GameManager gameManager;
    
    private float _health;

    private int _id = 0;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        hud.MaxHealth = MaxHealth;
        Health = MaxHealth;

        gameManager = FindObjectOfType<GameManager>();

        if (gameManager)
        {
            gameManager.GameEndEvent += new System.EventHandler(OnGameEnd);
        }

        if(gameState == GameState.InMenu)
        {
            hud.SetTimerTextVisible(false);
        }

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        Health -= Time.deltaTime * 30;
    }

    public float Health
    {
        get
        {
            return _health;
        }

        set
        {
            
            
            _health = value;
            if(hud) hud.Health = value;
            if (value <= 0)
            {
                Die();
            }
        }
    }

    public void Damage(float value,DamageType damageType)
    {
        Health -= value;
        Debug.Log("Player " + _id + " damaged by " + value + " " + damageType + " damage.");
    }

    private void Die()
    {
        if (gameManager)
        {
            gameManager.OnHealthIsZero(_id);
        }

        if(gameState == GameState.InMenu)
        {
            Debug.Log("Die In Menu");
            PlayerReset();
        }
    }

    private void OnGameEnd(object sender, System.EventArgs e)
    {

    }

    private void PlayerReset()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;

        Health = MaxHealth;

        jetpack jp = GetComponent<jetpack>();

        if (jp)
        {
            jp.Reset();
        }
    }
}
