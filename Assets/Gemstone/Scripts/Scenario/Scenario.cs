using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (t < 1 && t > 0)
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

        if (nemesis && nemesiscurTime > -1)
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
        Debug.Log("Spawning Nemesis");
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
