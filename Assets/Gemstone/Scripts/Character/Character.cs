using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public CharacterAttributes characterAttributes
    {
        protected set;
        get;
    }

    [SerializeField] protected LayerMask interactLayers;
    [SerializeField] protected int interactRange = 1;

    public abstract void Interacted();
    public abstract void Attack();
    public abstract void Interact();

}
