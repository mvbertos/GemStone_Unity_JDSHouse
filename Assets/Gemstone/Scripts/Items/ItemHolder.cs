using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ItemHolder : MonoBehaviour
{
    public Animator animator { private set; get; }

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void UseItem()
    {
        Item item = this.gameObject.GetComponentInChildren<Item>();
        if (item)
        {
            item.Use();
        }
    }
}
