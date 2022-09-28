using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Character
{

    private void Start()
    {
        CharacterAttributes.HealthReduced += AuchDialog;
    }

    private void AuchDialog(int reduced, int normal)
    {
        Chat("ouch man stop it!");
    }

    public override void Attack()
    {

    }

    public override void Interact()
    {

    }

    public override void Interacted()
    {
        Chat("Hello i´m mr.dummy you dum");
    }
}
