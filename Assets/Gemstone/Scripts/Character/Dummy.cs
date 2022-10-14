using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dummy : Character
{

    private void Start()
    {
        Attributes.HealthReduced += AuchDialog;
    }

    private void AuchDialog(int reduced, int normal)
    {
        string[] messages = { "Ouch!", "Stop IT!", "Mother F*****" };
        DialogueHandler.Instance.Chat(this, messages[Random.Range(0, messages.Length)]);
    }

    public override void Attack()
    {

    }

    public override void Interact()
    {

    }

    public override void Interacted()
    {
        string[] messages = { "Hey you.", "How is goin´. ", "Creepy room, eh!?" };
        DialogueHandler.Instance.Chat(this, messages[Random.Range(0, messages.Length)]);
    }
}
