using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Scenario : MonoBehaviour
{
    // HIDE EFFECT
    [SerializeField] SpriteRenderer hideSprite;
    [SerializeField][Range(0, 1)] private float speed = 0.1f;
    private bool hiding;
    private float t; //used to control interpolated animations
    // NEMESIS
    private bool nemesis = false;
    [SerializeField] private float nemesisTimer = 10;
    private float nemesiscurTime = 0;


    private void Start()
    {
        EnterScenarioCheck child = this.transform.GetComponentInChildren<EnterScenarioCheck>();
        child.OnEnterScenario += ShowScenario;
        child.OnExitScenario += HideScenario;
    }

    private void Update()
    {
        ScenarioAnimation();
        NemesisTimer();
    }

    private void NemesisTimer()
    {
        if (FindObjectsOfType<Enemy>().Length > 0 && nemesis && nemesiscurTime > -1)
        {
            nemesiscurTime -= Time.fixedDeltaTime;
            if (nemesiscurTime <= 0)
            {
                SpawnNemesis();
            }
        }
        else
        {
            nemesiscurTime = nemesisTimer;
        }
    }

    private void SpawnNemesis()
    {
        //if there is no Nemesis in game
        //spawn nemesis
        Transform spawPoint = this.transform.Find("SpawnPoints/" + Random.Range(1, 4).ToString());
        Instantiate(Resources.Load("Prefabs/Nemesis"), spawPoint.position, Quaternion.identity, spawPoint);
        //else
        //return
    }
    private void ScenarioAnimation()
    {
        if (t <= 1 & t >= 0)
        {
            if (hiding)
            {
                t += Time.fixedDeltaTime * speed;
            }
            else
            {
                t -= Time.fixedDeltaTime * speed;
            }
            hideSprite.color = new Color(hideSprite.color.r, hideSprite.color.g, hideSprite.color.b, Mathf.Lerp(1, 0, t));
        }
    }


    private void ShowScenario(Collider2D other = null)
    {
        Debug.Log("Showing cenário");
        // Fade out hide sprite
        t = 0;
        hiding = true;
        // starts nemesis timer
        nemesis = true;
        nemesiscurTime = nemesisTimer;
    }

    private void HideScenario(Collider2D other = null)
    {
        // Fade in hide scenário
        t = 1;
        hiding = false;
        // stop nemesis timer
        nemesis = false;

        // randomize this scenario elements
    }
}
