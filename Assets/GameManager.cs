using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private string EndSceneName = "EndScene";

    private float _gameTime = 5;
    private float _remainTime = 5;

    private bool isOnGame = true;

    private int _score;

    public event EventHandler GameEndEvent;
    private void Awake()
    {
        isOnGame = true;
        _remainTime = _gameTime;
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnGame) return;

        _remainTime -= Time.deltaTime;

        if(_remainTime < 0)
        {
            GameEnd();
        }
    }

    public void OnMonsterDie(int score)
    {
        _score += score;
    }

    private void GameEnd()
    {
        isOnGame = false;

        if(GameEndEvent != null)
        {
            GameEndEvent(this, EventArgs.Empty);
        }

        //Debug.Log("GameEnd gm");

        SceneManager.LoadScene(EndSceneName);
    }

    public float RemainTime
    {
        get
        {
            return _remainTime;
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
    }


}
