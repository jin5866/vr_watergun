using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private HUD hud;
    [SerializeField]
    private float MaxHealth;


    private GameManager gameManager;
    
    private float _health;

    private int _id = 0;

    private void Start()
    {
        hud.MaxHealth = MaxHealth;
        Health = MaxHealth;

        gameManager = FindObjectOfType<GameManager>();

        if (gameManager)
        {
            gameManager.GameEndEvent += new System.EventHandler(OnGameEnd);
        }
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
            hud.Health = value;
            if (value <= 0)
            {
                Die();
            }
        }
    }

    public void Damage(float value,DamageType damageType)
    {
        Health -= value;
    }

    private void Die()
    {
        if (gameManager)
        {
            gameManager.OnHealthIsZero(_id);
        }
    }

    private void OnGameEnd(object sender, System.EventArgs e)
    {

    }
}
