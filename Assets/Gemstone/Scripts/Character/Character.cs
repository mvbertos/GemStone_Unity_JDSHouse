using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterAttributes attributes;
    public CharacterAttributes Attributes { get { return attributes; } }


    protected void Awake()
    {
        attributes.HealthReduced += ValidateDeath;
    }

    private void ValidateDeath(int reduced, int normal)
    {
        if (reduced <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField] protected LayerMask interactLayers;
    [SerializeField] protected float interactRange = 1;

    public abstract void Interacted();
    public abstract void Attack();
    public abstract void Interact();

}
