using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemData data;
    public ItemData Data { get { return data; } }

    public virtual void Pick(SimpleInventory inventory)
    {
        if (inventory != null)
        {
            Debug.Log("Picking Item");
            inventory.AddItemInAvailableSlot(Data);
            Destroy(this.gameObject);
        }
    }
    public virtual void Drop()
    {
        Debug.Log("Dropping Item");
    }
    public virtual void Use()
    {
        Debug.Log("Using Item");
    }
    public virtual void Equip()
    {
        Debug.Log("Equiping Item");

    }
    public virtual void UnequipItem()
    {
        Debug.Log("Unequiping Item");
    }
}
