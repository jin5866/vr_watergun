using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;
    [SerializeField]
    private string timeFormatString = "{0:1}";

    [SerializeField]
    private HUDGaugeBar boostBar;
    [SerializeField]
    private HUDGaugeBar healthBar;


    private float _health = 0.5f;
    private float _maxhealth = 1.0f;
    private float _boost = 0.5f;
    private float _maxboost = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        RemainTime = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float Health 
    { private get 
        { return _health; }
        set 
        {
            healthBar.SetGauge(value / _maxhealth);
            _health = value;
        }
    }
    public float MaxHealth 
    {
        private get 
        { return _maxhealth; }
        
        set 
        {
            healthBar.SetGauge(_health / value);
            _maxhealth = value;
        }
    }

    public float Boost
    {
        private get
        { return _boost; }
        set
        {
            boostBar.SetGauge(value / _maxboost);
            _boost = value;
        }
    }

    public float MaxBoost
    {
        private get
        { return _maxboost; }
        set
        {
            boostBar.SetGauge(_boost / value);
            _maxboost = value;
        }
    }

    public float RemainTime
    {
        set
        {
            timeText.text = string.Format(timeFormatString, value);
        }
    }
    
}