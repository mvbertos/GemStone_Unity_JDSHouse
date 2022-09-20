using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemData data;
    public ItemData Data { get { return data; } }

    public void Pick(TetrisInventory inventory)
    {
        if (inventory != null)
        {
            Debug.Log("Picking Item");
            inventory.AddItem(new ItemData(data.name, data.description, data.spcRequired, data.spt));
            Destroy(this.gameObject);
        }
    }
    public void Drop()
    {
        Debug.Log("Dropping Item");
    }
    public void Use()
    {
        Debug.Log("Using Item");
    }
    public void Equip()
    {
        Debug.Log("Equiping Item");

    }
    public void UnequipItem()
    {
        Debug.Log("Unequiping Item");
    }
}
