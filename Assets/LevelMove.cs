using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour, Timer
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject text;

    [SerializeField]
    Color ActivedColor;
    [SerializeField]
    Color InavtivedColor;
    [SerializeField]
    ParticleSystem Particle;

    [SerializeField]
    float rotateMinDist = 2.0f;

    [SerializeField]
    string LevelName = "";

    [SerializeField]
    float WaitTime = 5.0f;

    [SerializeField]
    float RemainTime = 0.0f;
    bool IsEnter = false;
    private GameObject player;

    private HUD hud;
    void Start()
    {
        player = FindObjectOfType<PlayerState>().gameObject;
        SetParticleColor(false);
        RemainTime = WaitTime;
        hud = FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > rotateMinDist)
        {
            text.transform.LookAt(player.transform);
        }

        if (IsEnter)
        {
            RemainTime -= Time.deltaTime;
        }

        if (RemainTime <= 0)
        {
            ChangeLevel();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("Trigger Enter");
            SetParticleColor(true);
            RemainTime = WaitTime;
            IsEnter = true;

            if (hud) hud.SetTimer(this);
        }


        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("Trigger Out");
            SetParticleColor(false);
            RemainTime = WaitTime;
            IsEnter = false;

            if (hud) hud.SetTimer(null);
        }
    }

    private void SetParticleColor(bool active)
    {
        if (Particle)
        {
            if (active)
            {
                var main = Particle.main;
                main.startColor = ActivedColor;
            }
            else
            {
                var main = Particle.main;
                main.startColor = InavtivedColor;
            }
        }
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(LevelName);
    }

    public float GetRemainTime()
    {
        return RemainTime;
    }
}
