using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private Transform atkPoint;
    [SerializeField] private float damage;
    [SerializeField] private float range;

    public override void Use()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll((Vector2)atkPoint.position, range, (Vector2)this.transform.forward);
        foreach (RaycastHit2D hit in hits)
        {
            Debug.Log("hit:" + hit.collider.name);
            Rigidbody2D rb2d = hit.collider.attachedRigidbody;
            if (rb2d && rb2d.TryGetComponent<Character>(out Character character))
            {
                character.Interact();
            }
        }
    }

    public void Aim()
    {
        //if it is with a fire weapon, it will reduce recoil
    }
}
