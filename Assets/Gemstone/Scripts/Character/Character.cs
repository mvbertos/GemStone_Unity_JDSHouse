using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterAttributes characterAttributes;
    public CharacterAttributes CharacterAttributes { get { return characterAttributes; } }


    protected void Awake()
    {
        characterAttributes.HealthReduced += ValidateDeath;
    }

    private void ValidateDeath(int reduced, int normal)
    {
        if (reduced <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void Chat(String msg)
    {
        DialogueBox c = Instantiate<DialogueBox>(Resources.Load<DialogueBox>("Prefabs/UI/DialogueBox"), this.transform.position + this.transform.up, Quaternion.identity, this.transform);
        c.SetText(msg);
    }

    [SerializeField] protected LayerMask interactLayers;
    [SerializeField] protected int interactRange = 1;

    public abstract void Interacted();
    public abstract void Attack();
    public abstract void Interact();

}
