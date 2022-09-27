using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleInventory : MonoBehaviour
{
    private InputMappings inputMappings;
    [SerializeField] private ItemInfoUI itemInforUI;
    [SerializeField] private Transform slotsParent;
    private InventorySlot[] slots;
    private int curSlot;

    private void Start()
    {
        inputMappings = GameObject.FindObjectOfType<Player>().inputMappings;
        inputMappings.Player.NavInventory.performed += ctx => ChangeSlot(ctx.ReadValue<float>());



        slots = new InventorySlot[slotsParent.childCount];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotsParent.GetChild(i).GetComponent<InventorySlot>();
        }

        ChangeSlot(0);
    }

    void Update()
    {
        UIRaycast uIRaycast = new UIRaycast(LayerMask.NameToLayer("ItemSlot"));


        Vector2 mousePos = Input.mousePosition;
        ItemInfoUI instance = FindObjectOfType<ItemInfoUI>();

        if (uIRaycast.IsPointerOverUIElement())
        {
            if (uIRaycast.GetEventSystemRaycastResult().gameObject.TryGetComponent<InventorySlot>(out InventorySlot inventorySlot))
            {
                if (!instance && inventorySlot.data != null)
                {
                    Canvas canvas = GetComponentInParent<Canvas>();
                    instance = Instantiate(itemInforUI, mousePos, Quaternion.identity);
                    instance.Name.text = inventorySlot.data.name;
                    instance.Description.text = inventorySlot.data.description;
                    instance.transform.parent = canvas.transform;
                }
                instance.transform.position = mousePos;
            }
        }
        else if (instance)
        {
            Destroy(instance.gameObject);
        }
    }

    private void ChangeSlot(float v)
    {
        slots[curSlot].DisableHighlight();

        curSlot += (int)v;
        if (curSlot >= slots.Length - 1)
        {
            curSlot = slots.Length - 1;
        }
        else if (curSlot <= 0)
        {
            curSlot = 0;
        }

        slots[curSlot].EnableHighlight();

    }
    private void ChangeSlot(int v)
    {
        slots[curSlot].DisableHighlight();

        if (curSlot >= slots.Length || curSlot < 0)
        {
            return;
        }

        curSlot = v;
        slots[curSlot].EnableHighlight();
    }

    public void AddItemInAvailableSlot(ItemData item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.data == null)
            {
                slot.SetItem(item);
                return;
            }
        }
        Debug.Log("No space left");
    }
    public void RemoveItem()
    {
        slots[curSlot].ClearItem();
    }
    public InventorySlot GetCurrentSlot()
    {
        return slots[curSlot];
    }
}
