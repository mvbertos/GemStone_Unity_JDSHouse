using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public InputMappings inputMappings { private set; get; }
    [SerializeField] private SimpleInventory inventory;
    public SimpleInventory Inventory { get { return inventory; } }

    private void Awake()
    {
        inputMappings = new InputMappings();
        inputMappings.Player.Fire.performed += ctx => Attack();
        inputMappings.Player.Interact.performed += ctx => Interact();
        inputMappings.Player.Inventory.performed += ctx => OpenInventory();
        inputMappings.Player.Drop.performed += ctx => DropItem();

    }



    private void OnEnable()
    {
        inputMappings.Enable();
    }

    private void OnDisable()
    {
        inputMappings.Disable();
    }

    public override void Attack()
    {
        Debug.Log("Attacking");
    }

    public override void Interact()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)this.transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, interactRange, interactLayers);
        if (hit && hit.collider.attachedRigidbody)
        {
            Rigidbody2D rb = hit.collider.attachedRigidbody;
            if (rb.TryGetComponent<Item>(out Item item))
            {
                item.Pick(this.inventory);
            }
        }
    }
    private void DropItem()
    {
        InventorySlot slot = inventory.GetCurrentSlot();
        if (slot && slot.data != null)
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Items/" + slot.data.name);
            Instantiate(pref, this.transform.position, Quaternion.identity);
            inventory.RemoveItem();
        }
    }

    public override void Interacted()
    {
        Debug.Log("Being Interacted");
    }

    private void OpenInventory()
    {
        inventory.gameObject.SetActive(!inventory.gameObject.activeInHierarchy);
    }

    private void OnDrawGizmos()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)this.transform.position).normalized;
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, direction * interactRange);
    }
}