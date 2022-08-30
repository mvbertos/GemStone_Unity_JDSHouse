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
    private bool nemesisSpawned = false;
    [SerializeField] private float nemesisTimer = 10;
    private float nemesiscurTime = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        ShowScenario();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        HideScenario();
    }

    private void Update()
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

        if (!nemesisSpawned && nemesis && nemesiscurTime > -1)
        {
            nemesiscurTime -= Time.fixedDeltaTime;
            if (nemesiscurTime <= 0)
            {
                SpawnNemesis();
            }
        }
    }

    private void SpawnNemesis()
    {
        Transform spawPoint = this.transform.parent.Find("SpawnPoints/"+ Random.Range(1,4).ToString());
        Instantiate(Resources.Load("Prefabs/Nemesis"),spawPoint.position,Quaternion.identity,spawPoint);
        nemesisSpawned = true;
    }

    private void ShowScenario()
    {
        // Fade out hide sprite
        t = 0;
        hiding = true;
        // starts nemesis timer
        nemesis = true;
        nemesiscurTime = nemesisTimer;
    }

    private void HideScenario()
    {
        // Fade in hide scenário
        t = 1;
        hiding = false;
        // stop nemesis timer
        nemesis = false;

        // randomize this scenario elements
    }
}
