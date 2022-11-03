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

    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private string scoreFormatString = "{0}";

    private float _health = 0.5f;
    private float _maxhealth = 1.0f;
    private float _boost = 0.5f;
    private float _maxboost = 1.0f;

    private GameManager gameManager;
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "";
        //RemainTime = 10.0f;
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager)
        {
            gameManager.GameEndEvent += new System.EventHandler(OnGameEnd);
            SetTimer(gameManager);
        }
        else
        {
            Debug.LogError("No GameManager!");

            SetTimer(null);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer != null) 
        {
            RemainTime = timer.GetRemainTime();
        }
            
    }


    private void OnGameEnd(object sender, System.EventArgs e)
    {
        //Debug.Log("GameEnd");
        //Print Score On Canvas
        if (gameManager)
        {
            scoreText.text = string.Format(scoreFormatString, gameManager.Score);
        }
        
    }

    public void SetTimerTextVisible(bool val)
    {

        timeText.gameObject.SetActive(val);
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

    public void SetTimer(Timer timer)
    {
        this.timer = timer;

        if(timer ==null)
        {
            SetTimerTextVisible(false);
        }
        else
        {
            SetTimerTextVisible(true);
        }
    }


    
}
